using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace CodeSnippets
{
    public class ExceptionOperation
    {
        public static double SaveDivision(double x, double y)
        {
            if (y == 0)
                throw new DivideByZeroException();
            return x / y;
        }
        public static void TestThrow()
        {
            CustomException ex =
                new CustomException("Custom exception in TestThrow()");

            throw ex;
        }

        public static int GetInt(int[] array, int index)
        {
            try
            {
                return array[index];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                throw new ArgumentOutOfRangeException($"{nameof(index)} parameter is out of range", e);
            }
        }
    }

    public class CustomException : Exception
    {
        public CustomException() : base() { }
        public CustomException(string message) : base(message) { }
        public CustomException(string message, Exception inner) : base(message, inner) { }

        // 用于序列化异常
        public CustomException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
