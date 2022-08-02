using System;

namespace Reader
{
    #region Tag
    public class Tag
    {
        private int writeIndex = 0;
        private int readIndex = 0;
        private int optIndex = 0;

        private byte[] _noData = new byte[0];
        private double UNSPECTTEMP = -100.0;
        private byte[] rawData;
        private byte cmd;
        private byte freqAnt;
        private byte[] pc; // 2
        private byte[] epc; // N
        private byte rssiRaw;
        private byte[] phase; // 2
        private byte[] crc; // 2

        private byte[] data;

        byte antNo;
        byte freq;
        byte rssiH;
        byte rssi;

        byte region;
        byte startFreq;
        byte endFreq;
        byte freqSpace;
        byte freqQuantity;

        private int bufferTagCount = 0;

        private int readcount = 0;
        private int CountHigh = 0;

        private int opSuccessCount = 0;
        private int opDataLen = 0;

        /// <summary>
        /// Time that search started
        /// </summary>
        private DateTime _baseTime;
        /// <summary>
        /// Time tag was read, in milliseconds since start of search
        /// </summary>
        private int _readOffset = 0;
        private bool readPhase = false;
        private byte antGroup = 0x00;

        public Tag(byte[] tagData, byte tagCmd, byte antGroup)
        {
            this.antGroup = antGroup;
            //Console.WriteLine("Tag tagLen={0}", tagData.Length);
            rawData = new byte[tagData.Length];
            Array.Copy(tagData, 0, rawData, 0, rawData.Length);
            this.cmd = tagCmd;
            switch (cmd)
            {
                case 0x81:
                case 0x82:
                case 0x94:
                case 0x83:
                case 0x84:
                    parseOpTagData();
                    break;
                case 0x89:
                case 0x8B:
                case 0x8A:
                    parseInvTagData();
                    break;
                case 0x90:
                case 0x91:
                    parseBufferTagData();
                    break;
                default:
                    break;
            }
        }

        public Tag(byte[] tagData, bool readPhase, byte tagCmd, byte antGroup)
        {
            this.antGroup = antGroup;
            //Console.WriteLine("Tag cmd={0:X2}, readPhase={1}, tag[{2}] {3}", cmd, readPhase, tagData.Length, ReaderUtils.ToHex(tagData, "", " "));
            this.readPhase = readPhase;
            rawData = new byte[tagData.Length];
            Array.Copy(tagData, 0, rawData, 0, rawData.Length);
            this.cmd = tagCmd;
            switch (cmd)
            {
                case 0x89:
                case 0x8B:
                case 0x8A:
                    parseInvTagData();
                    break;
                case 0x90:
                case 0x91:
                    parseBufferTagData();
                    break;
                default:
                    break;
            }
        }

        public int BufferTagCount
        {
            get { return bufferTagCount; }
        }
        public int ReadCount
        {
            get { return readcount; }
            set { readcount = value; }
        }

        public string PC
        {
            get { return ReaderUtils.ToHex(pc, "", " "); }
        }

        public string EPC
        {
            get { return ReaderUtils.ToHex(epc, "", " "); }
        }

        public string Rssi
        {
            //get { return rssi.ToString("X2"); }
            get { return (rssi - 129).ToString(); }
        }

        public string Freq
        {
            //get { return freq.ToString("X2"); }
            get { return String.Format("{0:N2}", (865.0 + 0.5 * freq).ToString("0.00")); }
        }

        public byte FreqByte
        {
            get { return freq; }
        }

        public string Phase
        {
            get { return ReaderUtils.ToHex(phase, "", " "); }
        }

        public string Antenna
        {
            get { return string.Format("{0}", antNo); }
        }

        public string Data
        {
            get { return (data.Length == 0 ? "null" : ReaderUtils.ToHex(data, "", " ")); }
        }

        public string CRC
        {
            get { return ReaderUtils.ToHex(crc, "", " "); }
        }

        public int DataLen
        {
            get { return opDataLen; }
        }

        public int OpSuccessCount
        {
            get { return opSuccessCount; }
        }

