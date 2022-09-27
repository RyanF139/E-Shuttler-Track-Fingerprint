using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;
using System.IO.Ports;
using Reader;
using System.Net.Sockets;
using System.Diagnostics;
using System.Management;
using System.Windows.Threading;
using System.Resources;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceRequest;
using Fingerprint;
using System.ComponentModel;
using System.Runtime.InteropServices;
using libzkfpcsharp;
using System.Linq;
using System.Threading.Tasks;

namespace Track_ShuttleRun
{
    public partial class Form1 : Form
    {
        private Stopwatch stopwatch;
        private ReaderMethod reader;
        private static readonly HttpClient client = new HttpClient();

        private ReaderSetting m_curSetting = new ReaderSetting();
        private OperateTagISO18000Buffer m_curOperateTagISO18000Buffer = new OperateTagISO18000Buffer();

        //args
        public string idTestor;
        public string namaTestor;
        public string seleksiID;


        //Real-time inventory locking operation
        private bool m_bLockTab = false;
        //ISO18000 Tag continuous inventory identification
        private bool m_bContinue = false;
        private bool m_bDisplayLog = false;
        //Record the number of ISO18000 Tag cycle writes
        private int m_nLoopTimes = 0;
        //Record the number of characters written to the ISO18000 tag
        private int m_nBytes = 0;
        //Record the number of times the ISO18000 tag has been cycled
        private int m_nLoopedTimes = 0;

        private int m_FastExeCount;

        private bool m_getOutputPower = false;
        private bool m_setOutputPower = false;
        private bool m_setWorkAnt = false;
        private bool m_getWorkAnt = false;

        private CheckBox[] fast_inv_ants = null;
        private TextBox[] fast_inv_stays = null;
        private TextBox[] fast_inv_temp_pows = null;

        TagDB tagdb = null;
        bool isFastInv = false;
        bool doingFastInv = false;
        bool Inventorying = false;
        bool isRealInv = false;
        bool doingRealInv = false;
        bool isBufferInv = false;
        bool doingBufferInv = false;
        bool needGetBuffer = false;
        private int tagbufferCount = 0;
        TagDB tagOpDb = null;

        private bool ReverseTarget = false;
        private int stayBTimes = 0;
        private bool invTargetB = false;

        bool useAntG1 = true;

        /// <summary>
        /// Define a variable for the inventory test log
        /// </summary>
        TextWriter transportLogFile = null;
        uint inventory_times = 0;

        RadioButton[] sessionArr = null;
        RadioButton[] targetArr = null;
        RadioButton[] selectFlagArr = null;

        int channels = 1;

        DispatcherTimer dispatcherTimer = null;
        DispatcherTimer readratePerSecond = null;

        // Record the inventory start time
        DateTime startInventoryTime;
        DateTime beforeCmdExecTime;
        // The time elapsed between the beginning of the inventory and this moment
        public double elapsedTime = 0.0;

        List<string> antLists = null;

        private int WriteTagCount = 0;

        private ServiceRequest.HttpRequest httpRequest;

        private Boolean isInitialized = false;



        //Fingerprint
        int index = 0;
        IntPtr mDevHandle = IntPtr.Zero;
        IntPtr mDBHandle = IntPtr.Zero;
        IntPtr FormHandle = IntPtr.Zero;
        bool bIsTimeToDie = false;
        bool IsRegister = false;
        bool bIdentify = true;
        byte[] FPBuffer;
        int RegisterCount = 0;
        const int REGISTER_FINGER_COUNT = 3;

        byte[][] RegTmps = new byte[3][];
        byte[] RegTmp = new byte[2048];
        byte[] CapTmp = new byte[2048];
        int cbCapTmp = 2048;
        int cbRegTmp = 0;
        int iFid = 1;

        private int mfpWidth = 0;
        private int mfpHeight = 0;

        const int MESSAGE_CAPTURED_OK = 0x0400 + 6;


        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        //end Finger Print

        public string StatusStartPosisi;

        #region FindResource
        ResourceManager LocRM;
        private void initFindResource()
        {
            LocRM = new ResourceManager("Track_ShuttleRun.WinFormString", typeof(Form1).Assembly);
        }

        public string FindResource(string key)
        {
            try
            {
                return LocRM.GetString(key);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Not contains the key= {0}, {1}", key, ex.Message));
            }
        }
        #endregion //FindResource

        public Form1()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            InitializeComponent();

            string url_AFIS = System.Configuration.ConfigurationManager.AppSettings["SERVER_API_AFIS"];
            httpRequest = new HttpRequest(url_AFIS);

            textBarId.Text = "Finger ID";

            initFindResource();
            Text = string.Format("{0}{1}.{2}", "UHF RFID Reader Demo v",
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major,
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor);

            DoubleBuffered = true;

            fast_inv_ants = new CheckBox[] {
                chckbx_fast_inv_ant_1, chckbx_fast_inv_ant_2, chckbx_fast_inv_ant_3, chckbx_fast_inv_ant_4,
                chckbx_fast_inv_ant_5, chckbx_fast_inv_ant_6, chckbx_fast_inv_ant_7, chckbx_fast_inv_ant_8,
                chckbx_fast_inv_ant_9, chckbx_fast_inv_ant_10, chckbx_fast_inv_ant_11, chckbx_fast_inv_ant_12,
                chckbx_fast_inv_ant_13, chckbx_fast_inv_ant_14, chckbx_fast_inv_ant_15, chckbx_fast_inv_ant_16
            };

            fast_inv_stays = new TextBox[] {
                txt_fast_inv_Stay_1, txt_fast_inv_Stay_2, txt_fast_inv_Stay_3, txt_fast_inv_Stay_4,
                txt_fast_inv_Stay_5, txt_fast_inv_Stay_6, txt_fast_inv_Stay_7, txt_fast_inv_Stay_8,
                txt_fast_inv_Stay_9, txt_fast_inv_Stay_10, txt_fast_inv_Stay_11, txt_fast_inv_Stay_12,
                txt_fast_inv_Stay_13,txt_fast_inv_Stay_14, txt_fast_inv_Stay_15, txt_fast_inv_Stay_16
            };

            fast_inv_temp_pows = new TextBox[] {
                tv_temp_pow_1, tv_temp_pow_2, tv_temp_pow_3, tv_temp_pow_4, tv_temp_pow_5, tv_temp_pow_6, tv_temp_pow_7, tv_temp_pow_8,
                tv_temp_pow_9, tv_temp_pow_10, tv_temp_pow_11, tv_temp_pow_12, tv_temp_pow_13, tv_temp_pow_14, tv_temp_pow_15, tv_temp_pow_16
            };

            bindInvAntTableEvents();

            sessionArr = new RadioButton[] { radio_btn_S0, radio_btn_S1, radio_btn_S2, radio_btn_S3 };
            targetArr = new RadioButton[] { radio_btn_target_A, radio_btn_target_B };
            selectFlagArr = new RadioButton[] { radio_btn_sl_00, radio_btn_sl_01, radio_btn_sl_02, radio_btn_sl_03 };

            radio_btn_S1.Checked = true;
            radio_btn_target_A.Checked = true;
            radio_btn_sl_00.Checked = true;

            initRealInvAnts();
            //radio_btn_realtime_inv.Checked = true;
            radio_btn_fast_inv.Checked = true;
            cb_fast_inv_check_all_ant.Checked = true;



            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(50);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);

            readratePerSecond = new DispatcherTimer();
            readratePerSecond.Interval = TimeSpan.FromMilliseconds(900);
            readratePerSecond.Tick += new EventHandler(readRatePerSec_Tick);

