using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Media;

namespace DrunkPC
{
    class MainClass
    {
        public static Random _random = new Random();

        public static void Main(string[] args)
        {
            Console.WriteLine("DrunkPC Prank Application by Joana");

            Thread drunkMouseThread = new Thread(new ThreadStart(DrunkMouseThread));
            Thread drunkKeyboardThread = new Thread(new ThreadStart(DrunkKeyboardThread));
            Thread drunkSoundThread = new Thread(new ThreadStart(DrunkSoundThread));
            Thread drunkPopupThread = new Thread(new ThreadStart(DrunkPopupThread));

            drunkMouseThread.Start();
            drunkKeyboardThread.Start();
            drunkSoundThread.Start();
            drunkPopupThread.Start();

            Console.Read();

            drunkMouseThread.Abort();
            drunkKeyboardThread.Abort();
            drunkSoundThread.Abort();
            drunkPopupThread.Abort();
        }

        #region Thread Functions

        public static void DrunkMouseThread()
        {
            Console.WriteLine("DrunkMouseThread Started");

            int moveX = 0;
            int moveY = 0;

            while (true)
            {
                //Console.WriteLine(Cursor.Position.ToString());

                moveX = _random.Next(20) - 10;
                moveY = _random.Next(20) - 10;
                
                Cursor.Position = new System.Drawing.Point(
                    Cursor.Position.X + moveX,
                    Cursor.Position.Y + moveY);
                Thread.Sleep(50);
            }
        }
        public static void DrunkKeyboardThread()
        {
            Console.WriteLine("DrunkKeyboardThread Started");
            while (true)
            {
                char key = (char)(_random.Next(25)+65);
                if(_random.Next(2) == 0)
                {
                    key = char.ToLower(key);
                }
                SendKeys.SendWait(key.ToString());
                Thread.Sleep(_random.Next(500));
            }
        }
        public static void DrunkSoundThread()
        {
            Console.WriteLine("DrunkSoundThread Started");
            while (true)
            {
                if(_random.Next(100) > 90)
                {
                    switch (_random.Next(5))
                    {
                        case 0:
                            SystemSounds.Asterisk.Play();
                            break;
                        case 1:
                            SystemSounds.Beep.Play();
                            break;
                        case 2:
                            SystemSounds.Exclamation.Play();
                            break;
                        case 3:
                            SystemSounds.Hand.Play();
                            break;
                        case 4:
                            SystemSounds.Question.Play();
                            break;

                    }
                    SystemSounds.Asterisk.Play();
                }
                SystemSounds.Asterisk.Play();
                Thread.Sleep(1000);
            }
        }
        public static void DrunkPopupThread()
        {
            Console.WriteLine("DrunkPopupThread Started");
            while (true)
            {
                if(_random.Next(100) > 90)
                {
                    switch (_random.Next(2))
                    {
                        case 0:
                            MessageBox.Show(
                                "Google Chrome has stopped working",
                                "Google Chrome",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            break;
                        case 1:
                            MessageBox.Show(
                                "Your system is running low on resources",
                                "Microsoft Windows",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            break;
                    }
                    
                }
                
                Thread.Sleep(10000);
            }
        }
        #endregion
    }
}