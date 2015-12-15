using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace tspp_lab3
{
   
        class Pokazatel
        {
            /// <summary>
            /// Значення показника
            /// </summary>
            public int val_prm = 0;
            /// <summary>
            /// Ім'я показника
            /// </summary>
            public string name_prm = "";
            /// <summary>
            /// Малювання показника на діаграмі
            /// </summary>
            /// <param name="grf">Об'єкт для виводу діаграми</param>
            /// <param name="clr">Колір зафарбування фігури, що відповідає. показнику</param>
            /// <param name="X">Коорд.X лівого верхнього кута фігури</param>
            /// <param name="Y">Коорд.Y лівого верхнього кута фігури</param>
            /// <param name="W">Ширина фігури</param>
            /// <param name="H">Висота фігури</param>
            public void Draw(Graphics grf, Color clr, int X, int Y, int W, int H)
            {
                //Виводяться еліпс і значення: «ім'я показника» - «значення»
                //Колір тексту - чорний
                Font font = new Font("Arial", 8);
                SolidBrush brush = new SolidBrush(clr);
                grf.FillEllipse(brush, X, Y, W, H);
                grf.DrawString(name_prm + "-" + val_prm.ToString(), font, Brushes.Black, X, Y - 5 + H / 2);
            }
        }

}
