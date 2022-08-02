using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fingerprint
{
    public class DelegateCallback
    {
        public delegate void ScanRegisterFingerCallback(String message);
        public delegate void ScanRegisterFingerWithTemplateCallback(String message, byte[] blobTemplate);
    }
}
