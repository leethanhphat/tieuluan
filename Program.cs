using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace touch
{
    class Program
    {
        static string[,] Array = new string[30, 150];
        static string Level, st = "";
        static int Time;
        const int Length_Game = 150;
        const int TimeEasy = 300;
        const int TimeMedium = 150;
        const int TimeHard = 70;

        static void KhoiTao()
        {
            Console.WriteLine("Chon muc do (De, Trung Binh, Kho)");
            string st = Console.ReadLine();
            st = st.ToUpper();
            Level = (st == "DE") ? "easy" : (st == "TRUNG BINH") ? "medium" : "hard";
            Time = (st == "DE") ? TimeEasy : (st == "TRUNG BINH") ? TimeMedium : TimeHard;
            Console.Clear();
            for (int i = 0; i < 29; i++)
                for (int j = 0; j < 150; j++)
                    Array[i, j] = " ";
        }
        static void TaoThanhDung()
        {
            Console.SetCursorPosition(1, 30);
            for (int i = 1; i <= Length_Game; i++)
                Console.Write('_');
        }
        static void RoiChu()
        {
            Random rd = new Random();

            Thread t2 = new Thread(() =>
            {
                do
                {
                    st = Console.ReadLine();
                } while (true);
            });
            t2.Start();
            do
            {
                Thread t3 = new Thread(() =>
                {

                    int n = rd.Next(1, 5);
                    for (int i = 1; i <= n; i++)
                    {
                        string TextRd = Convert.ToString((char)rd.Next(97, 122));
                        int NumRd = rd.Next(0, Length_Game - 1);
                        if (Array[0, NumRd] == " ") Array[0, NumRd] = TextRd;
                    }
                });
                t3.Start();
                Push();
            } while (true);


        }
        static void Write()
        {
            Console.Clear();
            for (int i = 1; i <= 29; i++)
            {
                for (int j = 0; j < 150; j++)
                    Console.Write(Array[i, j]);
                Console.WriteLine();
            }
            TaoThanhDung();
            Thread.Sleep(Time);
        }
        static void Push()
        {
            for (int i = 0; i <= 29; i++)
            {
                for (int j = 0; j <= 149; j++)
                {
                    if (Array[i, j] == st) Array[i, j] = " ";
                    else if (Array[i, j] != " " && i < 29)
                    {
                        Array[i + 1, j] = Array[i, j];
                        Array[i, j] = " ";
                    }
                    else if (i == 29) Array[i, j] = " ";
                }
                Write();
            }
        }
        static void Main(string[] args)
        {
            KhoiTao();
            TaoThanhDung();
            RoiChu();
        }
    }
}