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
                throw new ArgumentOutOfRangeException(errMessage);
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
                throw new ArgumentOutOfRangeException(errMessage);
            }
        }

        public static void CheckIfObjectIsNull(object obj, string errMessage)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(errMessage);
            }
        }

    }
}
