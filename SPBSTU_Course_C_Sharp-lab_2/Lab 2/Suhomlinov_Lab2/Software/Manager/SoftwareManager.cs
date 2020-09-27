using System;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

namespace Suhomlinov_Lab2
{
    public class SoftwareManager
    {
        /// <summary>
        /// Переменная для хранения числа ПО, которое будет храниться  
        /// </summary>
        public int softCount;

        /// <summary>
        /// Переменная для хранения объектов ПО
        /// </summary>
        public AbstractSoftware[] softs;

        public SoftwareManager()
        {
            Trace.WriteLine("Call constructor SoftwareManager with softCount: " + 0);

            this.softCount = 0;
            this.softs = new AbstractSoftware[softCount];
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="softCount">число ПО, которое будет храниться</param>
        public SoftwareManager(int softCount)
        {
            Trace.WriteLine("Call constructor SoftwareManager with softCount: " + softCount);
            this.softCount = softCount;
            this.softs = new AbstractSoftware[softCount];
        }

        /// <summary>
        /// Метод для вывода информации о ПО и возмодности его использования в консоль 
        /// </summary>
        public void printAllSoftInfoAndValidation()
        {
            Trace.WriteLine("Call SoftwareManager method printAllSoftInfoAndValidation()");
            Trace.Indent();
            Trace.WriteLine("Start printing all information about software and validation");
            Trace.Indent();

            foreach (AbstractSoftware soft in softs)
            {
                if (soft is null)
                {
                    Console.Write("Can't print! Value is null");
                }
                else
                {
                    soft.printInfo();
                    if (soft.validate())
                    {
                        Console.Write("It can be used today\n");
                    }
                    else
                    {
                        Console.Write("It can't be used today\n");
                    }
                    Console.WriteLine();
                }
            }

            Trace.Unindent();
            Trace.WriteLine("End printing all information about software and validation");
            Trace.Unindent();
        }

        /// <summary>
        /// Метод для добавления массива данных о ПО в массив ПО 
        /// </summary>
        /// <param name="softData">Массив данных о ПО</param>
        /// <param name="index">Индекс массива для вставки ПО</param>
        public void addSoft(string[] softData, int index)
        {
            Trace.WriteLine("Call SoftwareManager method addSoft() for index " + index);
            Trace.Indent();
            AbstractSoftware element = convertArrayInfoToSoftware(softData);

            if (element is null)
            {
                Console.WriteLine("Data is not correct in line " + index);
            }
            else if (index > -1 && index < softCount)
            {
                softs[index] = element;
            }
            else
            {
                Console.WriteLine("Wrong index " + index);
            }
            Trace.Unindent();
        }

        /// <summary>
        /// Функция для генерации XML-файла
        /// </summary>
        /// <param name="fileName">название файла для генерации XML</param>
        public void serialize(string fileName)
        {
            Trace.WriteLine("Call SoftwareManager method serialize() with file name: " + fileName);

            TextWriter writer = new StreamWriter(fileName, true);
            XmlSerializer serializer = new XmlSerializer(typeof(SoftwareManager),
                new Type[] { typeof(CommercialSoftware), typeof(FreeSoftware), typeof(SharewareSoftware) });
            serializer.Serialize(writer, this);
            writer.Close();
        }

        /// <summary>
        /// Функция для генерации XML-файла для ОП
        /// </summary>
        /// <param name="fileName">название файла для генерации XML</param>
        public void serializeSoft(string fileName)
        {
            Trace.WriteLine("Call SoftwareManager method serializeSoft() with file name: " + fileName);

            TextWriter writer = new StreamWriter(fileName);
            foreach (AbstractSoftware soft in softs)
            {
                soft.serialize(fileName);
            }
            writer.Close();
        }

        /// <summary>
        /// Метод для ковертирования строк данных в объект ПО
        /// </summary>
        /// <param name="info">Массив данных о ПО</param>
        /// <returns>AbstractSoftware - если получилось проинициализорвать данные, иначе - null</returns>
        private AbstractSoftware convertArrayInfoToSoftware(string[] info)
        {
            Trace.WriteLine("Call SoftwareManager method convertArrayInfoToSoftware()");
            
            string softwareType = info[0].ToLower();
            switch (softwareType)
            {
                case "freesoftware":
                    return new FreeSoftware(info[1], info[2]);
                case "sharewaresoftware":
                    return new SharewareSoftware(info[1], info[2],
                        DateTime.ParseExact(info[3], "dd.MM.yyyy", CultureInfo.InvariantCulture), Convert.ToInt32(info[4]));
                case "commercialsoftware":
                    return new CommercialSoftware(info[1], info[2], Convert.ToDouble(info[3]),
                        DateTime.ParseExact(info[4], "dd.MM.yyyy", CultureInfo.InvariantCulture), Convert.ToInt32(info[5]));
                default:
                    return null;
            }
        }
    }
}
