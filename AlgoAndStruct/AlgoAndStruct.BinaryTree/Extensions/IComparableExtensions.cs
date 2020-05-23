using System;

namespace AlgoAndStruct.BinaryTree.Extensions
{
    public static class IComparableExtensions
    {
        public static bool GreaterThan(this IComparable x, object y)
        {
            return x.CompareTo(y) == 1;
        }

        public static bool LessThan(this IComparable x, object y)
        {
            return x.CompareTo(y) == -1;
        }

        public static bool IsEqual(this IComparable x, object y)
        {
            return x.CompareTo(y) == 0;
        }
    }
}
