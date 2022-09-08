using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace rustQueueSkipForms
{
    internal static class Program
    {
        //public static int serverName;

        static Form FormForCursor;
        //This is a replacement for Cursor.Position in WinForms
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        //[DllImport("user32.dll")]
        //public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);

        [STAThread]
        static void Main(string[] args)
        {
            //Maximize();
            //Console.WriteLine("1 = main");
            //Console.WriteLine("2 = mondays");
            //Console.WriteLine("Choose server: ");
            //int choice = Int32.Parse(Console.ReadLine());
            //Thread.Sleep(1000);
            //Console.Clear();

            //if (choice == 1)
            //{
            //    Console.WriteLine("You chose main");
            //}
            //else if (choice == 2)
            //{
            //    Console.WriteLine("You chose mondays");
            //}

            //Thread.Sleep(2000);
            //Console.Clear();

            //Console.WriteLine("Starting in 10 seconds. Switch to rust with your F1 window open and wait!");
            //Thread.Sleep(10000);
            //Console.Clear();

            //// Step 1: test for null.
            //if (args == null)
            //{
            //    Console.WriteLine("args is null");
            //    Console.WriteLine("Server options: main or mondays");
            //    Console.WriteLine("Usage: programName.exe main");
            //    Thread.Sleep(5000);
            //}
            //else
            //{
            //    serverName = args[0];
            //    Console.WriteLine($"You chose sever: {args[0]}");
            //}
           
            Thread.Sleep(10000);

            FormForCursor = new Form();
            FormForCursor.AutoSize = false;
            FormForCursor.FormBorderStyle = FormBorderStyle.None;
            FormForCursor.ShowInTaskbar = false;
            FormForCursor.TopMost = true;
            FormForCursor.Shown += new EventHandler(Form_Shown);
            Application.Run(FormForCursor);
        }
        static void Form_Shown(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            FormForCursor.Hide();
            System.Windows.Forms.Cursor.Position = new Point(705, 924);
            LeftMouseDoubleClick(705, 924);

            string server = File.ReadAllText("server.txt");
            Clipboard.SetText(server);

            //Clipboard.SetText("connect main.rustoria.us:28015");
            while (true)
            {
                //copy and paste instead of sendkeys
                //add option to choose which server

                //mondays
                //SendKeys.Send("connect 208.103.169.85:28015");

                //main
                //SendKeys.Send("connect main.rustoria.us:28015");
                SendKeys.Send("^{v}");

                SendKeys.Send("{ENTER}");
                Thread.Sleep(400);

                if (Keyboard.IsKeyDown(Key.Back))
                {
                    Environment.Exit(0);
                    FormForCursor.Close();
                }
            }
        }
        public static void LeftMouseDoubleClick(int xpos, int ypos)
        {
            //SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
        }
        //private static void Maximize()
        //{
        //    Process p = Process.GetCurrentProcess();
        //    ShowWindow(p.MainWindowHandle, 3); //SW_MAXIMIZE = 3
        //}
    }
}
