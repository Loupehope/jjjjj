using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

namespace Installer
{
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
        static void Main(string[] args)
        {
            Dialog();
            Console.ReadKey();
        }

        static void AddControlFiles(string path)
        {
            //File.Copy("Proga.exe", path + "\\Program.exe");
            Directory.CreateDirectory(path + "\\bin");
            uint serialNum, maxNameLen, flags;
            string rootPath = path.Substring(0, path.IndexOf(":\\") + 2);

            StringBuilder name = new StringBuilder();
            GetVolumeInformation(rootPath, name, 100, out serialNum, out maxNameLen, out flags, null, 0);
            string serial = serialNum.ToString();

            string result = String.Empty;
            Random random = new Random();

            for (int i = 0; i < serial.Length; i++)
            {
                string num = Convert.ToChar(Convert.ToInt32(serial[i]) + 65).ToString();
                string rand = Convert.ToChar(random.Next(1, 256)).ToString();
                result += num + rand;
            }

            using (StreamWriter sw = new StreamWriter(path + "\\bin\\lsasetup.log", false, Encoding.UTF8))
                sw.Write(result.Substring(0, 5));
            using (StreamWriter sw = new StreamWriter(path + "\\apds.dll", false, Encoding.UTF8))
                sw.Write(result.Substring(5, 5));
        }

        static void Dialog()
        {
            string path;
            Console.WriteLine("Путь для установки:");

            try
            {
                path = Console.ReadLine();
                AddControlFiles(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ащибка");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Завершено успешно");
        }
    }
}
