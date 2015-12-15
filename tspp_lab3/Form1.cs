using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tspp_lab3
{

    
    public partial class Form1 : Form
    {
        Pokazatel[] prm = null;
        char[] separator = { ';' };
        Random randObj = new Random();
        public Form1()
        {
            InitializeComponent();

            
            
            		//Генератор випадкових чисел

            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void Draw_diagrama(Graphics graf, Color fon)
        {
            int w_graf = pictureBox1.Width;		//Ширина діаграми
            int h_graf = pictureBox1.Height;		//Висота діаграми
            int h_zone = h_graf / 3;			//Висота зони фігури
            float xc = pictureBox1.Width / 2f;		//Абсциса центра pictureBox1
            float yc = pictureBox1.Height / 2f;		//Ордината центра pictureBox1
            //Визначення інструментів для малювання
            Font font = new Font("Arial", 8);
            SolidBrush brush = new SolidBrush(Color.LightSteelBlue);
            Pen pen = new Pen(Color.Black, 2);
            Color clr = Color.Bisque;

            int N = prm.Length / 2;		// до-у зон в одному ряді
            if (N * 2 != prm.Length) N++;
            int pole = 4;
            int w_zone = w_graf / N;	//ширина зони
            int summa = 0;
            //рисование суммы:
            graf.FillEllipse(brush, xc-35, 0, 70, 35);
            int Y = 35, X = w_graf/2;
            graf.DrawLine(pen, X, Y, X, Y+10);
            Y = 45; X = 45;
            graf.DrawLine(pen, X, Y, w_graf-45, Y);
            Y = 55; X = 10;
            //ряд сверху
            for (int j = 0; j < N; j++)
            {
                clr = Color.FromArgb(randObj.Next(255), randObj.Next(255), randObj.Next(255));
                prm[j].Draw(graf, clr, X, Y, 70, 35);
                graf.DrawLine(pen, X+35, Y+1, X+35, 45);
                X += 183;
                summa += prm[j].val_prm;

            }
            //РЯД НИЖЕ
            Y = 100; X = 10;
            for (int j = 0; j < N; j++)
            {
                clr = Color.FromArgb(randObj.Next(255), randObj.Next(255), randObj.Next(255));
                prm[j].Draw(graf, clr, X, Y, 70, 35);
                graf.DrawLine(pen, X + 35, Y + 1, X + 35, 90);
                X += 183;
                summa += prm[j].val_prm;

            }
            graf.DrawString("Summa: " + summa.ToString(), font, Brushes.Black, xc - 35 + pole, 25 / 2 - pole);

            /*///-вивід верхнього ряду-
            int Y = pole, X = pole;	//установка початкових значень
            int sum = 0;		//установка в 0 підсумкової суми
            for (int j = 0; j < N; j++)
            {
                //генерація випадкового кольору зафарбування 
                clr = Color.FromArgb(randObj.Next(255), randObj.Next(255), randObj.Next(255));

                //малювання лінії із центра фігури в центр малюнка
                graf.DrawLine(pen, X + w_zone / 2, Y + h_zone / 2, xc, yc);

                //виклик методу промальовування поточного показника
                prm[j].Draw(graf, clr, X, Y, w_zone - pole, h_zone - pole);

                //додавання значення показника до підсумкової суми
                sum += prm[j].val_prm;

                //установка абсциси наступної зони (перехід вправо)
                X += w_zone;
            }
            //-вивід нижнього ряду-
            Y = 2 * h_zone + pole;		//ордината нижнього ряду зон
            X = pictureBox1.Width - w_zone + pole;//абсциса самої правої зони

            for (int j = N; j < prm.Length; j++)
            {
                //генерація випадкового кольору зафарбування 
                clr = Color.FromArgb(randObj.Next(255), randObj.Next(255), randObj.Next(255));
                //малювання лінії із центра фігури в центр малюнка
                graf.DrawLine(pen, X + w_zone / 2, Y + h_zone / 2, xc, yc);
                //виклик методу промальовування поточного показника
                prm[j].Draw(graf, clr, X, Y, w_zone - pole, h_zone - pole);
                //додавання значення показника до підсумкової суми
                sum += prm[j].val_prm;
                //установка абсциси наступної зони (перехід уліво)
                X -= w_zone;
            }
            //-вивід підсумку-
            //Визначення координат центральної фігури
            float X1 = (w_graf - w_zone) / 2;
            float Y1 = (h_graf - h_zone) / 2;

            //Промальовування еліпса для підсумкової суми
            graf.FillEllipse(brush, X1, Y1, w_zone - pole, h_zone - pole);

            //Вивід значення підсумкової суми
            graf.DrawString("Summa: " + sum.ToString(), font, Brushes.Black, X1 + pole, Y1 + h_zone / 2 + pole);*/
        
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graf = pictureBox1.CreateGraphics();	//Об'єкт класу Graphics
            Color fon = pictureBox1.BackColor;		//Цвіт тла об'єкта pictureBox1
            graf.Clear(fon);		//очищення площі рисунка
            if (textBox1.Lines.Length == 0) return;
            //очищення масиву об'єктів класу Pokazatel
            if (prm != null) Array.Clear(prm, 0, prm.Length);
            //створення масиву об'єктів класу Pokazatel
            prm = new Pokazatel[textBox1.Lines.Length];

            string[] mass; 		//масив для зберігання подстрок
            string rab;     		//робочий рядок
            //цикл обробки рядків з описами показників
            for (int j = 0; j < prm.Length; j++)
            {
                rab = textBox1.Lines[j];	//вибірка чергового рядка
                //розбивка рядка на масив підрядків по ";"
                mass = rab.Split(separator); //separator - масив роздільників
                prm[j] = new Pokazatel();    //створення об'єкта класу Pokazatel
                if (rab == "")
                { prm[j].name_prm = ""; prm[j].val_prm = 0; }
                else
                {
                    prm[j].name_prm = mass[0];  //запис ім'я показника
                    prm[j].val_prm = Convert.ToInt32(mass[1]); //запис значення
                }
            }
            Draw_diagrama(graf, fon);		//підпрограма 


        }
    }
}
