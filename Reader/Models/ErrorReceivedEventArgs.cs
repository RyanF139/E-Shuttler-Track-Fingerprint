using System;

namespace Reader
{
    public class ErrorReceivedEventArgs : EventArgs
    {
        private string exStr;
        private Exception e;
        public ErrorReceivedEventArgs(string exStr, Exception e)
        {
            this.exStr = exStr;
            this.e = e;
        }

        public Error EventType { get; }
        public string ErrStr { get { return exStr; } }

        public Exception Err { get { return e; } }
    }

    public enum Error
    {
        Default
    }
}