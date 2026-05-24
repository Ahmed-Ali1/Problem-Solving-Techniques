using System;
using System.Collections.Generic;
using System.Text;

namespace Brute_Force
{
    public static class Generator
    {
        private static readonly Random _random = new Random();

        public static int[,] GenerateMaze(int rows=60, int cols=104, int sRow=1, int sCol =1)
        {
            int eRow = rows - 2;
            int eCol = cols - 2;
            int[,] grid = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (r == 0 || r == rows - 1 || c == 0 || c == cols - 1)
                    {
                        grid[r, c] = 1; 
                    }
                    else
                    {
                        // جدران داخلية بنسبة 35%
                        grid[r, c] = (_random.Next(0, 100) < 35) ? 1 : 0;
                    }
                }
            }

            // الخطوة 2: حفر مسار متعرج وعشوائي (Random Walk)
            int currR = sRow;
            int currC = sCol;

            // استمرار الحفر طالما لم نصل للهدف بعد
            while (currR != eRow || currC != eCol)
            {
                grid[currR, currC] = 0; // فتح الخلية الحالية

                // تحديد الخيارات المتاحة للتقرب من الهدف
                bool canMoveRow = currR != eRow;
                bool canMoveCol = currC != eCol;

                if (canMoveRow && canMoveCol)
                {
                    // اختيار عشوائي 50% للتحرك إما رأسياً أو أفقياً
                    if (_random.Next(0, 2) == 0)
                    {
                        currR += (eRow > currR) ? 1 : -1;
                    }
                    else
                    {
                        currC += (eCol > currC) ? 1 : -1;
                    }
                }
                else if (canMoveRow)
                {
                    // مجبر على التحرك رأسياً فقط
                    currR += (eRow > currR) ? 1 : -1;
                }
                else if (canMoveCol)
                {
                    // مجبر على التحرك أفقياً فقط
                    currC += (eCol > currC) ? 1 : -1;
                }
            }

            // الخطوة 3: تأكيد فتح البداية والنهاية
            grid[sRow, sCol] = 0;
            grid[eRow, eCol] = 0;

            return grid;
        }

    }
}
