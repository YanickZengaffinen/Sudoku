using System;
using System.Collections.Generic;
using System.Text;

namespace ZenDoku.Util
{
    /// <summary>
    /// Class that holds extension methods for operations on arrays
    /// </summary>
    public static class ArrayUtil
    {
        /// <summary>
        /// Loops over a 2D array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this T[,] array, Action<T, RowColumnPointer> action)
        {
            for(int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    action.Invoke(array[i,j], new RowColumnPointer(i, j));
                }
            }
        }
        
    }
}
