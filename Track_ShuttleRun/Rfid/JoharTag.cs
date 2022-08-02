using Reader;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Track_ShuttleRun
{
    public class JoharTag
    {
        byte[] _noData = new byte[0];
        private byte[] aryTranData;
        private byte[] pc; // 2
        private byte[] epc;
        private byte[] data;
        private byte[] crc; // 2

        private int readcount = 0;
        /// <summary>
        /// Time tag was read, in milliseconds since start of search
        /// </summary>
        internal int _readOffset = 0;

        public JoharTag(byte[] aryTranData)
        {
            this.aryTranData = aryTranData;

            byte[] rawData = new byte[aryTranData.Length];
            Array.Copy(aryTranData, 0, rawData, 0, rawData.Length);

            int msgLen = rawData.Length;
            int readindex = 0;
            byte hdr = rawData[readindex++];
            //Console.WriteLine("#1 JoharTag [{1}]hdr={0:x2}", hdr, readindex);
            byte len = rawData[readindex++];
            //Console.WriteLine("#1 JoharTag [{1}]len={0:x2}", len, readindex);
            byte addr = rawData[readindex++];
            //Console.WriteLine("#1 JoharTag [{1}]addr={0:x2}", addr, readindex);
            byte cmd = rawData[readindex++];
            //Console.WriteLine("#1 JoharTag [{1}]cmd={0:x2}", cmd, readindex);
            byte[] data = new byte[msgLen - 5]; // hdr + len + addr + cmd + check
            Array.Copy(rawData, readindex, data, 0, data.Length);
            readindex += data.Length;
            byte check = rawData[readindex++];
            //Console.WriteLine("#1 JoharTag [{1}]check={0:x2}", check, readindex);

            parseJoharData(data);
        }

        public int ReadCount
        {
            get { return readcount; }
            set { readcount = value; }
        }

        public string PC
        {
            get { return ReaderUtils.ToHex(pc, "", ""); }
        }

        public string EPC
        {
            get { return ReaderUtils.ToHex(epc, "", ""); }
        }

        public string Data
        {
            get { return (data.Length==0?"null": ReaderUtils.ToHex(data, "", "")); }
        }

        public string CRC
        {
            get { return ReaderUtils.ToHex(crc, "", ""); }
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
            if(epc.Length <= 11 || data.Length < 4)
            {
                //Console.WriteLine("getTemp epc({0})={2}, data({1})={3}", epc.Length, data.Length, EPC, Data);
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
                //Console.WriteLine("Invalid sensor data!");
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
            //Detection is not LTU32 version of the chip,USR bank 0x09[15:12] == 0010b
            if (((bytes[6] >> 4) & 0x0F) != 0x02)
            {
                return -5;
            }
            int senData = ((((bytes[0] & 0x0F) << 8) | (bytes[1] & 0xFF)) << 12) | ((bytes[2] & 0x0F) << 8) | (bytes[3] & 0xFF);
            //sensor data SEN_DATA[23:19] It needs to be 00100b, otherwise the data is invalid
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

        private void parseJoharData(byte[] data)
        {
            //Console.WriteLine("parseJoharData");
            byte[] parseData = new byte[data.Length];
            Array.Copy(data, 0, parseData, 0, parseData.Length);

            int readindex = 0;
            byte[] tagCount = new byte[2];
            Array.Copy(parseData, readindex, tagCount, 0, tagCount.Length);
            //Console.WriteLine("#2 parseJoharData [{1}]tagCount={0}", ReaderUtils.ToHex(tagCount, "", " "), readindex);
            readindex += tagCount.Length;
            

            byte dataLen = parseData[readindex++];
            //Console.WriteLine("#2 parseJoharData [{1}]dataLen={0:x2}", dataLen, readindex);

            // pc[2] + epc + crc[2]
            byte[] tagdata = new byte[dataLen];
            Array.Copy(parseData, readindex, tagdata, 0, tagdata.Length);
            readindex += tagdata.Length;
            //Console.WriteLine("#2 parseJoharData [{1}]tagdata={0}", ReaderUtils.ToHex(tagdata, "", " "), readindex);

            byte readLen = parseData[readindex++];
            //Console.WriteLine("#2 parseJoharData [{1}]readLen={0:x2}", readLen, readindex);

            byte antId = parseData[readindex++];
            //Console.WriteLine("#2 parseJoharData [{1}]antId={0:x2}", antId, readindex);

            byte readCount = parseData[readindex++];
            //Console.WriteLine("#2 parseJoharData [{1}]readCount={0:x2}", readCount, readindex);
            readcount = readCount;

            parseJoharTagData(tagdata, readLen);
        }

        private void parseJoharTagData(byte[] tagdata, byte readLen)
        {
            //Console.WriteLine("parseJoharTagData");
            byte[] tData = new byte[tagdata.Length];
            Array.Copy(tagdata, 0, tData, 0, tData.Length);

            int tagLen = tData.Length;
            int readindex = 0;
            pc = new byte[2];
            Array.Copy(tData, readindex, pc, 0, pc.Length);
            readindex += pc.Length;
            //Console.WriteLine("#3 parseJoharTagData PC({1})={0}", ReaderUtils.ToHex(pc, "", " "), pc.Length);

            int epcLen = tagLen - 4 - readLen;
            epc = new byte[epcLen]; // - (pc + crc + dataLen)
            Array.Copy(tData, readindex, epc, 0, epc.Length);
            readindex += epc.Length;
            //Console.WriteLine("#3 parseJoharTagData EPC({1})={0}", ReaderUtils.ToHex(epc, "", " "), epcLen);

            crc = new byte[2];
            Array.Copy(tData, readindex, crc, 0, crc.Length);
            readindex += crc.Length;
            //Console.WriteLine("#3 parseJoharTagData CRC({1})={0}", ReaderUtils.ToHex(crc, "", " "), crc.Length);

            if (readLen > 0)
            {
                data = new byte[readLen];
                Array.Copy(tData, readindex, data, 0, data.Length);
                readindex += data.Length;
                //Console.WriteLine("#3 parseJoharTagData Data({1})={0}", ReaderUtils.ToHex(data, "", " "), data.Length);
            }
            else
            {
                data = _noData;
            }

        }
    }

    public class TagReadRecordBindingList : SortableBindingList<JorharTagRecord>
    {
        protected override Comparison<JorharTagRecord> GetComparer(PropertyDescriptor prop)
        {
            Comparison<JorharTagRecord> comparer = null;
            switch (prop.Name)
            {
                case "SerialNumber":
                    comparer = new Comparison<JorharTagRecord>(delegate (JorharTagRecord a, JorharTagRecord b)
                    {
                        return (int)(a.SerialNumber - b.SerialNumber);
                    });
                    break;
                case "ReadCount":
                    comparer = new Comparison<JorharTagRecord>(delegate (JorharTagRecord a, JorharTagRecord b)
                    {
                        return a.ReadCount - b.ReadCount;
                    });
                    break;
                case "EPC":
                    comparer = new Comparison<JorharTagRecord>(delegate (JorharTagRecord a, JorharTagRecord b)
                    {
                        return String.Compare(a.EPC, b.EPC);
                    });
                    break;
                case "Data":
                    comparer = new Comparison<JorharTagRecord>(delegate (JorharTagRecord a, JorharTagRecord b)
                    {
                        return String.Compare(a.Data, b.Data);
                    });
                    break;
                case "Temperature":
                    comparer = new Comparison<JorharTagRecord>(delegate (JorharTagRecord a, JorharTagRecord b)
                    {
                        return String.Compare(a.Temperature, b.Temperature); ;
                    });
                    break;
            }
            return comparer;
        }
    }

    public class JoharTagDB
    {
        private TagReadRecordBindingList _tagList = new TagReadRecordBindingList();

        /// <summary>
        /// EPC index into tag list
        /// </summary>
        private Dictionary<string, JorharTagRecord> EpcIndex = new Dictionary<string, JorharTagRecord>();

        static long UniqueTagCounts = 0;
        static long TotalTagCounts = 0;

        public BindingList<JorharTagRecord> TagList
        {
            get { return _tagList; }
        }
        public long UniqueTagCount
        {
            get { return UniqueTagCounts; }
        }
        public long TotalTagCount
        {
            get { return TotalTagCounts; }
        }

        public void Clear()
        {
            EpcIndex.Clear();
            UniqueTagCounts = 0;
            TotalTagCounts = 0;
            _tagList.Clear();
            // Clear doesn't fire notifications on its own
            _tagList.ResetBindings();
        }

        public void Add(JoharTag addData)
        {
            lock (new Object())
            {
                string key = null;
                key = addData.EPC.Substring(0, 4);

                UniqueTagCounts = 0;
                TotalTagCounts = 0;

                if (!EpcIndex.ContainsKey(key))
                {
                    JorharTagRecord value = new JorharTagRecord(addData);
                    value.SerialNumber = (uint)EpcIndex.Count + 1;
                    _tagList.Add(value);
                    EpcIndex.Add(key, value);
                    //Call this method to calculate total tag reads and unique tag read counts 
                    UpdateTagCountTextBox(EpcIndex);
                }
                else
                {
                    EpcIndex[key].Update(addData);
                    UpdateTagCountTextBox(EpcIndex);
                }
            }
        }

        //Calculate total tag reads and unique tag reads.
        public void UpdateTagCountTextBox(Dictionary<string, JorharTagRecord> EpcIndex)
        {
            UniqueTagCounts += EpcIndex.Count;
            JorharTagRecord[] dataRecord = new JorharTagRecord[EpcIndex.Count];
            EpcIndex.Values.CopyTo(dataRecord, 0);
            TotalTagCounts = 0;
            for (int i = 0; i < dataRecord.Length; i++)
            {
                TotalTagCounts += dataRecord[i].ReadCount;
            }
        }
    }

    public class JorharTagRecord : INotifyPropertyChanged
    {
        protected JoharTag RawRead = null;
        protected bool dataChecked = false;
        protected UInt32 serialNo = 0;
        protected string oldTemp = "null";
        public JorharTagRecord(JoharTag newData)
        {
            lock (new Object())
            {
                RawRead = newData;
            }
        }
        /// <summary>
        /// Merge new tag read with existing one
        /// </summary>
        /// <param name="data">New tag read</param>
        public void Update(JoharTag mergeData)
        {
            //Console.WriteLine("Update {0}", mergeData.EPC);
            mergeData.ReadCount += ReadCount;
            RawRead = mergeData;
            RawRead.ReadCount = mergeData.ReadCount;
            if (!RawRead.Temperature.Equals("null"))
            {
                oldTemp = RawRead.Temperature;
            }
            OnPropertyChanged(null);
        }

        public UInt32 SerialNumber
        {
            get { return serialNo; }
            set { serialNo = value; }
        }

        public int ReadCount
        {
            get { return RawRead.ReadCount; }
        }

        public string EPC
        {
            get { return RawRead.EPC.Substring(0, 4); }
        }
        public string Data
        {
            get { return RawRead.Data; }
        }

        public string Temperature
        {
            
            get {
                bool checkTemp = RawRead.Temperature.Equals("null");
                return (checkTemp==false?RawRead.Temperature:oldTemp);
            }
        }

        //public bool Checked
        //{
        //    get { return dataChecked; }
        //    set
        //    {
        //        dataChecked = value;
        //    }
        //}

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventArgs td = new PropertyChangedEventArgs(name);
            try
            {
                if (null != PropertyChanged)
                {
                    PropertyChanged(this, td);
                }
            }
            finally
            {
                td = null;
            }
        }
        #endregion
    }
}