using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Reader
{
    public class ReaderUtils
    {

        public static byte[] StringArrayToByteArray(string[] strAryHex, int nLen)
        {
            if (strAryHex.Length < nLen)
            {
                nLen = strAryHex.Length;
            }

            byte[] btAryHex = new byte[nLen];

            try
            {
                int nIndex = 0;
                foreach (string strTemp in strAryHex)
                {
                    btAryHex[nIndex] = Convert.ToByte(strTemp, 16);
                    nIndex++;
                }
            }
            catch (System.Exception ex)
            {
            	
            }

            return btAryHex;
        }

        public static string ByteArrayToString(byte[] btAryHex, int nIndex, int nLen)
        {
            if (nIndex + nLen > btAryHex.Length)
            {
                nLen = btAryHex.Length - nIndex;
            }

            string strResult = string.Empty;

            for (int nloop = nIndex; nloop < nIndex + nLen; nloop++ )
            {
                string strTemp = string.Format(" {0:X2}", btAryHex[nloop]);

                strResult += strTemp;
            }

            return strResult;
        }

        /// <summary>
        /// Intercepts and converts a string to a specified length as an array of characters. Spaces are ignored
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="nLength"></param>
        /// <returns></returns>
        public static string[] StringToStringArray(string strValue, int nLength)
        {
            string[] strAryResult = null;

            if (!string.IsNullOrEmpty(strValue))
            {
                System.Collections.ArrayList strListResult = new System.Collections.ArrayList();
                string strTemp = string.Empty;
                int nTemp = 0;

                for (int nloop = 0; nloop < strValue.Length; nloop++ )
                {
                    if (strValue[nloop] == ' ')
                    {
                        continue;
                    }
                    else
                    {
                        nTemp++;

                        // Check whether the intercepted characters are between A~F and 0~9, or exit directly if not
                        System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^(([A-F])*(\d)*)$");
                        if (!reg.IsMatch(strValue.Substring(nloop, 1)))
                        {
                            return strAryResult;
                        }

                        strTemp += strValue.Substring(nloop, 1);

                        // Determine whether the interception length has been reached
                        if ((nTemp == nLength) || (nloop == strValue.Length - 1 && !string.IsNullOrEmpty(strTemp)))
                        {
                            strListResult.Add(strTemp);
                            nTemp = 0;
                            strTemp = string.Empty;
                        }
                    }
                }

                if (strListResult.Count > 0)
                {
                    strAryResult = new string[strListResult.Count];
                    strListResult.CopyTo(strAryResult);
                }
            }

            return strAryResult;
        }

        public static string FormatErrorCode(byte btErrorCode)
        {
            string strErrorCode = "";
            switch (btErrorCode)
            {
                case 0x10:
                    strErrorCode = "Command succeeded";
                    break;
                case 0x11:
                    strErrorCode = "Command failed";
                    break;
                case 0x20:
                    strErrorCode = "CPU reset error";
                    break;
                case 0x21:
                    strErrorCode = "Turn on CW error";
                    break;
                case 0x22:
                    strErrorCode = "Antenna is missing";
                    break;
                case 0x23:
                    strErrorCode = "Write flash error";
                    break;
                case 0x24:
                    strErrorCode = "Read flash error";
                    break;
                case 0x25:
                    strErrorCode = "Set output power error";
                    break;
                case 0x31:
                    strErrorCode = "Error occurred during inventory";
                    break;
                case 0x32:
                    strErrorCode = "Error occurred during read";
                    break;
                case 0x33:
                    strErrorCode = "Error occurred during write";
                    break;
                case 0x34:
                    strErrorCode = "Error occurred during lock";
                    break;
                case 0x35:
                    strErrorCode = "Error occurred during kill";
                    break;
                case 0x36:
                    strErrorCode = "There is no tag to be operated";
                    break;
                case 0x37:
                    strErrorCode = "Tag Inventoried but access failed";
                    break;
                case 0x38:
                    strErrorCode = "Buffer is empty";
                    break;
                case 0x40:
                    strErrorCode = "Access failed or wrong password";
                    break;
                case 0x41:
                    strErrorCode = "Invalid parameter";
                    break;
                case 0x42:
                    strErrorCode = "WordCnt is too long";
                    break;
                case 0x43:
                    strErrorCode = "MemBank out of range";
                    break;
                case 0x44:
                    strErrorCode = "Lock region out of range";
                    break;
                case 0x45:
                    strErrorCode = "LockType out of range";
                    break;
                case 0x46:
                    strErrorCode = "Invalid reader address";
                    break;
                case 0x47:
                    strErrorCode = "AntennaID out of range";
                    break;
                case 0x48:
                    strErrorCode = "Output power out of range";
                    break;
                case 0x49:
                    strErrorCode = "Frequency region out of range";
                    break;
                case 0x4A:
                    strErrorCode = "Baud rate out of range";
                    break;
                case 0x4B:
                    strErrorCode = "Buzzer behavior out of range";
                    break;
                case 0x4C:
                    strErrorCode = "EPC match is too long";
                    break;
                case 0x4D:
                    strErrorCode = "EPC match length wrong";
                    break;
                case 0x4E:
                    strErrorCode = "Invalid EPC match mode";
                    break;
                case 0x4F:
                    strErrorCode = "Invalid frequency range";
                    break;
                case 0x50:
                    strErrorCode = "Failed to receive RN16 from tag";
                    break;
                case 0x51:
                    strErrorCode = "Invalid DRM mode";
                    break;
                case 0x52:
                    strErrorCode = "PLL can not lock";
                    break;
                case 0x53:
                    strErrorCode = "No response from RF chip";
                    break;
                case 0x54:
                    strErrorCode = "Can't achieve desired output power level";
                    break;
                case 0x55:
                    strErrorCode = "Can't authenticate firmware copyright";
                    break;
                case 0x56:
                    strErrorCode = "Spectrum regulation wrong";
                    break;
                case 0x57:
                    strErrorCode = "Output power is too low";
                    break;
                case 0xFF:
                    strErrorCode = "Unknown error";
                    break;

                default:
                    strErrorCode = "Unknown error";
                    break;
            }

            return strErrorCode;
        }

        #region FromHex
        /// <summary>
        /// Convert human-readable hex string to byte array;
        /// e.g., 123456 or 0x123456 -> {0x12, 0x34, 0x56};
        /// </summary>
        /// <param name="hex">Human-readable hex string to convert</param>
        /// <returns>Byte array</returns>
        public static byte[] FromHex(string hex)
        {
            int prelen = 0;

            if (hex.StartsWith("0x") || hex.StartsWith("0X"))
                prelen = 2;

            byte[] bytes = new byte[(hex.Length - prelen) / 2];

            for (int i = 0; i < bytes.Length; i++)
            {
                string bytestring = hex.Substring(prelen + (2 * i), 2);
                bytes[i] = byte.Parse(bytestring, System.Globalization.NumberStyles.HexNumber);
            }

            return bytes;
        }
        #endregion

        #region ToHex
        /// <summary>
        /// Convert byte array to human-readable hex string; e.g., {0x12, 0x34, 0x56} -> 123456
        /// </summary>
        /// <param name="bytes">Byte array to convert</param>
        /// <returns>Human-readable hex string</returns>
        public static string ToHex(byte[] bytes)
        {
            return ToHex(bytes, "0x", "");
        }

        /// <summary>
        /// Convert byte array to human-readable hex string; e.g., {0x12, 0x34, 0x56} -> 123456
        /// </summary>
        /// <param name="bytes">Byte array to convert</param>
        /// <param name="prefix">String to place before byte strings</param>
        /// <param name="separator">String to place between byte strings</param>
        /// <returns>Human-readable hex string</returns>
        public static string ToHex(byte[] bytes, string prefix, string separator)
        {
            if (null == bytes)
                return "null";

            List<string> bytestrings = new List<string>();

            foreach (byte b in bytes)
                bytestrings.Add(b.ToString("X2"));

            return prefix + String.Join(separator, bytestrings.ToArray());
        }

        /// <summary>
        /// Convert u16 array to human-readable hex string; e.g., {0x1234, 0x5678} -> 12345678
        /// </summary>
        /// <param name="words">u16 array to convert</param>
        /// <returns>Human-readable hex string</returns>
        public static string ToHex(UInt16[] words)
        {
            StringBuilder sb = new StringBuilder(4 * words.Length);

            foreach (UInt16 word in words)
                sb.Append(word.ToString("X4"));

            return sb.ToString();
        }
        #endregion

        /// <summary>
        /// Converts word array to byte array
        /// </summary>
        /// <param name="bytes">The byte array</param>
        /// <returns>The converted word array</returns>
        public static ushort[] bytesToWords(byte[] bytes)
        {
            ushort[] memWords = new ushort[bytes.Length / 2];
            for (int i = 0; i < memWords.Length; i++)
            {
                memWords[i] = bytes[2 * i];
                memWords[i] <<= 8;
                memWords[i] |= bytes[2 * i + 1];
            }
            return memWords;
        }

        /// <summary>
        /// Converts byte array to word array
        /// </summary>
        /// <param name="words">The word array</param>
        /// <returns>The converted byte array</returns>
        public static byte[] wordsToBytes(ushort[] words)
        {
            byte[] dataBytes = new byte[words.Length * 2];
            for (int i = 0; i < words.Length; i++)
            {
                dataBytes[2 * i] = (byte)((words[i] >> 8) & 0xFF);
                dataBytes[2 * i + 1] = (byte)((words[i]) & 0xFF);
            }
            return dataBytes;
        }

        #region FromU16

        /// <summary>
        /// Insert unsigned 16-bit integer into big-endian byte string
        /// </summary>
        /// <param name="bytes">Target big-endian byte string</param>
        /// <param name="offset">Location to insert into</param>
        /// <param name="value">16-bit integer to insert</param>
        /// <returns>Number of bytes inserted</returns>
        public static int FromU16(byte[] bytes, int offset, UInt16 value)
        {
            int end = offset;
            bytes[end++] = (byte)((value >> 8) & 0xFF);
            bytes[end++] = (byte)((value >> 0) & 0xFF);
            return end - offset;
        }

        #endregion

        /// <summary>
        /// Extract unsigned 16-bit integer from big-endian byte string
        /// </summary>
        /// <param name="bytes">Source big-endian byte string</param>
        /// <param name="offset">Location to extract from.  Will be updated to post-decode offset.</param>
        /// <returns>Unsigned 16-bit integer</returns>
        public static UInt16 ToU16(byte[] bytes, ref int offset)
        {
            if (null == bytes) return default(byte);
            int hi = (UInt16)(bytes[offset++]) << 8;
            int lo = (UInt16)(bytes[offset++]);
            return (UInt16)(hi | lo);
        }

        #region FromU32

        /// <summary>
        /// Insert unsigned 32-bit integer into big-endian byte string
        /// </summary>
        /// <param name="bytes">Target big-endian byte string</param>
        /// <param name="offset">Location to insert into</param>
        /// <param name="value">32-bit integer to insert</param>
        /// <returns>Number of bytes inserted</returns>
        public static int FromU32(byte[] bytes, int offset, UInt32 value)
        {
            int end = offset;
            bytes[end++] = (byte)((value >> 24) & 0xFF);
            bytes[end++] = (byte)((value >> 16) & 0xFF);
            bytes[end++] = (byte)((value >> 8) & 0xFF);
            bytes[end++] = (byte)((value >> 0) & 0xFF);
            return end - offset;
        }

        #endregion

        #region ToU32

        /// <summary>
        /// Extract unsigned 32-bit integer from big-endian byte string
        /// </summary>
        /// <param name="bytes">Source big-endian byte string</param>
        /// <param name="offset">Location to extract from</param>
        /// <returns>Unsigned 32-bit integer</returns>
        public static UInt32 ToU32(byte[] bytes, ref int offset)
        {
            return (UInt32)(0
                | ((UInt32)(bytes[offset++]) << 24)
                | ((UInt32)(bytes[offset++]) << 16)
                | ((UInt32)(bytes[offset++]) << 8)
                | ((UInt32)(bytes[offset++]) << 0)
                );
        }

        #endregion

        public static byte[] GetIpAddrBytes(string ip)
        {
            return IPAddress.Parse(ip).GetAddressBytes();
            //List<byte> list = new List<byte>();
            //foreach(string str in ip.Split('.'))
            //{
            //    list.Add(byte.Parse(Convert.ToInt32(str).ToString("x"), System.Globalization.NumberStyles.HexNumber));
            //}
            //return list.ToArray() ;
        }

        public static bool CheckIpAddr(string ip)
        {
            IPAddress address;
            return IPAddress.TryParse(ip, out address);
        }

        public static bool CheckMacAddr(string macAddr)
        {
            string pattern = @"^([0-9a-fA-F]{2}:){5}([0-9a-fA-F]{2})$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(macAddr);
        }

        public static byte CheckSum(byte[] btAryBuffer, int nStartPos, int nLen)
        {
            byte btSum = 0x00;

            for (int nloop = nStartPos; nloop < nStartPos + nLen; nloop++)
            {
                btSum += btAryBuffer[nloop];
            }

            return Convert.ToByte(((~btSum) + 1) & 0xFF);
        }
    }
}