        public string Temperature
        {
            get
            {
                return getTemp();
            }
        }
        private string getTemp()
        {
            return "0";
            if(epc.Length <= 11 || data.Length < 4)
            {
                Console.WriteLine("getTemp epc({0})={2}, data({1})={3}", epc.Length, data.Length, EPC, Data);
                return "null";
            }
            byte[] bytes = new byte[8];
            int writeIndex = 0;
            Array.Copy(epc, epc.Length - 4, bytes, 0, 4);
            writeIndex += 4;
            //Console.WriteLine(" Data: {0}", ReaderUtils.ToHex(data, "", " "));
            Array.Copy(data, 0, bytes, writeIndex, 4);
            writeIndex += 4;

            //Console.WriteLine("getTemperature: {0}", ReaderUtils.ToHex(bytes, "", " "));
            int senData = checkData(bytes);
            if (senData < 0)
            {
                Console.WriteLine("Invalid sensor data!");
                return "null";
            }
            int D2 = (senData >> 3) & 0xFFFF;
            //Console.WriteLine("D2: {0}", D2);
            short Δ1 = (short)(((bytes[4] & 0xFF) << 8) | (bytes[5] & 0xFF));
            //Console.WriteLine("Δ1: {0}", Δ1);
            double temp = 11109.6 / (24 + (D2 + Δ1) / 375.3) - 290;
            if (temp > 125)
            {
                temp = temp * 1.2 - 25;
            }
                /*Math.Round(temp, 2)*/;
            String strTemp = Math.Round(temp, 2).ToString();
            return strTemp;
        }
        /**
         * Get senData
         *
         * @param bytes RawData
         * @return value >=0 : success
         * value = -1 : Failed to verify data length
         * value = -2 : Sensor data HEADER verification failed
         * value = -3 : Sensing data SEN_DATA[23:19] needs to be 00100b, otherwise the data is invalid
         * value = -4 : Sensor data verification failed
         * value = -5 : Detect chips that are not LTU32 version
         */
        private int checkData(byte[] bytes)
        {
            //Check data length
            if (bytes.Length != 8)
            {
                return -1;
            }
            //The sensor data HEADER needs to be 0xF, otherwise the data is invalid
            if (((bytes[0] >> 4) & 0x0F) != 0x0F)
            {
                return -2;
            }
            if (((bytes[2] >> 4) & 0x0F) != 0x0F)
            {
                return -2;
            }
            //Detection is LTU32 version of the chip,USR area 0x09[15:12] == 0010b
            if (((bytes[6] >> 4) & 0x0F) != 0x02)
            {
                return -5;
            }
            int senData = ((((bytes[0] & 0x0F) << 8) | (bytes[1] & 0xFF)) << 12) | ((bytes[2] & 0x0F) << 8) | (bytes[3] & 0xFF);
            //Sensor data SEN_DATA[23:19] needs to be 00100b, otherwise the data is invalid
            if (((senData >> 19) & 0x1F) != 0x04)
            {
                return -3;
            }
            //The sensor data shall be verified as follows, otherwise the data will be invalid
            if (((senData >> 2) & 1) != (~(((senData >> 14) & 1) ^ ((senData >> 11) & 1) ^ ((senData >> 8) & 1) ^ ((senData >> 5) & 1)) & 1))
            {
                return -4;
            }
            if (((senData >> 1) & 1) != (~(((senData >> 13) & 1) ^ ((senData >> 10) & 1) ^ ((senData >> 7) & 1) ^ ((senData >> 4) & 1)) & 1))
            {
                return -4;
            }
            if ((senData & 1) != (~(((senData >> 12) & 1) ^ ((senData >> 9) & 1) ^ ((senData >> 6) & 1) ^ ((senData >> 3) & 1)) & 1))
            {
                return -4;
            }
            return senData;
        }

