using LibMas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_2
{
    public static class Calculation
    {
        /// <summary>
        /// Нахождение произведения чисел 
        /// </summary>
        /// <param name="array">Массив чисел больше и меньше нуля</param>
        /// <returns>Произведение чисел</returns>
        public static string GetProduct(this Arrayx array)
        {
            int rez = 1;
            for (int i = 0; i < array.Length; i++)
            {
                rez *= array[i];
            }
            return rez.ToString();
        }
    }
}
