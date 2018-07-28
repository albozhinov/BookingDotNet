using System;
using Utility;

namespace StartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            Validation.CantBeZero(-5, "ERROR");
        }
    }
}
