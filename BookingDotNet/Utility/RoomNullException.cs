using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    public class RoomNullException: ApplicationException
    {
        public RoomNullException(string msg)
            : base(msg)
        {
            
        }
    }
}
