using libzkfpcsharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Fingerprint.DelegateCallback;

namespace Fingerprint
{
    public class FingerprintService
    {
       
        private IntPtr deviceHandle;
        private IntPtr dbHandle;

        private int cbRegTmp;
#pragma warning disable CS0414 // The field 'FingerprintService.iFid' is assigned but its value is never used
        private int iFid;
#pragma warning restore CS0414 // The field 'FingerprintService.iFid' is assigned but its value is never used
        private int cbCapTmp;

        private int mfpWidth = 0;
        private int mfpHeight = 0;
        private int mfpDpi = 0;

        byte[] FPBuffer;
        byte[] CapTmp = new byte[2048];
        byte[][] regTemplates = new byte[3][];

        public int activeScenario;
        public int REGISTER_FINGER_COUNT = 3;

        public FingerprintService()
        {
            this.activeScenario = 0;
        }

        public FingerprintService(int scenario)
        {
            this.activeScenario = scenario;
        }

        public int InitializeDevice()
        {
            int ret = zkfperrdef.ZKFP_ERR_OK;
            // init device
            if ((ret = zkfp2.Init()) == zkfperrdef.ZKFP_ERR_OK)
            {
                // Count device connected
                int deviceCount = zkfp2.GetDeviceCount();
                if (deviceCount < 1)
                {
                    // no device found, terminate lib!
                    zkfp2.Terminate();
                }
            }

            return ret;
        }

        public int OpenDevice()
        {
            // Open device
            if (deviceHandle == IntPtr.Zero)
            {
                if (IntPtr.Zero == (deviceHandle = zkfp2.OpenDevice(0)))
                {
                    // failed to open device, Terminate lib!
                    zkfp2.Terminate();
                    return zkfp.ZKFP_ERR_OPEN;
                }
            }

            // default config device
            cbRegTmp = 0;
            iFid = 1;
            byte[] paramValue = new byte[4];
            int size = 4;
            zkfp2.GetParameters(deviceHandle, 1, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpWidth);

            size = 4;
            zkfp2.GetParameters(deviceHandle, 2, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpHeight);

            FPBuffer = new byte[mfpWidth * mfpHeight];

            size = 4;
            zkfp2.GetParameters(deviceHandle, 3, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpDpi);

            return zkfp.ZKFP_ERR_OK;
        }

        public int initDB()
        {
            if (dbHandle == IntPtr.Zero)
            {
                // init DB Algorithm
                dbHandle = zkfp2.DBInit();
                Console.WriteLine("DBHandle Pointer " + dbHandle);
                if (IntPtr.Zero == dbHandle)
                {
                    // failed to init db algorithm, close device!
                    zkfp2.CloseDevice(deviceHandle);
                    deviceHandle = IntPtr.Zero;
                    return zkfp.ZKFP_ERR_INITLIB;
                }
            }

            return 0;
        }

        public String AcquireFingerprint()
        {
            String strTemplate = "";
            Boolean isScanFP = true;
            long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            while (isScanFP)
            {
                long current = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                if (current - start == 60000)
                {
                    // cannot get any fp template in 1min
                    strTemplate = "";
                    isScanFP = false;
                }

                cbCapTmp = 2048;
                int ret = zkfp2.AcquireFingerprint(deviceHandle, FPBuffer, CapTmp, ref cbCapTmp);
                if (ret == zkfp.ZKFP_ERR_OK)
                {
                    strTemplate = BlobToString(CapTmp);
                    isScanFP = false;
                }

                // timeout to next scan
                Thread.Sleep(200);
            }
            Console.WriteLine(strTemplate);
            return strTemplate;
        }

        public String RegisterFPData(ScanRegisterFingerWithTemplateCallback callback)
        {
            Boolean isScanFP = true;
            int registerCount = 0;
            String strTemplate = "";
            long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            byte[][] regTemplates = new byte[3][];
            for (int i = 0; i < REGISTER_FINGER_COUNT; i++)
            {
                regTemplates[i] = new byte[cbCapTmp];
            }

            Console.WriteLine("Scan Pertama kali");
            Console.WriteLine("Scan fingerprint anda " + REGISTER_FINGER_COUNT + " kali");
            // callback("Letakan jari anda, " + REGISTER_FINGER_COUNT + " kali lagi", null);
            callback("Letakkan jari CASIS pada pembaca sidik jari", null);
            while (registerCount < REGISTER_FINGER_COUNT && isScanFP)
            {
                long current = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                if (current - start == 60000)
                {
                    // cannot get any fp template in 1min
                    strTemplate = "";
                    isScanFP = false;
                }

                byte[] _fpTemplate = new byte[2048];
                int ret = zkfp2.AcquireFingerprint(deviceHandle, FPBuffer, _fpTemplate, ref cbCapTmp);
                if (ret == zkfp.ZKFP_ERR_OK)
                {
                    Thread.Sleep(1000);
                    callback("Angkat jari CASIS", null);
                    Thread.Sleep(2000);
                    regTemplates[registerCount] = _fpTemplate;
                    registerCount++;
                    var scanFingerRemaining = (REGISTER_FINGER_COUNT - registerCount);
                    Console.WriteLine("Scan fingerprint anda " + scanFingerRemaining + " kali");
                    if (scanFingerRemaining > 0)
                    {
                        callback("Letakkan jari CASIS sekali lagi", null);
                        // callback("Letakan jari anda, " + scanFingerRemaining + " kali lagi", FPBuffer);
                    }
                }

                Thread.Sleep(200);
            }

            if (registerCount >= REGISTER_FINGER_COUNT)
            {
                int ret = 0;
                byte[] regTemplate = new byte[2048];
                if (zkfp.ZKFP_ERR_OK == (ret = zkfp2.DBMerge(dbHandle, regTemplates[0], regTemplates[1], regTemplates[2], regTemplate, ref cbRegTmp)))
                {
                    strTemplate = BlobToString(regTemplate);
                }
            }

            return strTemplate;
        }

