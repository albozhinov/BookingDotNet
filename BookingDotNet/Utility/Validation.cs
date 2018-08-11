using System;
using System.Collections.Generic;


namespace Utility
{
    public static class Validation
    {
        public static void NumberBorderCheck<T>(T minCap, T maxCap, T givenCap, string errMessage)
            where T : IComparable<T>
        {
            if (givenCap.CompareTo(minCap) == -1 || givenCap.CompareTo(maxCap) == 1)
            {
                throw new ArgumentException(errMessage);
            }
        }
        public static void StringLengthCheck(int minCap, int maxCap, string givenMes, string errMessage)
        {
            if (givenMes.Length < minCap || givenMes.Length > maxCap)
            {
                throw new ArgumentException(errMessage);
            }
        }
        public static void CantBeZero<T>(T givenNum, string errMessage)
            where T : IComparable<T>
        {

            if (Comparer<T>.Default.Compare(givenNum, default(T)) < 0)
            {
                throw new ArgumentException(errMessage);
            }
        }

        public static void CheckIfObjectIsNull(object obj, string ex)
        {
            if (obj == null)
            {
                throw new ArgumentException(ex);
            }
        }

        public static void CheckIfObjectIsNull(object obj)
        {
            if (obj == null)
            {
                throw new RoomNullException("No room found");
            }
        }
        public static void isNumber (string givenNum, string errMessage)
        {
            if (!long.TryParse(givenNum,out long result))
            {
                throw new ArgumentException(errMessage);
            }
        }


    }
}
