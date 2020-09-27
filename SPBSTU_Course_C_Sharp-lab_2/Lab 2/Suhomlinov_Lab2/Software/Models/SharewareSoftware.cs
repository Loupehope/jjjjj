using System;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

namespace Suhomlinov_Lab2
{

    /// <summary>
    /// Класс условно-бесплатного ПО.
    /// </summary>
    public class SharewareSoftware: AbstractSoftware
    {
        /// <summary>
        /// Переменная для хранения даты установки ПО
        /// </summary>
        public DateTime installationDate;

        /// <summary>
        /// Переменная для хранения периода бесплатного использования ПО
        /// </summary>
        public int freeUsagePeriod;

        /// <summary>
        /// Базовый конструктор класса
        /// </summary>
        public SharewareSoftware() : base(String.Empty, String.Empty)
        {
            this.installationDate = DateTime.Today;
            this.freeUsagePeriod = 0;
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name">Название ПО</param>
        /// <param name="manufacturer">Производитель</param>
        /// <param name="installationDate">Дата установки ПО</param>
        /// <param name="freeUsagePeriod">Период бесплатного использования</param>
        public SharewareSoftware(string name, string manufacturer,
            DateTime installationDate, int freeUsagePeriod) : base(name, manufacturer)
        {
            Trace.WriteLine("Call constructor SharewareSoftware");
            Trace.Indent();
            Trace.WriteLine("Name: " + name);
            Trace.WriteLine("Manufacturer: " + manufacturer);
            Trace.WriteLine("Installation date: " + installationDate.ToString());
            Trace.WriteLine("Free usage period: " + freeUsagePeriod);
            Trace.Unindent();

            this.installationDate = installationDate;
            this.freeUsagePeriod = freeUsagePeriod;
        }

        /// <summary>
        /// Функция вывода в консоль информации о платном ПО
        /// </summary>
        public override void printInfo()
        {
            Trace.WriteLine("Call SharewareSoftware method printInfo()");

            Console.WriteLine(baseInfo + "\nInstallation date: " + installationDate.ToString("dd.MM.yyyy") + "\n" +
                "Free period: " + freeUsagePeriod);
        }

        /// <summary>
        /// Функция для проверки возможности использования ПО на нынешнюю дату
        /// </summary>
        /// <returns>true - можно пользоваться, false - нельзя пользоваться</returns>
        public override bool validate()
        {
            Trace.WriteLine("Call SharewareSoftware method validate()");

            return DateTime.Today.Subtract(installationDate).Days <= freeUsagePeriod;
        }

        /// <summary>
        /// Функция для генерации XML-файла
        /// </summary>
        /// <param name="fileName">название файла для генерации XML</param>
        public override void serialize(string fileName)
        {
            Trace.WriteLine("Call SharewareSoftware method serialize() with file name: " + fileName);

            TextWriter writer = new StreamWriter(fileName, true);
            XmlSerializer serializer = new XmlSerializer(typeof(SharewareSoftware));
            serializer.Serialize(writer, this);
            writer.Close();
        }
    }
}
