using System;

namespace Reader
{
    public class TagMask
    {
        private int writeIndex = 0;
        private int readIndex = 0;

        private byte[] _noData = new byte[0];
        private byte mask_id;
        private byte mask_quantity;
        private byte target;
        private byte action;
        private byte membank;
        private byte startAddr;
        private byte bitLen;
        private byte[] mask;
        private byte truncate;

        //Mask ID MaskQuantity Target Action Membank StartingMaskAdd MaskBitLen Mask Truncate
        public TagMask(byte[] data)
        {
            if(data.Length == 0)
            {
                mask_id = 0x00;
                mask_quantity = 0x00;
                target = 0x00;
                action = 0x00;
                membank = 0x00;
                startAddr = 0x00;
                bitLen = 0x00;
                mask = _noData;
                truncate = 0x00;
                return;
            }
            readIndex = 0;
            mask_id = data[readIndex++];
            mask_quantity = data[readIndex++];
            target = data[readIndex++];
            action = data[readIndex++];
            membank = data[readIndex++];
            startAddr = data[readIndex++];
            bitLen = data[readIndex++];
            int bytesLen = bitLen / 8;
            mask = new byte[bytesLen];
            Array.Copy(data, readIndex, mask, 0, bytesLen);
            readIndex += bytesLen;

            truncate = data[readIndex++];
        }

        public int MaskID { get { return mask_id; } }
        public int Quantity { get { return mask_quantity; } }
        public SessionID Target 
        { 
            get 
            {
                if(target<0||target>4)
                {
                    return SessionID.S0;
                }
                return (SessionID)target; 
            } 
        }
        public byte Action { get { return action; } }

        public string ActionStr { get { return string.Format("0x{0:x2}", action); } }

        public MemBank Bank
        {
            get
            {
                if (membank < 0 || membank > 3)
                {
                    return MemBank.Reserved;
                }
                return (MemBank)membank;
            }
        }
        public string StartAddrHexStr { get { return startAddr.ToString("x2"); } }//HexStr
        public int StartAddr { get { return startAddr; } }
        public string MaskBitLenHexStr { get { return bitLen.ToString("x2"); } }//HexStr
        public int MaskBitLen { get { return bitLen; } }
        public string Mask { get { return ReaderUtils.ToHex(mask, "", " "); } }
        public byte Truncate { get { return truncate; } }

        public override string ToString()
        {
            return string.Format($"mask_id={mask_id}," +
                $"quantity={mask_quantity}," +
                $"target={target}," +
                $"action={action}," +
                $"membank={membank}," +
                $"startAddr={startAddr}," +
                $"bitLen={bitLen}({bitLen/8}Bytes)," +
                $"mask={ReaderUtils.ToHex(mask, "", " ")}," +
                $"truncate={truncate}");
        }

        public void Update(TagMask addData)
        {
            mask_id = (byte)addData.MaskID;
            mask_quantity = (byte)addData.Quantity;
            target = (byte)addData.Target;
            action = (byte)addData.Action;
            membank = (byte)addData.Bank;
            startAddr = (byte)addData.StartAddr;
            bitLen = (byte)addData.MaskBitLen;
            mask = ReaderUtils.FromHex(addData.Mask.Replace(" ", ""));
            truncate = (byte)addData.Truncate;
        }
    }

    public enum SessionID
    {
        //0x00	Inventoried S0
        //0x01	Inventoried S1
        //0x02	Inventoried S2
        //0x03	Inventoried S3
        //0x04	SL
        S0 = 0x00,
        S1 = 0x01,
        S2 = 0x02,
        S3 = 0x03,
        SL = 0x04,
        Reserve5 = 0x05,
        Reserve6 = 0x06,
        Reserve7 = 0x07,
    }

    public enum MemBank
    {
        //Reserved for Future use
        //EPC
        //TID
        //USER
        Reserved = 0x00,
        EPC = 0x01,
        TID = 0x02,
        USER = 0x03,
    }

    public enum MaskAction
    {
        //Tag Matches Mask    Tag Doesn’t Match Mask
        //0x00	Assert SL or inventoried ->A    Deassert SL or inventoried ->B
        //0x01	Assert SL or inventoried ->A    Do nothing
        //0x02	Do nothing  Deassert SL or inventoried->B
        //0x03	Negate SL or(A->B, B->A)	Do nothing
        //0x04	Deassert SL or inventoried ->B  Assert SL or inventoried->A
        //0x05	Deaaert SL or inventoried ->B   Do nothing
        //0x06	Do nothing  Assert SL or inventoried ->A
        //0x07	Do nothing  Negate SL or (A->B, B->A)
        //0x00	Reserved for Future use
    }
}