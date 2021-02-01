using System;

namespace Logger
{
    public static class Debug
    {
        public static bool printDebugStuff = false;
        public static void Log(string message = "", string name = "main")
        {
            string _text = "[" + name + "] [" + GetTime() + "] [Info]  \t: " + message;
            if (UnityEngine.Application.isEditor)
                UnityEngine.Debug.Log(_text);
            else
            {
                ConsoleColor PrevColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                ClearCurrentConsoleLine();
                Console.WriteLine(_text);
                Console.ForegroundColor = PrevColor;
            }
            RedrawInput();
            SaveToLogFile(_text);
        }

        public static void LogWarn(string message = "", string name = "main")
        {
            string _text = "[" + name + "] [" + GetTime() + "] [Warn] \t: " + message;
            if (UnityEngine.Application.isEditor)
                UnityEngine.Debug.LogWarning(_text);
            else
            {
                ConsoleColor PrevColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                ClearCurrentConsoleLine();
                Console.WriteLine(_text);
                Console.ForegroundColor = PrevColor;
            }
            RedrawInput();
            SaveToLogFile(_text);
        }

        public static void LogError(string message = "", string name = "main")
        {
            string _text = "[" + name + "] [" + GetTime() + "] [Error] \t: " + message;
            if (UnityEngine.Application.isEditor)
                UnityEngine.Debug.LogError(_text);
            else
            {
                ConsoleColor PrevColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                ClearCurrentConsoleLine();
                Console.WriteLine(_text);
                Console.ForegroundColor = PrevColor;
            }
            RedrawInput();
            SaveToLogFile(_text);
        }


        public static void LogDebug(string message = "", string name = "main")
        {
            string _text = "[" + name + "] [" + GetTime() + "] [Debug] \t: " + message;
            if (printDebugStuff)
            {
                ConsoleColor PrevColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                ClearCurrentConsoleLine();
                Console.WriteLine(_text);
                Console.ForegroundColor = PrevColor;
            }
            RedrawInput();
            SaveToLogFile(_text);
        }

        public static void LogNetwork(string message = "", string name = "main")
        {
            string _text = "[" + name + "] [" + GetTime() + "] [Net] \t: " + message;
            if (UnityEngine.Application.isEditor)
                UnityEngine.Debug.Log(_text);
            else
            {
                ConsoleColor PrevColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Cyan;
                ClearCurrentConsoleLine();
                Console.WriteLine(_text);
                Console.ForegroundColor = PrevColor;
            }
            RedrawInput();
            SaveToLogFile(_text);
        }

        static string GetTime()
        {
            return DateTime.Now.ToString("M-dd-yyyy H:mm:ss");
        }

        static string ConsoleLabel = string.Empty;
        static string ConsoleInput = string.Empty;
        static string ConsolePassInput = string.Empty;
        public static string ReadLine(string label = "")
        {
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && ConsoleInput.Length > 0)
                {
                    if (ConsoleInput.Length == 1)
                        ConsoleInput = string.Empty;
                    else
                        ConsoleInput = ConsoleInput.Substring(0, ConsoleInput.Length - 1);
                    RedrawInput();
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    ConsoleInput += keyInfo.KeyChar;
                    RedrawInput();
                }
            } while (key != ConsoleKey.Enter);
            Console.WriteLine();
            string pass = ConsoleInput;
            ConsoleInput = string.Empty;
            return pass;
        }

        public static string ReadPass(string label = "")
        {
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && ConsoleInput.Length > 0)
                {
                    if (ConsoleInput.Length == 1)
                    {
                        ConsoleInput = string.Empty;
                        ConsolePassInput = string.Empty;
                    }
                    else
                    {
                        ConsoleInput = ConsoleInput.Substring(0, ConsoleInput.Length - 1);
                        ConsolePassInput = string.Empty;
                    }
                    RedrawInput();
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    ConsoleInput += '*';
                    ConsolePassInput += keyInfo.KeyChar;
                    RedrawInput();
                }
            } while (key != ConsoleKey.Enter);
            Console.WriteLine();
            string pass = ConsolePassInput;
            ConsoleInput = string.Empty;
            ConsolePassInput = string.Empty;
            return pass;
        }

        public static void RedrawInput()
        {
            ClearCurrentConsoleLine();
            Console.Write(ConsoleLabel + ConsoleInput);
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        static void SaveToLogFile(string text)
        {
            /* if (!Directory.Exists(Environment.CurrentDirectory + "\\Logs"))
                 Directory.CreateDirectory(Environment.CurrentDirectory + "\\Logs");

             string _filePath = Environment.CurrentDirectory + "\\Logs\\" + DateTime.Now.ToString("yyyy-M-dd") + ".log";
             if (File.Exists(_filePath))
             {
                 using (StreamWriter _sw = File.AppendText(_filePath))
                 {
                     _sw.Write("\n" + text);
                 }
             }
             else File.WriteAllText(_filePath, text);*/
        }
    }
}
