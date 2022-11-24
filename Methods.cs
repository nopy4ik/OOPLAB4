using FLib.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLAB4
{
    /// <summary>
    /// Методы для работы с командами и фигурами
    /// </summary>
    internal static class Methods
    {
        /// <summary>
        /// Метод проверяет является ли символ в команде не оператором
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool IsNotOperation(char item)
        {
            if (!(item == 'M' || item == 'E' || item == 'D' || item == ',' || item == '(' || item == ')' || item == 'A' || item == 'X'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Метод проверяет будет ли фигура в границах холста при создании
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool IsInBounds(int x, int y, int w, int h)
        {
            if ((y < 0) || (y + h > Init.canvas.Height) || (x < 0) || (x + w > Init.canvas.Width))
            {
                throw new Exception("Нарушены границы или что-то не так");
            }
            else return true;
        }
    }
}
