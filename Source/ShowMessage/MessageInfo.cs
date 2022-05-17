using System;
using System.Collections.Generic;
using System.Text;

namespace ShowMessage
{
    public class MessageInfo
    {
        public string title
        {
            get;
            set;
        }

        public string content
        {
            get;
            set;
        }

        public string url
        {
            get;
            set;
        }

        public string time
        {
            get;
            set;
        }

        public bool Equals(MessageInfo info)
        {
            if (info == null)
                return true;
            return (this.time==info.time)
                && (this.title == info.title)
                && (this.content == info.content)
                && (this.url == info.url);
        }
    }
}
