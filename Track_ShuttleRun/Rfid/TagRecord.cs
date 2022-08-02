using Reader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Track_ShuttleRun
{
    public class TagRecordBindingList : SortableBindingList<TagRecord>
    {
        protected override Comparison<TagRecord> GetComparer(PropertyDescriptor prop)
        {
            Comparison<TagRecord> comparer = null;
            switch (prop.Name)
            {
                case "SerialNumber":
                    comparer = new Comparison<TagRecord>(delegate (TagRecord a, TagRecord b)
                    {
                        return (int)(a.SerialNumber - b.SerialNumber);
                    });
                    break;
                case "ReadCount":
                    comparer = new Comparison<TagRecord>(delegate (TagRecord a, TagRecord b)
                    {
                        return a.ReadCount - b.ReadCount;
                    });
                    break;
                case "PC":
                    comparer = new Comparison<TagRecord>(delegate (TagRecord a, TagRecord b)
                    {
                        return String.Compare(a.PC, b.PC);
                    });
                    break;
                case "CRC":
                    comparer = new Comparison<TagRecord>(delegate (TagRecord a, TagRecord b)
                    {
                        return String.Compare(a.CRC, b.CRC);
                    });
                    break;
                case "EPC":
                    comparer = new Comparison<TagRecord>(delegate (TagRecord a, TagRecord b)
                    {
                        return String.Compare(a.EPC, b.EPC);
                    });
                    break;
                case "Rssi":
                    comparer = new Comparison<TagRecord>(delegate (TagRecord a, TagRecord b)
                    {
                        return String.Compare(a.Rssi, b.Rssi);
                    });
                    break;
                case "Phase":
                    comparer = new Comparison<TagRecord>(delegate (TagRecord a, TagRecord b)
                    {
                        return String.Compare(a.Phase, b.Phase);
                    });
                    break;
                case "Freq":
                    comparer = new Comparison<TagRecord>(delegate (TagRecord a, TagRecord b)
                    {
                        return String.Compare(a.Freq, b.Freq);
                    });
                    break;
                case "Antenna":
                    comparer = new Comparison<TagRecord>(delegate (TagRecord a, TagRecord b)
                    {
                        return String.Compare(a.Antenna, b.Antenna);
                    });
                    break;
                case "Data":
                    comparer = new Comparison<TagRecord>(delegate (TagRecord a, TagRecord b)
                    {
                        return String.Compare(a.Data, b.Data);
                    });
                    break;
                case "DataLen":
                    comparer = new Comparison<TagRecord>(delegate (TagRecord a, TagRecord b)
                    {
                        return String.Compare(a.DataLen, b.DataLen);
                    });
                    break;
                case "OpSuccessCount":
                    comparer = new Comparison<TagRecord>(delegate (TagRecord a, TagRecord b)
                    {
                        return String.Compare(a.OpSuccessCount, b.OpSuccessCount);
                    });
                    break;
            }
            return comparer;
        }
    }

    #region TagDB
    public class TagDB
    {
        private TagRecordBindingList _tagList = new TagRecordBindingList();

        /// <summary>
        /// EPC index into tag list
        /// </summary>
        private Dictionary<string, TagRecord> EpcIndex = new Dictionary<string, TagRecord>();
        private List<string> EpcIndexForTest = new List<string>();

        static long uniqueTagCounts = 0; // Total Tag quantity
        static long totalReadCounts = 0; // Total read times
        static uint totalCommandTimes = 0; // Total execution time
        uint cmdTotalRead = 0; // Number of labels read in a single inventory (including duplicate labels)
        uint cmdCommandDuration = 0; // Single execution instruction time
        ushort cmdReadRate = 0; // The counting rate of a single execution instruction
        uint cmdTotalUniqueRead = 0; //Number of labels read in a single inventory (excluding duplicate labels)

        #region 0x79
        byte region;
        byte startFreq;
        byte endFreq;
        byte freqSpace;
        byte freqQuantity;
        #endregion 0x79

        private byte antGroup = 0x00;

        public BindingList<TagRecord> TagList
        {
            get { return _tagList; }
        }
        public long TotalTagCounts
        {
            get { return uniqueTagCounts; }
        }
        public long TotalReadCounts
        {
            get { return totalReadCounts; }
        }

        public uint TotalCommandTime { 
            get { return totalCommandTimes; } 
        }

        public uint CommandDuration
        {
            get { return cmdCommandDuration; }
        }

        public long CmdTotalRead
        {
            get { return cmdTotalRead; }
        }

        public int CmdReadRate
        {
            get { return cmdReadRate; }
        }

        public uint CmdUniqueTagCount
        {
            get { return cmdTotalUniqueRead; }
            set {
                if(value == 0)
                {
                    EpcIndexForTest.Clear();
                }
                cmdTotalUniqueRead = value; 
            }
        }

        public int MinRSSI { get; internal set; }
        public int MaxRSSI { get; internal set; }
        public byte AntGroup 
        { 
            get { return antGroup; } 
            set 
            {
                if (value == 0x00)
                {
                    antGroup = 0x00;
                }
                else
                {
                    antGroup = 0x01;
                }
            } 
        }

        public void UpdateCmd89ExecuteSuccess(byte[] data)
        {
            //msg : [hdr][len][addr][cmd][data][check]
            //data: [antId][TotalRead][CommandDuration]
            //      [  1  ][  2      ][      4        ] 
            //Console.WriteLine("data={0}", ReaderUtils.ToHex(data, "", " "));
            int readIndex = 0;
            byte antId = data[readIndex++];
            ushort readRate = ReaderUtils.ToU16(data, ref readIndex);
            
            uint totalRead = ReaderUtils.ToU32(data, ref readIndex);

            cmdTotalRead = totalRead;
            cmdReadRate = readRate;
            cmdCommandDuration = cmdReadRate == 0 ? cmdCommandDuration : ((cmdTotalRead * 1000) / cmdReadRate);
            totalCommandTimes += cmdCommandDuration;
            //Console.WriteLine("antId={0}, readRate={1}, totalRead={2}, totalTime={3}", antId, readRate, totalRead, cmdReadRate == 0 ? cmdCommandDuration : ((cmdTotalRead * 1000) / cmdReadRate));
        }

        public void UpdateCmd8AExecuteSuccess(byte[] data)
        {
            //msg : [hdr][len][addr][cmd][data][check]
            //data: [TotalRead][CommandDuration]
            //      [  3      ][      4        ] 
            //Console.WriteLine("data={0}", ReaderUtils.ToHex(data, "", " "));
            int readIndex = 0;
            byte[] bTotalRead = new byte[4];
            Array.Copy(data, 0, bTotalRead, 1, bTotalRead.Length - 1);
            uint totalRead = ReaderUtils.ToU32(bTotalRead, ref readIndex);
            readIndex--;

            //Console.WriteLine("readIndex={0}, bTotalRead={1}", readIndex, ReaderUtils.ToHex(bTotalRead, "", " "));
            uint commandDuration = ReaderUtils.ToU32(data, ref readIndex);
            //Console.WriteLine("readIndex={0}, totalRead={1}, commandDuration={2}", readIndex, totalRead, commandDuration);

            cmdTotalRead = totalRead;
            cmdCommandDuration = commandDuration;
            cmdReadRate = (cmdCommandDuration == 0 ? cmdReadRate : (ushort)(cmdTotalRead * 1000 / cmdCommandDuration));
            totalCommandTimes += cmdCommandDuration;
            //Console.WriteLine("antId={0}, readRate={1}, totalRead={2}, totalTime={3}", antId, readRate, totalRead, cmdReadRate == 0 ? cmdCommandDuration : ((cmdTotalRead * 1000) / cmdReadRate));
        }

        public void UpdateCmd80ExecuteSuccess(byte[] data)
        {
            //msg : [hdr][len][addr][cmd][data][check]
            //data: [AntId][TagCount][ReadRate][TotalRead]
            //      [  1  ][   2    ][  2     ][   4     ] 
            //Console.WriteLine("data={0}", ReaderUtils.ToHex(data, "", " "));
            int readIndex = 0;
            byte antId = data[readIndex++];
            int tagCount = ReaderUtils.ToU16(data, ref readIndex);
            int readRate = ReaderUtils.ToU16(data, ref readIndex);
            uint totalRead = ReaderUtils.ToU32(data, ref readIndex);

            //Console.WriteLine("readIndex={0}, antId={1}, tagCount={2}, readRate={3}, totalRead={4}", readIndex, antId, tagCount, readRate, totalRead);

            cmdTotalRead = totalRead;
            cmdReadRate = (ushort)readRate;
            uniqueTagCounts = (uint)tagCount;
            totalReadCounts += totalRead;
        }

        public void Clear()
        {
            EpcIndex.Clear();
            _tagList.Clear();
            MaxRSSI = 0;
            MinRSSI = 0;
            uniqueTagCounts = 0;
            totalReadCounts = 0;
            totalCommandTimes = 0;
            cmdCommandDuration = 0;
            cmdReadRate = 0;
            cmdTotalRead = 0;
            // Clear doesn't fire notifications on its own
            _tagList.ResetBindings();

            EpcIndexForTest.Clear();
            cmdTotalUniqueRead = 0;

        }

        public void Add(Tag addData)
        {
            lock (new Object())
            {
                string key = null;
                key = addData.EPC;

                if(!EpcIndexForTest.Contains(key))
                {
                    cmdTotalUniqueRead++;
                    EpcIndexForTest.Add(key);
                }

                uniqueTagCounts = 0;
                totalReadCounts = 0;

                if (!EpcIndex.ContainsKey(key))
                {
                    //Console.WriteLine("Add key={0}", key);
                    TagRecord value = new TagRecord(addData);
                    value.SerialNumber = (uint)EpcIndex.Count + 1;
                    value.Region = region;
                    value.StartFreq = startFreq;
                    value.EndFreq = endFreq;
                    value.FreqSpace = freqSpace;
                    value.FreqQuantity = freqQuantity;

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
        public void UpdateTagCountTextBox(Dictionary<string, TagRecord> EpcIndex)
        {
            uniqueTagCounts = EpcIndex.Count;
            TagRecord[] dataRecord = new TagRecord[EpcIndex.Count];
            EpcIndex.Values.CopyTo(dataRecord, 0);
            totalReadCounts = 0;
            for (int i = 0; i < dataRecord.Length; i++)
            {
                totalReadCounts += dataRecord[i].ReadCount;
            }
        }

        #region 0x79
        public void UpdateRegionInfo(byte[] data)
        {
            int readIndex = 0;
            region = data[readIndex++];
            switch (region)
            {
                case 0x01:
                case 0x02:
                case 0x03:
                    startFreq = data[readIndex++];
                    endFreq = data[readIndex++];
                    freqSpace = 0x05;
                    freqQuantity = (byte)((endFreq - startFreq) / freqSpace);
                    break;
                case 0x04:
                    freqSpace = data[readIndex++];
                    freqQuantity = data[readIndex++];
                    startFreq = data[readIndex++];
                    endFreq = (byte)(startFreq + (freqSpace * 10) * freqQuantity);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Manually release change events
        /// </summary>
        public void Repaint()
        {
            _tagList.RaiseListChangedEvents = true;

            //Causes a control bound to the BindingSource to reread all the items in the list and refresh their displayed values.
            _tagList.ResetBindings();

            _tagList.RaiseListChangedEvents = false;
        }
        #endregion 0x79
    }
    #endregion TagDB
    public class TagRecord : INotifyPropertyChanged
    {
        protected Tag RawRead = null;
        protected bool dataChecked = false;
        protected UInt32 serialNo = 0;
        protected string oldTemp = "null";

        #region 0x79
        byte region;
        byte startFreq;
        byte endFreq;
        byte freqSpace;
        byte freqQuantity;
        #endregion 0x79

        public TagRecord(Tag newData)
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
        public void Update(Tag mergeData)
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

        //public DateTime TimeStamp
        //{
        //    get
        //    {
        //        //return DateTime.Now.ToLocalTime();
        //        TimeSpan difftime = (DateTime.Now.ToUniversalTime() - RawRead.Time.ToUniversalTime());
        //        //double a1111 = difftime.TotalSeconds;
        //        if (difftime.TotalHours > 24)
        //            return DateTime.Now.ToLocalTime();
        //        else
        //            return RawRead.Time.ToLocalTime();
        //    }
        //}

        public int ReadCount
        {
            get { return RawRead.ReadCount; }
        }

        public string PC
        {
            get { return RawRead.PC; }
        }

        public string EPC
        {
            get { return RawRead.EPC; }
        }

        public string CRC
        {
            get { return RawRead.CRC; }
        }

        public string Rssi
        {
            get { return RawRead.Rssi; }
        }

        public string Freq
        {
            get {
                //Console.WriteLine("Freq {0:X2}", RawRead.FreqByte);
                //Console.WriteLine("Region {0:X2} [{1:X2} to {2:X2}] space={3:X2} quantity={4:X2}", 
                //    region, startFreq, endFreq, freqSpace, freqQuantity);
                string strFreq;
                switch (region)
                {
                    case 0x01:
                    case 0x02:
                    case 0x03:
                        if (RawRead.FreqByte < 0x07)
                            strFreq = (865 + RawRead.FreqByte * 0.5).ToString("0.00");
                        else
                        {
                            strFreq = (902 + (RawRead.FreqByte - 7) * 0.5).ToString("0.00");
                        }
                        break;
                    case 0x04:
                        strFreq = ((startFreq + (freqSpace * 10) * RawRead.FreqByte) / 1000).ToString("0.00"); 
                        break;
                    default:
                        strFreq = "0.00";
                        break;
                }

                return strFreq;
            }
        }

        public string Phase
        {
            get { return RawRead.Phase; }
        }

        public string Antenna
        {
            get { return RawRead.Antenna; }
        }

        public string Data
        {
            get { return RawRead.Data; }
        }

        public string DataLen
        {
            get { return RawRead.DataLen.ToString(); }
        }

        public string OpSuccessCount
        {
            get { return RawRead.OpSuccessCount.ToString(); }
        }

        public byte Region
        {
            set { region = value; }
        }
        public byte StartFreq
        {
            set { startFreq = value; }
        }
        public byte EndFreq
        {
            set { endFreq = value; }
        }
        public byte FreqSpace
        {
            set { freqSpace = value; }
        }
        public byte FreqQuantity
        {
            set { freqQuantity = value; }
        }

        public string Temperature
        {
            get
            {
                bool checkTemp = RawRead.Temperature.Equals("null");
                return (checkTemp == false ? RawRead.Temperature : oldTemp);
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
