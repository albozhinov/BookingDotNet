using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    class RoomNullException: ApplicationException
    {
        public RoomNullException(string msg)
            : base(msg)
        {
            
        }
    }
}