        private void parseBufferTagData()
        {
            //Console.WriteLine("parseBufferTagData={0}", ReaderUtils.ToHex(rawData, "", " "));
            //[TagCount][DataLen][Data][Rssi][FreqAnt][ReadCount]
            //[   2    ][  1    ][  N ][ 1  ][   1   ][   1     ]
            //Data:  PC(2Bytes) + EPC (According to tags specifications + CRC (2Bytes)) 
            int tagLen = rawData.Length;
            writeIndex = 0;
            //TagCount
            bufferTagCount = ReaderUtils.ToU16(rawData, ref writeIndex);
            //DataLen
            int dataLen = rawData[writeIndex++];

            //PC
            pc = new byte[2];
            Array.Copy(rawData, writeIndex, pc, 0, pc.Length);
            writeIndex += pc.Length;

            int epcLen = 0;
            epcLen = dataLen - 4;// pc + crc
            epc = new byte[epcLen];
            Array.Copy(rawData, writeIndex, epc, 0, epc.Length);
            writeIndex += epc.Length;

            crc = new byte[2];
            Array.Copy(rawData, writeIndex, crc, 0, crc.Length);
            writeIndex += crc.Length;

            rssiRaw = rawData[writeIndex++];

            freqAnt = rawData[writeIndex++];

            readcount = rawData[writeIndex++];

            phase = _noData;

            data = _noData;

            freq = (byte)((freqAnt & 0xFC) >> 2);
            antNo = (byte)(freqAnt & 0x03);
            //Console.WriteLine("#3 parseBufferTagData freq={0:x2}", freq);

            rssiH = (byte)((rssiRaw & 0x80) >> 7);
            rssi = (byte)(rssiRaw & 0x7F);
            //Console.WriteLine("#3 parseBufferTagData rssi={0:x2}", rssi);

            // rssiH == true, 5,6,7,8
            antNo = (byte)(antNo + (rssiH == 1 ? 0x04 : 0x00) + (antGroup == 0x01 ? 0x08 : 0x00) + 0x01);
            //Console.WriteLine("#3 parseBufferTagData antNo={0:x2}", antNo);
        }

        private void parseInvTagData()
        {
            //Console.WriteLine("parseInvTagData={0}", ReaderUtils.ToHex(rawData, "", " "));
            //[FreqAnt][PC][EPC][Rssi][Phase]
            //[   1   ][2 ][ N ][ 1  ][   2 ]
            int tagLen = rawData.Length;
            writeIndex = 0;
            //FreqAnt
            freqAnt = rawData[writeIndex++];
            //Console.WriteLine("#3 parseInvTagData freqAnt={0:x2}", freqAnt);

            //PC
            pc = new byte[2];
            Array.Copy(rawData, writeIndex, pc, 0, pc.Length);
            writeIndex += pc.Length;
            //Console.WriteLine("#3 parseInvTagData PC({1})={0}", ReaderUtils.ToHex(pc, "", " "), pc.Length);

            int epcLen = 0;
            if (readPhase)
            {
                epcLen = tagLen - 6;// freqAnt + pc + rssi + phase
            }
            else
            {
                epcLen = tagLen - 4;// freqAnt + pc + rssi
            }
            epc = new byte[epcLen];
            Array.Copy(rawData, writeIndex, epc, 0, epc.Length);
            writeIndex += epc.Length;
            //Console.WriteLine("#3 parseInvTagData EPC({1})={0}", ReaderUtils.ToHex(epc, "", " "), epcLen);

            rssiRaw = rawData[writeIndex++];
            //Console.WriteLine("#3 parseInvTagData rssiRaw={0:x2}", rssiRaw);

            if (readPhase)
            {
                phase = new byte[2];
                Array.Copy(rawData, writeIndex, phase, 0, phase.Length);
            }
            else
            {
                phase = _noData;
            }
            writeIndex += phase.Length;
            //Console.WriteLine("#3 parseInvTagData phase({1})={0}", ReaderUtils.ToHex(phase, "", " "), phase.Length);

            crc = _noData;

            data = _noData;

            freq = (byte)((freqAnt & 0xFC) >> 2);
            antNo = (byte)(freqAnt & 0x03);
            //Console.WriteLine("#3 parseInvTagData freq={0:x2}", freq);

            rssiH = (byte)((rssiRaw & 0x80) >> 7);
            rssi = (byte)(rssiRaw & 0x7F);
            //Console.WriteLine("#3 parseInvTagData rssi={0:x2}", rssi);

            // rssiH == true, 5,6,7,8
            antNo = (byte)(antNo + (rssiH == 1 ? 0x04 : 0x00) + (antGroup == 0x01 ? 0x08 : 0x00) + 0x01);
            //Console.WriteLine("#3 parseInvTagData antNo={0:x2}", antNo);

            readcount = 1;
        }

