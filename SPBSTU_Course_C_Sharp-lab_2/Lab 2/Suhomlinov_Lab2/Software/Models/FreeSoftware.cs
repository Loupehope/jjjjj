using System;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

namespace Suhomlinov_Lab2
{
    /// <summary>
    /// Класс свободного ПО.
    /// </summary>
    public class FreeSoftware: AbstractSoftware
    {
        /// <summary>
        /// Базовый конструктор класса
        /// </summary>
        public FreeSoftware() : base(String.Empty, String.Empty) { }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name">Название ПО</param>
        /// <param name="manufacturer">Производитель</param>
        public FreeSoftware(string name, string manufacturer) : base(name, manufacturer)
        {
            Trace.WriteLine("Call constructor FreeSoftware");
            Trace.Indent();
            Trace.WriteLine("Name: " + name);
            Trace.WriteLine("Manufacturer: " + manufacturer);
            Trace.Unindent();
        }

        /// <summary>
        /// Функция вывода в консоль информации о платном ПО
        /// </summary>
        public override void printInfo()
        {
            Trace.WriteLine("Call FreeSoftware method printInfo()");

            Console.WriteLine(baseInfo);
        }

        /// <summary>
        /// Функция для проверки возможности использования ПО на нынешнюю дату
        /// </summary>
        /// <returns>true - можно пользоваться, false - нельзя пользоваться</returns>
        public override bool validate()
        {
            Trace.WriteLine("Call FreeSoftware method validate()");

            return true;
        }

        /// <summary>
        /// Функция для генерации XML-файла
        /// </summary>
        /// <param name="fileName">название файла для генерации XML</param>
        public override void serialize(string fileName)
        {
            Trace.WriteLine("Call FreeSoftware method serialize() with file name: " + fileName);

            TextWriter writer = new StreamWriter(fileName, true);
            XmlSerializer serializer = new XmlSerializer(typeof(FreeSoftware));
            serializer.Serialize(writer, this);
            writer.Close();
        }
    }
}