            rdbEpc.Checked = true;
            FormHandle = this.Handle;


        }

        public List<Dictionary<String, Object>> getRegisteredTemplate()
        {
            string url_AFIS = System.Configuration.ConfigurationManager.AppSettings["SERVER_API_AFIS"];
            //MessageBox.Show(seleksiID);
            string route = "/api/v2/fingerprint?seleksiid="+seleksiID;
            return httpRequest.execReturnList(url_AFIS + route, new Dictionary<string, object>(), new Dictionary<string, object>(), HttpRequest.METHOD_GET);
        }

        public void connectFP()
        {
            int ret = zkfperrdef.ZKFP_ERR_OK;
            if ((ret = zkfp2.Init()) == zkfperrdef.ZKFP_ERR_OK)
            {
                int nCount = zkfp2.GetDeviceCount();
                if (nCount > 0)
                {
                    for (int i = 0; i < nCount; i++)
                    {

                    }
                    btnReconnect.Text = "Connected";
                    btnReconnect.Enabled = false;

                    showMessage("Scan Finger Peserta", Color.FromArgb(243, 246, 249));
                }
                else
                {
                    zkfp2.Terminate();
                    MessageBox.Show("No device connected!");

                    btnReconnect.Text = "Reconnect";
                    btnReconnect.Enabled = true;

                    showMessage("Hubungkan Fingerprint terlebih dahulu", Color.FromArgb(243, 246, 249));
                }
            }
            else
            {
                //MessageBox.Show("Initialize fail, ret=" + ret + " !");//
                MessageBox.Show("Fingerprint Tidak Terhubung");
                showMessage("Hubungkan Fingerprint terlebih dahulu", Color.FromArgb(243, 246, 249));
            }
        }

        public void OpenFP()
        {
            int ret = zkfp.ZKFP_ERR_OK;
            if (IntPtr.Zero == (mDevHandle = zkfp2.OpenDevice(index)))
            {
                //MessageBox.Show("OpenDevice fail");
                return;
            }
            if (IntPtr.Zero == (mDBHandle = zkfp2.DBInit()))
            {
                MessageBox.Show("Init DB fail");
                zkfp2.CloseDevice(mDevHandle);
                mDevHandle = IntPtr.Zero;
                return;
            }
            RegisterCount = 0;
            cbRegTmp = 0;
            iFid = 1;
            for (int i = 0; i < 3; i++)
            {
                RegTmps[i] = new byte[2048];
            }
            byte[] paramValue = new byte[4];
            int size = 4;
            zkfp2.GetParameters(mDevHandle, 1, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpWidth);

            size = 4;
            zkfp2.GetParameters(mDevHandle, 2, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpHeight);

            FPBuffer = new byte[mfpWidth * mfpHeight];

            Thread captureThread = new Thread(new ThreadStart(DoCapture));
            captureThread.IsBackground = true;
            captureThread.Start();
            bIsTimeToDie = false;
            string status = "Open succ";
            Console.WriteLine(status);
        }


        public void initFingerPrint()
        {
            try
            {
                Constant.fp = new FingerprintService();
                Constant.fp.InitializeDevice();
                Console.WriteLine("Initialize device berhasil");

                Console.WriteLine("Init DB");
                Constant.fp.initDB();
                Console.WriteLine("Init DB berhasil");

                Console.WriteLine("Clear memory");
                Constant.fp.ClearMemory();

                List<Dictionary<String, Object>> fpTemplates = getRegisteredTemplate();
                Console.WriteLine(fpTemplates);
                foreach (Dictionary<String, Object> template in fpTemplates)
                {
                    Console.WriteLine(template["fingerdata"]);
                    int retFPToMemory = Constant.fp.AddFPToMemory(Int32.Parse(template["id"].ToString()), template["fingerdata"].ToString());
                    Console.WriteLine(retFPToMemory);
                }

                Console.WriteLine("SUCCESSS INSERT");
                bIdentify = true;
                string message = "Please press your finger!";
                //showMessage("Scan Finger Peserta", Color.FromArgb(243, 246, 249));
                Console.WriteLine(message);
            }
            catch (Exception e)
            {
                DialogResult res = MessageBox.Show("Tidak terhubung ke FPReader, Pastikan USB FPReader sudah terhubung dengan PC", "Warning", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    //Environment.Exit(0);
                    //if (this.loaded) this.Close();
                    // else Environment.Exit(0);
                }
            }
        }

        private void DoCapture()
        {
            while (!bIsTimeToDie)
            {
                cbCapTmp = 2048;
                int ret = zkfp2.AcquireFingerprint(mDevHandle, FPBuffer, CapTmp, ref cbCapTmp);
                if (ret == zkfp.ZKFP_ERR_OK)
                {
                    SendMessage(FormHandle, MESSAGE_CAPTURED_OK, IntPtr.Zero, IntPtr.Zero);
                }
                Thread.Sleep(200);
            }
        }

        /*public async void getDataUser(int id)
        {
            var responseString = await client.GetStringAsync("http://192.168.21.200:33335/fingerprint/getUserdata?id=" + id.ToString());
            JObject obj = JObject.Parse(responseString);
            if (obj["statusCode"].ToString() == "200")
            {
                textBarId.Text = id.ToString();
                lblNama.Text = obj["response"]["nama"].ToString();
                lblTanggalLahir.Text = obj["response"]["tanggal_lahir"].ToString();
                cmbListTestor.Enabled = true;

                string Track = System.Configuration.ConfigurationManager.AppSettings["NoTrack"];
                string noPeserta = obj["response"]["id"].ToString();

                //MessageBox.Show(no_pst);
                string Cek = "select * from history where no_peserta = '" + noPeserta + "' limit 1";
                DataTable cek = new Connect().getTable(Cek);
                if (cek.Rows.Count == 0)
                {
                    string InsertHistoryAwal = "insert into history_track (no_track,antena,barcode,no_rfid,waktu) values ('" + Track + "','" + 0 + "','" + id.ToString() + "','" + 0 + "','" + 0 + "')";
                    new Connect().execute(InsertHistoryAwal);

                    string InsertHistoryWaktu = "insert into history (no_peserta,no_track,barcode,putaran1,putaran2,putaran3,waktu_akhir) values ('" + noPeserta + "','" + Track + "','" + id.ToString() + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "')";
                    new Connect().execute(InsertHistoryWaktu);



                    showMessage("Mohon Pilih Testor terlebih dahulu", Color.FromArgb(243, 246, 249));
                }
                else
                {
                    MessageBox.Show("Peserta Sudah Melaksanakan Tes");
                    btn_Ulangi.Show();

                    showMessage("Klik Ulangi/Reload ", Color.FromArgb(243, 246, 249));
                }
            }
        }*/

        protected override void DefWndProc(ref Message m)
        {
            Console.WriteLine(m.Msg);
            switch (m.Msg)
            {
                case MESSAGE_CAPTURED_OK:
                    {
                        Console.WriteLine("test");
                        MemoryStream ms = new MemoryStream();
                        BitmapFormat.GetBitmap(FPBuffer, mfpWidth, mfpHeight, ref ms);
                        Bitmap bmp = new Bitmap(ms);
                        this.picFPImg.Image = bmp;
                        if (bIdentify)
                        {

                            Console.Write("test");
                            int ret = zkfp.ZKFP_ERR_OK;
                            int fid = 0, score = 0;
                            ret = zkfp2.DBIdentify(mDBHandle, CapTmp, ref fid, ref score);
                            Console.WriteLine(ret);
                            if (zkfp.ZKFP_ERR_OK == ret)
                            {
                                getData(fid.ToString());
                                btnConnect.Enabled = true;
                                string message = "Berhasil identifikasi sidik jari !,score=" + score + "!";
                                Console.WriteLine(message);
                                return;
                            }
                            else
                            {
                                string messasge = "Identifikasi sidik jari error, ret= " + ret;
                                Console.WriteLine(messasge);
                                MessageBox.Show("Fingerdata tidak ditemukan harap registrasi terlebih dahulu !", "Error Finger Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                picFPImg.Image = null;
                                return;
                            }
                        }
                        else
                        {
                            int ret = zkfp2.DBMatch(mDBHandle, CapTmp, RegTmp);
                            if (0 < ret)
                            {
                                string message = "Match finger succ, score=" + ret + "!";
                                Console.WriteLine(message);
                                return;
                            }
                            else
                            {
                                string message = "Match finger fail, ret= " + ret;
                                Console.WriteLine(message);
                                return;
                            }
                        }
                    }
                    break;

                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }


        async void getData(String fid)
        {

            try
            {
                string url = System.Configuration.ConfigurationManager.AppSettings["SERVER_API"];
                string route = "/api/v2/garjas/peserta?fingerid=" + fid;
                string GET_Data_Peserta = url + route;

                Console.WriteLine(GET_Data_Peserta);

                HttpResponseMessage response = await client.GetAsync(GET_Data_Peserta);
                response.EnsureSuccessStatusCode();

                var responseString = await client.GetStringAsync(GET_Data_Peserta);
                //MessageBox.Show(responseString.ToString());
                JObject stuff = JObject.Parse(responseString);

                textBarId.Text = fid;

                if (stuff["status"].ToString() == "Success")
                {
                    JObject data = JObject.Parse(stuff["data"].ToString());
                    string nama = data["nama"].ToString() == "" ? "-" : data["nama"].ToString();
                    string pangkat = data["pangkat"].ToString() == "" ? "-" : data["pangkat"].ToString();
                    string nrp = data["nrp"].ToString() == "" ? "-" : data["nrp"].ToString();
                    string korps = data["korps"].ToString() == "" ? "-" : data["korps"].ToString();
                    string tanggal_lahir = DateTime.Parse(data["tanggal_lahir"].ToString()).ToString("dd-MM-yyyy");
                    string jabatan = data["jabatan"].ToString() == "" ? "-" : data["jabatan"].ToString();
                    string Track = System.Configuration.ConfigurationManager.AppSettings["NoTrack"];
                    string no_Peserta = data["id"].ToString();
                    string jenisKelamin = data["jenis_kelamin"].ToString();

                    Console.WriteLine(jenisKelamin);


                    int tanggalLahir = int.Parse(DateTime.Parse(data["tanggal_lahir"].ToString()).ToString("yyyyMMdd"));
                    DateTime time = DateTime.Now;
                    int DateNow = int.Parse(DateTime.Now.ToString("yyyyMMdd"));

                    lblNama.Text = (nama + "/" + pangkat);
                    lblNOPJurusan.Text = (nrp + "/" + korps);
                    lblTanggalLahir.Text = tanggal_lahir;
                    lblAsalSekolah.Text = jabatan;
                    lblUsia.Text = ((DateNow - tanggalLahir) / 10000).ToString();
                    lblNamaTestor.Text = namaTestor;
                    Label_NoPeserta.Text = no_Peserta;

                    if (jenisKelamin == "PRIA")
                    {
                        icon_Male.Show();
                    }
                    else if (jenisKelamin == "WANITA")
                    {
                        icon_Female.Show();
                    }

                    string Cek = "select * from history where no_peserta = '" + no_Peserta + "' limit 1";
                    DataTable cek = new Connect().getTable(Cek);
                    if (cek.Rows.Count == 0)
                    {
                        if (StatusStartPosisi == "Kanan")
                        {
                            string InsertHistoryAwal = "insert into history_track (no_track,antena,barcode,no_rfid,waktu) values ('" + Track + "','" + 0 + "','" + fid + "','" + 0 + "','" + 0 + "')";
                            new Connect().execute(InsertHistoryAwal);

                            string InsertHistoryWaktu = "insert into history (no_peserta,no_track,barcode,putaran1,putaran2,putaran3,waktu_akhir) values ('" + no_Peserta + "','" + Track + "','" + fid + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "')";
                            new Connect().execute(InsertHistoryWaktu);

                            showMessage("Klik 'Connect'", Color.FromArgb(243, 246, 249));

                            btnConnect.Enabled = true;
                        }
                        else if (StatusStartPosisi == "Kiri")
                        {
                            string InsertHistoryAwal = "insert into history_track (no_track,antena,barcode,no_rfid,waktu) values ('" + Track + "','" + 5 + "','" + fid + "','" + 0 + "','" + 0 + "')";
                            new Connect().execute(InsertHistoryAwal);

                            string InsertHistoryWaktu = "insert into history (no_peserta,no_track,barcode,putaran1,putaran2,putaran3,waktu_akhir) values ('" + no_Peserta + "','" + Track + "','" + fid + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "')";
                            new Connect().execute(InsertHistoryWaktu);

                            showMessage("Klik 'Connect'", Color.FromArgb(243, 246, 249));

                            btnConnect.Enabled = true;
                        }

                        



                        showMessage("Klik 'Connect'", Color.FromArgb(243, 246, 249));
                    }
                    else
                    {
                        MessageBox.Show("Peserta Sudah Melaksanakan Tes");
                        btn_Ulangi.Show();
                        btnConnect.Enabled = false;
                        showMessage("Klik Ulangi/NEXT ", Color.FromArgb(243, 246, 249));
                    }
                }
                else
                {
                    MessageBox.Show("Peserta belum terdaftar");

                    string port = System.Configuration.ConfigurationManager.AppSettings["SerialPortBarcode"]; ;
                    SerialPort mySerialPort = new SerialPort(port);

                    //button1.PerformClick();
                }

            }
            catch (HttpRequestException e)
            {
                MessageBox.Show("Peserta belum terdaftar");
                btn_Reload.PerformClick();
            }




        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Argumen

            string[] passedInArgs = Environment.GetCommandLineArgs();

            if (passedInArgs.Length > 1)
            {
                idTestor = passedInArgs[1];                
                namaTestor = passedInArgs[2];
                seleksiID = passedInArgs[3];
                //MessageBox.Show(idTestor);
            }

            btnStartKanan.PerformClick();

            //MessageBox.Show(seleksiID);

            Label_No_ShuttleRun.Text = System.Configuration.ConfigurationManager.AppSettings["NoShuttleRun"];
            btn_Ulangi.Hide();
            icon_Female.Hide();
            icon_Male.Hide();

            //CekSeleksi();

            stopwatch = new Stopwatch();

            //btnInventory.Enabled = false;
            btnConnect.Enabled = false;
            //btnConnect.Enabled();

            // Open_Port();
            //Initializes the access reader instance
            reader = new Reader.ReaderMethod();



            //The callback function
            reader.AnalyCallback = AnalyData;
            reader.SendCallback = SendData;
            reader.ReceiveCallback = RecvData;
            reader.ErrCallback = OnError;

            //Sets the validity of interface elements
            SetFormEnable(false);
            radio_btn_tcp.Checked = true;
            antType4.Checked = true;

            //Initializes the default configuration of the connection reader
            RefreshComPorts();

            cmbBaudrate.SelectedIndex = 1; // 115200
            ipIpServer.IpAddressStr = System.Configuration.ConfigurationManager.AppSettings["IpRfidReader"];

            // Console.WriteLine(ipIpServer.IpAddressStr);

            txtTcpPort.Text = System.Configuration.ConfigurationManager.AppSettings["TcpPortRfidReader"];

            combo_mast_id.SelectedIndex = 0;
            combo_menbank.SelectedIndex = 1;
            combo_action.SelectedIndex = 0;
            combo_session.SelectedIndex = 0;
            comboBox16.SelectedIndex = 0;

            cmbReturnLossFreq.SelectedIndex = 33;
            if (cbUserDefineFreq.Checked == true)
            {
                groupBox21.Enabled = false;
                groupBox23.Enabled = true;

            }
            else
            {
                groupBox21.Enabled = true;
                groupBox23.Enabled = false;
            };

            //save inventory log
            //saveLog();

            GenerateColmnsDataGridForInv();
            tagdb = new TagDB();
            dgv_fast_inv_tags.DataSource = tagdb.TagList;
            GenerateColmnsDataGridForTagOp();
            tagOpDb = new TagDB();
            dgvTagOp.DataSource = tagOpDb.TagList;

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(cb_tagFocus, FindResource("tipTagFocus"));

            #region NetPort
            toolTip.SetToolTip(chkbxPort1_RandEn, FindResource("tipRandEn"));
            toolTip.SetToolTip(chkbxPort1_PhyDisconnect, FindResource("tipPhyDisconnect"));
            toolTip.SetToolTip(chkbxPort1_ResetCtrl, FindResource("tipResetCtrl"));
            toolTip.SetToolTip(chkbxHwCfgDhcpEn, FindResource("tipHwCfgDhcpEn"));
            toolTip.SetToolTip(chkbxHwCfgComCfgEn, FindResource("tipHwCfgComCfgEn"));
            toolTip.SetToolTip(chkbxPort0PortEn, FindResource("tipHeartbeatEn"));

            if (ncdb == null)
                ncdb = new NetCardDB();

            cmbbxNetCard.DataSource = null;
            cmbbxNetCard.DataSource = ncdb.NetCardList;
            initDgvNetPort();
            initDgvNetPortUI();
            #endregion //NetPort

            initDgvTagMask();

            connectFP();
            OpenFP();
            initFingerPrint();

        }

        private void initRealInvAnts()
        {
            antLists = new List<string>();
            antLists.Add(string.Format("{0}{1}", FindResource("Antenna"), 1));
            combo_realtime_inv_ants.Items.AddRange(antLists.ToArray());
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            lock (tagdb)
            {
                tagdb.Repaint();
            }
        }

        void readRatePerSec_Tick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Calculate total elapsed time between present time and start read command
        /// initiated
        /// </summary>
        /// <returns>Returns total time elapsed </returns>
        private double CalculateElapsedTime()
        {
            TimeSpan elapsed = (DateTime.Now - startInventoryTime);
            // elapsed time + previous cached async read time
            double totalseconds = elapsedTime + elapsed.TotalSeconds;
            label_totaltime.Text = string.Format("{0} {1}", Math.Round(totalseconds, 2), FindResource("Sec"));
            if (doingBufferInv)
            {
                ledFast_total_execute_time.Text = FormatLongToTimeStr((long)totalseconds);
            }
            return totalseconds;
        }

        private double CalculateExecTime()
        {
            return (DateTime.Now - beforeCmdExecTime).TotalMilliseconds;
        }

        private void showMessage(string message, Color bgColor)
        {
            DialogMessage dialogmessage = new DialogMessage(message, bgColor);
            dialogmessage.Show();
        }

        private async void CekSeleksi()
        {
            string Cek_Seleksi = "select * from socket";
            DataTable cek_seleksi = new Connect().getTable(Cek_Seleksi);
            string CekSeleksi = (cek_seleksi.Rows[0]["seleksiid"].ToString());

            try
            {
                string API = "http://173.208.177.186:8501/api/v2/garjas/testor?subjenis_test=SHUTTLE" + " " + "RUN&seleksiid=";
                string API_Garjas_GetPeserta = API + CekSeleksi;

                HttpResponseMessage response = await client.GetAsync(API_Garjas_GetPeserta);
                response.EnsureSuccessStatusCode();

                var responseString = await client.GetStringAsync(API_Garjas_GetPeserta);
                JObject stuff = JObject.Parse(responseString);

                //   Console.Write(stuff);

                JArray data = (JArray)stuff["data"];


                int i = 0;


                foreach (JObject obj in data)
                {
                    // Console.Write(obj);
                    //MessageBox.Show(obj.ToString());
                    string nama = obj["nama"].ToString();
                    string id_testor = obj["id"].ToString();

                }
            }
            catch (HttpRequestException e)
            {

            }
        }

        private void Open_Port()
        {
            try
            {
                string port = System.Configuration.ConfigurationManager.AppSettings["SerialPortBarcode"];
                int Baudrate = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["BaudrateBarcode"]);

                SerialPort mySerialPort = new SerialPort(port);
                mySerialPort.BaudRate = Baudrate;
                mySerialPort.Parity = Parity.None;
                mySerialPort.StopBits = StopBits.One;
                mySerialPort.DataBits = 8;
                mySerialPort.Handshake = Handshake.None;
                mySerialPort.RtsEnable = true;
                mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                /*if (mySerialPort => 0)
                {

                }*/
                mySerialPort.Open();
                btnReconnect.Text = "Connected";
                btnReconnect.Enabled = false;

                showMessage("Scan Barcode Peserta", Color.FromArgb(243, 246, 249));

            }
            catch (Exception ex)
            {
                btnReconnect.Text = "Reconnect";
                //MessageBox.Show("Please Connect Barcode Reader");
                showMessage("Please Reconnect Barcode", Color.FromArgb(243, 246, 249));
            }

        }

        //BarScan
        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBarId.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBarId.Text = text.ToString().Replace("\r", "");
                string id_Barcode = textBarId.Text.ToString().Replace("\r", "");
                getData(id_Barcode);
                //string sql = "select * from peserta where barcode = '" + id_Barcode + "' limit 1";
                //DataTable dt = new Connect().getTable(sql);

                //string Track = "Track 1";
                //string noPeserta = Label_NoPeserta.Text;
                //Console.WriteLine(sql);
                //btnConnect.Enabled = true;
                //if (dt.Rows.Count > 0)
                //{
                //    string no_pst = dt.Rows[0]["no_peserta"].ToString();                    
                //    Label_NoPeserta.Text = no_pst;

                //    //MessageBox.Show(no_pst);
                //    string Cek = "select * from history where no_peserta = '" + no_pst + "' limit 1";
                //    DataTable cek = new Connect().getTable(Cek);
                //    if (cek.Rows.Count == 0)
                //    {
                //        string InsertHistoryAwal = "insert into history_track (no_track,antena,barcode,no_rfid,waktu) values ('" + Track + "','" + 0 + "','" + id_Barcode + "','" + 0 + "','" + 0 + "')";
                //        new Connect().execute(InsertHistoryAwal);

                //        string InsertHistoryWaktu = "insert into history (no_peserta,no_track,barcode,putaran1,putaran2,putaran3,waktu_akhir) values ('" + no_pst + "','" + Track + "','" + id_Barcode + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "')";
                //        new Connect().execute(InsertHistoryWaktu);


                //        LabelNotif.Text = "Track Siap";
                //    }
                //    else
                //    {

                //    }


                //    //stopwatch.Start();

                //}
                //else
                //{
                //    MessageBox.Show("Data Tidak Ditemukan");
                //}

            }
        }


        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string inData = sp.ReadExisting(); // ReadLine includes the + "\n"
                                               //displayToWindow(inData);
                                               //Console.WriteLine("Data Received:");
                                               //Console.Write(indata);

            //MessageBox.Show(inData);
            SetText(inData);


        }




        /// <summary>
        /// Display read rate per sec
        /// </summary>
        /// <param name="totalElapsedSeconds"> total elapsed time</param>
        private void UpdateReadRate(double totalElapsedSeconds)
        {
            long totalReads = 0;
            long tags = 0;
            if (Inventorying)
            {
                totalReads = tagdb.TotalReadCounts;
                tags = tagdb.TotalTagCounts;

            }
            label_totalread_count.Text = string.Format("{0} {1}", totalReads, FindResource("Times"));
            label_totaltag_count.Text = string.Format("{0} {1}", tags, FindResource("Tags"));
            label_readrate.Text = string.Format("{0} {1}", Math.Round((totalReads / totalElapsedSeconds), 2), FindResource("PerSec"));
        }

        private void bindInvAntTableEvents()
        {
            foreach (CheckBox cb in fast_inv_ants)
            {
                cb.CheckedChanged += new EventHandler(fastInvAntChecked);
            }
        }

        private void fastInvAntChecked(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            int antNo = Convert.ToInt32(cb.Text) - 1;
            if (cb.Checked)
            {
                fast_inv_stays[antNo].Text = "1";
                fast_inv_temp_pows[antNo].Text = "20";
            }
            else
            {
                fast_inv_stays[antNo].Text = "0";
                fast_inv_temp_pows[antNo].Text = "0";
            }
        }

        private void RefreshComPorts()
        {
            cmbComPort.Items.Clear();
            string[] portNames = SerialPort.GetPortNames();
            if (portNames != null && portNames.Length > 0)
            {
                cmbComPort.Items.AddRange(portNames);
            }
            cmbComPort.SelectedIndex = cmbComPort.Items.Count - 1;
        }

        private void SendData(object sender, byte[] data)
        {
            if (m_bDisplayLog)
            {
                string strLog = "Send: " + ReaderUtils.ToHex(data, "", " ");
                //Console.WriteLine("-->  {0}", strLog);
                WriteLog(lrtxtDataTran, strLog, 0);
            }
        }

        private void RecvData(object sender, TransportDataEventArgs e)
        {
            if (m_bDisplayLog)
            {
                string strLog = e.Tx ? "Send: " : "Recv: " + ReaderUtils.ToHex(e.Data, "", " ");
                //Console.WriteLine("<--  {0}", strLog);
                WriteLog(lrtxtDataTran, strLog, e.Tx ? 0 : 1);
            }
        }

        private void OnError(object sender, ErrorReceivedEventArgs e)
        {
            WriteLog(lrtxtLog, e.ErrStr, 1);
            if (radio_btn_tcp.Checked)
            {
                if (e.ErrStr.Contains(FindResource("tipReconnectSuccess")) && !btnInventory.Text.Equals(FindResource("StartInventory")))
                {
                    BeginInvoke(new ThreadStart(delegate ()
                    {
                        FastInventory_Click(null, null);
                        FastInventory_Click(null, null);
                    }));
                }
            }
        }

        private void AnalyData(object sender, Reader.MessageTran msgTran)
        {
            if (msgTran.PacketType != 0xA0)
            {
                return;
            }
            switch (msgTran.Cmd)
            {
                case 0x66:
                    ProcessSetTempOutpower(msgTran);
                    break;
                case 0x69:
                    ProcessSetProfile(msgTran);
                    break;
                case 0x6A:
                    ProcessGetProfile(msgTran);
                    break;
                case 0x6c:
                    ProcessSetReaderAntGroup(msgTran);
                    break;
                case 0x6d:
                    ProcessGetReaderAntGroup(msgTran);
                    break;
                case 0x71:
                    ProcessSetUartBaudrate(msgTran);
                    break;
                case 0x72:
                    ProcessGetFirmwareVersion(msgTran);
                    break;
                case 0x73:
                    ProcessSetReadAddress(msgTran);
                    break;
                case 0x74:
                    ProcessSetWorkAntenna(msgTran);
                    break;
                case 0x75:
                    ProcessGetWorkAntenna(msgTran);
                    break;
                case 0x76:
                    ProcessSetOutputPower(msgTran);
                    break;
                case 0x97:
                case 0x77:
                    ProcessGetOutputPower(msgTran);
                    break;
                case 0x78:
                    ProcessSetFrequencyRegion(msgTran);
                    break;
                case 0x79:
                    ProcessGetFrequencyRegion(msgTran);
                    break;
                case 0x7A:
                    ProcessSetBeeperMode(msgTran);
                    break;
                case 0x7B:
                    ProcessGetReaderTemperature(msgTran);
                    break;
                case 0x7C:
                    ProcessSetDrmMode(msgTran);
                    break;
                case 0x7D:
                    ProcessGetDrmMode(msgTran);
                    break;
                case 0x7E:
                    ProcessGetImpedanceMatch(msgTran);
                    break;
                case 0x60:
                    ProcessReadGpioValue(msgTran);
                    break;
                case 0x61:
                    ProcessWriteGpioValue(msgTran);
                    break;
                case 0x62:
                    ProcessSetAntDetector(msgTran);
                    break;
                case 0x63:
                    ProcessGetAntDetector(msgTran);
                    break;
                case 0x67:
                    ProcessSetReaderIdentifier(msgTran);
                    break;
                case 0x68:
                    ProcessGetReaderIdentifier(msgTran);
                    break;
                case 0x80:
                    ProcessInventory(msgTran);
                    break;
                case 0x81:
                    ProcessReadTag(msgTran);
                    break;
                case 0x82:
                case 0x94:
                    ProcessWriteTag(msgTran);
                    break;
                case 0x83:
                    ProcessLockTag(msgTran);
                    break;
                case 0x84:
                    ProcessKillTag(msgTran);
                    break;
                case 0x85:
                    ProcessSetAccessEpcMatch(msgTran);
                    break;
                case 0x86:
                    ProcessGetAccessEpcMatch(msgTran);
                    break;

                case 0x89:
                case 0x8B:
                    ProcessInventoryReal(msgTran);
                    break;
                case 0x8A:
                    ProcessFastSwitch(msgTran);
                    break;
                case 0x8D:
                    ProcessSetMonzaStatus(msgTran);
                    break;
                case 0x8E:
                    ProcessGetMonzaStatus(msgTran);
                    break;
                case 0x90:
                    ProcessGetInventoryBuffer(msgTran);
                    break;
                case 0x91:
                    ProcessGetAndResetInventoryBuffer(msgTran);
                    break;
                case 0x92:
                    ProcessGetInventoryBufferTagCount(msgTran);
                    break;
                case 0x93:
                    ProcessResetInventoryBuffer(msgTran);
                    break;
                case 0x98:
                    ProcessTagMask(msgTran);
                    break;
                case 0xAA:
                    ProcessGetInternalVersion(msgTran);
                    break;
                case 0xb0:
                    ProcessInventoryISO18000(msgTran);
                    break;
                case 0xb1:
                    ProcessReadTagISO18000(msgTran);
                    break;
                case 0xb2:
                    ProcessWriteTagISO18000(msgTran);
                    break;
                case 0xb3:
                    ProcessLockTagISO18000(msgTran);
                    break;
                case 0xb4:
                    ProcessQueryISO18000(msgTran);
                    break;
                default:
                    break;
            }
        }

        private void ProcessSetTempOutpower(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipSetTempOutpower"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x10)
                {
                    m_curSetting.btReadId = msgTran.ReadId;
                    WriteLog(lrtxtLog, strCmd, 0);
                    FastInventory();
                    return;
                }
                else
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        public void WriteLog(CustomControl.LogRichTextBox logRichTxt, string strLog, int nType)
        {
            if (this == null)
                return;
            BeginInvoke(new ThreadStart(delegate () {
                if (nType == 0)
                {
                    logRichTxt.AppendTextEx(strLog, Color.Indigo);
                }
                else
                {
                    logRichTxt.AppendTextEx(strLog, Color.Red);
                }

                if (ckClearOperationRec.Checked)
                {
                    if (logRichTxt.Lines.Length > 50)
                    {
                        logRichTxt.Clear();
                    }
                }

                logRichTxt.Select(logRichTxt.TextLength, 0);
                logRichTxt.ScrollToCaret();
            }));
        }

        private void RefreshReadSetting(CMD btCmd)
        {
            BeginInvoke(new ThreadStart(delegate () {
                htxtReadId.Text = string.Format("{0:X2}", m_curSetting.btReadId);
                switch (btCmd)
                {
                    case CMD.cmd_get_rf_link_profile:
                        {
                            if (m_curSetting.btLinkProfile == 0xd0)
                            {
                                rdbProfile0.Checked = true;
                            }
                            else if (m_curSetting.btLinkProfile == 0xd1)
                            {
                                rdbProfile1.Checked = true;
                            }
                            else if (m_curSetting.btLinkProfile == 0xd2)
                            {
                                rdbProfile2.Checked = true;
                            }
                            else if (m_curSetting.btLinkProfile == 0xd3)
                            {
                                rdbProfile3.Checked = true;
                            }
                            else
                            {
                            }
                        }
                        break;
                    case CMD.cmd_get_reader_identifier:
                        {
                            htbGetIdentifier.Text = m_curSetting.btReaderIdentifier;
                        }
                        break;
                    case CMD.cmd_get_firmware_version:
                        {
                            txtFirmwareVersion.Text = m_curSetting.btMajor.ToString() + "." + m_curSetting.btMinor.ToString();
                        }
                        break;
                    case CMD.cmd_get_work_antenna:
                        {
                            if (antType16.Checked && tagdb.AntGroup == 0x01)
                            {
                                cmbWorkAnt.SelectedIndex = m_curSetting.btWorkAntenna + 0x08;
                            }
                            else
                            {
                                if (!antType16.Checked && (m_curSetting.btWorkAntenna > 4 && !antType8.Checked))
                                {
                                    antType8.Checked = true;
                                }
                                cmbWorkAnt.SelectedIndex = m_curSetting.btWorkAntenna;
                            }
                        }
                        break;
                    case CMD.cmd_get_output_power:
                        {
                            if (antType4.Checked)
                            {
                                if (m_curSetting.btOutputPower != 0 && m_curSetting.btOutputPowers == null)
                                {
                                    tb_outputpower_1.Text = m_curSetting.btOutputPower.ToString();
                                    tb_outputpower_2.Text = m_curSetting.btOutputPower.ToString();
                                    tb_outputpower_3.Text = m_curSetting.btOutputPower.ToString();
                                    tb_outputpower_4.Text = m_curSetting.btOutputPower.ToString();

                                    m_curSetting.btOutputPower = 0;
                                    m_curSetting.btOutputPowers = null;
                                }
                                else if (m_curSetting.btOutputPowers != null)
                                {
                                    tb_outputpower_1.Text = m_curSetting.btOutputPowers[0].ToString();
                                    tb_outputpower_2.Text = m_curSetting.btOutputPowers[1].ToString();
                                    tb_outputpower_3.Text = m_curSetting.btOutputPowers[2].ToString();
                                    tb_outputpower_4.Text = m_curSetting.btOutputPowers[3].ToString();

                                    m_curSetting.btOutputPower = 0;
                                    m_curSetting.btOutputPowers = null;
                                }

                            }

                            if (antType1.Checked)
                            {
                                if (m_curSetting.btOutputPower != 0 && m_curSetting.btOutputPowers == null)
                                {
                                    tb_outputpower_1.Text = m_curSetting.btOutputPower.ToString();
                                    m_curSetting.btOutputPower = 0;
                                    m_curSetting.btOutputPowers = null;
                                }
                                else if (m_curSetting.btOutputPowers != null)
                                {
                                    tb_outputpower_1.Text = m_curSetting.btOutputPowers[0].ToString();
                                    m_curSetting.btOutputPower = 0;
                                    m_curSetting.btOutputPowers = null;
                                }
                            }

                        }
                        break;
                    case CMD.cmd_get_output_power_eight:
                        {
                            if (antType8.Checked)
                            {

                                if (m_curSetting.btOutputPower != 0 && m_curSetting.btOutputPowers == null)
                                {
                                    tb_outputpower_1.Text = m_curSetting.btOutputPower.ToString();
                                    tb_outputpower_2.Text = m_curSetting.btOutputPower.ToString();
                                    tb_outputpower_3.Text = m_curSetting.btOutputPower.ToString();
                                    tb_outputpower_4.Text = m_curSetting.btOutputPower.ToString();


                                    tb_outputpower_5.Text = m_curSetting.btOutputPower.ToString();
                                    tb_outputpower_6.Text = m_curSetting.btOutputPower.ToString();
                                    tb_outputpower_7.Text = m_curSetting.btOutputPower.ToString();
                                    tb_outputpower_8.Text = m_curSetting.btOutputPower.ToString();

                                    m_curSetting.btOutputPower = 0;
                                    m_curSetting.btOutputPowers = null;
                                }
                                else if (m_curSetting.btOutputPowers != null)
                                {
                                    tb_outputpower_1.Text = m_curSetting.btOutputPowers[0].ToString();
                                    tb_outputpower_2.Text = m_curSetting.btOutputPowers[1].ToString();
                                    tb_outputpower_3.Text = m_curSetting.btOutputPowers[2].ToString();
                                    tb_outputpower_4.Text = m_curSetting.btOutputPowers[3].ToString();
                                    tb_outputpower_5.Text = m_curSetting.btOutputPowers[4].ToString();
                                    tb_outputpower_6.Text = m_curSetting.btOutputPowers[5].ToString();
                                    tb_outputpower_7.Text = m_curSetting.btOutputPowers[6].ToString();
                                    tb_outputpower_8.Text = m_curSetting.btOutputPowers[7].ToString();

                                    m_curSetting.btOutputPower = 0;
                                    m_curSetting.btOutputPowers = null;
                                }
                            }
                            else if (antType16.Checked)
                            {
                                if (m_curSetting.btOutputPowers != null)
                                {
                                    tb_outputpower_1.Text = m_curSetting.btOutputPowers[0].ToString();
                                    tb_outputpower_2.Text = m_curSetting.btOutputPowers[1].ToString();
                                    tb_outputpower_3.Text = m_curSetting.btOutputPowers[2].ToString();
                                    tb_outputpower_4.Text = m_curSetting.btOutputPowers[3].ToString();
                                    tb_outputpower_5.Text = m_curSetting.btOutputPowers[4].ToString();
                                    tb_outputpower_6.Text = m_curSetting.btOutputPowers[5].ToString();
                                    tb_outputpower_7.Text = m_curSetting.btOutputPowers[6].ToString();
                                    tb_outputpower_8.Text = m_curSetting.btOutputPowers[7].ToString();

                                    if (m_curSetting.btOutputPowers.Length >= 16)
                                    {
                                        tb_outputpower_9.Text = m_curSetting.btOutputPowers[8].ToString();
                                        tb_outputpower_10.Text = m_curSetting.btOutputPowers[9].ToString();
                                        tb_outputpower_11.Text = m_curSetting.btOutputPowers[10].ToString();
                                        tb_outputpower_12.Text = m_curSetting.btOutputPowers[11].ToString();
                                        tb_outputpower_13.Text = m_curSetting.btOutputPowers[12].ToString();
                                        tb_outputpower_14.Text = m_curSetting.btOutputPowers[13].ToString();
                                        tb_outputpower_15.Text = m_curSetting.btOutputPowers[14].ToString();
                                        tb_outputpower_16.Text = m_curSetting.btOutputPowers[15].ToString();
                                        m_curSetting.btOutputPowers = null;
                                    }
                                }
                            }
                        }
                        break;
                    case CMD.cmd_get_frequency_region:
                        {
                            switch (m_curSetting.btRegion)
                            {
                                case 0x01:
                                    {
                                        cbUserDefineFreq.Checked = false;
                                        textStartFreq.Text = "";
                                        TextFreqInterval.Text = "";
                                        textFreqQuantity.Text = "";
                                        rdbRegionFcc.Checked = true;
                                        cmbFrequencyStart.SelectedIndex = Convert.ToInt32(m_curSetting.btFrequencyStart) - 7;
                                        cmbFrequencyEnd.SelectedIndex = Convert.ToInt32(m_curSetting.btFrequencyEnd) - 7;
                                    }
                                    break;
                                case 0x02:
                                    {
                                        cbUserDefineFreq.Checked = false;
                                        textStartFreq.Text = "";
                                        TextFreqInterval.Text = "";
                                        textFreqQuantity.Text = "";
                                        rdbRegionEtsi.Checked = true;
                                        cmbFrequencyStart.SelectedIndex = Convert.ToInt32(m_curSetting.btFrequencyStart);
                                        cmbFrequencyEnd.SelectedIndex = Convert.ToInt32(m_curSetting.btFrequencyEnd);
                                    }
                                    break;
                                case 0x03:
                                    {
                                        cbUserDefineFreq.Checked = false;
                                        textStartFreq.Text = "";
                                        TextFreqInterval.Text = "";
                                        textFreqQuantity.Text = "";
                                        rdbRegionChn.Checked = true;
                                        cmbFrequencyStart.SelectedIndex = Convert.ToInt32(m_curSetting.btFrequencyStart) - 43;
                                        cmbFrequencyEnd.SelectedIndex = Convert.ToInt32(m_curSetting.btFrequencyEnd) - 43;
                                    }
                                    break;
                                case 0x04:
                                    {
                                        cbUserDefineFreq.Checked = true;
                                        rdbRegionChn.Checked = false;
                                        rdbRegionEtsi.Checked = false;
                                        rdbRegionFcc.Checked = false;
                                        cmbFrequencyStart.SelectedIndex = -1;
                                        cmbFrequencyEnd.SelectedIndex = -1;
                                        textStartFreq.Text = m_curSetting.nUserDefineStartFrequency.ToString();
                                        TextFreqInterval.Text = Convert.ToString(m_curSetting.btUserDefineFrequencyInterval * 10);
                                        textFreqQuantity.Text = m_curSetting.btUserDefineChannelQuantity.ToString();
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case CMD.cmd_get_reader_temperature:
                        {
                            string strTemperature = string.Empty;
                            if (m_curSetting.btPlusMinus == 0x0)
                            {
                                strTemperature = "-" + m_curSetting.btTemperature.ToString() + "℃";
                            }
                            else
                            {
                                strTemperature = m_curSetting.btTemperature.ToString() + "℃";
                            }
                            txtReaderTemperature.Text = strTemperature;
                        }
                        break;
                    case CMD.cmd_get_drm_mode:
                        {
                            /*
                            if (m_curSetting.btDrmMode == 0x00)
                            {
                                rdbDrmModeClose.Checked = true;
                            }
                            else
                            {
                                rdbDrmModeOpen.Checked = true;
                            }
                             * */
                        }
                        break;
                    case CMD.cmd_get_rf_port_return_loss:
                        {
                            textReturnLoss.Text = m_curSetting.btAntImpedance.ToString() + " dB";
                        }
                        break;
                    case CMD.cmd_get_impinj_fast_tid:
                        {
                            if (m_curSetting.btMonzaStatus == 0x8D)
                            {
                                rdbMonzaOn.Checked = true;
                            }
                            else
                            {
                                rdbMonzaOff.Checked = true;
                            }
                        }
                        break;
                    case CMD.cmd_read_gpio_value:
                        {
                            if (m_curSetting.btGpio1Value == 0x00)
                            {
                                rdbGpio1Low.Checked = true;
                            }
                            else
                            {
                                rdbGpio1High.Checked = true;
                            }

                            if (m_curSetting.btGpio2Value == 0x00)
                            {
                                rdbGpio2Low.Checked = true;
                            }
                            else
                            {
                                rdbGpio2High.Checked = true;
                            }
                        }
                        break;
                    case CMD.cmd_get_ant_connection_detector:
                        {
                            tbAntDectector.Text = m_curSetting.btAntDetector.ToString();
                        }
                        break;
                    default:
                        break;
                }
            }));
        }

        private void RunLoopInventroy()
        {
            BeginInvoke(new ThreadStart(delegate () {
                if (doingRealInv)
                {
                    cmdRealInventorySend();
                }
                else if (doingBufferInv)
                {
                    cmdCachedInventorySend();
                }
                else
                {
                    //Console.WriteLine("RunLoopInventroy ...");
                }
            }));
        }

        private void cmdGetAndResetInventoryBuffer()
        {
            beforeCmdExecTime = DateTime.Now;
            reader.GetAndResetInventoryBuffer(m_curSetting.btReadId);
        }

        private void cmdGetInventoryBuffer()
        {
            beforeCmdExecTime = DateTime.Now;
            reader.GetInventoryBuffer(m_curSetting.btReadId);
        }

        private void cmdCachedInventorySend()
        {
            RefreshInventoryInfo();
            beforeCmdExecTime = DateTime.Now;
            reader.Inventory(m_curSetting.btReadId, Convert.ToByte(txtRepeat.Text));
        }

        private void cmdRealInventorySend()
        {
            RefreshInventoryInfo();
            beforeCmdExecTime = DateTime.Now;
            int writeIndex = 0;
            byte[] data = new byte[256];
            data[writeIndex++] = 0xA0;
            data[writeIndex++] = 0x03;
            data[writeIndex++] = m_curSetting.btReadId;
            if (cb_customized_session_target.Checked)
            {
                data[writeIndex++] = 0x8B; // cmd
                data[writeIndex++] = getParamSession(); // session
                if (ReverseTarget)
                {
                    if (invTargetB && stayBTimes > 1)
                    {
                        stayBTimes--;
                        data[writeIndex++] = 0x01; // Target B
                    }
                    else
                    {
                        stayBTimes = Convert.ToInt32(tb_fast_inv_staytargetB_times.Text);
                        data[writeIndex++] = (byte)(invTargetB == false ? 0x00 : 0x01); // Target
                        invTargetB = !invTargetB;
                    }
                }
                else
                {
                    data[writeIndex++] = getParamTarget(); // Target
                }

                if (cb_use_selectFlags_tempPows.Checked)
                {
                    data[writeIndex++] = getParamSelectFlag(); // SL
                }
                if (cb_use_Phase.Checked)
                    data[writeIndex++] = cb_use_Phase.Checked ? (byte)0x01 : (byte)0x00; // Phase
                if (cb_use_powerSave.Checked)
                {
                    data[writeIndex++] = Convert.ToByte(txtPowerSave.Text); // PowerSave
                }
            }
            else
            {
                data[writeIndex++] = 0x89;
            }
            data[writeIndex++] = Convert.ToByte(txtRepeat.Text);//Repeat
            int msgLen = writeIndex + 1;
            data[1] = (byte)(msgLen - 2); // len

            data[writeIndex] = ReaderUtils.CheckSum(data, 0, msgLen - 1); // check
            Array.Resize(ref data, msgLen);
            reader.SendMessage(data);
        }

        private void cmdFastInventorySend(bool antG1)
        {
            // Head Len Address Cmd ABCD     Interval                                                                    Repeat Check
            // Head Len Address Cmd ABCDEFGH Interval                                                                    Repeat Check
            // Head Len Address Cmd ABCDEFGH Interval Reserve5    Session Target Optimize Ongoing [Target Quantity]Phase Repeat Check
            // Head Len Address Cmd ABCDEFGH Interval Reserve4 SL Session Target Phase Pow12345678                       Repeat Check
            beforeCmdExecTime = DateTime.Now;
            
            BeginInvoke(new ThreadStart(delegate () {
                int writeIndex = 0;
                byte[] rawData = new byte[256];
                rawData[writeIndex++] = 0xA0; // hdr
                rawData[writeIndex++] = 0x03; // len minLen = 3
                rawData[writeIndex++] = m_curSetting.btReadId; // addr
                rawData[writeIndex++] = 0x8A; // cmd

                //antenna/stay
                if (antType1.Checked)
                {
                    int antCount = 4;
                    if (cb_customized_session_target.Checked)
                    {
                        antCount = 8;
                    }
                    for (int i = 0; i < antCount; i++)
                    {
                        rawData[writeIndex++] = (byte)(Convert.ToInt32(fast_inv_ants[i].Text) - 1);
                        if (i == 0)
                        {
                            rawData[writeIndex++] = Convert.ToByte(fast_inv_stays[i].Text);
                        }
                        else
                        {
                            rawData[writeIndex++] = 0x00;
                        }
                    }
                }
                if (antType4.Checked)
                {
                    int antCount = 4;
                    if (cb_customized_session_target.Checked)
                    {
                        antCount = 8;
                    }
                    for (int i = 0; i < antCount; i++)
                    {
                        rawData[writeIndex++] = (byte)(Convert.ToInt32(fast_inv_ants[i].Text) - 1);
                        rawData[writeIndex++] = Convert.ToByte(fast_inv_stays[i].Text);
                    }
                }
                else if (antType16.Checked || antType8.Checked)
                {
                    // data
                    if (antG1)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            rawData[writeIndex++] = (byte)(Convert.ToInt32(fast_inv_ants[i].Text) - 1);
                            rawData[writeIndex++] = Convert.ToByte(fast_inv_stays[i].Text);
                        }
                    }
                    else
                    {
                        for (int i = 8; i < 16; i++)
                        {
                            rawData[writeIndex++] = (byte)(Convert.ToInt32(fast_inv_ants[i].Text) - 9);
                            rawData[writeIndex++] = Convert.ToByte(fast_inv_stays[i].Text);
                        }
                    }

                    //Console.WriteLine("antType8/16 end [G{0}]", useAntG1 ? "1" : "2");
                }

                rawData[writeIndex++] = Convert.ToByte(this.txtInterval.Text); // Interval, 0 ms

                if (cb_customized_session_target.Checked)
                {
                    if (cb_use_selectFlags_tempPows.Checked)
                    {
                        rawData[writeIndex++] = Convert.ToByte(this.tb_fast_inv_reserved_1.Text); // Reserve
                        rawData[writeIndex++] = Convert.ToByte(this.tb_fast_inv_reserved_2.Text);
                        rawData[writeIndex++] = Convert.ToByte(this.tb_fast_inv_reserved_3.Text);
                        rawData[writeIndex++] = Convert.ToByte(this.tb_fast_inv_reserved_4.Text);


                        rawData[writeIndex++] = getParamSelectFlag();//SL
                        rawData[writeIndex++] = getParamSession(); // session
                        rawData[writeIndex++] = (byte)(invTargetB == false ? 0x00 : 0x01); // Target
                        rawData[writeIndex++] = cb_use_Phase.Checked ? (byte)0x01 : (byte)0x00; // Phase
                        if (antG1) //Temp Power > 20
                        {
                            for (int i = 0; i < 8; i++)
                            {
                                rawData[writeIndex++] = Convert.ToByte(fast_inv_temp_pows[i].Text);
                            }
                        }
                        else
                        {
                            for (int i = 8; i < 16; i++)
                            {
                                rawData[writeIndex++] = Convert.ToByte(fast_inv_temp_pows[i].Text);
                            }
                        }
                    }
                    else
                    {
                        rawData[writeIndex++] = Convert.ToByte(this.tb_fast_inv_reserved_1.Text); // Reserve
                        rawData[writeIndex++] = Convert.ToByte(this.tb_fast_inv_reserved_2.Text);
                        rawData[writeIndex++] = Convert.ToByte(this.tb_fast_inv_reserved_3.Text);
                        rawData[writeIndex++] = Convert.ToByte(this.tb_fast_inv_reserved_4.Text);
                        rawData[writeIndex++] = Convert.ToByte(this.tb_fast_inv_reserved_5.Text);

                        rawData[writeIndex++] = getParamSession(); // session

                        // Target
                        if (ReverseTarget)
                        {
                            if (invTargetB && stayBTimes > 1)
                            {
                                stayBTimes--;
                                rawData[writeIndex++] = 0x01; // Target B
                            }
                            else
                            {
                                stayBTimes = Convert.ToInt32(tb_fast_inv_staytargetB_times.Text);
                                rawData[writeIndex++] = (byte)(invTargetB == false ? 0x00 : 0x01); // Target

                                invTargetB = !invTargetB;
                            }
                        }
                        else
                        {
                            rawData[writeIndex++] = getParamTarget(); // Target
                        }

                        rawData[writeIndex++] = Convert.ToByte(txtOptimize.Text, 16); // Optimize

                        rawData[writeIndex++] = Convert.ToByte(txtOngoing.Text, 16);//Ongoing

                        rawData[writeIndex++] = Convert.ToByte(txtTargetQuantity.Text);//Target Quantity

                        rawData[writeIndex++] = cb_use_Phase.Checked ? (byte)0x01 : (byte)0x00; // Phase
                    }
                }

                rawData[writeIndex++] = Convert.ToByte(txtRepeat.Text); // Repeat
                int msgLen = writeIndex + 1;
                rawData[1] = (byte)(msgLen - 2); // except hdr+len
                //Console.WriteLine("FastInv writeIndex={0}, msgLen={0}, len={2}", writeIndex, msgLen, rawData[1]);

                rawData[writeIndex] = ReaderUtils.CheckSum(rawData, 0, msgLen - 1); // check
                Array.Resize(ref rawData, msgLen);
                int nResult = reader.SendMessage(rawData);
            }));
        }

        public void FastInventory()
        {
            BeginInvoke(new ThreadStart(delegate () {
                //Console.WriteLine("-----------------RunLoopFastSwitch");
                
                if (antType16.Checked)
                {
                    if (useAntG1)
                    {
                        if (checkFastInvAntG2Count())
                        {
                            cmdSwitchAntG2();
                        }
                        else
                        {
                            if (m_FastExeCount == -1)
                            {
                                RefreshInventoryInfo();
                                cmdFastInventorySend(useAntG1);
                            }
                            else
                            {
                                if (m_FastExeCount > 1)
                                {
                                    m_FastExeCount--;
                                    RefreshInventoryInfo();
                                    cmdFastInventorySend(useAntG1);
                                }
                                else
                                {
                                    stopFastInv();
                                }
                            }
                        }
                    }
                    else
                    {
                        RefreshInventoryInfo();
                        if (m_FastExeCount == -1)
                        {
                            if (checkFastInvAntG1Count())
                            {
                                cmdSwitchAntG1();
                            }
                            else
                            {
                                cmdFastInventorySend(useAntG1);
                            }
                        }
                        else
                        {
                            if (m_FastExeCount > 1)
                            {
                                m_FastExeCount--;
                                if (checkFastInvAntG1Count())
                                {
                                    cmdSwitchAntG1();
                                }
                                else
                                {
                                    cmdFastInventorySend(useAntG1);
                                }
                            }
                            else
                            {
                                stopFastInv();
                            }
                        }
                    }
                }
                else
                {
                    if (m_FastExeCount == -1)
                    {
                        RefreshInventoryInfo();
                        cmdFastInventorySend(useAntG1);
                    }
                    else
                    {
                        if (m_FastExeCount > 1)
                        {
                            m_FastExeCount--;
                            RefreshInventoryInfo();
                            cmdFastInventorySend(useAntG1);
                        }
                        else
                        {
                            btnInventory.BackColor = Color.WhiteSmoke;
                            btnInventory.ForeColor = Color.DarkBlue;
                            btnInventory.Text = FindResource("StartInventory");
                            stopFastInv();
                        }
                    }
                }
            }));
        }

        private void RefreshISO18000(byte btCmd)
        {
            BeginInvoke(new ThreadStart(delegate () {
                switch (btCmd)
                {
                    case 0xb0:
                        {
                            ltvTagISO18000.Items.Clear();
                            int nLength = m_curOperateTagISO18000Buffer.dtTagTable.Rows.Count;
                            int nIndex = 1;
                            foreach (DataRow row in m_curOperateTagISO18000Buffer.dtTagTable.Rows)
                            {
                                ListViewItem item = new ListViewItem();
                                item.Text = nIndex.ToString();
                                item.SubItems.Add(row[1].ToString());
                                item.SubItems.Add(row[0].ToString());
                                item.SubItems.Add(row[2].ToString());
                                ltvTagISO18000.Items.Add(item);

                                nIndex++;
                            }

                            //txtTagCountISO18000.Text = m_curOperateTagISO18000Buffer.dtTagTable.Rows.Count.ToString();

                            if (m_bContinue)
                            {
                                reader.InventoryISO18000(m_curSetting.btReadId);
                            }
                            else
                            {
                                WriteLog(lrtxtLog, FindResource("StopInventory"), 0);
                            }
                        }
                        break;
                    case 0xb1:
                        {
                            htxtReadData18000.Text = m_curOperateTagISO18000Buffer.strReadData;
                        }
                        break;
                    case 0xb2:
                        {
                            //txtWriteLength.Text = m_curOperateTagISO18000Buffer.btWriteLength.ToString();
                        }
                        break;
                    case 0xb3:
                        {
                            //switch(m_curOperateTagISO18000Buffer.btStatus)
                            //{
                            //    case 0x00:
                            //        string.Format("{0}", FindResource("tipThisByteIsLocked"));
                            //        break;
                            //    case 0xFE:
                            //        string.Format("{0}", FindResource("tipThisByteIsAlreadyLocked"));
                            //        break;
                            //    case 0xFF:
                            //        string.Format("{0}", FindResource("tipThisByteIsNotLocked"));
                            //        break;
                            //    default:
                            //        break;
                            //}
                        }
                        break;
                    case 0xb4:
                        {
                            switch (m_curOperateTagISO18000Buffer.btStatus)
                            {
                                case 0x00:
                                    txtStatus.Text = string.Format("{0}", FindResource("tipThisByteIsNotLocked"));
                                    break;
                                case 0xFE:
                                    txtStatus.Text = string.Format("{0}", FindResource("tipThisByteIsAlreadyLocked"));
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }));
        }

        private void RunLoopISO18000(int nLength)
        {
            BeginInvoke(new ThreadStart(delegate () {
                if (nLength == m_nBytes)
                {
                    m_nLoopedTimes++;
                    txtLoopTimes.Text = m_nLoopedTimes.ToString();
                }
                m_nLoopTimes--;
                if (m_nLoopTimes > 0)
                {
                    WriteTagISO18000();
                }
            }));
        }

        private void connectType_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_btn_rs232.Checked)
            {
                grb_rs232.Visible = true;
                grb_tcp.Visible = false;
                // btnConnect.Enabled = true;
            }
            else if (radio_btn_tcp.Checked)
            {
                grb_rs232.Visible = false;
                grb_tcp.Visible = true;
                //  btnConnect.Enabled = true;
            }
        }

        private void SetFormEnable(bool bIsEnable)
        {
            gbConnectType.Enabled = (!bIsEnable);
            gbCmdReaderAddress.Enabled = bIsEnable;
            gbCmdVersion.Enabled = bIsEnable;
            gbCmdBaudrate.Enabled = bIsEnable;
            gbCmdTemperature.Enabled = bIsEnable;
            gbCmdOutputPower.Enabled = bIsEnable;
            gbCmdAntenna.Enabled = bIsEnable;
            //gbCmdDrm.Enabled = bIsEnable;
            gbCmdRegion.Enabled = bIsEnable;
            gbCmdBeeper.Enabled = bIsEnable;
            gbCmdReadGpio.Enabled = bIsEnable;
            gbCmdAntDetector.Enabled = bIsEnable;
            gbReturnLoss.Enabled = bIsEnable;
            gbProfile.Enabled = bIsEnable;

            btnResetReader.Enabled = bIsEnable;

            gbCmdOperateTag.Enabled = bIsEnable;

            btnInventoryISO18000.Enabled = bIsEnable;
            btnClear.Enabled = bIsEnable;
            gbISO1800ReadWrite.Enabled = bIsEnable;
            gbISO1800LockQuery.Enabled = bIsEnable;

            tab_6c_Tags_Test.Enabled = bIsEnable;

            gbMonza.Enabled = bIsEnable;
            lbChangeBaudrate.Enabled = bIsEnable;
            cmbSetBaudrate.Enabled = bIsEnable;
            btnSetUartBaudrate.Enabled = bIsEnable;
            btReaderSetupRefresh.Enabled = bIsEnable;

            btRfSetup.Enabled = bIsEnable;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text.Equals(FindResource("Connect")))
            {
                //btnInventory.Enabled = true;
                btnConnect.Enabled = true;
                ConnectReader();
                btnInventory_Click_1(sender, e);


            }
            else if (btnConnect.Text.Equals(FindResource("Disconnect")))
            {
                btnConnect.Text = FindResource("Connect");
                btnInventory.Enabled = false;
                btnConnect.Enabled = false;

                DisconnectReader();
            }
        }


        private bool btnisstartSound = false;
        private void btnStartSound(object sender , EventArgs e)
        {
            if(!btnisstartSound)
            {
                btnInventory.BackColor = Color.WhiteSmoke;
                btnInventory.ForeColor = Color.DarkBlue;
                btnInventory.Text = "STOP";
                PlaySoundStart();
                btnisstartSound = true;
            }
            else
            {
                btnInventory.BackColor = Color.WhiteSmoke;
                btnInventory.ForeColor = Color.DarkBlue;
                btnInventory.Text = "START";
                stopwatch.Stop();
                timer1.Stop();
                btnisstartSound = false;
                btn_Reload.Enabled = true;
                btnConnect.PerformClick();
                btn_Ulangi.Show();
                
            }
        }

        private void DisconnectReader()
        {
            Inventorying = false;
            isFastInv = false;
            isBufferInv = false;
            isRealInv = false;
            doingFastInv = false;
            doingRealInv = false;
            doingBufferInv = false;
            setInvStoppedStatus();

            if (radio_btn_rs232.Checked)
            {
                reader.CloseCom();
                SetFormEnable(false);
            }
            else if (radio_btn_tcp.Checked)
            {
                reader.SignOut();
                SetFormEnable(false);
            }
        }

        private async void ConnectReader()
        {
            if (radio_btn_rs232.Checked)
            {
                string strException = string.Empty;
                string strComPort = cmbComPort.Text;
                int nBaudrate = Convert.ToInt32(cmbBaudrate.Text);

                int nRet = reader.OpenCom(strComPort, nBaudrate, out strException);
                if (nRet != 0)
                {
                    string strLog = string.Format("{0} {1}", FindResource("tipConnectFailedCause"), strException);
                    WriteLog(lrtxtLog, strLog, 1);

                    return;
                }
                else
                {
                    string strLog = string.Format("{0} {1}@{2}", FindResource("tipConnect"), strComPort, nBaudrate);
                    WriteLog(lrtxtLog, strLog, 0);
                    btnConnect.Text = FindResource("Disconnect");
                }

                SetFormEnable(true);
            }
            else if (radio_btn_tcp.Checked)
            {
                try
                {
                    string strException = string.Empty;
                    IPAddress ipAddress = IPAddress.Parse(ipIpServer.IpAddressStr);
                    int nPort = Convert.ToInt32(txtTcpPort.Text);

                    int nRet = reader.ConnectServer(ipAddress, nPort, out strException);
                    if (nRet != 0)
                    {
                        string strLog = string.Format("{0} {1}", FindResource("tipConnectFailedCause"), strException);
                        WriteLog(lrtxtLog, strLog, 1);


                        return;
                    }
                    else
                    {
                        string strLog = string.Format("{0} {1}:{2}", FindResource("tipConnect"), ipIpServer.IpAddressStr, nPort);
                        WriteLog(lrtxtLog, strLog, 0);
                        btnConnect.Text = FindResource("Disconnect");
                        showMessage("Klik 'Start'", Color.FromArgb(243, 246, 249));
                    }

                    SetFormEnable(true);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("ConnectReader {0}", ex.Message));
                    showMessage("Reader Rfid Tidak Terhubung", Color.FromArgb(243, 246, 249));
                }
            }
        }

        private void btnResetReader_Click(object sender, EventArgs e)
        {
            int nRet = reader.Reset(m_curSetting.btReadId);
            if (nRet != 0)
            {
                string strLog = string.Format("{0} Failed", FindResource("tipResetReader"));
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = string.Format("{0}", FindResource("tipResetReader"));
                m_curSetting.btReadId = (byte)0xFF;
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void btnSetReadAddress_Click(object sender, EventArgs e)
        {
            try
            {
                if (htxtReadId.Text.Length != 0)
                {
                    string strTemp = htxtReadId.Text.Trim();
                    reader.SetReaderAddress(m_curSetting.btReadId, Convert.ToByte(strTemp, 16));
                    m_curSetting.btReadId = Convert.ToByte(strTemp, 16);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(string.Format("SetReadAddress {0}", ex.Message));
            }

        }

        private void ProcessSetReadAddress(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipSetReadAddress"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x10)
                {
                    m_curSetting.btReadId = msgTran.ReadId;
                    WriteLog(lrtxtLog, strCmd, 0);

                    return;
                }
                else
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void btnGetFirmwareVersion_Click(object sender, EventArgs e)
        {
            reader.GetFirmwareVersion(m_curSetting.btReadId);
        }

        private void ProcessGetFirmwareVersion(MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipGetFirmwareVersion"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 2)
            {
                m_curSetting.btMajor = msgTran.AryData[0];
                m_curSetting.btMinor = msgTran.AryData[1];
                m_curSetting.btReadId = msgTran.ReadId;

                RefreshReadSetting((CMD)msgTran.Cmd);
                WriteLog(lrtxtLog, strCmd, 0);

                cmdGetInternalVersion();

                return;
            }
            else if (msgTran.AryData.Length == 1)
            {
                strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        #region GetInternalVersion
        private void cmdGetInternalVersion()
        {
            // minLen = addr + cmd + check = 3
            // [hdr][len][addr][cmd][data][check]
            // 0xA0 len addr 0xAA 
            int writeIndex = 0;
            byte[] rawData = new byte[256];
            rawData[writeIndex++] = 0xA0;
            rawData[writeIndex++] = 3;
            rawData[writeIndex++] = m_curSetting.btReadId;
            rawData[writeIndex++] = 0xAA;

            int msgLen = writeIndex + 1;
            rawData[1] = (byte)(msgLen - 2); // update len, except hdr+len

            rawData[writeIndex] = ReaderUtils.CheckSum(rawData, 0, msgLen - 1); // check
            Array.Resize(ref rawData, msgLen);
            int nResult = reader.SendMessage(rawData);
        }

        private void ProcessGetInternalVersion(MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipGetInternalVersion"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                m_curSetting.btInternalVersion = msgTran.AryData[0];
                BeginInvoke(new ThreadStart(delegate () {
                    txtFirmwareVersion.Text = String.Format("{0}.{1}.{2}", m_curSetting.btMajor, m_curSetting.btMinor, BitConverter.ToString(new byte[] { m_curSetting.btInternalVersion }));
                }));
                WriteLog(lrtxtLog, strCmd, 0);
                return;
            }
            else
            {
                strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }
        #endregion GetInternalVersion

        private void btnSetUartBaudrate_Click(object sender, EventArgs e)
        {
            if (cmbSetBaudrate.SelectedIndex != -1)
            {
                reader.SetUartBaudrate(m_curSetting.btReadId, cmbSetBaudrate.SelectedIndex + 3);
                m_curSetting.btIndexBaudrate = Convert.ToByte(cmbSetBaudrate.SelectedIndex);
            }
        }

        private void ProcessSetUartBaudrate(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipSetUartBaudrate"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x10)
                {
                    m_curSetting.btReadId = msgTran.ReadId;
                    WriteLog(lrtxtLog, strCmd, 0);

                    return;
                }
                else
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void btnGetReaderTemperature_Click(object sender, EventArgs e)
        {
            reader.GetReaderTemperature(m_curSetting.btReadId);
        }

        private void ProcessGetReaderTemperature(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipGetReaderTemperature"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 2)
            {
                m_curSetting.btReadId = msgTran.ReadId;
                m_curSetting.btPlusMinus = msgTran.AryData[0];
                m_curSetting.btTemperature = msgTran.AryData[1];

                RefreshReadSetting((CMD)msgTran.Cmd);
                WriteLog(lrtxtLog, strCmd, 0);
                return;
            }
            else if (msgTran.AryData.Length == 1)
            {
                strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void btnGetOutputPower_Click(object sender, EventArgs e)
        {
            if (antType16.Checked)
            {
                m_getOutputPower = true;
                tagdb.AntGroup = 0x00;
                reader.SetReaderAntGroup(m_curSetting.btReadId, tagdb.AntGroup);
            }
            else if (antType8.Checked)
            {
                reader.GetOutputPower(m_curSetting.btReadId);
            }
            else if (antType4.Checked || antType1.Checked)
            {
                reader.GetOutputPowerFour(m_curSetting.btReadId);
            }
        }

        private void ProcessGetOutputPower(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipGetOutputPower"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                m_curSetting.btReadId = msgTran.ReadId;
                m_curSetting.btOutputPower = msgTran.AryData[0];

                RefreshReadSetting(CMD.cmd_get_output_power);
                WriteLog(lrtxtLog, strCmd, 0);
                return;
            }
            else if (msgTran.AryData.Length == 8)
            {
                m_curSetting.btReadId = msgTran.ReadId;
                if (antType16.Checked && m_getOutputPower)
                {
                    if (tagdb.AntGroup == 0x00)
                    {
                        m_curSetting.btOutputPowers = msgTran.AryData;
                        tagdb.AntGroup = 0x01;
                        reader.SetReaderAntGroup(m_curSetting.btReadId, tagdb.AntGroup);
                    }
                    else
                    {
                        byte[] btPowers = new byte[m_curSetting.btOutputPowers.Length + msgTran.AryData.Length];
                        Array.Copy(m_curSetting.btOutputPowers, 0, btPowers, 0, m_curSetting.btOutputPowers.Length);
                        Array.Copy(msgTran.AryData, 0, btPowers, m_curSetting.btOutputPowers.Length, msgTran.AryData.Length);
                        m_curSetting.btOutputPowers = btPowers;
                        m_getOutputPower = false;
                    }
                }
                else
                {
                    m_curSetting.btOutputPowers = msgTran.AryData;
                }

                RefreshReadSetting(CMD.cmd_get_output_power_eight);
                WriteLog(lrtxtLog, strCmd, 0);
                return;
            }
            else if (msgTran.AryData.Length == 4)
            {
                m_curSetting.btReadId = msgTran.ReadId;
                m_curSetting.btOutputPowers = msgTran.AryData;

                RefreshReadSetting(CMD.cmd_get_output_power);
                WriteLog(lrtxtLog, strCmd, 0);
                return;
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void btnSetOutputPower_Click(object sender, EventArgs e)
        {
            try
            {
                if (antType16.Checked)
                {
                    m_setOutputPower = true;
                    cmdSwitchAntG1();
                }
                else if (antType8.Checked)
                {
                    if (tb_outputpower_1.Text.Length != 0 || tb_outputpower_2.Text.Length != 0 || tb_outputpower_3.Text.Length != 0 || tb_outputpower_4.Text.Length != 0
                       || tb_outputpower_5.Text.Length != 0 || tb_outputpower_6.Text.Length != 0 || tb_outputpower_7.Text.Length != 0 || tb_outputpower_8.Text.Length != 0)
                    {
                        byte[] OutputPower = new byte[8];
                        OutputPower[0] = Convert.ToByte(tb_outputpower_1.Text);
                        OutputPower[1] = Convert.ToByte(tb_outputpower_2.Text);
                        OutputPower[2] = Convert.ToByte(tb_outputpower_3.Text);
                        OutputPower[3] = Convert.ToByte(tb_outputpower_4.Text);
                        OutputPower[4] = Convert.ToByte(tb_outputpower_5.Text);
                        OutputPower[5] = Convert.ToByte(tb_outputpower_6.Text);
                        OutputPower[6] = Convert.ToByte(tb_outputpower_7.Text);
                        OutputPower[7] = Convert.ToByte(tb_outputpower_8.Text);

                        //m_curSetting.btOutputPower = Convert.ToByte(txtOutputPower.Text);
                        reader.SetOutputPower(m_curSetting.btReadId, OutputPower);
                        // m_curSetting.btOutputPower = Convert.ToByte(txtOutputPower.Text);
                    }
                }
                else if (antType4.Checked)
                {
                    if (tb_outputpower_1.Text.Length != 0 || tb_outputpower_2.Text.Length != 0 || tb_outputpower_3.Text.Length != 0 || tb_outputpower_4.Text.Length != 0)
                    {
                        byte[] OutputPower = new byte[4];
                        OutputPower[0] = Convert.ToByte(tb_outputpower_1.Text);
                        OutputPower[1] = Convert.ToByte(tb_outputpower_2.Text);
                        OutputPower[2] = Convert.ToByte(tb_outputpower_3.Text);
                        OutputPower[3] = Convert.ToByte(tb_outputpower_4.Text);
                        //m_curSetting.btOutputPower = Convert.ToByte(txtOutputPower.Text);
                        reader.SetOutputPower(m_curSetting.btReadId, OutputPower);
                        // m_curSetting.btOutputPower = Convert.ToByte(txtOutputPower.Text);
                    }
                }
                else if (antType1.Checked)
                {
                    if (tb_outputpower_1.Text.Length != 0)
                    {
                        byte[] OutputPower = new byte[1];
                        OutputPower[0] = Convert.ToByte(tb_outputpower_1.Text);
                        //m_curSetting.btOutputPower = Convert.ToByte(txtOutputPower.Text);
                        reader.SetOutputPower(m_curSetting.btReadId, OutputPower);
                        // m_curSetting.btOutputPower = Convert.ToByte(txtOutputPower.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("SetOutputPower {0}", ex.Message));
            }

        }

        private void ProcessSetOutputPower(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipSetOutputPower"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x10)
                {
                    m_curSetting.btReadId = msgTran.ReadId;
                    if (antType16.Checked && m_setOutputPower)
                    {
                        if (useAntG1)
                        {
                            cmdSwitchAntG2();
                        }
                        else
                        {
                            cmdSwitchAntG1(); // Finally switch to G1
                            m_setOutputPower = false;
                        }
                    }
                    WriteLog(lrtxtLog, strCmd, 0);
                    return;
                }
                else
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void btnGetWorkAntenna_Click(object sender, EventArgs e)
        {
            m_getWorkAnt = true;
            reader.GetReaderAntGroup(m_curSetting.btReadId);
        }

        private void ProcessGetWorkAntenna(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipGetWorkAntenna"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x00 || msgTran.AryData[0] == 0x01 || msgTran.AryData[0] == 0x02 || msgTran.AryData[0] == 0x03
                    || msgTran.AryData[0] == 0x04 || msgTran.AryData[0] == 0x05 || msgTran.AryData[0] == 0x06 || msgTran.AryData[0] == 0x07)
                {
                    m_curSetting.btReadId = msgTran.ReadId;
                    m_curSetting.btWorkAntenna = msgTran.AryData[0];

                    RefreshReadSetting(CMD.cmd_get_work_antenna);
                    WriteLog(lrtxtLog, string.Format("{0} {1:x2}", strCmd, msgTran.AryData[0]), 0);
                    return;
                }
                else
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void btnSetWorkAntenna_Click(object sender, EventArgs e)
        {
            if (cmbWorkAnt.SelectedIndex != -1)
            {
                m_setWorkAnt = true;
                byte btWorkAntenna = (byte)cmbWorkAnt.SelectedIndex;
                if (btWorkAntenna >= 0x08)
                    tagdb.AntGroup = 0x01;
                else
                    tagdb.AntGroup = 0x00;
                reader.SetReaderAntGroup(m_curSetting.btReadId, tagdb.AntGroup);
            }
        }

        private void ProcessSetWorkAntenna(Reader.MessageTran msgTran)
        {
            int intCurrentAnt = 0;
            if (antType16.Checked && tagdb.AntGroup == 0x01)
                intCurrentAnt = m_curSetting.btWorkAntenna + 9;
            else
                intCurrentAnt = m_curSetting.btWorkAntenna + 1;
            string strCmd = string.Format("{0} {1}", FindResource("tipSetWorkAntenna"), intCurrentAnt);

            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x10)
                {
                    m_curSetting.btReadId = msgTran.ReadId;
                    WriteLog(lrtxtLog, strCmd, 0);
                    if (Inventorying)
                        RunLoopInventroy();
                    return;
                }
                else
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
            if (Inventorying)
            {
                if (radio_btn_realtime_inv.Checked)
                {
                    stopRealInv();
                }
                else if (radio_btn_fast_inv.Checked)
                {
                    stopFastInv();
                }
                else if (radio_btn_cache_inv.Checked)
                {
                    stopBufferInv();
                }
            }
        }

        private void btnGetDrmMode_Click(object sender, EventArgs e)
        {
            reader.GetDrmMode(m_curSetting.btReadId);
        }

        private void ProcessGetDrmMode(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipGetDrmMode"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x00 || msgTran.AryData[0] == 0x01)
                {
                    m_curSetting.btReadId = msgTran.ReadId;
                    m_curSetting.btDrmMode = msgTran.AryData[0];

                    RefreshReadSetting(CMD.cmd_get_drm_mode);
                    WriteLog(lrtxtLog, strCmd, 0);
                    return;
                }
                else
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void btnSetDrmMode_Click(object sender, EventArgs e)
        {
            byte btDrmMode = 0xFF;
            /*
            if (rdbDrmModeClose.Checked)
            {
                btDrmMode = 0x00;
            }
            else if (rdbDrmModeOpen.Checked)
            {
                btDrmMode = 0x01;
            }
            else
            {
                return;
            }
             */

            reader.SetDrmMode(m_curSetting.btReadId, btDrmMode);
            m_curSetting.btDrmMode = btDrmMode;
        }

        private void ProcessSetDrmMode(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipSetDrmMode"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x10)
                {
                    m_curSetting.btReadId = msgTran.ReadId;
                    WriteLog(lrtxtLog, strCmd, 0);

                    return;
                }
                else
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void rdbRegionFcc_CheckedChanged(object sender, EventArgs e)
        {
            cmbFrequencyStart.SelectedIndex = -1;
            cmbFrequencyEnd.SelectedIndex = -1;
            cmbFrequencyStart.Items.Clear();
            cmbFrequencyEnd.Items.Clear();

            float nStart = 902.00f;
            for (int nloop = 0; nloop < 53; nloop++)
            {
                string strTemp = nStart.ToString("0.00");
                cmbFrequencyStart.Items.Add(strTemp);
                cmbFrequencyEnd.Items.Add(strTemp);

                nStart += 0.5f;
            }
        }

        private void rdbRegionEtsi_CheckedChanged(object sender, EventArgs e)
        {
            cmbFrequencyStart.SelectedIndex = -1;
            cmbFrequencyEnd.SelectedIndex = -1;
            cmbFrequencyStart.Items.Clear();
            cmbFrequencyEnd.Items.Clear();

            float nStart = 865.00f;
            for (int nloop = 0; nloop < 7; nloop++)
            {
                string strTemp = nStart.ToString("0.00");
                cmbFrequencyStart.Items.Add(strTemp);
                cmbFrequencyEnd.Items.Add(strTemp);

                nStart += 0.5f;
            }
        }

        private void rdbRegionChn_CheckedChanged(object sender, EventArgs e)
        {
            cmbFrequencyStart.SelectedIndex = -1;
            cmbFrequencyEnd.SelectedIndex = -1;
            cmbFrequencyStart.Items.Clear();
            cmbFrequencyEnd.Items.Clear();

            float nStart = 920.00f;
            for (int nloop = 0; nloop < 11; nloop++)
            {
                string strTemp = nStart.ToString("0.00");
                cmbFrequencyStart.Items.Add(strTemp);
                cmbFrequencyEnd.Items.Add(strTemp);

                nStart += 0.5f;
            }
        }

        private string GetFreqString(byte btFreq)
        {
            string strFreq = string.Empty;

            if (m_curSetting.btRegion == 4)
            {
                float nExtraFrequency = btFreq * m_curSetting.btUserDefineFrequencyInterval * 10;
                float nstartFrequency = ((float)m_curSetting.nUserDefineStartFrequency) / 1000;
                float nStart = nstartFrequency + nExtraFrequency / 1000;
                string strTemp = nStart.ToString("0.000");
                return strTemp;
            }
            else
            {
                if (btFreq < 0x07)
                {
                    float nStart = 865.00f + Convert.ToInt32(btFreq) * 0.5f;

                    string strTemp = nStart.ToString("0.00");

                    return strTemp;
                }
                else
                {
                    float nStart = 902.00f + (Convert.ToInt32(btFreq) - 7) * 0.5f;

                    string strTemp = nStart.ToString("0.00");

                    return strTemp;
                }
            }
        }

        private void btnGetFrequencyRegion_Click(object sender, EventArgs e)
        {
            reader.GetFrequencyRegion(m_curSetting.btReadId);
        }

        private void ProcessGetFrequencyRegion(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipGetFrequencyRegion"));
            string strErrorCode = string.Empty;

            parseGetFrequencyRegion(msgTran.AryData);

            if (msgTran.AryData.Length == 3)
            {
                m_curSetting.btReadId = msgTran.ReadId;
                m_curSetting.btRegion = msgTran.AryData[0];
                m_curSetting.btFrequencyStart = msgTran.AryData[1];
                m_curSetting.btFrequencyEnd = msgTran.AryData[2];

                RefreshReadSetting(CMD.cmd_get_frequency_region);
                WriteLog(lrtxtLog, strCmd, 0);
                return;
            }
            else if (msgTran.AryData.Length == 6)
            {
                m_curSetting.btReadId = msgTran.ReadId;
                m_curSetting.btRegion = msgTran.AryData[0];
                m_curSetting.btUserDefineFrequencyInterval = msgTran.AryData[1];
                m_curSetting.btUserDefineChannelQuantity = msgTran.AryData[2];
                m_curSetting.nUserDefineStartFrequency = msgTran.AryData[3] * 256 * 256 + msgTran.AryData[4] * 256 + msgTran.AryData[5];
                RefreshReadSetting(CMD.cmd_get_frequency_region);
                WriteLog(lrtxtLog, strCmd, 0);
                return;


            }
            else if (msgTran.AryData.Length == 1)
            {
                strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void btnSetFrequencyRegion_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbUserDefineFreq.Checked == true)
                {
                    int nStartFrequency = Convert.ToInt32(textStartFreq.Text);
                    int nFrequencyInterval = Convert.ToInt32(TextFreqInterval.Text);
                    nFrequencyInterval = nFrequencyInterval / 10;
                    byte btChannelQuantity = Convert.ToByte(textFreqQuantity.Text);
                    reader.SetUserDefineFrequency(m_curSetting.btReadId, nStartFrequency, (byte)nFrequencyInterval, btChannelQuantity);
                    m_curSetting.btRegion = 4;
                    m_curSetting.nUserDefineStartFrequency = nStartFrequency;
                    m_curSetting.btUserDefineFrequencyInterval = (byte)nFrequencyInterval;
                    m_curSetting.btUserDefineChannelQuantity = btChannelQuantity;
                }
                else
                {
                    byte btRegion = 0x00;
                    byte btStartFreq = 0x00;
                    byte btEndFreq = 0x00;

                    int nStartIndex = cmbFrequencyStart.SelectedIndex;
                    int nEndIndex = cmbFrequencyEnd.SelectedIndex;
                    if (nEndIndex < nStartIndex)
                    {
                        MessageBox.Show(FindResource("tipFreqNotInRegion"));
                        return;
                    }

                    if (rdbRegionFcc.Checked)
                    {
                        btRegion = 0x01;
                        btStartFreq = Convert.ToByte(nStartIndex + 7);
                        btEndFreq = Convert.ToByte(nEndIndex + 7);
                    }
                    else if (rdbRegionEtsi.Checked)
                    {
                        btRegion = 0x02;
                        btStartFreq = Convert.ToByte(nStartIndex);
                        btEndFreq = Convert.ToByte(nEndIndex);
                    }
                    else if (rdbRegionChn.Checked)
                    {
                        btRegion = 0x03;
                        btStartFreq = Convert.ToByte(nStartIndex + 43);
                        btEndFreq = Convert.ToByte(nEndIndex + 43);
                    }
                    else
                    {
                        return;
                    }

                    reader.SetFrequencyRegion(m_curSetting.btReadId, btRegion, btStartFreq, btEndFreq);
                    m_curSetting.btRegion = btRegion;
                    m_curSetting.btFrequencyStart = btStartFreq;
                    m_curSetting.btFrequencyEnd = btEndFreq;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("SetFrequencyRegion {0}", ex.Message));
            }
        }

        private void ProcessSetFrequencyRegion(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipSetFrequencyRegion"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x10)
                {
                    m_curSetting.btReadId = msgTran.ReadId;
                    WriteLog(lrtxtLog, strCmd, 0);

                    return;
                }
                else
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void btnSetBeeperMode_Click(object sender, EventArgs e)
        {
            byte btBeeperMode = 0xFF;

            if (rdbBeeperModeSlient.Checked)
            {
                btBeeperMode = 0x00;
            }
            else if (rdbBeeperModeInventory.Checked)
            {
                btBeeperMode = 0x01;
            }
            else if (rdbBeeperModeTag.Checked)
            {
                btBeeperMode = 0x02;
            }
            else
            {
                return;
            }

            reader.SetBeeperMode(m_curSetting.btReadId, btBeeperMode);
            m_curSetting.btBeeperMode = btBeeperMode;
        }

        private void ProcessSetBeeperMode(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipSetBeeperMode"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x10)
                {
                    m_curSetting.btReadId = msgTran.ReadId;
                    WriteLog(lrtxtLog, strCmd, 0);

                    return;
                }
                else
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void btnReadGpioValue_Click(object sender, EventArgs e)
        {
            reader.ReadGpioValue(m_curSetting.btReadId);
        }

        private void ProcessReadGpioValue(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipReadGpioValue"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 2)
            {
                m_curSetting.btReadId = msgTran.ReadId;
                m_curSetting.btGpio1Value = msgTran.AryData[0];
                m_curSetting.btGpio2Value = msgTran.AryData[1];

                RefreshReadSetting(CMD.cmd_read_gpio_value);
                WriteLog(lrtxtLog, strCmd, 0);
                return;
            }
            else if (msgTran.AryData.Length == 1)
            {
                strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void btnWriteGpio3Value_Click(object sender, EventArgs e)
        {
            byte btGpioValue = 0xFF;

            if (rdbGpio3Low.Checked)
            {
                btGpioValue = 0x00;
            }
            else if (rdbGpio3High.Checked)
            {
                btGpioValue = 0x01;
            }
            else
            {
                return;
            }

            reader.WriteGpioValue(m_curSetting.btReadId, 0x03, btGpioValue);
            m_curSetting.btGpio3Value = btGpioValue;
        }

        private void btnWriteGpio4Value_Click(object sender, EventArgs e)
        {
            byte btGpioValue = 0xFF;

            if (rdbGpio4Low.Checked)
            {
                btGpioValue = 0x00;
            }
            else if (rdbGpio4High.Checked)
            {
                btGpioValue = 0x01;
            }
            else
            {
                return;
            }

            reader.WriteGpioValue(m_curSetting.btReadId, 0x04, btGpioValue);
            m_curSetting.btGpio4Value = btGpioValue;
        }

        private void ProcessWriteGpioValue(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipWriteGpioValue"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x10)
                {
                    m_curSetting.btReadId = msgTran.ReadId;
                    WriteLog(lrtxtLog, strCmd, 0);

                    return;
                }
                else
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void btnGetAntDetector_Click(object sender, EventArgs e)
        {
            reader.GetAntDetector(m_curSetting.btReadId);
        }

        private void ProcessGetAntDetector(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipGetAntDetector"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                m_curSetting.btReadId = msgTran.ReadId;
                m_curSetting.btAntDetector = msgTran.AryData[0];

                RefreshReadSetting(CMD.cmd_get_ant_connection_detector);
                WriteLog(lrtxtLog, strCmd, 0);
                return;
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void ProcessGetMonzaStatus(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipGetMonzaStatus"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x00 || msgTran.AryData[0] == 0x8D)
                {
                    m_curSetting.btReadId = msgTran.ReadId;
                    m_curSetting.btMonzaStatus = msgTran.AryData[0];

                    RefreshReadSetting(CMD.cmd_get_impinj_fast_tid);
                    WriteLog(lrtxtLog, strCmd, 0);
                    return;
                }
                else
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void ProcessSetMonzaStatus(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipSetMonzaStatus"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x10)
                {
                    m_curSetting.btReadId = msgTran.ReadId;
                    m_curSetting.btAntDetector = msgTran.AryData[0];

                    WriteLog(lrtxtLog, strCmd, 0);
                    return;
                }
                else
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void ProcessSetProfile(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipSetProfile"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x10)
                {
                    m_curSetting.btReadId = msgTran.ReadId;
                    m_curSetting.btLinkProfile = msgTran.AryData[0];

                    WriteLog(lrtxtLog, strCmd, 0);
                    return;
                }
                else
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void ProcessGetProfile(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipGetProfile"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if ((msgTran.AryData[0] >= 0xd0) && (msgTran.AryData[0] <= 0xd3))
                {
                    m_curSetting.btReadId = msgTran.ReadId;
                    m_curSetting.btLinkProfile = msgTran.AryData[0];

                    RefreshReadSetting(CMD.cmd_get_rf_link_profile);
                    WriteLog(lrtxtLog, strCmd, 0);
                    return;
                }
                else
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void ProcessSetReaderAntGroup(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0} {1}", FindResource("tipSetReaderAntGroup"), tagdb.AntGroup);
            string strErrorCode;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x10)
                {
                    m_curSetting.btReadId = msgTran.ReadId;
                    WriteLog(lrtxtLog, strCmd, 0);
                    if (m_setWorkAnt)
                    {
                        BeginInvoke(new ThreadStart(delegate () {
                            m_setWorkAnt = false;
                            byte btWorkAntenna = (byte)cmbWorkAnt.SelectedIndex;
                            if (btWorkAntenna >= 0x08)
                                btWorkAntenna = (byte)((btWorkAntenna & 0xFF) - 0x08);
                            reader.SetWorkAntenna(m_curSetting.btReadId, btWorkAntenna);
                            m_curSetting.btWorkAntenna = btWorkAntenna;
                            return;
                        }));
                    }
                    if (m_getOutputPower)
                    {
                        reader.GetOutputPower(m_curSetting.btReadId);
                        return;
                    }
                    if (m_setOutputPower)
                    {
                        if (tagdb.AntGroup == 0x00)
                        {
                            if (tb_outputpower_1.Text.Length != 0 || tb_outputpower_2.Text.Length != 0 || tb_outputpower_3.Text.Length != 0 || tb_outputpower_4.Text.Length != 0
                               || tb_outputpower_5.Text.Length != 0 || tb_outputpower_6.Text.Length != 0 || tb_outputpower_7.Text.Length != 0 || tb_outputpower_8.Text.Length != 0)
                            {
                                byte[] OutputPower = new byte[8];
                                OutputPower[0] = Convert.ToByte(tb_outputpower_1.Text);
                                OutputPower[1] = Convert.ToByte(tb_outputpower_2.Text);
                                OutputPower[2] = Convert.ToByte(tb_outputpower_3.Text);
                                OutputPower[3] = Convert.ToByte(tb_outputpower_4.Text);
                                OutputPower[4] = Convert.ToByte(tb_outputpower_5.Text);
                                OutputPower[5] = Convert.ToByte(tb_outputpower_6.Text);
                                OutputPower[6] = Convert.ToByte(tb_outputpower_7.Text);
                                OutputPower[7] = Convert.ToByte(tb_outputpower_8.Text);

                                reader.SetOutputPower(m_curSetting.btReadId, OutputPower);
                            }
                        }
                        else
                        {
                            if (tb_outputpower_9.Text.Length != 0 || tb_outputpower_10.Text.Length != 0 || tb_outputpower_11.Text.Length != 0 || tb_outputpower_12.Text.Length != 0
                               || tb_outputpower_13.Text.Length != 0 || tb_outputpower_14.Text.Length != 0 || tb_outputpower_15.Text.Length != 0 || tb_outputpower_16.Text.Length != 0)
                            {
                                byte[] OutputPower = new byte[8];
                                OutputPower[0] = Convert.ToByte(tb_outputpower_9.Text);
                                OutputPower[1] = Convert.ToByte(tb_outputpower_10.Text);
                                OutputPower[2] = Convert.ToByte(tb_outputpower_11.Text);
                                OutputPower[3] = Convert.ToByte(tb_outputpower_12.Text);
                                OutputPower[4] = Convert.ToByte(tb_outputpower_13.Text);
                                OutputPower[5] = Convert.ToByte(tb_outputpower_14.Text);
                                OutputPower[6] = Convert.ToByte(tb_outputpower_15.Text);
                                OutputPower[7] = Convert.ToByte(tb_outputpower_16.Text);

                                reader.SetOutputPower(m_curSetting.btReadId, OutputPower);
                            }
                        }
                        return;
                    }
                    if (doingRealInv)
                    {
                        reader.SetWorkAntenna(m_curSetting.btReadId, m_curSetting.btWorkAntenna);
                    }
                    else if (doingFastInv)
                    {
                        cmdFastInventorySend(useAntG1);
                    }
                    else if (doingBufferInv)
                    {
                        reader.SetWorkAntenna(m_curSetting.btReadId, m_curSetting.btWorkAntenna);
                    }
                    return;
                }
                else
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private byte getParamSelectFlag()
        {
            for (int i = 0; i < selectFlagArr.Length; i++)
            {
                if (selectFlagArr[i].Checked)
                    return (byte)i;
            }
            return 0x00;//default SL00
        }

        private byte getParamTarget()
        {
            for (int i = 0; i < targetArr.Length; i++)
            {
                if (targetArr[i].Checked)
                    return (byte)i;
            }
            return 0x00;//default target A
        }

        private byte getParamSession()
        {
            for (int i = 0; i < sessionArr.Length; i++)
            {
                if (sessionArr[i].Checked)
                    return (byte)i;
            }
            return 0x01;//default S1
        }

        private void ProcessGetReaderAntGroup(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipGetReaderAntGroup"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x00 || msgTran.AryData[0] == 0x01)
                {
                    m_curSetting.btReadId = msgTran.ReadId;
                    tagdb.AntGroup = msgTran.AryData[0];
                    if (tagdb.AntGroup == 0x01)
                    {
                        BeginInvoke(new ThreadStart(delegate () {
                            if (!antType16.Checked)
                                antType16.Checked = true;
                        }));
                    }
                    if (m_getWorkAnt)
                    {
                        m_getWorkAnt = false;
                        reader.GetWorkAntenna(m_curSetting.btReadId);
                    }
                    WriteLog(lrtxtLog, strCmd, 0);
                    return;
                }
                else
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void ProcessGetReaderIdentifier(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipGetReaderIdentifier"));
            string strErrorCode = string.Empty;
            short i;
            string readerIdentifier = "";

            if (msgTran.AryData.Length == 12)
            {
                m_curSetting.btReadId = msgTran.ReadId;
                for (i = 0; i < 12; i++)
                {
                    readerIdentifier = readerIdentifier + string.Format("{0:X2}", msgTran.AryData[i]) + " ";


                }
                m_curSetting.btReaderIdentifier = readerIdentifier;
                RefreshReadSetting(CMD.cmd_get_reader_identifier);

                WriteLog(lrtxtLog, strCmd, 0);
                return;
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void ProcessGetImpedanceMatch(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipGetImpedanceMatch"));
            string strErrorCode = string.Empty;


            if (msgTran.AryData.Length == 1)
            {
                m_curSetting.btReadId = msgTran.ReadId;

                m_curSetting.btAntImpedance = msgTran.AryData[0];
                RefreshReadSetting(CMD.cmd_get_rf_port_return_loss);

                WriteLog(lrtxtLog, strCmd, 0);
                return;
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void ProcessSetReaderIdentifier(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipSetImpedanceMatch"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x10)
                {
                    m_curSetting.btReadId = msgTran.ReadId;
                    WriteLog(lrtxtLog, strCmd, 0);
                    return;
                }
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void btnSetAntDetector_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbAntDectector.Text.Length != 0)
                {
                    reader.SetAntDetector(m_curSetting.btReadId, Convert.ToByte(tbAntDectector.Text));
                    m_curSetting.btAntDetector = Convert.ToByte(tbAntDectector.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("SetAntDetector {0}", ex.Message));
            }
        }

        private void ProcessSetAntDetector(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipSetAntDetector"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x10)
                {
                    m_curSetting.btReadId = msgTran.ReadId;
                    WriteLog(lrtxtLog, strCmd, 0);

                    return;
                }
                else
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void ProcessFastSwitch(Reader.MessageTran msgTran)
        {
 
            string strCmd = string.Format("{0}", FindResource("tipFastSwitch"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
               
                WriteLog(lrtxtLog, strLog, 1);
                
                if (isFastInv)
                {
                    FastInventory();
                }
                else
                {
                    stopFastInv();
                }
            }
            else if (msgTran.AryData.Length == 2)
            {
                strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[1]);
                string strLog = string.Format("{0}{1}: {2} ant{3}", strCmd, FindResource("FailedCause"), strErrorCode, (msgTran.AryData[0] + 1));
                WriteLog(lrtxtLog, strLog, 1);
            }
            else if (msgTran.AryData.Length == 7)
            {
                if (doingFastInv)
                {
                    WriteLog(lrtxtLog, strCmd, 0);
                    
                    BeginInvoke(new ThreadStart(delegate () {
                        tagdb.UpdateCmd8AExecuteSuccess(msgTran.AryData);
                        led_cmd_readrate.Text = tagdb.CmdReadRate.ToString();
                        led_total_tagreads.Text = tagdb.TotalTagCounts.ToString();
                        txtCmdTagCount.Text = tagdb.CmdTotalRead.ToString();
                        led_cmd_execute_duration.Text = tagdb.CommandDuration.ToString();
                        ledFast_total_execute_time.Text = FormatLongToTimeStr(tagdb.TotalCommandTime);
                    }));

                    if (isFastInv)
                    {
                        FastInventory();
                    }
                    else
                    {
                        stopFastInv();
                    }
                }
            }
            else
            {
                if (doingFastInv)
                {
                    parseInvTag(cb_use_Phase.Checked, msgTran.AryData, 0x8a);
                }
            }
        }

        private void stopFastInv()
        {
            doingFastInv = false;
            Inventorying = false;
            // real stop fastInv
            if (!useAntG1)
            {
                // reswitch to G1 
                cmdSwitchAntG1();
            }

            BeginInvoke(new ThreadStart(delegate {
                setInvStoppedStatus();
            }));
        }

        private void stopRealInv()
        {
            doingRealInv = false;
            Inventorying = false;
            // real stop realtimeInv
            if (!useAntG1)
            {
                // reswitch to G1 
                cmdSwitchAntG1();
            }

            BeginInvoke(new ThreadStart(delegate {
                setInvStoppedStatus();
            }));
        }

        private void stopBufferInv()
        {
            doingBufferInv = false;
            Inventorying = false;
            // real stop bufferInv
            if (!useAntG1)
            {
                // reswitch to G1 
                cmdSwitchAntG1();
            }

            BeginInvoke(new ThreadStart(delegate {
                setInvStoppedStatus();
            }));
        }

        private void ProcessInventoryReal(Reader.MessageTran msgTran)
        {
            string strCmd = "";
            if (msgTran.Cmd == 0x89)
            {
                strCmd = string.Format("{0}", FindResource("tipInventoryReal"));
            }
            if (msgTran.Cmd == 0x8B)
            {
                strCmd = string.Format("{0}", FindResource("tipCustomizeTargetSessionInventory"));
            }
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
                WriteLog(lrtxtLog, strLog, 1);

                if (m_FastExeCount != -1)
                {
                    if (m_FastExeCount > 1)
                    {
                        m_FastExeCount--;
                    }
                    else
                    {
                        isRealInv = false;
                    }
                }

                if (!isRealInv)
                {
                    stopRealInv();
                }
                if (doingRealInv)
                    RunLoopInventroy();

            }
            else if (msgTran.AryData.Length == 7)
            {
                WriteLog(lrtxtLog, strCmd, 0);
                BeginInvoke(new ThreadStart(delegate () {
                    tagdb.UpdateCmd89ExecuteSuccess(msgTran.AryData);
                    led_cmd_readrate.Text = tagdb.CmdReadRate.ToString();
                    led_cmd_execute_duration.Text = tagdb.CommandDuration.ToString();
                    ledFast_total_execute_time.Text = FormatLongToTimeStr(tagdb.TotalCommandTime);
                    led_total_tagreads.Text = tagdb.TotalTagCounts.ToString();
                    txtCmdTagCount.Text = tagdb.CmdTotalRead.ToString();
                }));

                if (m_FastExeCount != -1)
                {
                    if (m_FastExeCount > 1)
                    {
                        m_FastExeCount--;
                    }
                    else
                    {
                        isRealInv = false;
                    }
                }

                if (!isRealInv)
                {
                    stopRealInv();
                }
                if (doingRealInv)
                    RunLoopInventroy();
            }
            else
            {
                parseInvTag(cb_use_Phase.Checked, msgTran.AryData, 0x89);
            }
        }

        private void ProcessInventory(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipInventory"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 9)
            {
                WriteLog(lrtxtLog, strCmd, 0);
                BeginInvoke(new ThreadStart(delegate () {
                    tagdb.UpdateCmd80ExecuteSuccess(msgTran.AryData);
                    led_total_tagreads.Text = tagdb.TotalTagCounts.ToString();
                    txtCmdTagCount.Text = tagdb.CmdTotalRead.ToString();
                    led_cmd_execute_duration.Text = CalculateExecTime().ToString();
                    led_cmd_readrate.Text = tagdb.CmdReadRate.ToString();
                    led_totalread_count.Text = tagdb.TotalReadCounts.ToString();

                }));

                if (m_FastExeCount != -1)
                {
                    if (m_FastExeCount > 1)
                    {
                        m_FastExeCount--;
                    }
                    else
                    {
                        isBufferInv = false;
                    }
                }

                if (!isBufferInv)
                {
                    stopBufferInv();
                }
                if (doingBufferInv)
                    RunLoopInventroy();
                return;
            }
            else if (msgTran.AryData.Length == 1)
            {
                strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);

            if (m_FastExeCount != -1)
            {
                if (m_FastExeCount > 1)
                {
                    m_FastExeCount--;
                }
                else
                {
                    isBufferInv = false;
                }
            }

            if (!isBufferInv)
            {
                stopBufferInv();
            }
            if (doingBufferInv)
                RunLoopInventroy();
        }

        private void SetMaxMinRSSI(int nRSSI)
        {
            if (tagdb.MinRSSI == 0 && tagdb.MinRSSI == 0)
            {
                tagdb.MaxRSSI = nRSSI;
                tagdb.MinRSSI = nRSSI;
            }
            else
            {
                if (tagdb.MaxRSSI < nRSSI)
                {
                    tagdb.MaxRSSI = nRSSI;
                }

                if (tagdb.MinRSSI > nRSSI)
                {
                    tagdb.MinRSSI = nRSSI;
                }
            }
        }

        private void ProcessGetInventoryBuffer(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipGetInventoryBuffer"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
                WriteLog(lrtxtLog, strLog, 1);
                stopGetInventoryBuffer(false);
            }
            else
            {
                WriteLog(lrtxtLog, strCmd, 0);
                parseInvTag(false, msgTran.AryData, 0x90);
            }
        }

        private void ProcessGetAndResetInventoryBuffer(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipGetAndResetInventoryBuffer"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);
                WriteLog(lrtxtLog, strLog, 1);
                stopGetInventoryBuffer(true);
            }
            else
            {
                WriteLog(lrtxtLog, strCmd, 0);
                parseInvTag(false, msgTran.AryData, 0x91);
            }
        }

        private void stopGetInventoryBuffer(bool clearBuffer)
        {
            BeginInvoke(new ThreadStart(delegate () {
                lock (tagdb)
                {
                    tagbufferCount = 0;
                    needGetBuffer = false;
                    if (clearBuffer)
                    {
                        btnGetAndClearBuffer.Text = FindResource("GetAndClearBuffer");
                    }
                    else
                    {
                        btnGetBuffer.Text = FindResource("GetBuffer");
                    }
                    dispatcherTimer.Stop();
                    readratePerSecond.Stop();
                    elapsedTime = CalculateElapsedTime();

                    tagdb.Repaint();
                }
            }));
        }

        private void btnGetInventoryBufferTagCount_Click(object sender, EventArgs e)
        {
            reader.GetInventoryBufferTagCount(m_curSetting.btReadId);
        }

        private void ProcessGetInventoryBufferTagCount(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipGetInventoryBufferTagCount"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 2)
            {
                int nTagCount = Convert.ToInt32(msgTran.AryData[0]) * 256 + Convert.ToInt32(msgTran.AryData[1]);

                string strLog1 = strCmd + " " + nTagCount;
                WriteLog(lrtxtLog, strLog1, 0);
                return;
            }
            else if (msgTran.AryData.Length == 1)
            {
                strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);

            WriteLog(lrtxtLog, strLog, 1);
        }

        private void btnResetInventoryBuffer_Click(object sender, EventArgs e)
        {
            reader.ResetInventoryBuffer(m_curSetting.btReadId);
        }

        private void ProcessResetInventoryBuffer(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipResetInventoryBuffer"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x10)
                {
                    WriteLog(lrtxtLog, strCmd, 0);
                    return;
                }
                else
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);

            WriteLog(lrtxtLog, strLog, 1);
        }

        private void ProcessGetAccessEpcMatch(Reader.MessageTran msgTran)
        {
            // Head	Len	Address	Cmd	Status	EpcLen	EPC	Check
            // 0xA0             0x86
            string strCmd = string.Format("{0}", FindResource("tipGetAccessEpcMatch"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x01)
                {
                    WriteLog(lrtxtLog, string.Format("{0} {1}", strCmd, FindResource("tipHaveNoMatch")), 0);
                    return;
                }
                else
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                if (msgTran.AryData[0] == 0x00)
                {
                    BeginInvoke(new ThreadStart(delegate () {
                        txtAccessEpcMatch.Text = ReaderUtils.ByteArrayToString(msgTran.AryData, 2, Convert.ToInt32(msgTran.AryData[1]));
                    }));
                    WriteLog(lrtxtLog, string.Format("{0} ({1}){2}",
                        strCmd,
                        Convert.ToInt32(msgTran.AryData[2]),
                        ReaderUtils.ByteArrayToString(msgTran.AryData, 2, Convert.ToInt32(msgTran.AryData[1]))), 0);
                    return;
                }
                else
                {
                    strErrorCode = string.Format("{0}", FindResource("UnknowError"));
                }
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);

            WriteLog(lrtxtLog, strLog, 1);
        }

        private void btnSetAccessEpcMatch_Click(object sender, EventArgs e)
        {
            if (cmbSetAccessEpcMatch.Text.Trim().Equals(""))
            {
                MessageBox.Show(FindResource("tipHaveNotYetSelectedTag"));
                return;
            }
            byte[] btAryEpc = ReaderUtils.FromHex(cmbSetAccessEpcMatch.Text.Replace(" ", ""));

            txtAccessEpcMatch.Text = cmbSetAccessEpcMatch.Text;
            reader.SetAccessEpcMatch(m_curSetting.btReadId, 0x00, Convert.ToByte(btAryEpc.Length), btAryEpc);
        }

        private void ProcessSetAccessEpcMatch(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipSetAccessEpcMatch"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x10)
                {
                    WriteLog(lrtxtLog, strCmd, 0);
                    return;
                }
                else
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
            }

            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);

            WriteLog(lrtxtLog, strLog, 1);
        }

        private void btnReadTag_Click(object sender, EventArgs e)
        {
            try
            {
                byte btMemBank = getMembank();
                byte btWordAdd = Convert.ToByte(tb_startWord.Text);
                byte btWordCnt = Convert.ToByte(tb_wordLen.Text);
                if (btWordCnt <= 0)
                {
                    MessageBox.Show("Read word must large than 1");
                    return;
                }
                byte[] accessPw = ReaderUtils.FromHex(hexTb_accessPw.Text.Replace(" ", ""));

                tagOpDb.Clear();
                reader.ReadTag(m_curSetting.btReadId, btMemBank, btWordAdd, btWordCnt, accessPw);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("ReadTag {0}", ex.Message));
            }
        }

        private byte getMembank()
        {
            if (rdbReserved.Checked)
            {
                return 0x00;
            }
            else if (rdbEpc.Checked)
            {
                return 0x01;
            }
            else if (rdbTid.Checked)
            {
                return 0x02;
            }
            else if (rdbUser.Checked)
            {
                return 0x03;
            }
            else
            {
                MessageBox.Show(FindResource("tipSelectMemBank"));
                return 0x00;
            }
        }

        private void ProcessReadTag(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipReadTag"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);

                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                if (johar_cb.Checked)
                {
                    parseJoharRead(msgTran.AryTranData);
                }
                else
                {
                    AddTagToTagOpDb(msgTran);

                    WriteLog(lrtxtLog, strCmd, 0);
                }
            }
        }

        private void btnWriteTag_Click(object sender, EventArgs e)
        {
            try
            {
                byte btMemBank = getMembank();
                byte btWordAdd = Convert.ToByte(tb_startWord.Text);
                byte btWordCnt = 0;

                byte[] accessPw = ReaderUtils.FromHex(hexTb_accessPw.Text.Replace(" ", ""));
                byte[] writeData = ReaderUtils.FromHex(hexTb_WriteData.Text.Replace(" ", ""));
                btWordCnt = Convert.ToByte(writeData.Length / 2 + writeData.Length % 2);

                tb_wordLen.Text = btWordCnt.ToString();

                tagOpDb.Clear();
                if (radio_btnWrite.Checked)
                {
                    WriteLog(lrtxtLog, FindResource("tipWriteTag"), 0);
                    reader.WriteTag(m_curSetting.btReadId, accessPw, btMemBank, btWordAdd, btWordCnt, writeData);
                }
                if (radio_btnBlockWrite.Checked)
                {
                    WriteLog(lrtxtLog, FindResource("tipBlockWrite"), 0);
                    reader.BlockWrite(m_curSetting.btReadId, accessPw, btMemBank, btWordAdd, btWordCnt, writeData);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(string.Format("BlockWrite {0}", ex.Message));
            }
        }

        private void ProcessWriteTag(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", (msgTran.Cmd == 0x82 ? FindResource("tipWriteTag") : FindResource("tipBlockWrite")));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);

                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                int nLen = msgTran.AryData.Length;

                if (msgTran.AryData[nLen - 3] != 0x10)
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[nLen - 3]);
                    string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);

                    WriteLog(lrtxtLog, strLog, 1);
                    return;
                }
                WriteTagCount++;

                AddTagToTagOpDb(msgTran);

                WriteLog(lrtxtLog, string.Format("{0} success", strCmd), 0);
                if (WriteTagCount == (msgTran.AryData[0] * 256 + msgTran.AryData[1]))
                {
                    WriteTagCount = 0;
                }
            }
        }

        private void btnLockTag_Click(object sender, EventArgs e)
        {
            byte btMemBank = 0x00;
            byte btLockType = 0x00;

            if (rdbAccessPwd.Checked)
            {
                btMemBank = 0x04;
            }
            else if (rdbKillPwd.Checked)
            {
                btMemBank = 0x05;
            }
            else if (rdbEpcMermory.Checked)
            {
                btMemBank = 0x03;
            }
            else if (rdbTidMemory.Checked)
            {
                btMemBank = 0x02;
            }
            else if (rdbUserMemory.Checked)
            {
                btMemBank = 0x01;
            }
            else
            {
                MessageBox.Show(FindResource("tipSelectLockBank"));
                return;
            }

            if (rdbFree.Checked)
            {
                btLockType = 0x00;
            }
            else if (rdbFreeEver.Checked)
            {
                btLockType = 0x02;
            }
            else if (rdbLock.Checked)
            {
                btLockType = 0x01;
            }
            else if (rdbLockEver.Checked)
            {
                btLockType = 0x03;
            }
            else
            {
                MessageBox.Show(FindResource("tipSelectLockType"));
                return;
            }

            string[] reslut = ReaderUtils.StringToStringArray(htxtLockPwd.Text.ToUpper(), 2);

            if (reslut == null)
            {
                MessageBox.Show(FindResource("tipEmptyString"));
                return;
            }
            else if (reslut.GetLength(0) < 4)
            {
                MessageBox.Show(FindResource("tipFourBytesAtLeast"));
                return;
            }

            byte[] btAryPwd = ReaderUtils.StringArrayToByteArray(reslut, 4);

            tagOpDb.Clear();
            reader.LockTag(m_curSetting.btReadId, btAryPwd, btMemBank, btLockType);
        }

        private void ProcessLockTag(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipLockTag"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);

                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                int nLen = msgTran.AryData.Length;

                if (msgTran.AryData[nLen - 3] != 0x10)
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[nLen - 3]);
                    string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);

                    WriteLog(lrtxtLog, strLog, 1);
                    return;
                }

                AddTagToTagOpDb(msgTran);

                WriteLog(lrtxtLog, strCmd, 0);
            }
        }

        private void btnKillTag_Click(object sender, EventArgs e)
        {
            string[] reslut = ReaderUtils.StringToStringArray(htxtKillPwd.Text.ToUpper(), 2);

            if (reslut == null)
            {
                MessageBox.Show(FindResource("tipEmptyString"));
                return;
            }
            else if (reslut.GetLength(0) < 4)
            {
                MessageBox.Show(FindResource("tipFourBytesAtLeast"));
                return;
            }

            byte[] btAryPwd = ReaderUtils.StringArrayToByteArray(reslut, 4);

            tagOpDb.Clear();
            reader.KillTag(m_curSetting.btReadId, btAryPwd);
        }

        private void ProcessKillTag(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipKillTag"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);

                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                int nLen = msgTran.AryData.Length;
                int nEpcLen = Convert.ToInt32(msgTran.AryData[2]) - 4;

                if (msgTran.AryData[nLen - 3] != 0x10)
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[nLen - 3]);
                    string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);

                    WriteLog(lrtxtLog, strLog, 1);
                    return;
                }

                AddTagToTagOpDb(msgTran);

                WriteLog(lrtxtLog, strCmd, 0);
            }
        }

        private void AddTagToTagOpDb(MessageTran msgTran)
        {
            BeginInvoke(new ThreadStart(delegate () {
                tagOpDb.Add(new Tag(msgTran.AryData, msgTran.Cmd, tagdb.AntGroup));
            }));
        }

        private void btnInventoryISO18000_Click(object sender, EventArgs e)
        {
            if (Inventorying)
            {
                MessageBox.Show(FindResource("Inventorying"));
                return;
            }
            if (m_bContinue)
            {
                m_bContinue = false;
                btnInventoryISO18000.BackColor = Color.WhiteSmoke;
                btnInventoryISO18000.ForeColor = Color.Indigo;
                btnInventoryISO18000.Text = FindResource("StartInventory");
            }
            else
            {
                //判断EPC盘存是否正在进行
                if (Inventorying)
                {
                    if (MessageBox.Show("EPC C1G2 tag is in inventory, have you stopped?", "Tips", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        return;
                    }
                }

                m_curOperateTagISO18000Buffer.ClearBuffer();
                ltvTagISO18000.Items.Clear();
                m_bContinue = true;
                btnInventoryISO18000.BackColor = Color.Indigo;
                btnInventoryISO18000.ForeColor = Color.White;
                btnInventoryISO18000.Text = FindResource("StopInventory");

                string strCmd = string.Format("{0} start", FindResource("tipInventory6B"));
                WriteLog(lrtxtLog, strCmd, 0);

                reader.InventoryISO18000(m_curSetting.btReadId);
            }
        }

        private void ProcessInventoryISO18000(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipInventory6B"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] != 0xFF)
                {
                    strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                    string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);

                    WriteLog(lrtxtLog, strLog, 1);
                }
            }
            else if (msgTran.AryData.Length == 9)
            {
                string strAntID = ReaderUtils.ByteArrayToString(msgTran.AryData, 0, 1);
                string strUID = ReaderUtils.ByteArrayToString(msgTran.AryData, 1, 8);

                //Add the list of saved labels, add the record if there is no original inventory, otherwise add 1 to the number of label inventories
                DataRow[] drs = m_curOperateTagISO18000Buffer.dtTagTable.Select(string.Format("UID = '{0}'", strUID));
                if (drs.Length == 0)
                {
                    DataRow row = m_curOperateTagISO18000Buffer.dtTagTable.NewRow();
                    row[0] = strAntID;
                    row[1] = strUID;
                    row[2] = "1";
                    m_curOperateTagISO18000Buffer.dtTagTable.Rows.Add(row);
                    m_curOperateTagISO18000Buffer.dtTagTable.AcceptChanges();
                }
                else
                {
                    DataRow row = drs[0];
                    row.BeginEdit();
                    row[2] = (Convert.ToInt32(row[2]) + 1).ToString();
                    m_curOperateTagISO18000Buffer.dtTagTable.AcceptChanges();
                }

            }
            else if (msgTran.AryData.Length == 2)
            {
                m_curOperateTagISO18000Buffer.nTagCnt = Convert.ToInt32(msgTran.AryData[1]);
                RefreshISO18000(msgTran.Cmd);

                //WriteLog(lrtxtLog, strCmd, 0);
            }
            else
            {
                strErrorCode = string.Format("{0}", FindResource("UnknowError"));
                string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);

                WriteLog(lrtxtLog, strLog, 1);
            }
        }

        private void btnReadTagISO18000_Click(object sender, EventArgs e)
        {
            if (htxtReadUID.Text.Length == 0)
            {
                MessageBox.Show("please input UID");
                return;
            }
            if (htxtReadStartAdd.Text.Length == 0)
            {
                MessageBox.Show("please input start addr");
                return;
            }
            if (txtReadLength.Text.Length == 0)
            {
                MessageBox.Show("please input read length");
                return;
            }

            string[] reslut = ReaderUtils.StringToStringArray(htxtReadUID.Text.ToUpper(), 2);

            if (reslut == null)
            {
                MessageBox.Show(FindResource("tipEmptyString"));
                return;
            }
            else if (reslut.GetLength(0) < 4)
            {
                MessageBox.Show(FindResource("tipEightBytesAtLeast"));
                return;
            }
            byte[] btAryUID = ReaderUtils.StringArrayToByteArray(reslut, 8);

            reader.ReadTagISO18000(m_curSetting.btReadId, btAryUID, Convert.ToByte(htxtReadStartAdd.Text, 16), Convert.ToByte(txtReadLength.Text, 16));
        }

        private void ProcessReadTagISO18000(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipRead6BTag"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);

                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strAntID = ReaderUtils.ByteArrayToString(msgTran.AryData, 0, 1);
                string strData = ReaderUtils.ByteArrayToString(msgTran.AryData, 1, msgTran.AryData.Length - 1);

                m_curOperateTagISO18000Buffer.btAntId = Convert.ToByte(strAntID);
                m_curOperateTagISO18000Buffer.strReadData = strData;

                RefreshISO18000(msgTran.Cmd);

                WriteLog(lrtxtLog, strCmd, 0);
            }
        }

        private void btnWriteTagISO18000_Click(object sender, EventArgs e)
        {
            try
            {
                m_nLoopedTimes = 0;
                if (txtLoop.Text.Length == 0)
                    m_nLoopTimes = 0;
                else
                    m_nLoopTimes = Convert.ToInt32(txtLoop.Text);

                WriteTagISO18000();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("WriteTagISO18000 {0}", ex.Message));
            }
        }

        private void WriteTagISO18000()
        {
            if (htxtReadUID.Text.Length == 0)
            {
                MessageBox.Show("please input UID");
                return;
            }
            if (htxtWriteStartAdd.Text.Length == 0)
            {
                MessageBox.Show("please input start addr");
                return;
            }
            if (htxtWriteData18000.Text.Length == 0)
            {
                MessageBox.Show("please input write length");
                return;
            }

            string[] reslut = ReaderUtils.StringToStringArray(htxtReadUID.Text.ToUpper(), 2);

            if (reslut == null)
            {
                MessageBox.Show(FindResource("tipEmptyString"));
                return;
            }
            else if (reslut.GetLength(0) < 4)
            {
                MessageBox.Show(FindResource("tipEightBytesAtLeast"));
                return;
            }
            byte[] btAryUID = ReaderUtils.StringArrayToByteArray(reslut, 8);

            byte btStartAdd = Convert.ToByte(htxtWriteStartAdd.Text, 16);

            //string[] reslut = ReaderUtils.StringToStringArray(htxtWriteData18000.Text.ToUpper(), 2);
            string strTemp = cleanString(htxtWriteData18000.Text);
            reslut = ReaderUtils.StringToStringArray(strTemp.ToUpper(), 2);

            if (reslut == null)
            {
                MessageBox.Show(FindResource("tipEmptyString"));
                return;
            }

            byte[] btAryData = ReaderUtils.StringArrayToByteArray(reslut, reslut.Length);

            //byte btLength = Convert.ToByte(txtWriteLength.Text, 16);
            byte btLength = Convert.ToByte(reslut.Length);
            txtWriteLength.Text = String.Format("{0:X}", btLength);
            m_nBytes = reslut.Length;

            reader.WriteTagISO18000(m_curSetting.btReadId, btAryUID, btStartAdd, btLength, btAryData);
        }

        private string cleanString(string newStr)
        {
            string tempStr = newStr.Replace('\r', ' ');
            return tempStr.Replace('\n', ' ');
        }

        private void ProcessWriteTagISO18000(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipWrite6BTag"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);

                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                //string strAntID = ReaderUtils.ByteArrayToString(msgTran.AryData, 0, 1);
                //string strCnt = ReaderUtils.ByteArrayToString(msgTran.AryData, 1, 1);

                m_curOperateTagISO18000Buffer.btAntId = msgTran.AryData[0];
                m_curOperateTagISO18000Buffer.btWriteLength = msgTran.AryData[1];

                //RefreshISO18000(msgTran.Cmd);
                string strLength = msgTran.AryData[1].ToString();
                string strLog = string.Format("{0} successful write {1} Bytes", strCmd, strLength);
                WriteLog(lrtxtLog, strLog, 0);
                RunLoopISO18000(Convert.ToInt32(msgTran.AryData[1]));
            }
        }

        private void btnLockTagISO18000_Click(object sender, EventArgs e)
        {
            if (htxtReadUID.Text.Length == 0)
            {
                MessageBox.Show("please input UID");
                return;
            }
            if (htxtLockAdd.Text.Length == 0)
            {
                MessageBox.Show("please input lock addr");
                return;
            }

            if (MessageBox.Show("Are you sure you have permanent write protection for this address?", "Tips", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
            {
                return;
            }

            string[] reslut = ReaderUtils.StringToStringArray(htxtReadUID.Text.ToUpper(), 2);

            if (reslut == null)
            {
                MessageBox.Show(FindResource("tipEmptyString"));
                return;
            }
            else if (reslut.GetLength(0) < 4)
            {
                MessageBox.Show(FindResource("tipEightBytesAtLeast"));
                return;
            }
            byte[] btAryUID = ReaderUtils.StringArrayToByteArray(reslut, 8);

            byte btStartAdd = Convert.ToByte(htxtLockAdd.Text, 16);

            reader.LockTagISO18000(m_curSetting.btReadId, btAryUID, btStartAdd);
        }

        private void ProcessLockTagISO18000(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipLock6BTag"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);

                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                //string strAntID = ReaderUtils.ByteArrayToString(msgTran.AryData, 0, 1);
                //string strStatus = ReaderUtils.ByteArrayToString(msgTran.AryData, 1, 1);

                m_curOperateTagISO18000Buffer.btAntId = msgTran.AryData[0];
                m_curOperateTagISO18000Buffer.btStatus = msgTran.AryData[1];

                //RefreshISO18000(msgTran.Cmd);
                string strLog = string.Empty;
                switch (msgTran.AryData[1])
                {
                    case 0x00:
                        strLog = strCmd + ": " + "Successful lock";
                        break;
                    case 0xFE:
                        strLog = strCmd + ": " + "Already locked";
                        break;
                    case 0xFF:
                        strLog = strCmd + ": " + "Unable to lock";
                        break;
                    default:
                        break;
                }

                WriteLog(lrtxtLog, strLog, 0);

            }
        }

        private void btnQueryTagISO18000_Click(object sender, EventArgs e)
        {
            if (htxtReadUID.Text.Length == 0)
            {
                MessageBox.Show("please input UID");
                return;
            }
            if (htxtQueryAdd.Text.Length == 0)
            {
                MessageBox.Show("please input query addr");
                return;
            }

            string[] reslut = ReaderUtils.StringToStringArray(htxtReadUID.Text.ToUpper(), 2);

            if (reslut == null)
            {
                MessageBox.Show(FindResource("tipEmptyString"));
                return;
            }
            else if (reslut.GetLength(0) < 4)
            {
                MessageBox.Show(FindResource("tipEightBytesAtLeast"));
                return;
            }
            byte[] btAryUID = ReaderUtils.StringArrayToByteArray(reslut, 8);

            byte btStartAdd = Convert.ToByte(htxtQueryAdd.Text, 16);

            reader.QueryTagISO18000(m_curSetting.btReadId, btAryUID, btStartAdd);
        }

        private void ProcessQueryISO18000(Reader.MessageTran msgTran)
        {
            string strCmd = string.Format("{0}", FindResource("tipQuery6BTag"));
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                strErrorCode = ReaderUtils.FormatErrorCode(msgTran.AryData[0]);
                string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("FailedCause"), strErrorCode);

                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                //string strAntID = ReaderUtils.ByteArrayToString(msgTran.AryData, 0, 1);
                //string strStatus = ReaderUtils.ByteArrayToString(msgTran.AryData, 1, 1);

                m_curOperateTagISO18000Buffer.btAntId = msgTran.AryData[0];
                m_curOperateTagISO18000Buffer.btStatus = msgTran.AryData[1];

                RefreshISO18000(msgTran.Cmd);

                WriteLog(lrtxtLog, strCmd, 0);
            }
        }

        private void htxtSendData_Leave(object sender, EventArgs e)
        {
            if (htxtSendData.TextLength == 0)
            {
                return;
            }

            string[] reslut = ReaderUtils.StringToStringArray(htxtSendData.Text.ToUpper(), 2);
            byte[] btArySendData = ReaderUtils.StringArrayToByteArray(reslut, reslut.Length);

            byte btCheckData = ReaderUtils.CheckSum(btArySendData, 0, btArySendData.Length);
            htxtCheckData.Text = string.Format(" {0:X2}", btCheckData);
        }

        private void btnSendData_Click(object sender, EventArgs e)
        {
            if (htxtSendData.TextLength == 0)
            {
                return;
            }

            string strData = htxtSendData.Text + htxtCheckData.Text;

            string[] reslut = ReaderUtils.StringToStringArray(strData.ToUpper(), 2);
            byte[] btArySendData = ReaderUtils.StringArrayToByteArray(reslut, reslut.Length);

            reader.SendMessage(btArySendData);
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            htxtSendData.Text = "";
            htxtCheckData.Text = "";
        }

        private void lrtxtDataTran_DoubleClick(object sender, EventArgs e)
        {
            lrtxtDataTran.Text = "";
        }

        private void lrtxtLog_DoubleClick(object sender, EventArgs e)
        {
            lrtxtLog.Text = "";
        }

        private void tabCtrMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region NetPort
            if (!tabCtrMain.SelectedTab.Name.Equals("net_configure_tabPage"))
            {
                StopNetPort();
            }
            else
            {
                btnSearchNetCard_Click(null, null);
            }
            #endregion //NetPort

            #region Johar
            if (tabCtrMain.SelectedTab.Name.Equals("sensorTags_tabPage"))
            {
                johar_cb.Enabled = false;
                johar_session_s0_rb.Checked = true;
                johar_target_A_rb.Checked = true;
                johar_readmode_mode3.Checked = true;
                johar_cmd_interval_cb.SelectedIndex = 2;

                if (johardb == null)
                {
                    johardb = new JoharTagDB();
                    johar_tag_dgv.DataSource = johardb.TagList;
                }
            }
            else
            {
                if (johar_use_btn.Text.Equals(FindResource("Disable")))
                {
                    johar_use_btn.Text = FindResource("Enable");
                    enableReadJohar(false);
                    johar_cb.Checked = false;
                    clearSelect();
                }
            }
            #endregion Johar

            if (m_bLockTab)
            {
                tabCtrMain.SelectTab(1);
            }
            int nIndex = tabCtrMain.SelectedIndex;

            if (nIndex == 2)
            {
                lrtxtDataTran.Select(lrtxtDataTran.TextLength, 0);
                lrtxtDataTran.ScrollToCaret();
            }
        }

        private void txtTcpPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)ConsoleKey.Backspace)
            {
                e.Handled = false;
            }
        }

        private void txtOutputPower_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)ConsoleKey.Backspace)
            {
                e.Handled = false;
            }
        }

        private void txtChannel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)ConsoleKey.Backspace)
            {
                e.Handled = false;
            }
        }

        private void txtWordAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)ConsoleKey.Backspace)
            {
                e.Handled = false;
            }
        }

        private void txtWordCnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)ConsoleKey.Backspace)
            {
                e.Handled = false;
            }
        }

        private void cmbSetAccessEpcMatch_DropDown(object sender, EventArgs e)
        {
            BeginInvoke(new ThreadStart(delegate () {
                cmbSetAccessEpcMatch.Items.Clear();

                foreach (TagRecord trd in tagdb.TagList)
                {
                    cmbSetAccessEpcMatch.Items.Add(trd.EPC);
                }

                foreach (TagRecord trd in tagOpDb.TagList)
                {
                    if (!cmbSetAccessEpcMatch.Items.Contains(trd.EPC))
                        cmbSetAccessEpcMatch.Items.Add(trd.EPC);
                }
            }));
        }

        private void ltvTagISO18000_DoubleClick(object sender, EventArgs e)
        {
            //if (ltvTagISO18000.SelectedItems.Count == 1)
            //{
            //    ListViewItem item = ltvTagISO18000.SelectedItems[0];
            //    string strUID = item.SubItems[1].Text;
            //    htxtReadUID.Text = strUID;
            //}
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            htxtReadUID.Text = "";
            htxtReadStartAdd.Text = "";
            txtReadLength.Text = "";
            htxtReadData18000.Text = "";
            htxtWriteStartAdd.Text = "";
            txtWriteLength.Text = "";
            htxtWriteData18000.Text = "";
            htxtLockAdd.Text = "";
            htxtQueryAdd.Text = "";
            txtStatus.Text = "";
            txtLoop.Text = "1";
            ltvTagISO18000.Items.Clear();
        }

        private void ltvTagISO18000_Click(object sender, EventArgs e)
        {
            if (ltvTagISO18000.SelectedItems.Count == 1)
            {
                ListViewItem item = ltvTagISO18000.SelectedItems[0];
                string strUID = item.SubItems[1].Text;
                htxtReadUID.Text = strUID;
            }
        }

        private void ckDisplayLog_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDisplayLog.Checked)
            {
                m_bDisplayLog = true;
            }
            else
            {
                m_bDisplayLog = false;
            }
        }

        private void startRealtimeInv()
        {
            int antId = combo_realtime_inv_ants.SelectedIndex;
            if (antId >= 8)
            {
                m_curSetting.btWorkAntenna = (byte)(antId - 8);
                cmdSwitchAntG2();
            }
            else
            {
                useAntG1 = true;
                tagdb.AntGroup = 0x00;
                m_curSetting.btWorkAntenna = (byte)antId;
                reader.SetWorkAntenna(m_curSetting.btReadId, m_curSetting.btWorkAntenna);
            }
        }
        public bool isStartTime = false;
        public async void PlaySoundStart()
        {
            isStartTime = false;
            var myPlayer = new System.Media.SoundPlayer();
            string dir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            // myPlayer.SoundLocation = @"C:\Users\Ryan\Documents\Project TCB\Project 2022\E-Shuttlerun\Main Project\E-Shuttlerun_V.01\3. E-ShuttleDesktop\Track_ShuttleRun_NRP\Track_ShuttleRun\Sound\countdown shuttle run.wav";
            myPlayer.SoundLocation = dir + @"\Sound\Start.wav";
            myPlayer.Play();
            await Task.Delay(5000);
            isStartTime = true;
        }

        public void PlaySoundPutaran1()
        {
            var myPlayer = new System.Media.SoundPlayer();
            string dir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            // myPlayer.SoundLocation = @"C:\Users\Ryan\Documents\Project TCB\Project 2022\E-Shuttlerun\Main Project\E-Shuttlerun_V.01\3. E-ShuttleDesktop\Track_ShuttleRun_NRP\Track_ShuttleRun\Sound\countdown shuttle run.wav";
            myPlayer.SoundLocation = dir + @"\Sound\Putaran1.wav";
            myPlayer.Play();
        }

        public void PlaySoundPutaran2()
        {
            var myPlayer = new System.Media.SoundPlayer();
            string dir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            // myPlayer.SoundLocation = @"C:\Users\Ryan\Documents\Project TCB\Project 2022\E-Shuttlerun\Main Project\E-Shuttlerun_V.01\3. E-ShuttleDesktop\Track_ShuttleRun_NRP\Track_ShuttleRun\Sound\countdown shuttle run.wav";
            myPlayer.SoundLocation = dir + @"\Sound\Putaran2.wav";
            myPlayer.Play();
        }

        public void PlaySoundPutaran3()
        {
            var myPlayer = new System.Media.SoundPlayer();
            string dir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            // myPlayer.SoundLocation = @"C:\Users\Ryan\Documents\Project TCB\Project 2022\E-Shuttlerun\Main Project\E-Shuttlerun_V.01\3. E-ShuttleDesktop\Track_ShuttleRun_NRP\Track_ShuttleRun\Sound\countdown shuttle run.wav";
            myPlayer.SoundLocation = dir + @"\Sound\Putaran3.wav";
            myPlayer.Play();
        }

        public void PlaySoundWrongTrack()
        {
            var myPlayer = new System.Media.SoundPlayer();
            string dir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            // myPlayer.SoundLocation = @"C:\Users\Ryan\Documents\Project TCB\Project 2022\E-Shuttlerun\Main Project\E-Shuttlerun_V.01\3. E-ShuttleDesktop\Track_ShuttleRun_NRP\Track_ShuttleRun\Sound\countdown shuttle run.wav";
            myPlayer.SoundLocation = dir + @"\Sound\wrong track.wav";
            myPlayer.Play();

        }


        private void FastInventory_Click(object sender, EventArgs e)
        {

            if (btnInventory.Text.Equals(FindResource("StartInventory")))
            {
                if (Inventorying)
                {
                    MessageBox.Show(FindResource("Inventorying"));
                    
                    return;
                }

                if (!checkFastInvAnt())
                {
                    //MessageBox.Show("Please select at least one antenna to poll at least once and repeat at least once.");
                    MessageBox.Show("Please 'Connect' before 'Start'");
                    //btnInventory.BackColor = Color.WhiteSmoke;
                    //btnInventory.ForeColor = Color.DarkBlue;
                    //btnInventory.Text = FindResource("StartInventory");
                    
                    return;
                }

                try
                {
                    if (Convert.ToInt32(mInventoryExeCount.Text) == 0)
                    {
                        MessageBox.Show("Invalid Execute Count, execute once at least");
                        return;
                    }

                    //btnInventory.BackColor = Color.DarkBlue;
                    //btnInventory.ForeColor = Color.White;
                    //btnInventory.Text = FindResource("StopInventory");

                    isFastInv = true;
                    doingFastInv = true;
                    Inventorying = true;

                    invTargetB = false;

                    m_FastExeCount = Convert.ToInt32(mInventoryExeCount.Text);

                    tagdb.AntGroup = 0x00;

                    

                    if (antType16.Checked)
                    {
                        if (checkFastInvAntG1Count())
                        {
                            RefreshInventoryInfo();
                            cmdFastInventorySend(useAntG1);
                        }
                        else if (checkFastInvAntG2Count())
                        {
                            cmdSwitchAntG2();
                        }
                        else
                        {
                            useAntG1 = true;
                            isFastInv = false;
                            stopFastInv();
                            MessageBox.Show("No Antenna select!");
                        }
                    }
                    else
                    {
                        useAntG1 = true;
                        RefreshInventoryInfo();
                        cmdFastInventorySend(useAntG1);
                    }

                    showMessage("Track Siap !!", Color.FromArgb(243, 246, 249));
                    startInventoryTime = DateTime.Now;
                    dispatcherTimer.Start();
                    readratePerSecond.Start();
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("FastInventory {0}", ex.Message));
                }
            }
            else if (btnInventory.Text.Equals(FindResource("StopInventory")))
            {
                btn_Reload.Enabled = true;
                if (Inventorying)
                {
                    SetInvStopingStatus();
                    isFastInv = false;
                }
            }
        }

        private void SetInvStopingStatus()
        {
            btnInventory.BackColor = Color.LightBlue;
            btnInventory.ForeColor = Color.Red;
            btnInventory.Text = FindResource("Stopping");
        }

        private void setInvStoppedStatus()
        {
            dispatcherTimer.Stop();
            readratePerSecond.Stop();
            elapsedTime = CalculateElapsedTime();

            btnInventory.BackColor = Color.WhiteSmoke;
            btnInventory.ForeColor = Color.DarkBlue;
            btnInventory.Text = FindResource("StartInventory");
            // Ensure finally refresh ui
            lock (tagdb)
            {
                tagdb.Repaint();
            }
        }

        private bool checkFastInvAntG1Count()
        {
            for (int i = 0; i < 8; i++)
            {
                if (fast_inv_ants[i].Enabled)
                {
                    if (fast_inv_ants[i].Checked)
                    {
                        useAntG1 = true;
                        return true;
                    }
                }
            }
            useAntG1 = false;
            return false;
        }

        private bool checkFastInvAntG2Count()
        {
            for (int i = 8; i < 16; i++)
            {
                if (fast_inv_ants[i].Enabled)
                {
                    if (fast_inv_ants[i].Checked)
                    {
                        useAntG1 = false;
                        return true;
                    }
                }
            }
            useAntG1 = true;
            return false;
        }

        private bool checkFastInvAnt()
        {
            int antCount = 0;
            for (int i = 0; i < 16; i++)
            {
                if (fast_inv_ants[i].Enabled)
                {
                    antCount++;
                }
            }
            if (antCount > 0)
                return true;
            return false;
        }

        private void buttonFastFresh_Click(object sender, EventArgs e)
        {
            BeginInvoke(new ThreadStart(delegate () {
                startInventoryTime = DateTime.Now;
                elapsedTime = 0.0;
                lock (tagdb)
                {
                    tagdb.Clear();
                    tagdb.Repaint();

                    led_total_tagreads.Text = tagdb.TotalTagCounts.ToString();
                    txtCmdTagCount.Text = tagdb.CmdTotalRead.ToString();
                    led_cmd_readrate.Text = tagdb.CmdReadRate.ToString();
                    led_cmd_execute_duration.Text = tagdb.CommandDuration.ToString();
                    led_totalread_count.Text = tagdb.TotalReadCounts.ToString();
                    ledFast_total_execute_time.Text = tagdb.TotalCommandTime.ToString();
                    txtFastMinRssi.Text = tagdb.MinRSSI.ToString();
                    txtFastMaxRssi.Text = tagdb.MaxRSSI.ToString();

                    label_readrate.Text = tagdb.CmdReadRate.ToString();
                    label_totalread_count.Text = tagdb.TotalReadCounts.ToString();
                    label_totaltag_count.Text = tagdb.TotalTagCounts.ToString();
                    label_totaltime.Text = tagdb.TotalCommandTime.ToString();
                }
            }));
        }

        private void pageFast4AntMode_Enter(object sender, EventArgs e)
        {
            //buttonFastFresh_Click(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtFirmwareVersion.Text = "";
            htxtReadId.Text = "";
            htbSetIdentifier.Text = "";
            txtReaderTemperature.Text = "";
            //txtOutputPower.Text = "";
            tb_outputpower_1.Text = "";
            tb_outputpower_2.Text = "";
            tb_outputpower_3.Text = "";
            tb_outputpower_4.Text = "";

            htbGetIdentifier.Text = "";
        }

        private void btGetMonzaStatus_Click(object sender, EventArgs e)
        {
            reader.GetMonzaStatus(m_curSetting.btReadId);
        }

        private void btSetMonzaStatus_Click(object sender, EventArgs e)
        {
            byte btMonzaStatus = 0xFF;

            if (rdbMonzaOn.Checked)
            {
                btMonzaStatus = 0x8D;
            }
            else if (rdbMonzaOff.Checked)
            {
                btMonzaStatus = 0x00;
            }
            else
            {
                return;
            }

            reader.SetMonzaStatus(m_curSetting.btReadId, btMonzaStatus);
            m_curSetting.btMonzaStatus = btMonzaStatus;
        }

        private void btGetIdentifier_Click(object sender, EventArgs e)
        {
            reader.GetReaderIdentifier(m_curSetting.btReadId);
        }

        private void btSetIdentifier_Click(object sender, EventArgs e)
        {
            try
            {
                string strTemp = htbSetIdentifier.Text.Trim();


                string[] result = ReaderUtils.StringToStringArray(strTemp.ToUpper(), 2);

                if (result == null)
                {
                    MessageBox.Show(FindResource("tipEmptyString"));
                    return;
                }
                else if (result.GetLength(0) != 12)
                {
                    MessageBox.Show(FindResource("tipTwelveBytesAtLeast"));
                    return;
                }
                byte[] readerIdentifier = ReaderUtils.StringArrayToByteArray(result, 12);


                reader.SetReaderIdentifier(m_curSetting.btReadId, readerIdentifier);
                //m_curSetting.btReadId = Convert.ToByte(strTemp, 16);

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("SetReaderIdentifier {0}", ex.Message));
            }
        }

        private void btReaderSetupRefresh_Click(object sender, EventArgs e)
        {
            htxtReadId.Text = "";
            htbGetIdentifier.Text = "";
            htbSetIdentifier.Text = "";
            txtFirmwareVersion.Text = "";
            txtReaderTemperature.Text = "";
            rdbGpio1High.Checked = false;
            rdbGpio1Low.Checked = false;
            rdbGpio2High.Checked = false;
            rdbGpio2Low.Checked = false;
            rdbGpio3High.Checked = false;
            rdbGpio3Low.Checked = false;
            rdbGpio4High.Checked = false;
            rdbGpio4Low.Checked = false;

            rdbBeeperModeSlient.Checked = false;
            rdbBeeperModeInventory.Checked = false;
            rdbBeeperModeTag.Checked = false;

            cmbSetBaudrate.SelectedIndex = -1;
        }

        private void btRfSetup_Click(object sender, EventArgs e)
        {
            //txtOutputPower.Text = "";
            tb_outputpower_1.Text = "";
            tb_outputpower_2.Text = "";
            tb_outputpower_3.Text = "";
            tb_outputpower_4.Text = "";

            cmbFrequencyStart.SelectedIndex = -1;
            cmbFrequencyEnd.SelectedIndex = -1;
            tbAntDectector.Text = "";

            //rdbDrmModeOpen.Checked = false;
            //rdbDrmModeClose.Checked = false;

            rdbMonzaOn.Checked = false;
            rdbMonzaOff.Checked = false;
            rdbRegionFcc.Checked = false;
            rdbRegionEtsi.Checked = false;
            rdbRegionChn.Checked = false;

            textReturnLoss.Text = "";
            cmbWorkAnt.SelectedIndex = -1;
            textStartFreq.Text = "";
            TextFreqInterval.Text = "";
            textFreqQuantity.Text = "";

            rdbProfile0.Checked = false;
            rdbProfile1.Checked = false;
            rdbProfile2.Checked = false;
            rdbProfile3.Checked = false;
        }

        private void cbRealSession_CheckedChanged(object sender, EventArgs e)
        {
            /*
            if (cbRealSession.Checked == true)
            {
                label97.Enabled = true;
                label98.Enabled = true;
                cmbSession.Enabled = true;
                cmbTarget.Enabled = true;
            }
            else
            {
                label97.Enabled = false;
                label98.Enabled = false;
                cmbSession.Enabled = false;
                cmbTarget.Enabled = false;

                m_session_sl_cb.Checked = false;
            } */
        }

        private void btReturnLoss_Click(object sender, EventArgs e)
        {
            if (cmbReturnLossFreq.SelectedIndex != -1)
            {
                reader.MeasureReturnLoss(m_curSetting.btReadId, Convert.ToByte(cmbReturnLossFreq.SelectedIndex));
            }
        }

        private void cbUserDefineFreq_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUserDefineFreq.Checked == true)
            {
                groupBox21.Enabled = false;
                groupBox23.Enabled = true;

            }
            else
            {
                groupBox21.Enabled = true;
                groupBox23.Enabled = false;
            }
        }

        private void btSetProfile_Click(object sender, EventArgs e)
        {
            byte btSelectedProfile = 0xFF;

            if (rdbProfile0.Checked)
            {
                btSelectedProfile = 0xD0;
            }
            else if (rdbProfile1.Checked)
            {
                btSelectedProfile = 0xD1;
            }
            else if (rdbProfile2.Checked)
            {
                btSelectedProfile = 0xD2;
            }
            else if (rdbProfile3.Checked)
            {
                btSelectedProfile = 0xD3;
            }
            else
            {
                return;
            }

            reader.SetRadioProfile(m_curSetting.btReadId, btSelectedProfile);
        }

        private void btGetProfile_Click(object sender, EventArgs e)
        {
            reader.GetRadioProfile(m_curSetting.btReadId);
        }

        private void tabCtrMain_Click(object sender, EventArgs e)
        {
            if ((m_curSetting.btRegion < 1) || (m_curSetting.btRegion > 4)) //If it is a custom spectrum you need to extract the custom frequency information first
            {
                reader.GetFrequencyRegion(m_curSetting.btReadId);
                Thread.Sleep(5);

            }
        }

        private void ProcessTagMask(Reader.MessageTran msgTran)
        {
            //Set
            //Head	Len	Address	Cmd	ErrorCode	Check
            //0xA0    0x04         0x98
            //Clear
            //Head	Len	Address	Cmd	ErrorCode	Check
            //0xA0    0x04         0x98

            //Query
            //Head Len Add Cmd     Mask ID MaskQuantity   Target Action  Membank StartingMaskAdd MaskBitLen Mask    Truncate CC
            //0xA0         0x98

            //Head	Len	 Add	Cmd 	MaskQuantity	CC
            //0xA0  0x0B        0x98    0x00
            string strCmd = string.Format("{0}", FindResource("tipTagMask"));
            string strErrorCode = string.Empty;
            if (msgTran.AryTranData[1] == 0x04)
            {
                //Error
                //clear mask result
                if (msgTran.AryData[0] == 0x10)
                {
                    strCmd += ": " + FindResource("tipExecSuccess");
                    WriteLog(lrtxtLog, strCmd, 0);
                    return;
                }
                //query mask result, no mask case 
                else if (msgTran.AryData[0] == 0x00)
                {
                    WriteLog(lrtxtLog, string.Format("{0} {1}", strCmd, FindResource("tipNoTagMask")), 0);
                    return;
                }
                else if (msgTran.AryData[1] == (byte)0x41)
                {
                    strErrorCode = FindResource("tipInvalidParameter");
                }
                else
                {
                    strErrorCode = string.Format("{0} {1:x2}", FindResource("UnknowError"), msgTran.AryData[1]);
                }
            }
            else
            {
                //Mask ID MaskQuantity Target Action Membank StartingMaskAdd MaskBitLen Mask Truncate
                if (msgTran.AryData.Length > 7)
                {
                    TagMask tagMask = new TagMask(msgTran.AryData);
                    Console.WriteLine(string.Format("tagmask={0}", tagMask.ToString()));

                    BeginInvoke(new ThreadStart(delegate () {
                        tagmaskDB.Add(tagMask);
                    }));
                    return;
                }
                else
                {
                    strErrorCode = string.Format("{0} [{1}]", FindResource("UnknowError"), ReaderUtils.ToHex(msgTran.AryTranData, "", " "));
                }
            }
            string strLog = string.Format("{0}{1}: {2}", strCmd, FindResource("tipFailedCause"), strErrorCode);
            WriteLog(lrtxtLog, strLog, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (combo_mast_id.SelectedIndex == -1 || combo_session.SelectedIndex == -1 || combo_action.SelectedIndex == -1 || combo_menbank.SelectedIndex == -1)
            {
                MessageBox.Show("Target Action Membank must be selected");
                return;
            }
            byte btMaskNo = (byte)(combo_mast_id.SelectedIndex + 1);
            byte btTarget = (byte)combo_session.SelectedIndex;
            byte btAction = (byte)combo_action.SelectedIndex;
            byte btMembank = (byte)combo_menbank.SelectedIndex;

            string strMaskValue = hexTextBox_mask.Text.Trim();
            string[] maskValue = ReaderUtils.StringToStringArray(strMaskValue.ToUpper(), 2);

            if (!CheckByte(startAddr.Text) || !CheckByte(bitLen.Text))
            {
                MessageBox.Show("Mask Length and start address must be 1-255", "Start Address Or BitLen");
                return;
            }
            byte bStartAddress = Convert.ToByte(startAddr.Text);
            int iMaskLen = Convert.ToInt32(bitLen.Text);

            if (maskValue == null)
            {
                MessageBox.Show("MaskValue is null", "SetTagMask");
                return;
            }
            byte[] btsMaskValue = ReaderUtils.StringArrayToByteArray(maskValue, maskValue.Length);

            if (iMaskLen < (btsMaskValue.Length - 1) * 8 + 1 || iMaskLen > btsMaskValue.Length * 8)
            {
                MessageBox.Show(string.Format("Mask Length({0}) is invaild! The actual len is {1}", iMaskLen, btsMaskValue.Length * 8), "MaskValue");
                return;
            }

            string strCmd = string.Format("{0}", FindResource("tipSetTagMask"));
            WriteLog(lrtxtLog, strCmd, 0);

            reader.setTagMask((byte)0xFF, btMaskNo, btTarget, btAction, btMembank, bStartAddress, (byte)iMaskLen, btsMaskValue);
            //m_curSetting.btReadId = Convert.ToByte(strTemp, 16);
        }

        private bool CheckByte(string str)
        {
            string pattern = @"((^[0-9]$)|(^[1-9][0-9]$)|(^1[0-9][0-9]$)|(^2[0-5][0-5]$))";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (str.Length == 0 || str.Length > 3)
            {
                return false;
            }

            return regex.IsMatch(str.Trim());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox16.SelectedIndex == -1)
            {
                MessageBox.Show("MaskNO must be selected");
                return;
            }
            byte btMaskNo = (byte)comboBox16.SelectedIndex;

            string strCmd = string.Format("{0}", FindResource("tipClearTagMask"));
            WriteLog(lrtxtLog, strCmd, 0);

            reader.clearTagMask((byte)0xFF, btMaskNo);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strCmd = string.Format("{0}", FindResource("tipGetTagMask"));
            WriteLog(lrtxtLog, strCmd, 0);
            tagmaskDB.Clear();
            reader.getTagMask((byte)0xFF);
        }

        private void saveFastData()
        {
            string strDestinationFile = string.Empty;
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "CSV Files (*.csv)|*.csv";
                strDestinationFile = "InventoryResult"
                        + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + @".csv";
                saveFileDialog1.FileName = strDestinationFile;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    strDestinationFile = saveFileDialog1.FileName;
                    TextWriter tw = new StreamWriter(strDestinationFile, true, Encoding.Default);
                    StringBuilder sb = new StringBuilder();
                    //writing the header
                    int columnCount = dgv_fast_inv_tags.Columns.Count;

                    for (int count = 0; count < columnCount; count++)
                    {
                        string colHeader = dgv_fast_inv_tags.Columns[count].HeaderText;
                        sb.Append(colHeader + ", ");
                    }
                    tw.WriteLine(sb.ToString());

                    //writing the data
                    TagRecord rda = null;
                    for (int rowCount = 0; rowCount <= tagdb.TagList.Count - 1; rowCount++)
                    {
                        rda = tagdb.TagList[rowCount];
                        textWrite(tw, rda, rowCount + 1);
                    }
                    tw.Close();
                    MessageBox.Show(FindResource("tipDataExportSuccess"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("saveFastData {0}", ex.Message));
            }
        }

        /// <summary>
        /// For readability sake in the text file.
        /// </summary>
        /// <param name="tw"></param>
        /// <param name="rda"></param>
        private void textWrite(TextWriter tw, TagRecord rda, int rowNumber)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(rda.SerialNumber + ", ");

            sb.Append(rda.ReadCount + ", ");

            sb.Append(rda.PC + ", ");

            sb.Append(rda.EPC + ", ");

            sb.Append(rda.Antenna + ", ");

            sb.Append(rda.Rssi + ", ");

            sb.Append(rda.Freq + ", ");

            sb.Append(rda.Phase);

            sb.Append(rda.Data + ", ");


            //sb.Append(rda.Protocol + ", ");

            //sb.Append(rda.TimeStamp.ToString("MM-dd-yyyy HH:mm:ss:fff") + ", ");

            tw.Write(sb.ToString());
            tw.WriteLine();
        }

        //save tag as excel
        public DataTable ListViewToDataTable(ListView listView)
        {
            DataTable table = new DataTable();

            foreach (ColumnHeader header in listView.Columns)
            {
                table.Columns.Add(header.Text, typeof(string));
            }

            foreach (ListViewItem item in listView.Items)
            {
                DataRow row = table.NewRow();
                //处理行
                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    //MessageBox.Show(item.SubItems[i].Text);
                    row[i] = item.SubItems[i].Text;
                }

                table.Rows.Add(row);
            }
            return table;
        }

        //////////////////////////////////////////////////////////////////////////
        public void SaveToFile(MemoryStream ms, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                byte[] data = ms.ToArray();

                fs.Write(data, 0, data.Length);
                fs.Flush();

                data = null;
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            saveFastData();
        }

        private bool CheckPower(string power)
        {
            if (power.Trim().Length > 0)
            {
                try
                {
                    int tmp = Convert.ToInt16(power.Trim());
                    if (tmp > 33 || tmp < 0)
                    {
                        MessageBox.Show(string.Format("{0}, output power must in [0, 33]", FindResource("tipInvalidParameter")), "CheckPower");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("CheckPower Error: {0}", ex.Message), "CheckPower");
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!CheckPower(tb_outputpower_1.Text))
            {
                tb_outputpower_1.Text = "";
                return;
            }
            int channels = 1;

            if (antType4.Checked)
            {
                channels = 4;
            }

            if (antType8.Checked)
            {
                channels = 8;
            }

            if (antType16.Checked)
            {
                channels = 16;
            }

            if (channels >= 4)
            {
                tb_outputpower_2.Text = tb_outputpower_1.Text;
                tb_outputpower_3.Text = tb_outputpower_1.Text;
                tb_outputpower_4.Text = tb_outputpower_1.Text;

                if (channels >= 8)
                {
                    tb_outputpower_5.Text = tb_outputpower_1.Text;
                    tb_outputpower_6.Text = tb_outputpower_1.Text;
                    tb_outputpower_7.Text = tb_outputpower_1.Text;
                    tb_outputpower_8.Text = tb_outputpower_1.Text;

                    if (channels >= 16)
                    {
                        tb_outputpower_9.Text = tb_outputpower_1.Text;
                        tb_outputpower_10.Text = tb_outputpower_1.Text;
                        tb_outputpower_11.Text = tb_outputpower_1.Text;
                        tb_outputpower_12.Text = tb_outputpower_1.Text;

                        tb_outputpower_13.Text = tb_outputpower_1.Text;
                        tb_outputpower_14.Text = tb_outputpower_1.Text;
                        tb_outputpower_15.Text = tb_outputpower_1.Text;
                        tb_outputpower_16.Text = tb_outputpower_1.Text;
                    }
                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!CheckPower(tb_outputpower_2.Text))
            {
                tb_outputpower_2.Text = "";
                return;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!CheckPower(tb_outputpower_3.Text))
            {
                tb_outputpower_3.Text = "";
                return;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!CheckPower(tb_outputpower_4.Text))
            {
                tb_outputpower_4.Text = "";
                return;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (!CheckPower(tb_outputpower_5.Text))
            {
                tb_outputpower_5.Text = "";
                return;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (!CheckPower(tb_outputpower_6.Text))
            {
                tb_outputpower_6.Text = "";
                return;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (!CheckPower(tb_outputpower_7.Text))
            {
                tb_outputpower_7.Text = "";
                return;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (!CheckPower(tb_outputpower_8.Text))
            {
                tb_outputpower_8.Text = "";
                return;
            }
        }

        private void antType_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
            if (!btn.Checked)
                return;
            switch (btn.Name)
            {
                case "antType1":
                    channels = 1;
                    antType1_CheckedChanged(sender, e);
                    break;
                case "antType4":
                    channels = 4;
                    antType4_CheckedChanged(sender, e);
                    break;
                case "antType8":
                    channels = 8;
                    antType8_CheckedChanged(sender, e);
                    break;
                case "antType16":
                    channels = 16;
                    antType16_CheckedChanged(sender, e);
                    break;
            }
            InventoryTypeChanged(null, null);
        }

        private void antType1_CheckedChanged(object sender, EventArgs e)
        {
            if (antType1.Checked)
            {
                // output power 
                tb_outputpower_2.Enabled = false;
                tb_outputpower_3.Enabled = false;
                tb_outputpower_4.Enabled = false;
                tb_outputpower_5.Enabled = false;
                tb_outputpower_6.Enabled = false;
                tb_outputpower_7.Enabled = false;
                tb_outputpower_8.Enabled = false;
                tb_outputpower_9.Enabled = false;
                tb_outputpower_10.Enabled = false;
                tb_outputpower_11.Enabled = false;
                tb_outputpower_12.Enabled = false;
                tb_outputpower_13.Enabled = false;
                tb_outputpower_14.Enabled = false;
                tb_outputpower_15.Enabled = false;
                tb_outputpower_16.Enabled = false;

                //set work ant
                this.cmbWorkAnt.Items.Clear();
                string antPreFix = FindResource("Antenna");
                this.cmbWorkAnt.Items.AddRange(new object[] { string.Format("{0}1", antPreFix) });
                this.cmbWorkAnt.SelectedIndex = 0;
            }
        }

        private void antType4_CheckedChanged(object sender, EventArgs e)
        {
            if (antType4.Checked)
            {
                //set work ant
                this.cmbWorkAnt.Items.Clear();
                string antPreFix = FindResource("Antenna");
                this.cmbWorkAnt.Items.AddRange(new object[] {
                    string.Format("{0}1", antPreFix),
                    string.Format("{0}2", antPreFix),
                    string.Format("{0}3", antPreFix),
                    string.Format("{0}4", antPreFix),
                });
                this.cmbWorkAnt.SelectedIndex = 0;

                // output power 
                tb_outputpower_2.Enabled = true;
                tb_outputpower_3.Enabled = true;
                tb_outputpower_4.Enabled = true;
                tb_outputpower_5.Enabled = false;
                tb_outputpower_6.Enabled = false;
                tb_outputpower_7.Enabled = false;
                tb_outputpower_8.Enabled = false;
                tb_outputpower_9.Enabled = false;
                tb_outputpower_10.Enabled = false;
                tb_outputpower_11.Enabled = false;
                tb_outputpower_12.Enabled = false;
                tb_outputpower_13.Enabled = false;
                tb_outputpower_14.Enabled = false;
                tb_outputpower_15.Enabled = false;
                tb_outputpower_16.Enabled = false;
            }
        }

        private void antType8_CheckedChanged(object sender, EventArgs e)
        {
            if (antType8.Checked)
            {
                //set work ant
                this.cmbWorkAnt.Items.Clear();
                string antPreFix = FindResource("Antenna");
                this.cmbWorkAnt.Items.AddRange(new object[] {
                    string.Format("{0}1", antPreFix),
                    string.Format("{0}2", antPreFix),
                    string.Format("{0}3", antPreFix),
                    string.Format("{0}4", antPreFix),
                    string.Format("{0}5", antPreFix),
                    string.Format("{0}6", antPreFix),
                    string.Format("{0}7", antPreFix),
                    string.Format("{0}8", antPreFix),
                });
                this.cmbWorkAnt.SelectedIndex = 0;

                // output power 
                tb_outputpower_2.Enabled = true;
                tb_outputpower_3.Enabled = true;
                tb_outputpower_4.Enabled = true;
                tb_outputpower_5.Enabled = true;
                tb_outputpower_6.Enabled = true;
                tb_outputpower_7.Enabled = true;
                tb_outputpower_8.Enabled = true;
                tb_outputpower_9.Enabled = false;
                tb_outputpower_10.Enabled = false;
                tb_outputpower_11.Enabled = false;
                tb_outputpower_12.Enabled = false;
                tb_outputpower_13.Enabled = false;
                tb_outputpower_14.Enabled = false;
                tb_outputpower_15.Enabled = false;
                tb_outputpower_16.Enabled = false;
            }
        }

        private void antType16_CheckedChanged(object sender, EventArgs e)
        {
            if (antType16.Checked)
            {
                //set work ant
                this.cmbWorkAnt.Items.Clear();
                string antPreFix = FindResource("Antenna");
                this.cmbWorkAnt.Items.AddRange(new object[] {
                    string.Format("{0}1", antPreFix),
                    string.Format("{0}2", antPreFix),
                    string.Format("{0}3", antPreFix),
                    string.Format("{0}4", antPreFix),
                    string.Format("{0}5", antPreFix),
                    string.Format("{0}6", antPreFix),
                    string.Format("{0}7", antPreFix),
                    string.Format("{0}8", antPreFix),
                    string.Format("{0}9", antPreFix),
                    string.Format("{0}10", antPreFix),
                    string.Format("{0}11", antPreFix),
                    string.Format("{0}12", antPreFix),
                    string.Format("{0}13", antPreFix),
                    string.Format("{0}14", antPreFix),
                    string.Format("{0}15", antPreFix),
                    string.Format("{0}16", antPreFix),
                });
                this.cmbWorkAnt.SelectedIndex = 0;

                // output power 
                tb_outputpower_2.Enabled = true;
                tb_outputpower_3.Enabled = true;
                tb_outputpower_4.Enabled = true;
                tb_outputpower_5.Enabled = true;
                tb_outputpower_6.Enabled = true;
                tb_outputpower_7.Enabled = true;
                tb_outputpower_8.Enabled = true;
                tb_outputpower_9.Enabled = true;
                tb_outputpower_10.Enabled = true;
                tb_outputpower_11.Enabled = true;
                tb_outputpower_12.Enabled = true;
                tb_outputpower_13.Enabled = true;
                tb_outputpower_14.Enabled = true;
                tb_outputpower_15.Enabled = true;
                tb_outputpower_16.Enabled = true;
            }
        }

        private void cb_customized_session_target_CheckedChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("cb_customized_session_target_CheckedChanged");
            if (cb_customized_session_target.Checked)
            {
                // 允许测试反转AB
                cb_fast_inv_reverse_target.Visible = true;
                tb_fast_inv_staytargetB_times.Visible = true;

                if (radio_btn_fast_inv.Checked)
                {
                    tb_fast_inv_reserved_5.Visible = false;
                    grb_sessions.Visible = true; // Session
                    grb_targets.Visible = true; // Target
                    grb_Reserve.Visible = true;

                    cb_use_Phase.Visible = true;
                    cb_use_selectFlags_tempPows.Visible = true;
                    cb_use_optimize.Visible = true;
                    //cb_use_Phase_CheckedChanged(null, null);
                    //cb_use_selectFlags_tempPows_CheckedChanged(null, null);
                    //cb_use_optimize_CheckedChanged(null, null);
                }
                else
                {
                    grb_sessions.Visible = true;
                    grb_targets.Visible = true;

                    cb_use_Phase.Visible = true; // Phase
                    cb_use_selectFlags_tempPows.Visible = true;
                    cb_use_powerSave.Visible = true;
                }
            }
            else
            {
                // Forbid testing the reverse target AB
                cb_fast_inv_reverse_target.Checked = false;
                cb_fast_inv_reverse_target.Visible = false;
                tb_fast_inv_staytargetB_times.Visible = false;

                if (radio_btn_fast_inv.Checked)
                {
                    cb_use_Phase.Checked = false; // Phase
                    cb_use_Phase.Visible = false;

                    cb_use_selectFlags_tempPows.Checked = false;
                    cb_use_selectFlags_tempPows.Visible = false;
                    tb_fast_inv_reserved_5.Visible = true;
                    grb_sessions.Visible = false;
                    grb_targets.Visible = false;
                    grb_Reserve.Visible = false;

                    cb_use_optimize.Checked = false;
                    cb_use_optimize.Visible = false;
                    grb_Optimize.Visible = false;
                }
                else
                {
                    cb_use_Phase.Checked = false; // Phase
                    cb_use_Phase.Visible = false;

                    cb_use_selectFlags_tempPows.Checked = false;
                    cb_use_selectFlags_tempPows.Visible = false;
                    grb_selectFlags.Visible = false;
                    grb_sessions.Visible = false;
                    grb_targets.Visible = false;

                    cb_use_powerSave.Checked = false;
                    cb_use_powerSave.Visible = false;
                    grb_powerSave.Visible = false;
                }
            }
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            string strLog = lrtxtDataTran.Text;
            string path = Application.StartupPath + @"\Log.txt";
            StreamWriter sWriter = File.CreateText(path);
            sWriter.Write(strLog);
            sWriter.Flush();
            sWriter.Close();
            MessageBox.Show("Successfully saved" + path);

            lrtxtDataTran.Text = "";
        }

        public static String FormatLongToTimeStr(long ms)
        {
            int milliSecond = (int)(ms % 1000);
            int second = (int)(ms / 1000);
            int minute = 0;
            int hour = 0;

            if (second >= 60)
            {
                minute = second / 60;
                second = second % 60;
            }
            if (minute >= 60)
            {
                hour = minute / 60;
                minute = minute % 60;
            }
            return string.Format("{0:D4}-{1:D2}-{2:D2}-{3:D3}", hour, minute, second, milliSecond);
        }

        #region Johar
        /////
        /// SEN_DATA[23:0] -> EPC 0x06, 0x07
        /// delta1 = User 0x08
        /// Chip version compatible data -> User 0x09
        /// 
        /// 1.Access to raw data
        /// 2.Get SEN_DATA[23:0]
        /// 3.Sensor data verification
        /// 4.Acquisition of calibration parameters user 0x08
        /// 5.Acquisition of temperature data
        /// 
        bool joharReadingStarted = false;
        bool joharReading = false;
        JoharTagDB johardb = null;
        int joharCmdInterval = 100;

        private void johar_read_btn_Click(object sender, EventArgs e)
        {
            if (johar_read_btn.Text.Equals(FindResource("Start")))
            {
                johar_read_btn.Text = FindResource("Stop");
                if (johar_use_btn.Text.Equals(FindResource("Enable")))
                {
                    johar_use_btn.Text = FindResource("Disable");
                    enableReadJohar(true);
                    johar_cb.Checked = true;
                    selectJohar();
                }
                joharCmdInterval = Convert.ToInt32(johar_cmd_interval_cb.SelectedItem.ToString());
                jorharEnableView(false);
                new Thread(new ThreadStart(readingJohar)).Start();
            }
            else if (johar_read_btn.Text.Equals(FindResource("Stop")))
            {
                joharReadingStarted = false;
                while (joharReading)
                {
                    Thread.Sleep(200);
                }
                jorharEnableView(true);
                johar_read_btn.Text = FindResource("Start");
            }
        }

        private void jorharEnableView(bool enable)
        {
            johar_use_btn.Enabled = enable;
            johar_settings_gb.Enabled = enable;
            johar_cmd_interval_cb.Enabled = enable;
        }

        private void johar_use_btn_Click(object sender, EventArgs e)
        {
            if (johar_use_btn.Text.Equals(FindResource("Enable")))
            {
                johar_use_btn.Text = FindResource("Disable");
                enableReadJohar(true);
                johar_cb.Checked = true;
                selectJohar();
            }
            else if (johar_use_btn.Text.Equals(FindResource("Disable")))
            {
                johar_use_btn.Text = FindResource("Enable");
                enableReadJohar(false);
                johar_cb.Checked = false;
                clearSelect();
            }
        }

        private void johar_clear_btn_Click(object sender, EventArgs e)
        {
            this.BeginInvoke(new ThreadStart(delegate ()
            {
                johardb.Clear();
                johar_totalread_label.Text = johardb.TotalTagCount.ToString();
                johar_tagcount_label.Text = johardb.UniqueTagCount.ToString();
            }));
        }

        private void enableReadJohar(bool flag)
        {
            int writeIndex = 0;
            byte[] rawData = new byte[256];
            rawData[writeIndex++] = 0xA0; // hdr

            rawData[writeIndex++] = 0x03; // len minLen = 3

            rawData[writeIndex++] = m_curSetting.btReadId; // addr

            rawData[writeIndex++] = 0x8C; // cmd 8D - save to flash

            // data
            if (true == flag)
            {
                rawData[writeIndex++] = 0x90; // TempSel
            }
            else
            {
                rawData[writeIndex++] = 0x00; // TempSel
            }

            int msgLen = writeIndex + 1;
            rawData[1] = (byte)(msgLen - 2); // update len, except hdr+len

            rawData[writeIndex] = ReaderUtils.CheckSum(rawData, 0, msgLen - 1); // check
            Array.Resize(ref rawData, msgLen);
            int nResult = reader.SendMessage(rawData);
        }

        private void selectJohar()
        {
            int writeIndex = 0;
            byte[] rawData = new byte[256];
            rawData[writeIndex++] = 0xA0; // hdr

            rawData[writeIndex++] = 0x03; // len minLen = 3

            rawData[writeIndex++] = 0xFF;// m_curSetting.btReadId; // addr

            rawData[writeIndex++] = (byte)CMD.cmd_tag_select; // cmd

            // data
            // function
            rawData[writeIndex++] = 0x01;
            // target
            rawData[writeIndex++] = 0x07;
            // action
            rawData[writeIndex++] = 0x04;
            // membank
            rawData[writeIndex++] = 0x01;
            // StartingMaskAdd
            rawData[writeIndex++] = 0x01;
            // MaskBitLen
            rawData[writeIndex++] = 0x01;
            // Mask
            rawData[writeIndex++] = 0x00;
            // Truncate
            rawData[writeIndex++] = 0x00;

            int msgLen = writeIndex + 1;
            rawData[1] = (byte)(msgLen - 2); // update len, except hdr+len

            rawData[writeIndex] = ReaderUtils.CheckSum(rawData, 0, msgLen - 1); // check
            Array.Resize(ref rawData, msgLen);
            int nResult = reader.SendMessage(rawData);
        }

        private void clearSelect()
        {
            int writeIndex = 0;
            byte[] rawData = new byte[256];
            rawData[writeIndex++] = 0xA0; // hdr

            rawData[writeIndex++] = 0x03; // len minLen = 3

            rawData[writeIndex++] = m_curSetting.btReadId; // addr

            rawData[writeIndex++] = 0x98; // cmd

            // data
            rawData[writeIndex++] = 0x00;

            int msgLen = writeIndex + 1;
            rawData[1] = (byte)(msgLen - 2); // update len, except hdr+len

            rawData[writeIndex] = ReaderUtils.CheckSum(rawData, 0, msgLen - 1); // check
            Array.Resize(ref rawData, msgLen);
            int nResult = reader.SendMessage(rawData);
        }

        private void sendReadJoharMessage()
        {
            int writeIndex = 0;
            byte[] rawData = new byte[256];
            rawData[writeIndex++] = 0xA0; // hdr

            rawData[writeIndex++] = 0x03; // len minLen = 3

            rawData[writeIndex++] = m_curSetting.btReadId; // addr

            rawData[writeIndex++] = 0x81; // cmd

            // data
            rawData[writeIndex++] = 0x00; // reserved
            rawData[writeIndex++] = 0x00;

            rawData[writeIndex++] = 0x00; // Tid
            rawData[writeIndex++] = 0x00;

            rawData[writeIndex++] = 0x08; // User 08, 09
            rawData[writeIndex++] = 0x02;

            rawData[writeIndex++] = 0x00; // Access Password
            rawData[writeIndex++] = 0x00;
            rawData[writeIndex++] = 0x00;
            rawData[writeIndex++] = 0x00;

            rawData[writeIndex++] = getJoharSession(); // session

            rawData[writeIndex++] = getJoharTarget(); // Target

            rawData[writeIndex++] = getJoharReadMode(); // ReadMode

            rawData[writeIndex++] = 0x05; // TimeOut default: 5ms

            int msgLen = writeIndex + 1;
            rawData[1] = (byte)(msgLen - 2); // except hdr+len
            //Console.WriteLine("sendReadJoharMessage writeIndex={0}, msgLen={0}, len={2}", writeIndex, msgLen, rawData[1]);

            rawData[writeIndex] = ReaderUtils.CheckSum(rawData, 0, msgLen - 1); // check
            Array.Resize(ref rawData, msgLen);
            int nResult = reader.SendMessage(rawData);
        }

        private void readingJohar()
        {
            joharReadingStarted = true;
            joharReading = true;
            while (joharReadingStarted)
            {
                sendReadJoharMessage();
                Thread.Sleep(joharCmdInterval < 100 ? 100 : joharCmdInterval);
            }
            joharReading = false;
        }

        private void parseJoharRead(byte[] aryTranData)
        {
            this.BeginInvoke(new ThreadStart(delegate ()
            {
                //Console.WriteLine("parseJoharRead totalread={0}, tagcount={1}", johardb.TotalTagCount, johardb.UniqueTagCount);
                JoharTag tag = new JoharTag(aryTranData);
                johardb.Add(tag);
                johar_totalread_label.Text = johardb.TotalTagCount.ToString();
                johar_tagcount_label.Text = johardb.UniqueTagCount.ToString();
            }));
        }

        private byte getJoharReadMode()
        {
            if (johar_readmode_mode1.Checked)
            {
                return 0x00;
            }
            else if (johar_readmode_mode2.Checked)
            {
                return 0x01;
            }
            else if (johar_readmode_mode3.Checked)
            {
                return 0x02;
            }
            return 0x02; // default Mode3
        }

        private byte getJoharTarget()
        {
            if (johar_target_A_rb.Checked)
            {
                return 0x00;
            }
            else if (johar_target_B_rb.Checked)
            {
                return 0x01;
            }
            return 0x00; // default A
        }

        private byte getJoharSession()
        {
            if (johar_session_s0_rb.Checked)
            {
                return 0x00;
            }
            else if (johar_session_s1_rb.Checked)
            {
                return 0x01;
            }
            else if (johar_session_s2_rb.Checked)
            {
                return 0x02;
            }
            else if (johar_session_s3_rb.Checked)
            {
                return 0x02;
            }
            return 0x01; // default s1
        }

        #endregion Johar

        private void RefreshInventoryInfo()
        {
            if (inventory_times > 0)
                saveInventoryToLog(useAntG1, inventory_times);
            inventory_times++;
        }

        private void btn_StartKiri_Click(object sender, EventArgs e)
        {
            btnStartKanan.Enabled = true;
            btnStartKanan.BackColor = Color.FromArgb(217, 217, 217);
            btnStartKanan.ForeColor = Color.Black;

            btn_StartKiri.Enabled = false;
            btn_StartKiri.BackColor = Color.FromArgb(4, 96, 205);
            btn_StartKiri.ForeColor = Color.White;

            string UpdateAntena = "update history_track set antena = '" + 5 + "' order by id DESC limit 1";
            new Connect().execute(UpdateAntena);

            StatusStartPosisi = "Kiri";
            //MessageBox.Show(StatusStartPosisi);


        }

        private void btnStartKanan_Click(object sender, EventArgs e)
        {
            btnStartKanan.Enabled = false;
            btnStartKanan.BackColor = Color.FromArgb(4, 96, 205);
            btnStartKanan.ForeColor = Color.White;

            btn_StartKiri.Enabled = true;
            btn_StartKiri.BackColor = Color.FromArgb(217, 217, 217);
            btn_StartKiri.ForeColor = Color.Black;
            StatusStartPosisi = "Kanan";

            string UpdateAntena = "update history_track set antena = '" + 0 + "' order by id DESC limit 1";
            new Connect().execute(UpdateAntena);
            //MessageBox.Show(StatusStartPosisi);
        }

        //Cara 1
        private void parseInvTag(bool readPhase, byte[] data, byte cmd)
        {
            BeginInvoke(new ThreadStart(delegate ()
            {
                lock (tagdb)
                {
                    Tag tag = new Tag(data, readPhase, cmd, tagdb.AntGroup);

                    int antena = int.Parse(tag.Antenna);
                    string epc = tag.EPC;
                    string waktu = Label_Timer.Text;
                    string Track = System.Configuration.ConfigurationManager.AppSettings["NoTrack"];
                    string noPeserta = Label_NoPeserta.Text;
                    string id_barcode = textBarId.Text.ToString().Replace("\r", "");
                    string idtestor = idTestor;
                    string status = "Selesai";


                    if (StatusStartPosisi == "Kanan")
                    {
                        string Cek_Track = "select * from history where barcode = '" + id_barcode + "' order by no_peserta DESC limit 1";
                        DataTable cek_track = new Connect().getTable(Cek_Track);
                        string CekTrack = (cek_track.Rows[0]["no_track"].ToString());
                        if (Track == CekTrack)
                        {

                            string CariHistoryAntena = "select * from history_track where barcode='" + id_barcode + "' order by id DESC limit 1";
                            DataTable Cek_History = new Connect().getTable(CariHistoryAntena);

                            if (Cek_History.Rows.Count > 0)
                            {
                                int HistoryAntena = int.Parse(Cek_History.Rows[0]["antena"].ToString());

                                if (antena == HistoryAntena + 1)
                                {

                                    if (isStartTime)
                                    {
                                        string InsertHistory = "insert into history_track (no_track,barcode,antena,no_rfid,waktu) values('" + Track + "','" + id_barcode + "','" + antena + "' , '" + epc + "','" + waktu + "')";
                                        new Connect().execute(InsertHistory);
                                        stopwatch.Start();
                                        timer1.Start();
                                    }

                                    if (antena == 4 && HistoryAntena == 3)
                                    {
                                        string History = "select * from history where barcode='" + id_barcode + "' order by id DESC limit 1";
                                        DataTable history = new Connect().getTable(History);

                                        if (history.Rows.Count > 0)
                                        {
                                            string Putaran1 = (history.Rows[0]["putaran1"].ToString());
                                            string Putaran2 = (history.Rows[0]["putaran2"].ToString());
                                            string Putaran3 = (history.Rows[0]["putaran3"].ToString());
                                            if (Putaran1 == "0")
                                            {
                                                string UpdateWaktu = "update history set putaran1 = '" + waktu + "' where barcode = '" + id_barcode + "'";
                                                new Connect().execute(UpdateWaktu);

                                                showMessage("Putaran 1", Color.FromArgb(243, 246, 249));
                                                Label_JumlahPutaran.Text = "1";




                                                /*string History1 = "select * from history where barcode='" + id_barcode + "' order by id DESC limit 1";
                                                DataTable history1 = new Connect().getTable(History1);
                                                string waktu_p1 = history.Rows[0]["putaran1"].ToString();*/
                                                Label_Putaran1.Text = waktu;

                                                PlaySoundPutaran1();
                                            }
                                            else if (Putaran2 == "0")
                                            {
                                                string UpdateWaktu = "update history set putaran2 = '" + waktu + "' where barcode = '" + id_barcode + "'";
                                                new Connect().execute(UpdateWaktu);

                                                showMessage("Putaran 2", Color.FromArgb(243, 246, 249));
                                                Label_JumlahPutaran.Text = "2";




                                                /* string History2 = "select * from history where barcode='" + id_barcode + "' order by id DESC limit 1";
                                                 DataTable history2 = new Connect().getTable(History2);
                                                 string waktu_p2 = history.Rows[0]["putaran2"].ToString();*/
                                                Label_Putaran2.Text = waktu;

                                                PlaySoundPutaran2();

                                            }
                                            else if (Putaran3 == "0")
                                            {
                                                /*string UpdateWaktu = "update history set putaran3 = '" + waktu + "' where barcode = '" + id_barcode + "'";
                                                new Connect().execute(UpdateWaktu);
                                                string UpdateWaktuAkhir = "update history set waktu_akhir = '" + waktu + "' where barcode = '" + id_barcode + "'";
                                                new Connect().execute(UpdateWaktuAkhir);

                                                string UpdateStatus = "update history set status = '" + status + "' where barcode = '" + id_barcode + "'";
                                                new Connect().execute(UpdateStatus);

                                                string UpdateAkhir = "update peserta set capaian= '" + waktu + "' where barcode = '" + id_barcode + "'";
                                                new Connect().execute(UpdateAkhir);
                                                //MessageBox.Show("Selesai");*/

                                                string UpdateWaktu = "update history set putaran3 = '" + waktu + "',waktu_akhir = '" + waktu + "',status = 'selesai' where barcode = '" + id_barcode + "'";
                                                new Connect().execute(UpdateWaktu);
                                                Label_JumlahPutaran.Text = "3";


                                                /* string History3 = "select * from history where barcode='" + id_barcode + "' order by id DESC limit 1";
                                                 DataTable history3 = new Connect().getTable(History3);

                                                 string waktu_p3 = history.Rows[0]["putaran3"].ToString();*/
                                                Label_Putaran3.Text = waktu;
                                                stopwatch.Stop();
                                                timer1.Stop();
                                                PlaySoundPutaran3();

                                                postDataNilai(waktu, noPeserta, idtestor);




                                                btnInventory.PerformClick();
                                                btnInventory.Enabled = false;
                                                btnConnect.PerformClick();
                                                btnConnect.Enabled = false;

                                                btn_Ulangi.Show();
                                                isStartTime = false;

                                                LabelNotif.Text = "Finish..";
                                                showMessage("Finish. . Klik Ulangi/NEXT", Color.FromArgb(243, 246, 249));

                                            }
                                        }
                                    }
                                }
                                else if (antena == 1 && HistoryAntena == 4)
                                {
                                    string InsertHistory = "insert into history_track (no_track,barcode,antena,no_rfid,waktu) values('" + Track + "','" + id_barcode + "','" + antena + "' , '" + epc + "','" + waktu + "')";
                                    new Connect().execute(InsertHistory);
                                }

                                else if (antena == HistoryAntena)
                                {
                                    return;
                                }
                                else if (antena >= HistoryAntena + 1 || antena <= HistoryAntena + 1)
                                {
                                    //string InsertHistory = "insert into history_track (no_track,barcode,antena,no_rfid,waktu) values('" + Track + "','" + id_barcode + "','" + antena + "' , '" + epc + "','" + waktu + "')";
                                    //new Connect().execute(InsertHistory);

                                    //MessageBox.Show ("Salah");
                                    showMessage("Salah", Color.FromArgb(243, 246, 249));
                                    PlaySoundWrongTrack();
                                    //this.Close();
                                }
                            }
                            else
                            {
                                string InsertHistory = "insert into history_track (no_track,barcode,antena,no_rfid,waktu) values('" + Track + "','" + id_barcode + "','" + antena + "' , '" + epc + "','" + waktu + "')";
                                new Connect().execute(InsertHistory);
                                //MessageBox.Show("Isi Disini");
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Track Salah");
                            showMessage("Track Salah", Color.FromArgb(243, 246, 249));
                            PlaySoundWrongTrack();
                        }
                    }
                    else if (StatusStartPosisi == "Kiri")
                    {
                        string Cek_Track = "select * from history where barcode = '" + id_barcode + "' order by no_peserta DESC limit 1";
                        DataTable cek_track = new Connect().getTable(Cek_Track);
                        string CekTrack = (cek_track.Rows[0]["no_track"].ToString());
                        if (Track == CekTrack)
                        {

                            string CariHistoryAntena = "select * from history_track where barcode='" + id_barcode + "' order by id DESC limit 1";
                            DataTable Cek_History = new Connect().getTable(CariHistoryAntena);

                            if (Cek_History.Rows.Count > 0)
                            {
                                int HistoryAntena = int.Parse(Cek_History.Rows[0]["antena"].ToString());

                                if (antena == HistoryAntena - 1)
                                {

                                    if (isStartTime)
                                    {
                                        string InsertHistory = "insert into history_track (no_track,barcode,antena,no_rfid,waktu) values('" + Track + "','" + id_barcode + "','" + antena + "' , '" + epc + "','" + waktu + "')";
                                        new Connect().execute(InsertHistory);
                                        stopwatch.Start();
                                        timer1.Start();
                                    }

                                    if (antena == 1 && HistoryAntena == 2)
                                    {
                                        string History = "select * from history where barcode='" + id_barcode + "' order by id DESC limit 1";
                                        DataTable history = new Connect().getTable(History);

                                        if (history.Rows.Count > 0)
                                        {
                                            string Putaran1 = (history.Rows[0]["putaran1"].ToString());
                                            string Putaran2 = (history.Rows[0]["putaran2"].ToString());
                                            string Putaran3 = (history.Rows[0]["putaran3"].ToString());
                                            if (Putaran1 == "0")
                                            {
                                                string UpdateWaktu = "update history set putaran1 = '" + waktu + "' where barcode = '" + id_barcode + "'";
                                                new Connect().execute(UpdateWaktu);

                                                showMessage("Putaran 1", Color.FromArgb(243, 246, 249));
                                                Label_JumlahPutaran.Text = "1";




                                                /*string History1 = "select * from history where barcode='" + id_barcode + "' order by id DESC limit 1";
                                                DataTable history1 = new Connect().getTable(History1);
                                                string waktu_p1 = history.Rows[0]["putaran1"].ToString();*/
                                                Label_Putaran1.Text = waktu;

                                                PlaySoundPutaran1();
                                            }
                                            else if (Putaran2 == "0")
                                            {
                                                string UpdateWaktu = "update history set putaran2 = '" + waktu + "' where barcode = '" + id_barcode + "'";
                                                new Connect().execute(UpdateWaktu);

                                                showMessage("Putaran 2", Color.FromArgb(243, 246, 249));
                                                Label_JumlahPutaran.Text = "2";




                                                /* string History2 = "select * from history where barcode='" + id_barcode + "' order by id DESC limit 1";
                                                 DataTable history2 = new Connect().getTable(History2);
                                                 string waktu_p2 = history.Rows[0]["putaran2"].ToString();*/
                                                Label_Putaran2.Text = waktu;

                                                PlaySoundPutaran2();

                                            }
                                            else if (Putaran3 == "0")
                                            {
                                                /*string UpdateWaktu = "update history set putaran3 = '" + waktu + "' where barcode = '" + id_barcode + "'";
                                                new Connect().execute(UpdateWaktu);
                                                string UpdateWaktuAkhir = "update history set waktu_akhir = '" + waktu + "' where barcode = '" + id_barcode + "'";
                                                new Connect().execute(UpdateWaktuAkhir);

                                                string UpdateStatus = "update history set status = '" + status + "' where barcode = '" + id_barcode + "'";
                                                new Connect().execute(UpdateStatus);

                                                string UpdateAkhir = "update peserta set capaian= '" + waktu + "' where barcode = '" + id_barcode + "'";
                                                new Connect().execute(UpdateAkhir);
                                                //MessageBox.Show("Selesai");*/

                                                string UpdateWaktu = "update history set putaran3 = '" + waktu + "',waktu_akhir = '" + waktu + "',status = 'selesai' where barcode = '" + id_barcode + "'";
                                                new Connect().execute(UpdateWaktu);
                                                Label_JumlahPutaran.Text = "3";


                                                /* string History3 = "select * from history where barcode='" + id_barcode + "' order by id DESC limit 1";
                                                 DataTable history3 = new Connect().getTable(History3);

                                                 string waktu_p3 = history.Rows[0]["putaran3"].ToString();*/
                                                Label_Putaran3.Text = waktu;
                                                stopwatch.Stop();
                                                timer1.Stop();
                                                PlaySoundPutaran3();

                                                postDataNilai(waktu, noPeserta, idtestor);




                                                btnInventory.PerformClick();
                                                btnInventory.Enabled = false;
                                                btnConnect.PerformClick();
                                                btnConnect.Enabled = false;

                                                btn_Ulangi.Show();
                                                isStartTime = false;

                                                LabelNotif.Text = "Finish..";
                                                showMessage("Finish. . Klik Ulangi/NEXT", Color.FromArgb(243, 246, 249));

                                            }
                                        }
                                    }
                                }
                                else if (antena == 4 && HistoryAntena == 1)
                                {
                                    string InsertHistory = "insert into history_track (no_track,barcode,antena,no_rfid,waktu) values('" + Track + "','" + id_barcode + "','" + antena + "' , '" + epc + "','" + waktu + "')";
                                    new Connect().execute(InsertHistory);
                                }

                                else if (antena == HistoryAntena)
                                {
                                    return;
                                }
                                else if (HistoryAntena - 1 >= antena || HistoryAntena - 1 <= antena)
                                {
                                    //string InsertHistory = "insert into history_track (no_track,barcode,antena,no_rfid,waktu) values('" + Track + "','" + id_barcode + "','" + antena + "' , '" + epc + "','" + waktu + "')";
                                    //new Connect().execute(InsertHistory);

                                    //MessageBox.Show ("Salah");
                                    showMessage("Salah", Color.FromArgb(243, 246, 249));
                                    PlaySoundWrongTrack();
                                    //this.Close();
                                }
                            }
                            else
                            {
                                string InsertHistory = "insert into history_track (no_track,barcode,antena,no_rfid,waktu) values('" + Track + "','" + id_barcode + "','" + antena + "' , '" + epc + "','" + waktu + "')";
                                new Connect().execute(InsertHistory);
                                //MessageBox.Show("Isi Disini");
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Track Salah");
                            showMessage("Track Salah", Color.FromArgb(243, 246, 249));
                        }
                    }
                                                           

                    tagdb.Add(tag);
                    SetMaxMinRSSI(Convert.ToInt32(tag.Rssi));
                    txtFastMaxRssi.Text = tagdb.MaxRSSI + "dBm";
                    txtFastMinRssi.Text = tagdb.MinRSSI + "dBm";
                    led_totalread_count.Text = tagdb.TotalReadCounts.ToString();
                    led_total_tagreads.Text = tagdb.TotalTagCounts.ToString();

                    if (needGetBuffer)
                    {
                        tagbufferCount++;
                        //Console.WriteLine("parseInvTag tagbufferCount={0}, {1}", tagbufferCount, tag.BufferTagCount);
                        if (tagbufferCount >= tag.BufferTagCount)
                        {
                            needGetBuffer = false;
                        }
                        if (!needGetBuffer)
                        {
                            stopGetInventoryBuffer(false);
                        }
                    }
                }

            }));

        }

        async void postDataNilai(String waktu, String pesertaid, String idtestor)
        {
            try
            {
                var values = new Dictionary<string, string>
            {
                { "subjenis_test", "SHUTTLE RUN" },
                { "waktu", waktu },
                { "pesertaid", pesertaid },
                { "testorid",idtestor}
            };

                var content = new FormUrlEncodedContent(values);

                string url = System.Configuration.ConfigurationManager.AppSettings["SERVER_API"];
                string route = "/api/v2/garjas/nilai";

                var response = await client.PostAsync(url+route,content);
                var responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmdSwitchAntG1()
        {
            useAntG1 = true;
            tagdb.AntGroup = 0x00;
            cmdSwitchAntGroup(tagdb.AntGroup);
        }

        private void cmdSwitchAntG2()
        {
            useAntG1 = false;
            tagdb.AntGroup = 0x01;
            cmdSwitchAntGroup(tagdb.AntGroup);
        }

        private void cmdSwitchAntGroup(byte groupid)
        {
            int writeIndex = 0;
            byte[] rawData = new byte[256];
            rawData[writeIndex++] = 0xA0; // hdr

            rawData[writeIndex++] = 0x03; // len minLen = 3

            rawData[writeIndex++] = m_curSetting.btReadId; // addr

            rawData[writeIndex++] = (byte)CMD.cmd_set_antenna_group; // cmd

            rawData[writeIndex++] = groupid; // groupId G1=0x00, g2=0x01

            int msgLen = writeIndex + 1;
            rawData[1] = (byte)(msgLen - 2); // except hdr+len
            //Console.WriteLine("cmdSwitchAntGroup writeIndex={0}, msgLen={0}, len={2}", writeIndex, msgLen, rawData[1]);

            rawData[writeIndex] = ReaderUtils.CheckSum(rawData, 0, msgLen - 1); // check
            Array.Resize(ref rawData, msgLen);
            int nResult = reader.SendMessage(rawData);
        }

        private void GenerateColmnsDataGridForInv()
        {
            dgv_fast_inv_tags.AutoGenerateColumns = false;
            dgv_fast_inv_tags.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv_fast_inv_tags.BackgroundColor = Color.White;

            SerialNumber_fast_inv.DataPropertyName = "SerialNumber";
            SerialNumber_fast_inv.HeaderText = "#";

            PC_fast_inv.DataPropertyName = "PC";
            PC_fast_inv.HeaderText = FindResource("PC");

            EPC_fast_inv.DataPropertyName = "EPC";
            EPC_fast_inv.HeaderText = FindResource("EPC");
            EPC_fast_inv.MinimumWidth = 120;
            EPC_fast_inv.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ReadCount_fast_inv.DataPropertyName = "ReadCount";
            ReadCount_fast_inv.HeaderText = FindResource("ReadCount");

            Rssi_fast_inv.DataPropertyName = "Rssi";
            Rssi_fast_inv.HeaderText = FindResource("Rssi");

            Freq_fast_inv.DataPropertyName = "Freq";
            Freq_fast_inv.HeaderText = FindResource("Freq");

            Phase_fast_inv.DataPropertyName = "Phase";
            Phase_fast_inv.HeaderText = FindResource("Phase");
            Phase_fast_inv.Visible = false;

            Antenna_fast_inv.DataPropertyName = "Antenna";
            Antenna_fast_inv.HeaderText = FindResource("Antenna");

            Data_fast_inv.DataPropertyName = "Data";
            Data_fast_inv.HeaderText = FindResource("Data");
            Data_fast_inv.MinimumWidth = 120;
            Data_fast_inv.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Data_fast_inv.Visible = false;
            //dgv_fast_inv_tags.DataSource = tagdb.TagList;
        }

        private void GenerateColmnsDataGridForTagOp()
        {
            dgvTagOp.AutoGenerateColumns = false;
            dgvTagOp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvTagOp.BackgroundColor = Color.White;

            tagOp_SerialNumberColumn.DataPropertyName = "SerialNumber";
            tagOp_SerialNumberColumn.HeaderText = "#";

            tagOp_PcColumn.DataPropertyName = "PC";
            tagOp_PcColumn.HeaderText = FindResource("PC");

            tagOp_CrcColumn.DataPropertyName = "CRC";
            tagOp_CrcColumn.HeaderText = FindResource("CRC");

            tagOp_EpcColumn.DataPropertyName = "EPC";
            tagOp_EpcColumn.HeaderText = FindResource("EPC");
            tagOp_EpcColumn.MinimumWidth = 120;
            tagOp_EpcColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            tagOp_OpCountColumn.DataPropertyName = "ReadCount";
            tagOp_OpCountColumn.HeaderText = FindResource("ReadCount");

            tagOp_OpSuccessCountColumn.DataPropertyName = "opSuccessCount";
            tagOp_OpSuccessCountColumn.HeaderText = FindResource("opSuccessCount");

            tagOp_DataColumn.DataPropertyName = "Data";
            tagOp_DataColumn.HeaderText = FindResource("Data");
            tagOp_DataColumn.MinimumWidth = 120;
            tagOp_DataColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            tagOp_DataLenColumn.DataPropertyName = "DataLen";
            tagOp_DataLenColumn.HeaderText = FindResource("DataLen");

            tagOp_AntennaColumn.DataPropertyName = "Antenna";
            tagOp_AntennaColumn.HeaderText = FindResource("Antenna");

            tagOp_FreqColumn.DataPropertyName = "Freq";
            tagOp_FreqColumn.HeaderText = FindResource("Freq");

            //dgvTagOp.DataSource = tagOpDb.TagList;
        }

        private void cmdGetFrequencyRegion()
        {
            int writeIndex = 0;
            byte[] rawData = new byte[256];
            rawData[writeIndex++] = 0xA0; // hdr

            rawData[writeIndex++] = 0x03; // len minLen = 3

            rawData[writeIndex++] = m_curSetting.btReadId; // addr

            rawData[writeIndex++] = 0x79; // cmd

            // data
            int msgLen = writeIndex + 1;
            rawData[1] = (byte)(msgLen - 2); // except hdr+len
            //Console.WriteLine("cmdGetFrequencyRegion writeIndex={0}, msgLen={0}, len={2}", writeIndex, msgLen, rawData[1]);

            rawData[writeIndex] = ReaderUtils.CheckSum(rawData, 0, msgLen - 1); // check
            Array.Resize(ref rawData, msgLen);
            int nResult = reader.SendMessage(rawData);
        }



        private void R2000UartDemo_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                Constant.fp.ClearMemory();
                Constant.fp.TerminateDevice();
                if (null != transportLogFile)
                {
                    transportLogFile.Close();
                }

                #region NetPort
                StopNetPort();
                #endregion //NetPort

                if (Inventorying)
                {
                    btnInventory_Click_1(null, null);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void saveLog()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text Files (.txt)|*.txt";
            saveFileDialog1.Title = "Select a File to save transport layer logging";
            string strDestinationFile = "InventoryTesting-log"
                /*+ DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") */+ @".txt";
            saveFileDialog1.FileName = strDestinationFile;
            saveFileDialog1.InitialDirectory = Application.StartupPath;
            // Show the Dialog.
            // If the user clicked OK in the dialog and
            // a .txt file was selected, open it.
            if (true)//saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog1.FileName);
                writer.AutoFlush = true;
                transportLogFile = writer;
                // Todo: add callback
            }
            //if (null != transportLogFile)
            //{
            //    transportLogFile.Close();
            //}
        }

        private void saveInventoryToLog(bool useG1, uint times)
        {
            //Console.WriteLine("SaveInventoryToLog [G{0}] {1}", useG1 ? "1":"2", times);
            this.BeginInvoke(new ThreadStart(delegate ()
            {
                if (transportLogFile != null)
                {
                    lock (tagdb)
                    {
                        if (Inventorying)
                        {
                            transportLogFile.Write(String.Format("{0},{1}ms,{2},{3},[{4}], {5}",
                            DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt"),
                            times + "inventory spend" + tagdb.CommandDuration,
                            "use Group" + (useG1 ? "1" : "2"),
                            (ReverseTarget ? ("useTarget" + (invTargetB ? "B," : "A,")) : ""),
                            tagdb.CmdTotalRead,
                            tagdb.CmdUniqueTagCount));

                            transportLogFile.WriteLine();
                            transportLogFile.Flush();
                        }
                        tagdb.CmdUniqueTagCount = 0;
                    }
                }
            }));
        }

        private void parseGetFrequencyRegion(byte[] data)
        {
            //Console.WriteLine("parseGetFrequencyRegion: {0}", ReaderUtils.ToHex(data, "", " "));
            if (tagdb != null)
                tagdb.UpdateRegionInfo(data);
            if (tagOpDb != null)
                tagOpDb.UpdateRegionInfo(data);
        }

        private void cb_fast_inv_check_all_ant_CheckedChanged(object sender, EventArgs e)
        {
            bool check = cb_fast_inv_check_all_ant.Checked;
            foreach (CheckBox cb in fast_inv_ants)
            {
                cb.Checked = check;
            }
        }

        private void btn_refresh_comports_Click(object sender, EventArgs e)
        {
            RefreshComPorts();
        }

        private void cb_fast_inv_reverse_target_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_fast_inv_reverse_target.Checked)
            {
                ReverseTarget = true;
                invTargetB = false;
                stayBTimes = Convert.ToInt32(tb_fast_inv_staytargetB_times.Text);
            }
            else
            {
                ReverseTarget = false;
            }
        }

        private void cb_use_selectFlags_tempPows_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_use_selectFlags_tempPows.Checked)
            {
                if (radio_btn_fast_inv.Checked)
                {
                    cb_use_optimize.Checked = false;
                    tb_fast_inv_reserved_5.Visible = false; // reserver 5 disable
                    grb_selectFlags.Visible = true;//SL

                    grb_temp_pow_ants_g1.Visible = true;
                    if (channels > 8)
                        grb_temp_pow_ants_g2.Visible = true;
                    for (int i = 0; i < channels; i++)
                    {
                        fast_inv_temp_pows[i].Enabled = true;
                    }
                }
                else
                {
                    grb_selectFlags.Visible = true;
                }
            }
            else
            {
                if (radio_btn_fast_inv.Checked)
                {
                    tb_fast_inv_reserved_5.Visible = true;
                    grb_selectFlags.Visible = false;//SL

                    grb_temp_pow_ants_g1.Visible = false;
                    grb_temp_pow_ants_g2.Visible = false;
                }
                else
                {
                    cb_use_powerSave.Checked = false;
                    grb_selectFlags.Visible = false;
                }
            }
        }

        private void cb_use_Phase_CheckedChanged(object sender, EventArgs e)
        {
            Phase_fast_inv.Visible = cb_use_Phase.Checked;
            if (radio_btn_realtime_inv.Checked && cb_use_Phase.Checked)
            {
                cb_use_selectFlags_tempPows.Checked = true;
            }
        }

        private void InventoryTypeChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("InventoryTypeChanged channels={0}", channels);
            if (radio_btn_fast_inv.Checked)
            {
                grb_multi_ant.Visible = true;
                grb_cache_inv.Visible = false;
                grb_inventory_cfg.Visible = true;

                cb_use_powerSave.Checked = false;
                cb_use_powerSave.Visible = false;
                grb_real_inv_ants.Visible = false;

                grb_Interval.Visible = true;//Interval
                grb_Reserve.Visible = false;

                cb_customized_session_target.Enabled = true;
                cb_customized_session_target.Checked = false;
                cb_use_selectFlags_tempPows.Checked = false;
                cb_use_selectFlags_tempPows.Text = FindResource("useCmd8A25");
                cb_use_selectFlags_tempPows.Visible = false;
                grb_selectFlags.Visible = false;//SL

                grb_sessions.Visible = false;//Session
                grb_targets.Visible = false;//Target
                grb_temp_pow_ants_g1.Visible = false;//Power
                grb_temp_pow_ants_g2.Visible = false;

                cb_use_powerSave.Checked = false;
                grb_powerSave.Visible = false;

                grb_ants_g1.Visible = true;//Antenna 
                if (channels > 8)
                {
                    grb_ants_g2.Visible = true;
                }
                else
                {
                    grb_ants_g2.Visible = false;
                }
                for (int i = 0; i < 16; i++)
                {
                    if (i < channels)
                    {
                        if (i == 0)
                        {
                            fast_inv_ants[i].Checked = true;
                        }
                        fast_inv_ants[i].Visible = true;
                        fast_inv_stays[i].Visible = true;
                        fast_inv_temp_pows[i].Visible = true;
                    }
                    else
                    {
                        fast_inv_ants[i].Visible = false;
                        fast_inv_stays[i].Visible = false;
                        fast_inv_temp_pows[i].Visible = false;
                    }
                }

                cb_use_optimize.Checked = false;
                cb_use_optimize.Visible = false;
                grb_Optimize.Visible = false;
                grb_Ongoing.Visible = false;
                grb_TargetQuantity.Visible = false;

                cb_use_Phase.Checked = false;
                cb_use_Phase.Visible = false;//Phase
                grb_Repeat.Visible = true;//Repeat
                cb_customized_session_target_CheckedChanged(null, null);
            }
            else if (radio_btn_realtime_inv.Checked)
            {
                grb_multi_ant.Visible = false;
                grb_cache_inv.Visible = false;
                grb_inventory_cfg.Visible = true;

                grb_ants_g1.Visible = false;//Antenna
                grb_ants_g2.Visible = false;
                grb_temp_pow_ants_g1.Visible = false;//Power
                grb_temp_pow_ants_g2.Visible = false;

                grb_real_inv_ants.Visible = true;
                antLists.Clear();
                for (int i = 1; i <= channels; i++)
                {
                    antLists.Add(string.Format("{0}{1}", FindResource("Antenna"), i));
                }
                combo_realtime_inv_ants.Items.Clear();
                combo_realtime_inv_ants.Items.AddRange(antLists.ToArray());
                combo_realtime_inv_ants.SelectedIndex = 0;

                grb_Interval.Visible = false;//Interval
                grb_Reserve.Visible = false;

                cb_customized_session_target.Checked = true; // for disable use 89 Cmd
                cb_customized_session_target.Enabled = false;
                cb_use_selectFlags_tempPows.Checked = false;
                cb_use_selectFlags_tempPows.Text = "SL";
                grb_selectFlags.Visible = false;

                grb_sessions.Visible = false;
                grb_targets.Visible = false;

                cb_use_powerSave.Checked = false;
                grb_powerSave.Visible = false;

                cb_use_optimize.Checked = false;
                cb_use_optimize.Visible = false;
                grb_Optimize.Visible = false;
                grb_Ongoing.Visible = false;
                grb_TargetQuantity.Visible = false;

                cb_use_Phase.Checked = false;
                cb_use_Phase.Visible = false;//Phase

                grb_Repeat.Visible = true;//Repeat
                cb_customized_session_target_CheckedChanged(null, null);
            }
            else if (radio_btn_cache_inv.Checked)
            {
                cb_customized_session_target.Enabled = true;
                grb_multi_ant.Visible = false;
                grb_cache_inv.Visible = true;

                grb_real_inv_ants.Visible = true;
                antLists.Clear();
                for (int i = 1; i <= channels; i++)
                {
                    antLists.Add(string.Format("{0}{1}", FindResource("Antenna"), i));
                }
                combo_realtime_inv_ants.Items.Clear();
                combo_realtime_inv_ants.Items.AddRange(antLists.ToArray());
                combo_realtime_inv_ants.SelectedIndex = 0;

                grb_inventory_cfg.Visible = false;
                grb_Interval.Visible = false;
                grb_Reserve.Visible = false;
                grb_selectFlags.Visible = false;
                grb_sessions.Visible = false;
                grb_targets.Visible = false;
                grb_Optimize.Visible = false;
                grb_Ongoing.Visible = false;
                grb_TargetQuantity.Visible = false;
                grb_powerSave.Visible = false;
                grb_Repeat.Visible = true;

                grb_ants_g1.Visible = false;
                grb_ants_g2.Visible = false;
                grb_temp_pow_ants_g1.Visible = false;
                grb_temp_pow_ants_g2.Visible = false;
            }
        }

        private void cb_use_powerSave_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_use_powerSave.Checked)
            {
                cb_use_selectFlags_tempPows.Checked = true;
                grb_powerSave.Visible = true;
            }
            else
            {
                grb_powerSave.Visible = false;
            }
        }

        private void cb_use_optimize_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_use_optimize.Checked)
            {
                cb_use_selectFlags_tempPows.Checked = false;
                grb_Optimize.Visible = true;
                grb_Ongoing.Visible = true;
                grb_TargetQuantity.Visible = true;
            }
            else
            {
                grb_Optimize.Visible = false;
                grb_Ongoing.Visible = false;
                grb_TargetQuantity.Visible = false;
            }
        }

        private void btnInventory_Click_1(object sender, EventArgs e)
        {

            showMessage("Track Siap !!", Color.FromArgb(243, 246, 249));
            btn_Reload.Enabled = false;
            stopwatch.Stop();
            timer1.Stop();
            if (radio_btn_fast_inv.Checked)
            {
                //stopwatch.Start();
               
                FastInventory_Click(sender, e);
            }
            else if (radio_btn_realtime_inv.Checked)
            {
                //stopwatch.Start();
                RealTimeInventory_Click(sender, e);
            }
            else if (radio_btn_cache_inv.Checked)
            {
                //stopwatch.Start();
                CachedInventory_Click(sender, e);
            }
        }

        private void CachedInventory_Click(object sender, EventArgs e)
        {
            if (btnInventory.Text.Equals(FindResource("StartInventory")))
            {

                if (Inventorying)
                {
                    MessageBox.Show(FindResource("Inventorying"));
                    return;

                }

                try
                {
                    if (mInventoryExeCount.Text.Length == 0)
                    {
                        //aaaaaa

                        MessageBox.Show("Please input ExeCount");
                        return;
                    }

                    btnInventory.BackColor = Color.DarkBlue;
                    btnInventory.ForeColor = Color.White;
                    btnInventory.Text = FindResource("StopInventory");

                    isBufferInv = true;
                    doingBufferInv = true;
                    Inventorying = true;
                    startInventoryTime = DateTime.Now;
                    dispatcherTimer.Start();
                    readratePerSecond.Start();
                    tagbufferCount = 0;
                    m_FastExeCount = Convert.ToInt32(mInventoryExeCount.Text);
                    startCachedInv();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (btnInventory.Text.Equals(FindResource("StopInventory")))
            {

                SetInvStopingStatus();
                isBufferInv = false;

            }
        }

        private void startCachedInv()
        {
            int antId = combo_realtime_inv_ants.SelectedIndex;
            if (antId >= 8)
            {
                m_curSetting.btWorkAntenna = (byte)(antId - 8);
                cmdSwitchAntG2();
            }
            else
            {
                useAntG1 = true;
                tagdb.AntGroup = 0x00;
                m_curSetting.btWorkAntenna = (byte)antId;
                reader.SetWorkAntenna(m_curSetting.btReadId, m_curSetting.btWorkAntenna);
            }
        }

        private void RealTimeInventory_Click(object sender, EventArgs e)
        {
            if (btnInventory.Text.Equals(FindResource("StartInventory")))
            {
                if (Inventorying)
                {
                    MessageBox.Show(FindResource("Inventorying"));
                    return;
                }

                try
                {
                    if (mInventoryExeCount.Text.Length == 0)
                    {
                        MessageBox.Show("Please input ExeCount");
                        return;
                    }

                    btnInventory.BackColor = Color.DarkBlue;
                    btnInventory.ForeColor = Color.White;
                    btnInventory.Text = FindResource("StopInventory");

                    isRealInv = true;
                    doingRealInv = true;
                    Inventorying = true;
                    startInventoryTime = DateTime.Now;
                    dispatcherTimer.Start();
                    readratePerSecond.Start();
                    m_FastExeCount = Convert.ToInt32(mInventoryExeCount.Text);
                    startRealtimeInv();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (btnInventory.Text.Equals(FindResource("StopInventory")))
            {
                if (Inventorying)
                {
                    SetInvStopingStatus();
                    isRealInv = false;
                }
            }
        }

        private void btnGetBuffer_Click(object sender, EventArgs e)
        {
            if (btnGetBuffer.Text.Equals(FindResource("GetBuffer")))
            {
                btnGetBuffer.Text = FindResource("GettingBuffer");
                tagbufferCount = 0;
                needGetBuffer = true;
                startInventoryTime = DateTime.Now;
                dispatcherTimer.Start();
                readratePerSecond.Start();
                //Console.WriteLine("btnGetBuffer_Click startInventoryTime={0}", startInventoryTime.ToString("yyyy-MM-dd hh:mm:ss ffff"));
                cmdGetInventoryBuffer();
            }
            else if (btnGetBuffer.Text.Equals(FindResource("GettingBuffer")))
            {
                stopGetInventoryBuffer(false);
            }
        }

        private void btnGetAndClearBuffer_Click(object sender, EventArgs e)
        {
            if (btnGetAndClearBuffer.Text.Equals(FindResource("GetAndClearBuffer")))
            {
                btnGetAndClearBuffer.Text = FindResource("GettingBuffer");
                tagbufferCount = 0;
                needGetBuffer = true;
                startInventoryTime = DateTime.Now;
                dispatcherTimer.Start();
                readratePerSecond.Start();
                //Console.WriteLine("btnGetAndClearBuffer_Click startInventoryTime={0}", startInventoryTime.ToString("yyyy-MM-dd hh:mm:ss ffff"));
                cmdGetAndResetInventoryBuffer();
            }
            else if (btnGetAndClearBuffer.Text.Equals(FindResource("GettingBuffer")))
            {
                stopGetInventoryBuffer(true);
            }
        }

        private void btnClearBuffer_Click(object sender, EventArgs e)
        {
            reader.ResetInventoryBuffer(m_curSetting.btReadId);
        }

        private void btnGetBufferTagCount_Click(object sender, EventArgs e)
        {
            reader.GetInventoryBufferTagCount(m_curSetting.btReadId);
        }

        private void MembankCheckChanged(object sender, EventArgs e)
        {
            if (rdbEpc.Checked)
            {
                tb_startWord.Text = "2";
            }
            else
            {
                tb_startWord.Text = "0";
            }
        }

        private void cb_tagFocus_CheckedChanged(object sender, EventArgs e)
        {
            reader.SetMonzaStatus(m_curSetting.btReadId, cb_tagFocus.Checked ? (byte)0x8C : (byte)0x00);
        }

        #region NetPort
        UDPThread tUdp = null;

        //NetCard DB
        NetCardDB ncdb = null;
        //NetPort device DB
        NetPortDB netPortDB = null;

        //Initializes the WCH CH9121 device list
        private void initDgvNetPort()
        {
            dgvNetPort.AutoGenerateColumns = false;
            npSerialNumberColumn.DataPropertyName = "SerialNumber";
            npSerialNumberColumn.HeaderText = "#";
            npSerialNumberColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            npDeviceNameColumn.DataPropertyName = "DeviceName";
            npDeviceNameColumn.HeaderText = FindResource("npDeviceName");
            npDeviceNameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            npDeviceIpColumn.DataPropertyName = "DeviceIp";
            npDeviceIpColumn.HeaderText = FindResource("npDeviceIp");
            npDeviceIpColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            npDeviceMacColumn.DataPropertyName = "DeviceMac";
            npDeviceMacColumn.HeaderText = FindResource("npDeviceMac");
            npDeviceMacColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            npChipVerColumn.DataPropertyName = "ChipVer";
            npChipVerColumn.HeaderText = FindResource("npChipVer");
            npChipVerColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            npPcMacColumn.DataPropertyName = "PcMac";
            npPcMacColumn.HeaderText = FindResource("npPcMac");
            npPcMacColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (netPortDB == null)
                netPortDB = new NetPortDB();
            dgvNetPort.DataSource = null;
            dgvNetPort.DataSource = netPortDB.NetPortList;
        }

        //Initializes NetPort UI
        private void initDgvNetPortUI()
        {
            //cmbbxPort0NetMode.ItemsSource = Enum.GetValues(typeof(NETPORT_TYPE));
            //cmbbxPort0BaudRate.ItemsSource = Enum.GetValues(typeof(NETPORT_Baudrate));
            //cmbbxPort0DataSize.ItemsSource = Enum.GetValues(typeof(NETPORT_DataSize));
            //cmbbxPort0StopBits.ItemsSource = Enum.GetValues(typeof(NETPORT_StopBits));
            //cmbbxPort0Parity.ItemsSource = Enum.GetValues(typeof(NETPORT_Parity));

            cmbbxPort1_NetMode.DataSource = Enum.GetValues(typeof(NETPORT_TYPE));
            cmbbxPort1_BaudRate.DataSource = Enum.GetValues(typeof(NETPORT_Baudrate));
            cmbbxPort1_DataSize.DataSource = Enum.GetValues(typeof(NETPORT_DataSize));
            cmbbxPort1_StopBits.DataSource = Enum.GetValues(typeof(NETPORT_StopBits));
            cmbbxPort1_Parity.DataSource = Enum.GetValues(typeof(NETPORT_Parity));

            chkbxPort0PortEn_CheckedChanged(null, null);
            if (tUdp == null)
            {
                tUdp = new UDPThread();
                tUdp.NetCommRead += TUdp_NetCommRead;
            }
        }

        private void TUdp_NetCommRead(object sender, NetCommEventArgs e)
        {
            BeginInvoke(new ThreadStart(delegate () {
                tUdp.StopSearchNetPort();
            }));

            NET_COMM comm = e.NetComm;
            if (comm.Cmd == (int)NET_CMD.NET_MODULE_ACK_SEARCH)
            {
                BeginInvoke(new ThreadStart(delegate () {
                    netPortDB.Add(comm);
                    //WriteLog(lrtxtLog, string.Format("Recv: {0}", comm.FoundDev.ToString()), 1);
                }));

                BeginInvoke(new ThreadStart(delegate () {
                    lblNetPortCount.Text = string.Format("NetPort Device: {0}", netPortDB.GetCount());
                }));
            }
            if (comm.Cmd == (int)NET_CMD.NET_MODULE_ACK_RESEST)
            {
                BeginInvoke(new ThreadStart(delegate () {
                    btnResetNetport.Text = FindResource("npReset");
                    MessageBox.Show(string.Format("Reset Cfg Sucessful, Please ReSearch NetPort and ReGet to update this result"), "Reset Sucessful");
                }));
                netStartReset = false;
            }
            if (comm.Cmd == (int)NET_CMD.NET_MODULE_ACK_GET
                | comm.Cmd == (int)NET_CMD.NET_MODULE_ACK_SET)
            {
                BeginInvoke(new ThreadStart(delegate ()
                {
                    #region //NET_COMM
                    //txtbxHwCfgMajor.Text = string.Format("{0}", comm.HWConfig.DevType);
                    //txtbxHwCfgMinor.Text = string.Format("{0}", comm.HWConfig.AuxDevType);
                    //txtbxHwCfgIndex.Text = string.Format("{0}", comm.HWConfig.Index);
                    txtbxHwCfgDeviceName.Text = string.Format("{0}", comm.HWConfig.Modulename);
                    //txtbxHwCfgDeviceHwVer.Text = string.Format("{0}", comm.HWConfig.DevHardwareVer);
                    //txtbxHwCfgDeviceSwVer.Text = string.Format("{0}", comm.HWConfig.DevSoftwareVer);
                    txtbxHwCfgMac.Text = string.Format("{0}", comm.HWConfig.DevMAC);
                    txtbxHwCfgIp.Text = string.Format("{0}", comm.HWConfig.DevIP);
                    txtbxHwCfgMask.Text = string.Format("{0}", comm.HWConfig.DevIPMask);
                    txtbxHwCfgGateway.Text = string.Format("{0}", comm.HWConfig.DevGWIP);
                    chkbxHwCfgDhcpEn.Checked = comm.HWConfig.DhcpEnable;
                    //txtbxHwCfgWebPort.Text = string.Format("{0}", comm.HWConfig.WebPort);
                    //txtbxHwCfgUserName.Text = string.Format("{0}", comm.HWConfig.Username);
                    //chkbxHwCfgPwdEn.Checked = comm.HWConfig.PassWordEn;
                    //txtbxHwCfgPwd.Text = string.Format("{0}", comm.HWConfig.PassWord);
                    //chkbxHwCfgUpdateEn.Checked = comm.HWConfig.UpdateFlag;
                    chkbxHwCfgComCfgEn.Checked = comm.HWConfig.ComcfgEn;
                    //txtbxHwCfgReserved.Text = string.Format("{0}", comm.HWConfig.Reserved);
                    //Port_0
                    //txtbxPort0Index.Text = string.Format("{0}", comm.PortCfg_0.Index);
                    chkbxPort0PortEn.Checked = comm.PortCfg_0.PortEn;
                    //if (cmbbxPort0NetMode.Items.Contains((NETPORT_TYPE)comm.PortCfg_0.NetMode))
                    //{
                    //    cmbbxPort0NetMode.SelectedItem = (NETPORT_TYPE)comm.PortCfg_0.NetMode;
                    //}
                    //else
                    //{
                    //    LogReturnValue(string.Format("Port0 Not support: {0}", cmbbxPort0NetMode));
                    //}
                    //chkbxPort0RandEn.IsChecked = comm.PortCfg_0.RandSportFlag;
                    //txtbxPort0NetPort.Text = string.Format("{0}", comm.PortCfg_0.NetPort);
                    //txtbxPort0DesIp.Text = string.Format("{0}", comm.PortCfg_0.DesIP);
                    //txtbxPort0DesPort.Text = string.Format("{0}", comm.PortCfg_0.DesPort);
                    //chkbxPort0PortEn.IsChecked = comm.PortCfg_0.PortEn;
                    //if (cmbbxPort0BaudRate.Items.Contains((NETPORT_Baudrate)comm.PortCfg_0.BaudRate))
                    //{
                    //    cmbbxPort0BaudRate.SelectedItem = (NETPORT_Baudrate)comm.PortCfg_0.BaudRate;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Not support BaudRate " + comm.PortCfg_0.BaudRate);
                    //    return;
                    //}

                    //if (cmbbxPort0DataSize.Items.Contains((NETPORT_DataSize)comm.PortCfg_0.DataSize))
                    //{
                    //    cmbbxPort0DataSize.SelectedItem = (NETPORT_DataSize)comm.PortCfg_0.DataSize;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Not support DataSize " + comm.PortCfg_0.DataSize);
                    //    return;
                    //}

                    //if (cmbbxPort0StopBits.Items.Contains((NETPORT_StopBits)comm.PortCfg_0.StopBits))
                    //{
                    //    cmbbxPort0StopBits.SelectedItem = (NETPORT_StopBits)comm.PortCfg_0.StopBits;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Not support StopBits " + comm.PortCfg_0.StopBits);
                    //    return;
                    //}

                    //if (cmbbxPort0Parity.Items.Contains((NETPORT_Parity)comm.PortCfg_0.Parity))
                    //{
                    //    cmbbxPort0Parity.SelectedItem = (NETPORT_Parity)comm.PortCfg_0.Parity;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Not support Parity " + comm.PortCfg_0.Parity);
                    //    return;
                    //}

                    //chkbxPort0PhyDisconnect.IsChecked = comm.PortCfg_0.PHYChangeHandle;
                    //txtbxPort0RxPkgLen.Text = string.Format("{0}", comm.PortCfg_0.RxPktlength);
                    //txtbxPort0RxTimeout.Text = string.Format("{0}", comm.PortCfg_0.RxPktTimeout);
                    txtbxHeartbeatInterval.Text = string.Format("{0}", comm.PortCfg_0.RxPktTimeout);
                    //txtbxPort0ReConnectCnt.Text = string.Format("{0}", comm.PortCfg_0.ReConnectCnt);
                    //chkbxPort0ResetCtrl.IsChecked = comm.PortCfg_0.ResetCtrl;
                    //chkbxPort0DnsFlag.IsChecked = comm.PortCfg_0.DNSFlag;
                    //txtbxPort0DnsDomain.Text = string.Format("{0}", comm.PortCfg_0.Domainname);
                    txtbxHeartbeatContent.Text = string.Format("{0}", comm.PortCfg_0.Domainname);
                    //txtbxPort0DnsIp.Text = string.Format("{0}", comm.PortCfg_0.DNSHostIP);
                    //txtbxPort0Dnsport.Text = string.Format("{0}", comm.PortCfg_0.DNSHostPort);
                    //txtbxPort0Reserved.Text = string.Format("{0}", comm.PortCfg_0.Reserved);
                    ////Port_1
                    ////txtbxPort1_Index.Text = string.Format("{0}", comm.PortCfg_1.Index);
                    chkbxPort1_PortEn.Checked = comm.PortCfg_1.PortEn;
                    if (cmbbxPort1_NetMode.Items.Contains((NETPORT_TYPE)comm.PortCfg_1.NetMode))
                    {
                        cmbbxPort1_NetMode.SelectedItem = (NETPORT_TYPE)comm.PortCfg_1.NetMode;
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Port1 Not support: {0}", cmbbxPort1_NetMode));
                    }
                    chkbxPort1_RandEn.Checked = comm.PortCfg_1.RandSportFlag;
                    txtbxPort1_NetPort.Text = string.Format("{0}", comm.PortCfg_1.NetPort);
                    txtbxPort1_DesIp.Text = string.Format("{0}", comm.PortCfg_1.DesIP);
                    txtbxPort1_DesPort.Text = string.Format("{0}", comm.PortCfg_1.DesPort);
                    if (cmbbxPort1_BaudRate.Items.Contains((NETPORT_Baudrate)comm.PortCfg_1.BaudRate))
                    {
                        cmbbxPort1_BaudRate.SelectedItem = (NETPORT_Baudrate)comm.PortCfg_1.BaudRate;
                    }
                    else
                    {
                        MessageBox.Show("Not support BaudRate " + comm.PortCfg_1.BaudRate);
                        return;
                    }

                    if (cmbbxPort1_DataSize.Items.Contains((NETPORT_DataSize)comm.PortCfg_1.DataSize))
                    {
                        cmbbxPort1_DataSize.SelectedItem = (NETPORT_DataSize)comm.PortCfg_1.DataSize;
                    }
                    else
                    {
                        MessageBox.Show("Not support DataSize " + comm.PortCfg_1.DataSize);
                        return;
                    }

                    if (cmbbxPort1_StopBits.Items.Contains((NETPORT_StopBits)comm.PortCfg_1.StopBits))
                    {
                        cmbbxPort1_StopBits.SelectedItem = (NETPORT_StopBits)comm.PortCfg_1.StopBits;
                    }
                    else
                    {
                        MessageBox.Show("Not support StopBits " + comm.PortCfg_1.StopBits);
                        return;
                    }

                    if (cmbbxPort1_Parity.Items.Contains((NETPORT_Parity)comm.PortCfg_1.Parity))
                    {
                        cmbbxPort1_Parity.SelectedItem = (NETPORT_Parity)comm.PortCfg_1.Parity;
                    }
                    else
                    {
                        MessageBox.Show("Not support Parity " + comm.PortCfg_1.Parity);
                        return;
                    }
                    chkbxPort1_PhyDisconnect.Checked = comm.PortCfg_1.PHYChangeHandle;
                    txtbxPort1_RxPkgLen.Text = string.Format("{0}", comm.PortCfg_1.RxPktlength);
                    txtbxPort1_RxTimeout.Text = string.Format("{0}", comm.PortCfg_1.RxPktTimeout);
                    txtbxPort1_ReConnectCnt.Text = string.Format("{0}", comm.PortCfg_1.ReConnectCnt);
                    chkbxPort1_ResetCtrl.Checked = comm.PortCfg_1.ResetCtrl;
                    //chkbxPort1_DnsFlag.Checked = comm.PortCfg_1.DNSFlag;
                    txtbxPort1_DnsDomain.Text = string.Format("{0}", comm.PortCfg_1.Domainname);
                    txtbxPort1_DnsIp.Text = string.Format("{0}", comm.PortCfg_1.DNSHostIP);
                    txtbxPort1_Dnsport.Text = string.Format("{0}", comm.PortCfg_1.DNSHostPort);
                    //txtbxPort1_Reserved.Text = string.Format("{0}", comm.PortCfg_1.Reserved);
                    #endregion //NET_COMM
                    if (comm.Cmd == (int)NET_CMD.NET_MODULE_ACK_GET)
                    {
                        btnGetNetport.Text = FindResource("npGet");
                        netStartGet = false;
                        MessageBox.Show(string.Format("Get Cfg Sucessful"), "GetCfg Sucessful");
                    }
                    if (comm.Cmd == (int)NET_CMD.NET_MODULE_ACK_SET)
                    {
                        btnSetNetport.Text = FindResource("npSave");
                        netStartSave = false;

                        btnDefaultNetPort.Text = FindResource("npDefault");
                        netStartDefault = false;

                        MessageBox.Show(string.Format("Save/Default Cfg Sucessful"), "Save/Default Sucessful");
                    }
                }));
            }
        }

        //Search for the network card
        private void btnSearchNetCard_Click(object sender, EventArgs e)
        {
            ManagementObjectSearcher mObjs = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration where IPenabled=true");
            if (mObjs.Get().Count == 0)
            {
                MessageBox.Show("No NetCard Found");
                return;
            }
            foreach (ManagementObject mObj in mObjs.Get())
            {
                String desc = mObj.GetPropertyValue("Description").ToString();
                String[] ipAddr = (String[])mObj.GetPropertyValue("IPAddress");
                String pcIpaddr = String.Join(", ", ipAddr, 0, (ipAddr.Length > 1 ? 1 : 0));

                String[] subNet = (String[])mObj.GetPropertyValue("IPSubnet");
                String pcMask = String.Join("", subNet, 0, (subNet.Length > 1 ? 1 : 0));

                String pcMac = mObj.GetPropertyValue("MACAddress").ToString();

                NetCard nc = new NetCard(desc, pcIpaddr, pcMask, pcMac);
                ncdb.Add(nc);
            }
            cmbbxNetCard_SelectedIndexChanged(null, null);
        }
        //Switch NetCard
        private void cmbbxNetCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbxNetCard.Items.Count > 0)
            {
                tUdp.CurNetCard = (NetCard)cmbbxNetCard.SelectedItem;
                lblCurNetcard.Text = string.Format("ip:{0}, mask: {1}, mac: ", tUdp.CurNetCard.Ip, tUdp.CurNetCard.Mask);
                lblCurPcMac.Text = string.Format("{0}", tUdp.CurNetCard.Mac);
            }
        }

        //Clear the NetPort device list and the NetPort database
        private void btnClearNetPort_Click(object sender, EventArgs e)
        {
            netPortDB.Clear();

            BeginInvoke(new ThreadStart(delegate () {
                lblNetPortCount.Text = "";
                #region //NET_COMM
                //txtbxHwCfgMajor.Text = string.Format("{0}", comm.HWConfig.DevType);
                //txtbxHwCfgMinor.Text = string.Format("{0}", comm.HWConfig.AuxDevType);
                //txtbxHwCfgIndex.Text = string.Format("{0}", comm.HWConfig.Index);
                txtbxHwCfgDeviceName.Text = "";
                //txtbxHwCfgDeviceHwVer.Text = string.Format("{0}", comm.HWConfig.DevHardwareVer);
                //txtbxHwCfgDeviceSwVer.Text = string.Format("{0}", comm.HWConfig.DevSoftwareVer);
                txtbxHwCfgMac.Text = "";
                txtbxHwCfgIp.Text = "";
                txtbxHwCfgMask.Text = "";
                txtbxHwCfgGateway.Text = "";
                chkbxHwCfgDhcpEn.Checked = false;
                //txtbxHwCfgWebPort.Text = string.Format("{0}", comm.HWConfig.WebPort);
                //txtbxHwCfgUserName.Text = string.Format("{0}", comm.HWConfig.Username);
                //chkbxHwCfgPwdEn.Checked = comm.HWConfig.PassWordEn;
                //txtbxHwCfgPwd.Text = string.Format("{0}", comm.HWConfig.PassWord);
                //chkbxHwCfgUpdateEn.Checked = comm.HWConfig.UpdateFlag;
                chkbxHwCfgComCfgEn.Checked = false;
                //txtbxHwCfgReserved.Text = string.Format("{0}", comm.HWConfig.Reserved);
                //Port_0
                //txtbxPort0Index.Text = string.Format("{0}", comm.PortCfg_0.Index);
                chkbxPort0PortEn.Checked = false;
                //if (cmbbxPort0NetMode.Items.Contains((NETPORT_TYPE)comm.PortCfg_0.NetMode))
                //{
                //    cmbbxPort0NetMode.SelectedItem = (NETPORT_TYPE)comm.PortCfg_0.NetMode;
                //}
                //else
                //{
                //    LogReturnValue(string.Format("Port0 Not support: {0}", cmbbxPort0NetMode));
                //}
                //chkbxPort0RandEn.IsChecked = comm.PortCfg_0.RandSportFlag;
                //txtbxPort0NetPort.Text = string.Format("{0}", comm.PortCfg_0.NetPort);
                //txtbxPort0DesIp.Text = string.Format("{0}", comm.PortCfg_0.DesIP);
                //txtbxPort0DesPort.Text = string.Format("{0}", comm.PortCfg_0.DesPort);
                //chkbxPort0PortEn.IsChecked = comm.PortCfg_0.PortEn;
                //if (cmbbxPort0BaudRate.Items.Contains((NETPORT_Baudrate)comm.PortCfg_0.BaudRate))
                //{
                //    cmbbxPort0BaudRate.SelectedItem = (NETPORT_Baudrate)comm.PortCfg_0.BaudRate;
                //}
                //else
                //{
                //    MessageBox.Show("Not support BaudRate " + comm.PortCfg_0.BaudRate);
                //    return;
                //}

                //if (cmbbxPort0DataSize.Items.Contains((NETPORT_DataSize)comm.PortCfg_0.DataSize))
                //{
                //    cmbbxPort0DataSize.SelectedItem = (NETPORT_DataSize)comm.PortCfg_0.DataSize;
                //}
                //else
                //{
                //    MessageBox.Show("Not support DataSize " + comm.PortCfg_0.DataSize);
                //    return;
                //}

                //if (cmbbxPort0StopBits.Items.Contains((NETPORT_StopBits)comm.PortCfg_0.StopBits))
                //{
                //    cmbbxPort0StopBits.SelectedItem = (NETPORT_StopBits)comm.PortCfg_0.StopBits;
                //}
                //else
                //{
                //    MessageBox.Show("Not support StopBits " + comm.PortCfg_0.StopBits);
                //    return;
                //}

                //if (cmbbxPort0Parity.Items.Contains((NETPORT_Parity)comm.PortCfg_0.Parity))
                //{
                //    cmbbxPort0Parity.SelectedItem = (NETPORT_Parity)comm.PortCfg_0.Parity;
                //}
                //else
                //{
                //    MessageBox.Show("Not support Parity " + comm.PortCfg_0.Parity);
                //    return;
                //}

                //chkbxPort0PhyDisconnect.IsChecked = comm.PortCfg_0.PHYChangeHandle;
                //txtbxPort0RxPkgLen.Text = string.Format("{0}", comm.PortCfg_0.RxPktlength);
                //txtbxPort0RxTimeout.Text = string.Format("{0}", comm.PortCfg_0.RxPktTimeout);
                txtbxHeartbeatInterval.Text = "";
                //txtbxPort0ReConnectCnt.Text = string.Format("{0}", comm.PortCfg_0.ReConnectCnt);
                //chkbxPort0ResetCtrl.IsChecked = comm.PortCfg_0.ResetCtrl;
                //chkbxPort0DnsFlag.IsChecked = comm.PortCfg_0.DNSFlag;
                //txtbxPort0DnsDomain.Text = string.Format("{0}", comm.PortCfg_0.Domainname);
                txtbxHeartbeatContent.Text = "";
                //txtbxPort0DnsIp.Text = string.Format("{0}", comm.PortCfg_0.DNSHostIP);
                //txtbxPort0Dnsport.Text = string.Format("{0}", comm.PortCfg_0.DNSHostPort);
                //txtbxPort0Reserved.Text = string.Format("{0}", comm.PortCfg_0.Reserved);
                ////Port_1
                ////txtbxPort1_Index.Text = string.Format("{0}", comm.PortCfg_1.Index);
                chkbxPort1_PortEn.Checked = false;
                cmbbxPort1_NetMode.SelectedIndex = -1;
                chkbxPort1_RandEn.Checked = false;
                txtbxPort1_NetPort.Text = "";
                txtbxPort1_DesIp.Text = "";
                txtbxPort1_DesPort.Text = "";
                cmbbxPort1_BaudRate.SelectedIndex = -1;
                cmbbxPort1_DataSize.SelectedIndex = -1;
                cmbbxPort1_StopBits.SelectedIndex = -1;
                cmbbxPort1_Parity.SelectedIndex = -1;
                chkbxPort1_PhyDisconnect.Checked = false;
                txtbxPort1_RxPkgLen.Text = "";
                txtbxPort1_RxTimeout.Text = "";
                txtbxPort1_ReConnectCnt.Text = "";
                chkbxPort1_ResetCtrl.Checked = false;
                //chkbxPort1_DnsFlag.Checked = comm.PortCfg_1.DNSFlag;
                txtbxPort1_DnsDomain.Text = "";
                txtbxPort1_DnsIp.Text = "";
                txtbxPort1_Dnsport.Text = "";
                //txtbxPort1_Reserved.Text = string.Format("{0}", comm.PortCfg_1.Reserved);
                #endregion //NET_COMM
            }));
        }

        private void linklblOldNetPortCfgTool_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://drive.263.net/link/41OTclS6USY4fTc/";
            Process.Start(url);
        }

        private void linklblNetPortCfgTool_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://drive.263.net/link/cq8UK5i03uk1huN/";
            Process.Start(url);
        }

        //Search the NetPort device
        bool netStartSearch = false;
        private void btnSearchNetport_Click(object sender, EventArgs e)
        {
            if (cmbbxNetCard.SelectedItem == null)
            {
                MessageBox.Show(FindResource("nNoNetCardSelect"), "SearchNetport");
                return;
            }
            if (btnSearchNetport.Text.Equals(FindResource("npSearchNetPort")))
            {
                BeginInvoke(new ThreadStart(delegate () {
                    #region NET_COMM
                    NET_COMM comm = new NET_COMM();
                    comm.setFlag();
                    comm.setu8((int)NET_CMD.NET_MODULE_CMD_SEARCH);
                    #endregion //NET_COMM
                    Thread t = new Thread(new ThreadStart(delegate ()
                    {
                        netStartSearch = true;
                        while (netStartSearch)
                        {
                            tUdp.StartSearchNetPort(comm);
                            //WriteLog(lrtxtLog, string.Format("Searching: {0}", comm.Flag), 1);
                            Thread.Sleep(1000);
                        }
                    }));
                    t.Start();
                    //if (tUdp.StartSearchNetPort(comm))
                    btnSearchNetport.Text = FindResource("npSearchingNetPort");
                }));
            }
            else if (btnSearchNetport.Text.Equals(FindResource("npSearchingNetPort")))
            {
                netStartSearch = false;
                //if (tUdp.StopSearchNetPort())
                btnSearchNetport.Text = FindResource("npSearchNetPort");
            }
        }

        // Gets NetPort device information
        private void dgvNetPort_DoubleClick(object sender, EventArgs e)
        {
            btnGetNetport_Click(null, null);
        }

        bool netStartGet = false;
        private void btnGetNetport_Click(object sender, EventArgs e)
        {
            if (btnSearchNetport.Text.Equals(FindResource("npSearchingNetPort")))
            {
                btnSearchNetport_Click(null, null);
            }

            if (dgvNetPort.RowCount > 0 && cmbbxNetCard.SelectedIndex != -1)
            {
                //Cells[3] = DeviceMac
                NetPortDevice npd = netPortDB.GetNetPortDeviceByMac((string)dgvNetPort.CurrentRow.Cells[3].Value);
                if (npd == null)
                {
                    return;
                }
                btnGetNetport.Text = FindResource("npRetry");
                Thread t = new Thread(new ThreadStart(delegate ()
                {
                    netStartGet = true;
                    while (netStartGet)
                    {
                        tUdp.GetNetPort(npd);
                        Thread.Sleep(1000);
                    }
                }));
                t.Start();
            }
            else
            {
                MessageBox.Show("No Device Select");
            }
        }

        // Set NetPort device information
        bool netStartSave = false;
        private void btnSetNetport_Click(object sender, EventArgs e)
        {
            if (btnSearchNetport.Text.Equals(FindResource("npSearchingNetPort")))
            {
                btnSearchNetport_Click(null, null);
            }

            if (dgvNetPort.RowCount > 0 && cmbbxNetCard.SelectedIndex != -1)
            {

                //Cells[3] = DeviceMac
                NetPortDevice npd = netPortDB.GetNetPortDeviceByMac((string)dgvNetPort.CurrentRow.Cells[3].Value);
                BeginInvoke(new ThreadStart(delegate ()
                {
                    #region NET_COMM
                    NET_COMM comm = new NET_COMM();
                    comm.setFlag();                                                                       // 16
                    comm.setu8((int)NET_CMD.NET_MODULE_CMD_SET);                                          // 1
                    comm.setbytes(ReaderUtils.FromHex(npd.DeviceMac.Replace(":", "")));                    // 6
                    comm.setbytes(ReaderUtils.FromHex(lblCurPcMac.Text.ToString().Replace(":", "")));   // 6
                    comm.setu8(204);                                                                      // 1

                    #region HWConfig //HWConfig 74
                    comm.setu8(0x21);//Convert.ToInt32(txtbxHwCfgMajor.Text));//1 type 0x21
                    comm.setu8(0x21);//Convert.ToInt32(txtbxHwCfgMinor.Text));//1 auxType 0x21
                    comm.setu8(1);//Convert.ToInt32(txtbxHwCfgIndex.Text));//1 index
                    comm.setu8(2);//Convert.ToInt32(txtbxHwCfgDeviceHwVer.Text));//1 hw
                    comm.setu8(3);//Convert.ToInt32(txtbxHwCfgDeviceSwVer.Text));//1 sw

                    string devName = txtbxHwCfgDeviceName.Text.Trim();
                    if (devName.Length > 21)
                    {
                        devName = devName.Substring(0, 21);
                    }
                    byte[] bytes = System.Text.Encoding.Default.GetBytes(devName);
                    Array.Resize(ref bytes, 21);
                    comm.setbytes(bytes);//21 devname

                    if (!ReaderUtils.CheckMacAddr(npd.DeviceMac))
                    {
                        MessageBox.Show(string.Format("{0} {1}", npd.DeviceMac, FindResource("tWrongMacAddr")), "Device Mac addr");
                        return;
                    }
                    comm.setbytes(ReaderUtils.FromHex(npd.DeviceMac.Replace(":", "")));//6 mac

                    if (!ReaderUtils.CheckIpAddr(txtbxHwCfgIp.Text))
                    {
                        MessageBox.Show(string.Format("{0} {1}", txtbxHwCfgIp.Text, FindResource("tWrongIpAddr")), "Ip Addr");
                        return;
                    }
                    comm.setbytes(ReaderUtils.GetIpAddrBytes(txtbxHwCfgIp.Text));//4 ip

                    if (!ReaderUtils.CheckIpAddr(txtbxHwCfgGateway.Text))
                    {
                        MessageBox.Show(string.Format("{0} {1}", txtbxHwCfgGateway.Text, FindResource("tWrongIpAddr")), "GateWay Addr");
                        return;
                    }
                    comm.setbytes(ReaderUtils.GetIpAddrBytes(txtbxHwCfgGateway.Text));//4 gateway

                    if (!ReaderUtils.CheckIpAddr(txtbxHwCfgMask.Text))
                    {
                        MessageBox.Show(string.Format("{0} {1}", txtbxHwCfgMask.Text, FindResource("tWrongIpAddr")), "Mask Addr");
                        return;
                    }
                    comm.setbytes(ReaderUtils.GetIpAddrBytes(txtbxHwCfgMask.Text));//4 mask

                    comm.setu8(chkbxHwCfgDhcpEn.Checked ? 1 : 0);//1 dhcp

                    comm.setPort(80); //Convert.ToInt32(txtbxHwCfgWebPort.Text));//2 webport

                    byte[] username_bytes = System.Text.Encoding.Default.GetBytes("admin");// txtbxHwCfgUserName.Text);
                    Array.Resize(ref username_bytes, 8);
                    comm.setbytes(username_bytes);//8 username
                    comm.setu8(0);// chkbxHwCfgPwdEn.Checked ? 1 : 0);//1 pwdEn

                    byte[] pwd_bytes = System.Text.Encoding.Default.GetBytes("");// txtbxHwCfgPwd.Text);
                    Array.Resize(ref pwd_bytes, 8);
                    comm.setbytes(pwd_bytes);  //8 pwd

                    comm.setu8(0);// chkbxHwCfgUpdateEn.Checked ? 1 : 0);//1 updateEn
                    comm.setu8(chkbxHwCfgComCfgEn.Checked ? 1 : 0);//1 comCfgEn

                    byte[] hwCfgReserved_bytes = System.Text.Encoding.Default.GetBytes("");// txtbxHwCfgReserved.Text);
                    Array.Resize(ref hwCfgReserved_bytes, 8);
                    comm.setbytes(hwCfgReserved_bytes);  //8 reserved
                    #endregion //HWConfig

                    #region Port_0//Port_0 65 use as heartbeat test
                    comm.setu8(0);//1 index
                    comm.setu8(chkbxPort0PortEn.Checked == true ? 1 : 0);//1 portEn
                    comm.setu8(2);//1 netMode
                    comm.setu8(1);//1 randEn
                    comm.setPort(3000);//2 netPort
                    comm.setbytes(ReaderUtils.GetIpAddrBytes("192.168.1.100"));//4 desIp
                    comm.setPort(2000);//2 desPort
                    comm.setLength(9600);//4 baudrate
                    comm.setu8(8);//1 datasize
                    comm.setu8(1);//1 stopbits
                    comm.setu8(4);//1 parity

                    comm.setu8(1);//1 phyEn
                    comm.setLength(1024);//4 pkgLen
                    comm.setLength(Convert.ToInt32(txtbxHeartbeatInterval.Text));//4 pkgTimeout
                    comm.setu8(0);//1 reconnectCnt
                    comm.setu8(0);//1 resetCtrl
                    comm.setu8(0);//1 dnsEn

                    string domain = txtbxHeartbeatContent.Text.Trim();
                    if (domain.Length > 20)
                    {
                        domain = domain.Substring(0, 20);
                    }
                    byte[] domain_bytes = System.Text.Encoding.Default.GetBytes(domain);
                    Array.Resize(ref domain_bytes, 20);
                    comm.setbytes(domain_bytes);//20 domain

                    comm.setbytes(ReaderUtils.GetIpAddrBytes("0.0.0.0"));//4 dnsIp

                    comm.setPort(0);//2 dnsPort

                    byte[] port0Reserved_bytes = System.Text.Encoding.Default.GetBytes("");
                    Array.Resize(ref port0Reserved_bytes, 8);
                    comm.setbytes(port0Reserved_bytes); //8 reserved
                    #endregion //Port_0

                    #region Port_1//Port_1 Use as Serial
                    comm.setu8(1);                                                                //1 index
                    comm.setu8(chkbxPort1_PortEn.Checked == true ? 1 : 0);//1 portEn
                    if (cmbbxPort1_NetMode == null)
                    {
                        cmbbxPort1_NetMode.SelectedItem = cmbbxPort1_NetMode.Items.IndexOf(NETPORT_TYPE.TCP_SERVER);
                    }
                    comm.setu8(Convert.ToInt32(cmbbxPort1_NetMode.SelectedItem));//1 netMode
                    comm.setu8(chkbxPort1_RandEn.Checked == true ? 1 : 0);//1 randEn
                    comm.setPort(Convert.ToInt32(txtbxPort1_NetPort.Text));//2 netPort

                    if (!ReaderUtils.CheckIpAddr(txtbxPort1_DesIp.Text))
                    {
                        MessageBox.Show(string.Format("{0} {1}", txtbxPort1_DesIp.Text, FindResource("tWrongIpAddr")), "Port_1 DesIP Addr");
                        return;
                    }
                    comm.setbytes(ReaderUtils.GetIpAddrBytes(txtbxPort1_DesIp.Text));//4 desIp

                    comm.setPort(Convert.ToInt32(txtbxPort1_DesPort.Text));//2 desPort
                    if (cmbbxPort1_BaudRate.SelectedItem == null)
                    {
                        cmbbxPort1_BaudRate.SelectedIndex = cmbbxPort1_NetMode.Items.IndexOf(NETPORT_Baudrate.B115200);
                    }
                    comm.setLength(Convert.ToInt32(cmbbxPort1_BaudRate.SelectedItem));//4 baudrate

                    if (cmbbxPort1_DataSize.SelectedItem == null)
                    {
                        cmbbxPort1_DataSize.SelectedIndex = cmbbxPort1_DataSize.Items.IndexOf(NETPORT_DataSize.Bits8);
                    }
                    comm.setu8(Convert.ToInt32(cmbbxPort1_DataSize.SelectedItem));//1 datasize

                    if (cmbbxPort1_StopBits.SelectedItem == null)
                    {
                        cmbbxPort1_StopBits.SelectedIndex = cmbbxPort1_StopBits.Items.IndexOf(NETPORT_StopBits.One);
                    }
                    comm.setu8(Convert.ToInt32(cmbbxPort1_StopBits.SelectedItem));//1 stopbits

                    if (cmbbxPort1_Parity.SelectedItem == null)
                    {
                        cmbbxPort1_Parity.SelectedIndex = cmbbxPort1_Parity.Items.IndexOf(NETPORT_Parity.Odd);
                    }
                    comm.setu8(Convert.ToInt32(cmbbxPort1_Parity.SelectedItem));//1 parity
                    comm.setu8(chkbxPort1_PhyDisconnect.Checked == true ? 1 : 0);//1 phyEn
                    comm.setLength(Convert.ToInt32(txtbxPort1_RxPkgLen.Text));//4 pkgLen
                    comm.setLength(Convert.ToInt32(txtbxPort1_RxTimeout.Text));//4 pkgTimeout
                    comm.setu8(Convert.ToInt32(txtbxPort1_ReConnectCnt.Text));//1 reconnectCnt
                    comm.setu8(chkbxPort1_ResetCtrl.Checked == true ? 1 : 0);//1 resetCtrl
                    comm.setu8(0);//1 dnsEn

                    string domain1 = txtbxPort1_DnsDomain.Text.Trim();
                    if (domain1.Length > 20)
                    {
                        domain1 = domain1.Substring(0, 20);
                    }
                    byte[] domain_bytes1 = System.Text.Encoding.Default.GetBytes(domain1);
                    Array.Resize(ref domain_bytes1, 20);
                    comm.setbytes(domain_bytes1);//20 domain

                    if (!ReaderUtils.CheckIpAddr(txtbxPort1_DnsIp.Text))
                    {
                        MessageBox.Show(string.Format("{0} {1}", txtbxPort1_DnsIp.Text, FindResource("tWrongIpAddr")), "Port_1 Dns host ip");
                        return;
                    }
                    comm.setbytes(ReaderUtils.GetIpAddrBytes(txtbxPort1_DnsIp.Text));//4 dnsIp

                    comm.setPort(Convert.ToInt32(txtbxPort1_Dnsport.Text));//2 dnsPort

                    byte[] port1Reserved_bytes = System.Text.Encoding.Default.GetBytes("");
                    Array.Resize(ref port1Reserved_bytes, 8);
                    comm.setbytes(port1Reserved_bytes); //8 reserved
                    #endregion //Port_1
                    #endregion //NET_COMM

                    btnSetNetport.Text = FindResource("npRetry");
                    Thread t = new Thread(new ThreadStart(delegate ()
                    {
                        netStartSave = true;
                        while (netStartSave)
                        {
                            tUdp.SetNetPort(npd, comm);
                            Thread.Sleep(1000);
                        }
                    }));
                    t.Start();
                }));
            }
            else
            {
                MessageBox.Show("No Device Select");
            }
        }

        //Reset NetPort device information
        bool netStartReset = false;
        private void btnResetNetport_Click(object sender, EventArgs e)
        {
            if (btnSearchNetport.Text.Equals(FindResource("npSearchingNetPort")))
            {
                btnSearchNetport_Click(null, null);
            }

            if (dgvNetPort.RowCount > 0 && cmbbxNetCard.SelectedIndex != -1)
            {
                //Cells[3] = DeviceMac
                NetPortDevice npd = netPortDB.GetNetPortDeviceByMac((string)dgvNetPort.CurrentRow.Cells[3].Value);
                if (npd == null)
                {
                    return;
                }

                btnResetNetport.Text = FindResource("npRetry");
                Thread t = new Thread(new ThreadStart(delegate ()
                {
                    netStartReset = true;
                    while (netStartReset)
                    {
                        tUdp.ResetNetPort(npd);
                        Thread.Sleep(3000);
                    }
                }));
                t.Start();

            }
            else
            {
                MessageBox.Show("No Device Select");
            }
        }

        //Set NetPort as the default
        bool netStartDefault = false;
        private void btnDefaultNetPort_Click(object sender, EventArgs e)
        {
            if (btnSearchNetport.Text.Equals(FindResource("npSearchingNetPort")))
            {
                btnSearchNetport_Click(null, null);
            }

            if (dgvNetPort.RowCount > 0 && cmbbxNetCard.SelectedIndex != -1)
            {
                //Cells[3] = DeviceMac
                NetPortDevice npd = netPortDB.GetNetPortDeviceByMac((string)dgvNetPort.CurrentRow.Cells[3].Value);
                if (npd == null)
                {
                    return;
                }

                btnDefaultNetPort.Text = FindResource("npRetry");
                Thread t = new Thread(new ThreadStart(delegate ()
                {
                    netStartDefault = true;
                    while (netStartDefault)
                    {
                        tUdp.DefaultNetPort(npd, lblCurPcMac.Text);
                        Thread.Sleep(1000);
                    }
                }));
                t.Start();
            }
            else
            {
                MessageBox.Show("No Device Select");
            }
        }

        private void chkbxPort0PortEn_CheckedChanged(object sender, EventArgs e)
        {
            grbHeartbeat.Enabled = chkbxPort0PortEn.Checked;
        }

        private void cmbbxPort1_NetMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbxPort1_NetMode.SelectedIndex == cmbbxPort1_NetMode.Items.IndexOf(NETPORT_TYPE.TCP_SERVER))
            {
                EnableTcpServerUI(false);
            }
            else
            {
                EnableTcpServerUI(true);
            }
        }

        private void EnableTcpServerUI(bool flag)
        {
            chkbxPort1_RandEn.Enabled = flag;
            grbDesIpPort.Enabled = flag;
            chkbxPort1_RandEn.Enabled = flag;
            grbDnsDomain.Enabled = flag;
        }

        private void chkbxPort1_DomainEn_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxPort1_DomainEn.Checked)
            {
                grbDnsDomain.Enabled = true;
                grbDesIpPort.Enabled = false;
            }
            else
            {
                grbDnsDomain.Enabled = false;
                grbDesIpPort.Enabled = true;
            }
        }

        private void chkbxPort1_RandEn_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxPort1_RandEn.Checked)
            {
                txtbxPort1_NetPort.Enabled = false;
            }
            else
            {
                txtbxPort1_NetPort.Enabled = true;
            }
        }

        private void btnLoadCfgFromFile_Click(object sender, EventArgs e)
        {
            byte[] bytes = LoadCfg();
            if (bytes == null)
            {
                return;
            }
            #region NET_COMM
            NET_COMM comm = new NET_COMM();
            comm.setbytes(bytes);
            //HWConfig
            txtbxHwCfgDeviceName.Text = string.Format("{0}", comm.HWConfig.Modulename);
            txtbxHwCfgMac.Text = string.Format("{0}", comm.HWConfig.DevMAC);
            txtbxHwCfgIp.Text = string.Format("{0}", comm.HWConfig.DevIP);
            txtbxHwCfgMask.Text = string.Format("{0}", comm.HWConfig.DevIPMask);
            txtbxHwCfgGateway.Text = string.Format("{0}", comm.HWConfig.DevGWIP);
            chkbxHwCfgDhcpEn.Checked = comm.HWConfig.DhcpEnable;
            chkbxHwCfgComCfgEn.Checked = comm.HWConfig.ComcfgEn;
            //Port_0
            chkbxPort0PortEn.Checked = comm.PortCfg_0.PortEn;
            txtbxHeartbeatInterval.Text = string.Format("{0}", comm.PortCfg_0.RxPktTimeout);
            txtbxHeartbeatContent.Text = string.Format("{0}", comm.PortCfg_0.Domainname);
            ////Port_1
            chkbxPort1_PortEn.Checked = comm.PortCfg_1.PortEn;
            if (cmbbxPort1_NetMode.Items.Contains((NETPORT_TYPE)comm.PortCfg_1.NetMode))
            {
                cmbbxPort1_NetMode.SelectedItem = (NETPORT_TYPE)comm.PortCfg_1.NetMode;
            }
            else
            {
                MessageBox.Show(string.Format("Port1 Not support: {0}", cmbbxPort1_NetMode));
            }
            chkbxPort1_RandEn.Checked = comm.PortCfg_1.RandSportFlag;
            txtbxPort1_NetPort.Text = string.Format("{0}", comm.PortCfg_1.NetPort);
            txtbxPort1_DesIp.Text = string.Format("{0}", comm.PortCfg_1.DesIP);
            txtbxPort1_DesPort.Text = string.Format("{0}", comm.PortCfg_1.DesPort);
            if (cmbbxPort1_BaudRate.Items.Contains((NETPORT_Baudrate)comm.PortCfg_1.BaudRate))
            {
                cmbbxPort1_BaudRate.SelectedItem = (NETPORT_Baudrate)comm.PortCfg_1.BaudRate;
            }
            else
            {
                MessageBox.Show("Not support BaudRate " + comm.PortCfg_1.BaudRate);
                return;
            }

            if (cmbbxPort1_DataSize.Items.Contains((NETPORT_DataSize)comm.PortCfg_1.DataSize))
            {
                cmbbxPort1_DataSize.SelectedItem = (NETPORT_DataSize)comm.PortCfg_1.DataSize;
            }
            else
            {
                MessageBox.Show("Not support DataSize " + comm.PortCfg_1.DataSize);
                return;
            }

            if (cmbbxPort1_StopBits.Items.Contains((NETPORT_StopBits)comm.PortCfg_1.StopBits))
            {
                cmbbxPort1_StopBits.SelectedItem = (NETPORT_StopBits)comm.PortCfg_1.StopBits;
            }
            else
            {
                MessageBox.Show("Not support StopBits " + comm.PortCfg_1.StopBits);
                return;
            }

            if (cmbbxPort1_Parity.Items.Contains((NETPORT_Parity)comm.PortCfg_1.Parity))
            {
                cmbbxPort1_Parity.SelectedItem = (NETPORT_Parity)comm.PortCfg_1.Parity;
            }
            else
            {
                MessageBox.Show("Not support Parity " + comm.PortCfg_1.Parity);
                return;
            }
            chkbxPort1_PhyDisconnect.Checked = comm.PortCfg_1.PHYChangeHandle;
            txtbxPort1_RxPkgLen.Text = string.Format("{0}", comm.PortCfg_1.RxPktlength);
            txtbxPort1_RxTimeout.Text = string.Format("{0}", comm.PortCfg_1.RxPktTimeout);
            txtbxPort1_ReConnectCnt.Text = string.Format("{0}", comm.PortCfg_1.ReConnectCnt);
            chkbxPort1_ResetCtrl.Checked = comm.PortCfg_1.ResetCtrl;
            txtbxPort1_DnsDomain.Text = string.Format("{0}", comm.PortCfg_1.Domainname);
            txtbxPort1_DnsIp.Text = string.Format("{0}", comm.PortCfg_1.DNSHostIP);
            txtbxPort1_Dnsport.Text = string.Format("{0}", comm.PortCfg_1.DNSHostPort);
            #endregion //NET_COMM
        }

        private byte[] LoadCfg()
        {
            try
            {
                OpenFileDialog openLoadSaveConfigFileDialog = new OpenFileDialog();
                openLoadSaveConfigFileDialog.Filter = "NetPortConfigure (.cfg)|*.cfg";
                openLoadSaveConfigFileDialog.Title = "Select a configuration file to load";
                openLoadSaveConfigFileDialog.InitialDirectory = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                openLoadSaveConfigFileDialog.RestoreDirectory = true;
                if (DialogResult.OK == openLoadSaveConfigFileDialog.ShowDialog())
                {
                    FileStream fs = new FileStream(openLoadSaveConfigFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    StreamReader sr = new StreamReader(fs);   //选择编码方式
                    StringBuilder cfgStr = new StringBuilder();
                    while (sr.EndOfStream != true)
                    {
                        cfgStr.Append(sr.ReadLine());
                    }
                    //Console.WriteLine("cfgStr={0}", cfgStr.Replace(" ", ""));
                    MessageBox.Show(string.Format("LoadCfg successful: {0}", openLoadSaveConfigFileDialog.FileName), "LoadCfgFromFile Success");
                    return ReaderUtils.FromHex(cfgStr.Replace(" ", "").ToString());
                }
                else
                {
                    MessageBox.Show("Without load any cfg file", "LoadCfgFromFile Tips");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Load NetCfg: ", ex.Message), "LoadCfgFromFile Error");
            }
            return null;
        }

        private void btnStoreCfgToFile_Click(object sender, EventArgs e)
        {
            #region NET_COMM
            NET_COMM comm = new NET_COMM();
            comm.setFlag();                                                                       // 16
            comm.setu8((int)NET_CMD.NET_MODULE_RESERVE);                                          // 1
            comm.setbytes(ReaderUtils.FromHex("11:22:33:44:55:66".Replace(":", "")));                    // 6
            comm.setbytes(ReaderUtils.FromHex(lblCurPcMac.Text.ToString().Replace(":", "")));   // 6
            comm.setu8(204);                                                                      // 1

            #region HWConfig //HWConfig 74
            comm.setu8(0x21);//Convert.ToInt32(txtbxHwCfgMajor.Text));//1 type 0x21
            comm.setu8(0x21);//Convert.ToInt32(txtbxHwCfgMinor.Text));//1 auxType 0x21
            comm.setu8(1);//Convert.ToInt32(txtbxHwCfgIndex.Text));//1 index
            comm.setu8(2);//Convert.ToInt32(txtbxHwCfgDeviceHwVer.Text));//1 hw
            comm.setu8(3);//Convert.ToInt32(txtbxHwCfgDeviceSwVer.Text));//1 sw

            string devName = txtbxHwCfgDeviceName.Text.Trim();
            if (devName.Length > 21)
            {
                devName = devName.Substring(0, 21);
            }
            byte[] bytes = System.Text.Encoding.Default.GetBytes(devName);
            Array.Resize(ref bytes, 21);
            comm.setbytes(bytes);//21 devname

            if (!ReaderUtils.CheckMacAddr(txtbxHwCfgMac.Text))
            {
                MessageBox.Show(string.Format("{0} {1}", txtbxHwCfgMac.Text, FindResource("tWrongMacAddr")), "Device Mac addr");
                return;
            }
            comm.setbytes(ReaderUtils.FromHex(txtbxHwCfgMac.Text.Replace(":", "")));//6 mac

            if (!ReaderUtils.CheckIpAddr(txtbxHwCfgIp.Text))
            {
                MessageBox.Show(string.Format("{0} {1}", txtbxHwCfgIp.Text, FindResource("tWrongIpAddr")), "Ip Addr");
                return;
            }
            comm.setbytes(ReaderUtils.GetIpAddrBytes(txtbxHwCfgIp.Text));//4 ip

            if (!ReaderUtils.CheckIpAddr(txtbxHwCfgGateway.Text))
            {
                MessageBox.Show(string.Format("{0} {1}", txtbxHwCfgGateway.Text, FindResource("tWrongIpAddr")), "GateWay Addr");
                return;
            }
            comm.setbytes(ReaderUtils.GetIpAddrBytes(txtbxHwCfgGateway.Text));//4 gateway

            if (!ReaderUtils.CheckIpAddr(txtbxHwCfgMask.Text))
            {
                MessageBox.Show(string.Format("{0} {1}", txtbxHwCfgMask.Text, FindResource("tWrongIpAddr")), "Mask Addr");
                return;
            }
            comm.setbytes(ReaderUtils.GetIpAddrBytes(txtbxHwCfgMask.Text));//4 mask

            comm.setu8(chkbxHwCfgDhcpEn.Checked ? 1 : 0);//1 dhcp

            comm.setPort(80); //Convert.ToInt32(txtbxHwCfgWebPort.Text));//2 webport

            byte[] username_bytes = System.Text.Encoding.Default.GetBytes("admin");// txtbxHwCfgUserName.Text);
            Array.Resize(ref username_bytes, 8);
            comm.setbytes(username_bytes);//8 username
            comm.setu8(0);// chkbxHwCfgPwdEn.Checked ? 1 : 0);//1 pwdEn

            byte[] pwd_bytes = System.Text.Encoding.Default.GetBytes("");// txtbxHwCfgPwd.Text);
            Array.Resize(ref pwd_bytes, 8);
            comm.setbytes(pwd_bytes);  //8 pwd

            comm.setu8(0);// chkbxHwCfgUpdateEn.Checked ? 1 : 0);//1 updateEn
            comm.setu8(chkbxHwCfgComCfgEn.Checked ? 1 : 0);//1 comCfgEn

            byte[] hwCfgReserved_bytes = System.Text.Encoding.Default.GetBytes("");// txtbxHwCfgReserved.Text);
            Array.Resize(ref hwCfgReserved_bytes, 8);
            comm.setbytes(hwCfgReserved_bytes);  //8 reserved
            #endregion //HWConfig

            #region Port_0//Port_0 65 use as heartbeat test
            comm.setu8(0);//1 index
            comm.setu8(chkbxPort0PortEn.Checked == true ? 1 : 0);//1 portEn
            comm.setu8(2);//1 netMode
            comm.setu8(1);//1 randEn
            comm.setPort(3000);//2 netPort
            comm.setbytes(ReaderUtils.GetIpAddrBytes("192.168.1.100"));//4 desIp
            comm.setPort(2000);//2 desPort
            comm.setLength(9600);//4 baudrate
            comm.setu8(8);//1 datasize
            comm.setu8(1);//1 stopbits
            comm.setu8(4);//1 parity

            comm.setu8(1);//1 phyEn
            comm.setLength(1024);//4 pkgLen
            if (txtbxHeartbeatInterval.Text.Trim().Length == 0)
            {
                txtbxHeartbeatInterval.Text = "0";
            }
            comm.setLength(Convert.ToInt32(txtbxHeartbeatInterval.Text));//4 pkgTimeout
            comm.setu8(0);//1 reconnectCnt
            comm.setu8(0);//1 resetCtrl
            comm.setu8(0);//1 dnsEn

            string domain = txtbxHeartbeatContent.Text.Trim();
            if (domain.Length > 20)
            {
                domain = domain.Substring(0, 20);
            }
            byte[] domain_bytes = System.Text.Encoding.Default.GetBytes(domain);
            Array.Resize(ref domain_bytes, 20);
            comm.setbytes(domain_bytes);//20 domain

            comm.setbytes(ReaderUtils.GetIpAddrBytes("0.0.0.0"));//4 dnsIp

            comm.setPort(0);//2 dnsPort

            byte[] port0Reserved_bytes = System.Text.Encoding.Default.GetBytes("");
            Array.Resize(ref port0Reserved_bytes, 8);
            comm.setbytes(port0Reserved_bytes); //8 reserved
            #endregion //Port_0

            #region Port_1//Port_1 Use as Serial
            comm.setu8(1);                                                                //1 index
            comm.setu8(chkbxPort1_PortEn.Checked == true ? 1 : 0);//1 portEn
            if (cmbbxPort1_NetMode == null)
            {
                cmbbxPort1_NetMode.SelectedItem = cmbbxPort1_NetMode.Items.IndexOf(NETPORT_TYPE.TCP_SERVER);
            }
            comm.setu8(Convert.ToInt32(cmbbxPort1_NetMode.SelectedItem));//1 netMode
            comm.setu8(chkbxPort1_RandEn.Checked == true ? 1 : 0);//1 randEn
            if (txtbxPort1_NetPort.Text.Trim().Length == 0)
            {
                txtbxPort1_NetPort.Text = "0";
            }
            comm.setPort(Convert.ToInt32(txtbxPort1_NetPort.Text));//2 netPort

            if (cmbbxPort1_NetMode.SelectedIndex != cmbbxPort1_NetMode.Items.IndexOf(NETPORT_TYPE.TCP_SERVER))
            {
                if (!ReaderUtils.CheckIpAddr(txtbxPort1_DesIp.Text))
                {
                    MessageBox.Show(string.Format("{0} {1}", txtbxPort1_DesIp.Text, FindResource("tWrongIpAddr")), "Port_1 DesIP Addr");
                    return;
                }
            }
            else
            {
                txtbxPort1_DesIp.Text = "0.0.0.0";
            }
            comm.setbytes(ReaderUtils.GetIpAddrBytes(txtbxPort1_DesIp.Text));//4 desIp
            if (txtbxPort1_DesPort.Text.Trim().Length == 0)
            {
                txtbxPort1_DesPort.Text = "0";
            }
            comm.setPort(Convert.ToInt32(txtbxPort1_DesPort.Text));//2 desPort
            if (cmbbxPort1_BaudRate.SelectedItem == null)
            {
                cmbbxPort1_BaudRate.SelectedIndex = cmbbxPort1_NetMode.Items.IndexOf(NETPORT_Baudrate.B115200);
            }
            comm.setLength(Convert.ToInt32(cmbbxPort1_BaudRate.SelectedItem));//4 baudrate

            if (cmbbxPort1_DataSize.SelectedItem == null)
            {
                cmbbxPort1_DataSize.SelectedIndex = cmbbxPort1_DataSize.Items.IndexOf(NETPORT_DataSize.Bits8);
            }
            comm.setu8(Convert.ToInt32(cmbbxPort1_DataSize.SelectedItem));//1 datasize

            if (cmbbxPort1_StopBits.SelectedItem == null)
            {
                cmbbxPort1_StopBits.SelectedIndex = cmbbxPort1_StopBits.Items.IndexOf(NETPORT_StopBits.One);
            }
            comm.setu8(Convert.ToInt32(cmbbxPort1_StopBits.SelectedItem));//1 stopbits

            if (cmbbxPort1_Parity.SelectedItem == null)
            {
                cmbbxPort1_Parity.SelectedIndex = cmbbxPort1_Parity.Items.IndexOf(NETPORT_Parity.Odd);
            }
            comm.setu8(Convert.ToInt32(cmbbxPort1_Parity.SelectedItem));//1 parity
            comm.setu8(chkbxPort1_PhyDisconnect.Checked == true ? 1 : 0);//1 phyEn
            if (txtbxPort1_RxPkgLen.Text.Trim().Length == 0)
            {
                txtbxPort1_RxPkgLen.Text = "0";
            }
            comm.setLength(Convert.ToInt32(txtbxPort1_RxPkgLen.Text));//4 pkgLen
            if (txtbxPort1_RxTimeout.Text.Trim().Length == 0)
            {
                txtbxPort1_RxTimeout.Text = "0";
            }
            comm.setLength(Convert.ToInt32(txtbxPort1_RxTimeout.Text));//4 pkgTimeout
            if (txtbxPort1_ReConnectCnt.Text.Trim().Length == 0)
            {
                txtbxPort1_ReConnectCnt.Text = "0";
            }
            comm.setu8(Convert.ToInt32(txtbxPort1_ReConnectCnt.Text));//1 reconnectCnt
            comm.setu8(chkbxPort1_ResetCtrl.Checked == true ? 1 : 0);//1 resetCtrl
            comm.setu8(0);//1 dnsEn

            string domain1 = txtbxPort1_DnsDomain.Text.Trim();
            if (domain1.Length > 20)
            {
                domain1 = domain1.Substring(0, 20);
            }
            byte[] domain_bytes1 = System.Text.Encoding.Default.GetBytes(domain1);
            Array.Resize(ref domain_bytes1, 20);
            comm.setbytes(domain_bytes1);//20 domain
            comm.setbytes(ReaderUtils.GetIpAddrBytes("0.0.0.0"));//4 dnsIp

            comm.setPort(0);//2 dnsPort

            byte[] port1Reserved_bytes = System.Text.Encoding.Default.GetBytes("");
            Array.Resize(ref port1Reserved_bytes, 8);
            comm.setbytes(port1Reserved_bytes); //8 reserved
            #endregion //Port_1
            #endregion //NET_COMM
            //Console.WriteLine(comm.ToString());
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "NetPortConfigure (.cfg)|*.cfg";
                saveFileDialog1.Title = "Select a File to save net port cfg";
                string strDestinationFile = "NetPortConfigure"
                    + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + @".cfg";
                saveFileDialog1.FileName = strDestinationFile;
                //saveFileDialog1.InitialDirectory = "D://";
                // Show the Dialog.
                // If the user clicked OK in the dialog and
                // a .txt file was selected, open it.
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog1.FileName;// Application.StartupPath + @"\" + comm.Flag + ".cfg";
                    StreamWriter sWriter = File.CreateText(path);
                    sWriter.Write(ReaderUtils.ToHex(comm.message, "", ""));
                    sWriter.Flush();
                    sWriter.Close();
                    MessageBox.Show(string.Format("StoreCfgToFile successful: store to: {0}", path), "StoreCfgToFile Success");
                }
                else
                {
                    MessageBox.Show("Without store any cfg file", "StoreCfgToFile Tips");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Store NetCfg:", ex.Message), "StoreCfgToFile Error");
            }
        }

        private void StopNetPort()
        {
            netStartGet = false;
            netStartSave = false;
            netStartReset = false;
            netStartSearch = false;

            if (tUdp.IsStartRead)
            {
                if (btnSearchNetport.Text.Equals(FindResource("npSearchingNetPort")))
                {
                    btnSearchNetport_Click(null, null);
                }

                tUdp.StopSearchNetPort();
            }
        }
        #endregion //NetPort

        private void btnGetAccessEpcMatch_Click(object sender, EventArgs e)
        {
            reader.GetAccessEpcMatch(m_curSetting.btReadId);
        }

        private void btnCancelAccessEpcMatch_Click(object sender, EventArgs e)
        {
            txtAccessEpcMatch.Text = "";
            reader.CancelAccessEpcMatch(m_curSetting.btReadId, 0x01);
        }

        TagMaskDB tagmaskDB = null;
        private void initDgvTagMask()
        {
            dgvTagMask.AutoGenerateColumns = false;
            tagMask_MaskNoColumn.DataPropertyName = "MaskID";
            tagMask_MaskNoColumn.HeaderText = FindResource("tagmask_MaskNo");
            tagMask_MaskNoColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            tagMask_SessionIdColumn.DataPropertyName = "Target";
            tagMask_SessionIdColumn.HeaderText = FindResource("tagmask_SessionID");
            tagMask_SessionIdColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            tagMask_ActionColumn.DataPropertyName = "ActionStr";
            tagMask_ActionColumn.HeaderText = FindResource("tagmask_Action");
            tagMask_ActionColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            tagMask_MembankColumn.DataPropertyName = "Bank";
            tagMask_MembankColumn.HeaderText = FindResource("tagmask_MemBank");
            tagMask_MembankColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            tagMask_StartAddrColumn.DataPropertyName = "StartAddrHexStr";
            tagMask_StartAddrColumn.HeaderText = FindResource("tagmask_StartAddr");
            tagMask_StartAddrColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            tagMask_MaskLenColumn.DataPropertyName = "MaskBitLenHexStr";
            tagMask_MaskLenColumn.HeaderText = FindResource("tagmask_MaskLen");
            tagMask_MaskLenColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            tagMask_MaskValueColumn.DataPropertyName = "Mask";
            tagMask_MaskValueColumn.HeaderText = FindResource("tagmask_MaskValue");
            tagMask_MaskValueColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            tagMask_TruncateColumn.DataPropertyName = "Truncate";
            tagMask_TruncateColumn.HeaderText = FindResource("tagmask_Truncate");
            tagMask_TruncateColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (tagmaskDB == null)
                tagmaskDB = new TagMaskDB();
            dgvTagMask.DataSource = null;
            dgvTagMask.DataSource = tagmaskDB.TagList;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (radio_btn_fast_inv.Checked)
            {
                FastInventory_Click(sender, e);
            }
            else if (radio_btn_realtime_inv.Checked)
            {
                RealTimeInventory_Click(sender, e);
            }
            else if (radio_btn_cache_inv.Checked)
            {
                CachedInventory_Click(sender, e);
            }
        }

        private void Label_JumlahPutaran_Click(object sender, EventArgs e)
        {

        }

        private void textBarId_TextChanged(object sender, EventArgs e)
        {
            //string sql = "select * from peserta where barcode = '" + textBarId.Text.ToString() + "' limit 1";
            //DataTable dt = new Connect().getTable(sql);
            //if (dt.Rows.Count > 0)
            //{
            //    string no_pst = dt.Rows[0]["no_peserta"].ToString();
            //    //MessageBox.Show(no_pst);
            //    Label_NoPeserta.Text = no_pst;
            //}
            //else
            //{
            //    MessageBox.Show("Data Tidak Ditemukan");
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (stopwatch.Elapsed.ToString().Length > 8)
            {
                Console.WriteLine(stopwatch.Elapsed.ToString().Substring(3, 5));
                this.Label_Timer.Text = stopwatch.Elapsed.TotalSeconds.ToString().Substring(0, 5);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ReloadClear();
            Application.Restart();
            //Environment.Exit(0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Open_Port();
            connectFP();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblPangkat_Click(object sender, EventArgs e)
        {

        }

        private void Label_NoPeserta_Click(object sender, EventArgs e)
        {

        }

        private void ReloadClear()
        {
            btn_Ulangi.Hide();
            lblNama.Text = "";
            lblNOPJurusan.Text = "";
            lblUsia.Text = "";
            icon_Female.Hide();
            icon_Male.Hide();
            lblTanggalLahir.Text = "";
            lblAsalSekolah.Text = "";
            lblNamaTestor.Text = "";
            textBarId.Text ="Finnger ID";
            picFPImg.Image = null;


            Label_NoPeserta.Text = "0000";
            Label_Timer.Text = "00-00";
            Label_JumlahPutaran.Text = "0";
            Label_Putaran1.Text = "00-00";
            Label_Putaran2.Text = "00-00";
            Label_Putaran3.Text = "00-00";

            stopwatch.Reset();

            btnInventory.Enabled = true;
            showMessage("Scan Finger Peserta", Color.FromArgb(243, 246, 249));
        }

        private void btn_Ulangi_Click(object sender, EventArgs e)
        {
            try
            {
                string Track = System.Configuration.ConfigurationManager.AppSettings["NoTrack"];
                string finggerid = textBarId.Text;

                string InsertHistoryAwal = "insert into history_track (no_track,antena,barcode,no_rfid,waktu) values ('" + Track + "','" + 0 + "','" + finggerid + "','" + 0 + "','" + 0 + "')";
                new Connect().execute(InsertHistoryAwal);


                string UpdateHistoryWaktu = "update history set putaran1 = '" + 0.ToString() + "', putaran2 = '" + 0.ToString() + "', putaran3 = '" + 0.ToString() + "',waktu_akhir='" + 0.ToString() + "' where barcode = '" + finggerid + "'";
                Console.WriteLine(UpdateHistoryWaktu);
                bool updated = new Connect().execute(UpdateHistoryWaktu);
                //MessageBox.Show(updated.ToString());

                btnInventory.Enabled = true;
                btnConnect.Enabled = true;
                Label_Timer.Text = "00-00";
                Label_JumlahPutaran.Text = "0";
                Label_Putaran1.Text = "00-00";
                Label_Putaran2.Text = "00-00";
                Label_Putaran3.Text = "00-00";

                stopwatch.Reset();

                showMessage("Klik Connect'", Color.FromArgb(243, 246, 249));
                btn_Ulangi.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click_2(object sender, EventArgs e)
        {
            if (!bIdentify)
            {
                bIdentify = true;
                string message = "Please press your finger!";
                Console.WriteLine(message);
            }
        }

        private void lblNama_Click(object sender, EventArgs e)
        {

        }

        private void Label_No_ShuttleRun_Click(object sender, EventArgs e)
        {

        }
    }

    public class UDPThread
    {
        //UDP Client
        UdpClient netClient = null;
        //Local port, which is used to bind a UDP server
        IPEndPoint localEndpoint = null;
        //Network port, used to hold UDP broadcast addresses
        IPEndPoint netEndpoint = null;
        //UDP Recv Thread
        Thread netRecvthread = null;
        bool netStarted = false;
        //Wait for UDP to finish receiving
        ManualResetEvent waitForStopRecv = new ManualResetEvent(false);
        //Wait for the Get or Set instruction to return
        //ManualResetEvent waitForGetAndSetAck = new ManualResetEvent(false);
        //private bool startRecvUdp = false;

        //The network card currently used as a UDP service
        NetCard curNetCard = null;

        public event EventHandler<NetCommEventArgs> NetCommRead;

        public NetCard CurNetCard
        {
            get { return curNetCard; }
            set { curNetCard = value; }
        }

        public bool IsStartRead { get { return netStarted; } }

        //Start the UDP service
        private bool StartUdp()
        {
            if (curNetCard == null)
            {
                return false;
            }
            if (localEndpoint == null)
            {
                localEndpoint = new IPEndPoint(IPAddress.Parse(curNetCard.Ip), 60000);
            }

            if (netClient == null)
            {
                netClient = new UdpClient();
                Socket updSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                //Reuse must first than Bind
                updSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
                updSocket.Bind(localEndpoint);
                netClient.Client = updSocket;
                netClient.Client.SendTimeout = 5000;
                netClient.Client.ReceiveTimeout = 5000;
                netClient.Client.ReceiveBufferSize = 2 * 1024;
            }

            if (netEndpoint == null)
            {
                netEndpoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 50000); // Destination address information, broadcast address
            }

            if (netRecvthread == null)
            {
                netRecvthread = new Thread(new ThreadStart(StartRecvNetPort));
                netRecvthread.IsBackground = true;
                netRecvthread.Start();
            }
            return true;
        }

        //Stop UDP service
        private bool StopUdp()
        {
            if (netStarted)
            {
                netStarted = false;
                waitForStopRecv.Reset();
                waitForStopRecv.WaitOne();
            }

            netRecvthread = null;
            localEndpoint = null;
            netEndpoint = null;

            if (netClient != null)
            {
                netClient.Close();
                netClient = null;
            }

            return true;
        }

        //UDP Recv
        private void StartRecvNetPort()
        {
            netStarted = true;
            while (netStarted)
            {
                if (/*startRecvUdp ||*/ netClient.Available > 0)
                {
                    try
                    {
                        byte[] buf = netClient.Receive(ref netEndpoint);
                        string msg = ReaderUtils.ToHex(buf, "", " ");
                        //Console.WriteLine("#2 Recv:{0}", msg);
                        parseNetComm(buf);
                    }
                    catch (SocketException e)
                    {
                        MessageBox.Show("NetPort operation timeout {0}", e.Message);
                        //startRecvUdp = false;
                        //waitForGetAndSetAck.Set();
                    }
                }
                Thread.Sleep(10);
            }
            //startRecvUdp = false;
            waitForStopRecv.Set();
        }

        //Parse NetComm message
        private void parseNetComm(byte[] buf)
        {
            NET_COMM comm = new NET_COMM();
            comm.setbytes(buf);
            if (comm.Cmd == (int)NET_CMD.NET_MODULE_ACK_SEARCH)
            {

            }
            if (comm.Cmd == (int)NET_CMD.NET_MODULE_ACK_RESEST)
            {
                //waitForGetAndSetAck.Set();
            }
            if (comm.Cmd == (int)NET_CMD.NET_MODULE_ACK_GET
                | comm.Cmd == (int)NET_CMD.NET_MODULE_ACK_SET)
            {
                //waitForGetAndSetAck.Set();
            }
            NetCommRead?.Invoke(this, new NetCommEventArgs(comm));
        }

        // Send NetComm Message
        private void SendNetPortMessage(NET_COMM comm)
        {
            byte[] sendData = new byte[comm.Length];
            Array.Copy(comm.message, 0, sendData, 0, comm.Length);
            //Console.WriteLine("Send({0}): [{1}]", comm.Length, ReaderUtils.ToHex(sendData, "", " "));
            if (netClient != null && netStarted)
                netClient.Send(comm.message, comm.message.Length, netEndpoint);
        }

        public bool StartSearchNetPort(NET_COMM comm)
        {
            if (!StartUdp())
            {
                return false;
            }

            SendNetPortMessage(comm);
            return true;
        }

        public bool StopSearchNetPort()
        {
            return StopUdp();
        }

        public void GetNetPort(NetPortDevice npd)
        {
            #region NET_COMM
            NET_COMM comm = new NET_COMM();
            comm.setFlag();
            comm.setu8((int)NET_CMD.NET_MODULE_CMD_GET);
            comm.setbytes(ReaderUtils.FromHex(npd.DeviceMac.Replace(":", "")));
            #endregion //NET_COMM

            if (!StartUdp())
            {
                return;
            }
            SendNetPortMessage(comm);

            //startRecvUdp = true;
            //waitForGetAndSetAck.Reset();
            //waitForGetAndSetAck.WaitOne();
            //StopUdp();
            //Thread.Sleep(waitTimeout);
        }

        public void SetNetPort(NetPortDevice npd, NET_COMM comm)
        {
            StartUdp();
            SendNetPortMessage(comm);
            //startRecvUdp = true;
            //waitForGetAndSetAck.Reset();
            //waitForGetAndSetAck.WaitOne();
            //StopUdp();
            //Thread.Sleep(waitTimeout);
        }

        internal void ResetNetPort(NetPortDevice npd)
        {
            #region NET_COMM
            NET_COMM comm = new NET_COMM();
            comm.setFlag();
            comm.setu8((int)NET_CMD.NET_MODULE_CMD_RESET);
            comm.setbytes(ReaderUtils.FromHex(npd.DeviceMac.Replace(":", "")));
            #endregion //NET_COMM

            StartUdp();
            SendNetPortMessage(comm);
            //startRecvUdp = true;
            //waitForGetAndSetAck.Reset();
            //waitForGetAndSetAck.WaitOne();
            //StopUdp();
            //Thread.Sleep(waitTimeout);
        }

        internal void DefaultNetPort(NetPortDevice npd, string pcMac)
        {
            #region NET_COMM
            NET_COMM comm = new NET_COMM();
            new NET_COMM();
            comm.setFlag();                                                                       // 16
            comm.setu8((int)NET_CMD.NET_MODULE_CMD_SET);                                          // 1
            comm.setbytes(ReaderUtils.FromHex(npd.DeviceMac.Replace(":", "")));                    // 6
            comm.setbytes(ReaderUtils.FromHex(pcMac.ToString().Replace(":", "")));   // 6
            comm.setu8(204);                                                                      // 1
                                                                                                  //HWConfig 74
            comm.setu8(0x21);                                                                //1 type 0x21
            comm.setu8(0x21);                                                                //1 auxType 0x21
            comm.setu8(1);                                                                 //1 index
            comm.setu8(2);                                                                 //1 hw
            comm.setu8(6);                                                                 //1 sw
            byte[] bytes = System.Text.Encoding.Default.GetBytes("RoNetPort");
            Array.Resize(ref bytes, 21);
            comm.setbytes(bytes);                                                          //21 devname
            comm.setbytes(ReaderUtils.FromHex(npd.DeviceMac.Replace(":", "")));             //6 mac
            comm.setbytes(ReaderUtils.GetIpAddrBytes("192.168.0.178"));                     //4 ip
            comm.setbytes(ReaderUtils.GetIpAddrBytes("192.168.0.1"));                     //4 gateway
            comm.setbytes(ReaderUtils.GetIpAddrBytes("255.255.255.0"));                       //4 mask
            comm.setu8(0);                                                                 //1 dhcp
            comm.setPort(80);                                                              //2 webport
            byte[] username_bytes = System.Text.Encoding.Default.GetBytes("admin");
            Array.Resize(ref username_bytes, 8);
            comm.setbytes(username_bytes);                                                 //8 username
            comm.setu8(0);                                                                 //1 pwdEn
            comm.setbytes(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });  //8 pwd
            comm.setu8(0);                                                                 //1 updateEn
            comm.setu8(0);                                                                 //1 comCfgEn
            comm.setbytes(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });  //8 reserved
                                                                                           //Port_0 65 use as heartbeat test
            comm.setu8(0);                                                                //1 index
            comm.setu8(0);                                                                //1 portEn
            comm.setu8(1);                                                                //1 netMode
            comm.setu8(1);                                                                //1 randEn
            comm.setPort(3000);                                                           //2 netPort
            comm.setbytes(ReaderUtils.GetIpAddrBytes("192.168.1.100"));                    //4 desIp
            comm.setPort(2000);                                                           //2 desPort
            comm.setLength(9600);                                                         //4 baudrate
            comm.setu8(8);                                                                //1 datasize
            comm.setu8(1);                                                                //1 stopbits
            comm.setu8(4);                                                                //1 parity
            comm.setu8(1);                                                                //1 phyEn
            comm.setLength(1024);                                                         //4 pkgLen
            comm.setLength(0);                                                            //4 pkgTimeout
            comm.setu8(0);                                                                //1 reconnectCnt
            comm.setu8(0);                                                                //1 resetCtrl
            comm.setu8(0);                                                                //1 dnsEn
            byte[] domain_bytes = System.Text.Encoding.Default.GetBytes("");
            Array.Resize(ref domain_bytes, 20);
            comm.setbytes(domain_bytes);                                                  //20 domain
            comm.setbytes(ReaderUtils.GetIpAddrBytes("0.0.0.0"));                          //4 dnsIp
            comm.setPort(0);                                                              //2 dnsPort
            comm.setbytes(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }); //8 reserved

            //Port_1 Use as Serial
            comm.setu8(1);                                                                //1 index
            comm.setu8(1);                                                                //1 portEn
            comm.setu8(0);                                                                //1 netMode
            comm.setu8(0);                                                                //1 randEn
            comm.setPort(4001);                                                           //2 netPort
            comm.setbytes(ReaderUtils.GetIpAddrBytes("192.168.0.200"));                    //4 desIp
            comm.setPort(1000);                                                           //2 desPort
            comm.setLength(115200);                                                       //4 baudrate
            comm.setu8(8);                                                                //1 datasize
            comm.setu8(1);                                                                //1 stopbits
            comm.setu8(4);                                                                //1 parity
            comm.setu8(0);                                                                //1 phyEn
            comm.setLength(1024);                                                         //1 pkgLen
            comm.setLength(0);                                                            //4 pkgTimeout
            comm.setu8(0);                                                                //4 reconnectCnt
            comm.setu8(0);                                                                //1 resetCtrl
            comm.setu8(0);                                                                //1 dnsEn
            byte[] domain1_bytes = System.Text.Encoding.Default.GetBytes("");
            Array.Resize(ref domain1_bytes, 20);
            comm.setbytes(domain_bytes);                                                   //20 domain
            comm.setbytes(ReaderUtils.GetIpAddrBytes("0.0.0.0"));                           //4 dnsIp
            comm.setPort(0);                                                               //2 dnsPort
            comm.setbytes(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });  //8 reserved
            #endregion //NET_COMM

            StartUdp();
            //startRecvUdp = true;
            SendNetPortMessage(comm);
            //waitForGetAndSetAck.Reset();
            //waitForGetAndSetAck.WaitOne();
            //StopUdp();
            //Thread.Sleep(waitTimeout);
        }
    }

    public enum NotifyType
    {
        StatusMessage,
        ErrorMessage
    };
}