        private void parseOpTagData()
        {
            //[hdr][len][addr][cmd][TagCount][DataLen][Data][ReadLen][AntId][ReadCount][check]
            //[ 1 ][ 1 ][ 1  ][ 1 ][   2    ][   1   ][  N ][   1   ][  1  ][   1     ][  1  ]
            //Console.WriteLine("parseReadTagData {0}", ReaderUtils.ToHex(rawData, "", " "));
            int readindex = 0;
            //byte[] tagCount = new byte[2];
            //Array.Copy(rawData, readindex, tagCount, 0, tagCount.Length);
            //Console.WriteLine("#2 [{1}]tagCount={0}", ReaderUtils.ToHex(tagCount, "", " "), readindex);
            //readindex += tagCount.Length;
            opSuccessCount = ReaderUtils.ToU16(rawData, ref readindex);
            //Console.WriteLine("#2 [{0}]opSuccessCount={1}", readindex, opSuccessCount);

            byte dataLen = rawData[readindex++];
            //Console.WriteLine("#2 [{1}]dataLen={0:x2}", dataLen, readindex);

            // pc[2] + epc + crc[2]
            byte[] tagdata = new byte[dataLen];
            Array.Copy(rawData, readindex, tagdata, 0, tagdata.Length);
            readindex += tagdata.Length;
            //Console.WriteLine("#2 [{1}]tagdata={0}", ReaderUtils.ToHex(tagdata, "", " "), readindex);

            byte readLen = rawData[readindex++];
            //Console.WriteLine("#2 [{0}] {1}={2:x2}", readindex, (cmd == 0x81 ? "readLen" : "opStatus"), readLen);
            opDataLen = cmd == 0x81 ? Convert.ToInt32(readLen) : 0;

            byte antId = rawData[readindex++];
            //Console.WriteLine("#2 [{1}]antId={0:x2}", antId, readindex);

            freq = Convert.ToByte(((antId & 0xFC) >> 2));
            antNo = Convert.ToByte(((antId & 0x03) >> 0));
            //Console.WriteLine("freq={0},antNo={1}", freq, antNo);

            byte Count = rawData[readindex++];
            //Console.WriteLine("#2 [{1}]Count={0:x2}", Count, readindex);
            readcount = ((Count & 0x7F) >> 0);
            CountHigh = ((Count & 0x80) >> 7);

            // rssiH == true, 5,6,7,8
            antNo = (byte)(antNo + (CountHigh == 1 ? 0x04 : 0x00) + (antGroup == 0x01 ? 0x08 : 0x00) + 0x01);
            //Console.WriteLine("antNo={0}", antNo);
            parseTagData(tagdata, opDataLen);
        }

        private void parseTagData(byte[] tData, int opDataLen)
        {
            // 0x81
            //[PC][EPC][CRC][Data]
            //[ 2][ N ][ 2 ][ M  ] M = readLen
            //Console.WriteLine("parseTagData opDataLen={0}", opDataLen);
            //Console.WriteLine("parseTagData tDataLen={0}", tData.Length);
            //Console.WriteLine("parseTagData {0}", ReaderUtils.ToHex(tData, "", " "));
            int tagLen = tData.Length;
            int readindex = 0;
            pc = new byte[2];
            Array.Copy(tData, readindex, pc, 0, pc.Length);
            readindex += pc.Length;
            //Console.WriteLine("#3  PC({1})={0}", ReaderUtils.ToHex(pc, "", " "), pc.Length);

            int epcLen = tagLen - 4 - opDataLen;
            epc = new byte[epcLen]; // - (pc + crc + dataLen)
            Array.Copy(tData, readindex, epc, 0, epc.Length);
            readindex += epc.Length;
            //Console.WriteLine("#3  EPC({1})={0}", ReaderUtils.ToHex(epc, "", " "), epcLen);

            crc = new byte[2];
            Array.Copy(tData, readindex, crc, 0, crc.Length);
            readindex += crc.Length;
            //Console.WriteLine("#3  CRC({1})={0}", ReaderUtils.ToHex(crc, "", " "), crc.Length);

            if (opDataLen > 0)
            {
                data = new byte[opDataLen];
                Array.Copy(tData, readindex, data, 0, data.Length);
                readindex += data.Length;
                //Console.WriteLine("#3  Data({1})={0}", ReaderUtils.ToHex(data, "", " "), data.Length);
            }
            else
            {
                data = _noData;
            }
        }
    }
    #endregion Tag
}