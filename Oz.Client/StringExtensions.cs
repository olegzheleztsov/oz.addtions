using System;

namespace Oz.Client
{
    public static class StringExtensions
    {
        public static bool IsRotation(this string str, string other)
        {
            if (str.Length != other.Length)
            {
                return false;
            }
            string other2 = other + other;
            return other2.Contains(str);
        }
    }
}