        public String RegisterFPData()
        {
            Boolean isScanFP = true;
            int registerCount = 0;
            String strTemplate = "";
            long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            for (int i = 0; i < REGISTER_FINGER_COUNT; i++)
            {
                regTemplates[i] = new byte[cbCapTmp];
            }

            Console.WriteLine("Scan fingerprint anda " + REGISTER_FINGER_COUNT + " kali");
            while (registerCount < REGISTER_FINGER_COUNT && isScanFP)
            {
                long current = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                if (current - start == 60000)
                {
                    // cannot get any fp template in 1min
                    strTemplate = "";
                    isScanFP = false;
                }

                byte[] _fpTemplate = new byte[2048];
                int ret = zkfp2.AcquireFingerprint(deviceHandle, FPBuffer, _fpTemplate, ref cbCapTmp);

                if (ret == zkfp.ZKFP_ERR_OK)
                {
                    regTemplates[registerCount] = _fpTemplate;
                    registerCount++;
                    Console.WriteLine("Scan fingerprint anda " + (REGISTER_FINGER_COUNT - registerCount) + " kali");
                }

                Thread.Sleep(200);
            }

            if (registerCount >= REGISTER_FINGER_COUNT)
            {
                int ret = 0;
                byte[] regTemplate = new byte[2048];
                if (zkfp.ZKFP_ERR_OK == (ret = zkfp2.DBMerge(dbHandle, regTemplates[0], regTemplates[1], regTemplates[2], regTemplate, ref cbRegTmp)))
                {
                    strTemplate = BlobToString(regTemplate);
                }
            }

            return strTemplate;
        }

        public int Identify(String fpTemplate)
        {
            int fid = 0;
            int score = 0;
            Thread.Sleep(400);
            Byte[] _fptemplate = StringToBlob(fpTemplate);
            int ret = 0;
            try
            {
                ret = zkfp2.DBIdentify(dbHandle, _fptemplate, ref fid, ref score);
            }
            catch (AccessViolationException ave)
            {
                Console.WriteLine(ave.Message);
                return -1;
            }


            if (zkfp.ZKFP_ERR_OK != ret) return ret;

            _fptemplate = null;

            // success return fid/personid
            return fid;
        }

        public int ClearMemory()
        {
            if (dbHandle != IntPtr.Zero)
            {
                return zkfp2.DBClear(dbHandle);
            }
            else return zkfp.ZKFP_ERR_NOT_INIT;

        }

        public int AddFPToMemory(int fid, String fpTemplate)
        {
            if (dbHandle != IntPtr.Zero)
            {
                return zkfp2.DBAdd(dbHandle, fid, StringToBlob(fpTemplate));
            }
            return zkfp.ZKFP_ERR_NOT_INIT;
        }

        public int CloseDevice()
        {
            if (deviceHandle != IntPtr.Zero)
            {
                return zkfp2.CloseDevice(deviceHandle);
            }
            else return zkfp.ZKFP_ERR_NOT_OPENED;
        }

        public int TerminateDevice()
        {
            return zkfp2.Terminate();
        }

        public IntPtr getDBHandle()
        {
            return dbHandle;
        }

        public IntPtr getDeviceHandle()
        {
            return deviceHandle;
        }

        public int countFPinMemory()
        {
            return zkfp2.DBCount(dbHandle);
        }

        public Boolean isDeviceConnected()
        {
            return zkfp2.GetDeviceCount() > 0;
        }

        public String getBase64Image(String template)
        {
            MemoryStream ms = new MemoryStream();
            byte[] blobTemplate = StringToBlob(template);
            BitmapFormat.GetBitmap(FPBuffer, mfpWidth, mfpHeight, ref ms);
            byte[] imgTemplate = ms.ToArray();
            // close stream
            ms.Close();

            return BlobToString(imgTemplate);
        }

        private byte[] StringToBlob(String s)
        {
            return Convert.FromBase64String(s);
        }

        private String BlobToString(byte[] b)
        {
            // return Convert.ToBase64String(b);
            return Convert.ToBase64String(b);
        }
    }
    
}
