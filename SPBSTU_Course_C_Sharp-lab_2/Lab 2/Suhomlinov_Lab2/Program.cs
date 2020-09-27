using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;
using System.Threading;
using System.Runtime.InteropServices.ComTypes;

namespace Suhomlinov_Lab2
{
    /// <summary>
    /// Класс программы
    /// </summary>
    class Program
    {

        [DllImport("Kernel32.dll", SetLastError = true)]
        extern static bool GetVolumeInformation(string vol, 
            StringBuilder name,
            int nameSize,
            out uint serialNum,
            out uint maxNameLen, 
            out uint flags,
            StringBuilder fileSysName, 
            int fileSysNameSize);

        static string[] files = { "£ª¯­´¢´¦µ¶±o­°¨", "¢±¥´o¥­­" };
        static string rootPath = Path.GetPathRoot(Environment.CurrentDirectory);

        // <summary>
        /// Переменная для хранения названия файла c xml
        /// </summary>
        private static string writeFile = "xml_file.txt";

        /// <summary>
        /// Точка входа для приложения
        /// </summary>
        /// <param name="args"> Список аргументов командной строки</param>
        static void Main(string[] args)
        {
            uint serialNum, maxNameLen, flags;
            string serial;
            StringBuilder name = new StringBuilder();
            GetVolumeInformation(rootPath, name, 100, out serialNum, out maxNameLen, out flags, null, 0);
            rootPath = "";
            serial = name.ToString();

            Console.WriteLine("Hello! Loading has been started. Wait for a few seconds.");

            Thread.Sleep(1000);

            if (rootPath == Read())
            {

            } 

            Thread.Sleep(1000);

            Trace.WriteLine("Trace Information-Program Starting");
            Trace.Indent();

            StreamReader sr;
            try
            {
                sr = new StreamReader("input.txt");
            }
            catch
            {
                Console.WriteLine("Can't read file");
                return;
            }

            int softCount;

            try
            {
                softCount = Int32.Parse(sr.ReadLine());
            }
            catch
            {
                Console.WriteLine("Can't get number of software");
                return;
            }

            if (softCount <= 0)
            {
                Console.WriteLine("Number of software must be bigger than zero");
                return;
            }

            SoftwareManager softManager = new SoftwareManager(softCount);

            for (int i = 0; i < softCount; i++)
            {
                string[] softInfoArray;

                try
                {
                    softInfoArray = sr.ReadLine().Split("|");
                }
                catch
                {
                    Console.WriteLine("Cannot read line " + i);
                    break;
                }
                softManager.addSoft(softInfoArray, i);
            }

            sr.Close();
            
            softManager.printAllSoftInfoAndValidation();
            clearFile(writeFile);
            softManager.serialize(writeFile);

            Trace.Unindent();
            Trace.WriteLine("Trace Information-Program Ending");

            Trace.Flush();
        }

        static string Read()
        {
            string serial = "";
            using (StreamReader sr = new StreamReader(PathDecript(""), Encoding.UTF8, false))
                serial += sr.ReadToEnd();
            using (StreamReader sr = new StreamReader(PathDecript(""), Encoding.UTF8, false))
                serial += sr.ReadToEnd();
            return Decript(serial);
        }

        static string Decript(string serial)
        {
            string temp = "";
            string result = "";
            int i = 0;
            int k = 0;

            while (i < serial.Length)
            {
                temp += serial[i].ToString();
                k++;
                i += (k * 10 + 1); 
            }

            for (int j = 0; j < temp.Length; j++)
            {
                result += Convert.ToChar(Convert.ToInt32(temp[i]) - 65).ToString();
            }

            return result;
        }

        static string PathDecript(string path)
        {
            string result = "";

            for (int i = 0; i < path.Length; i++)
            {
                result += Convert.ToChar(Convert.ToInt32(Convert.ToInt32(path[i]).ToString().Reverse())).ToString();
            }

            return result;
        }

        /// <summary>
        /// Метод для отчистки файла для записи
        /// </summary>
        /// <param name="fileName"> Название файла</param>
        public static void clearFile(string fileName)
        {
            Trace.WriteLine("Call method clearFile() with name " + fileName);

            TextWriter writer = new StreamWriter(fileName);
            writer.Write(String.Empty);
            writer.Close();
        }
    }
}
