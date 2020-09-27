using System;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

namespace Suhomlinov_Lab2
{

    /// <summary>
    /// Класс коммерческого ПО.
    /// </summary>
    public class CommercialSoftware : AbstractSoftware
    {
        /// <summary>
        /// Переменная для хранения стоимости ПО
        /// </summary>
        public double cost;

        /// <summary>
        /// Переменная для хранения даты установки ПО
        /// </summary>
        public DateTime installationDate;

        /// <summary>
        /// Переменная для хранения периода использования ПО
        /// </summary>
        public int usagePeriod;

        /// <summary>
        /// Базовый конструктор класса
        /// </summary>
        public CommercialSoftware() : base(String.Empty, String.Empty)
        {
            this.cost = 0;
            this.installationDate = DateTime.Today;
            this.usagePeriod = 0;
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name">Название ПО</param>
        /// <param name="manufacturer">Производитель</param>
        /// <param name="cost">Стоимость ПО</param>
        /// <param name="installationDate">Дата установки ПО</param>
        /// <param name="usagePeriod">Период использования</param>
        public CommercialSoftware(string name, string manufacturer,
            double cost, DateTime installationDate, int usagePeriod) : base(name, manufacturer)
        {
            Trace.WriteLine("Call constructor CommercialSoftware");
            Trace.Indent();
            Trace.WriteLine("Name: " + name);
            Trace.WriteLine("Manufacturer: " + manufacturer);
            Trace.WriteLine("Cost: " + cost);
            Trace.WriteLine("Installation date: " + installationDate.ToString());
            Trace.WriteLine("Usage period: " + usagePeriod);
            Trace.Unindent();

            this.cost = cost;
            this.installationDate = installationDate;
            this.usagePeriod = usagePeriod;
        }

        /// <summary>
        /// Функция вывода в консоль информации о платном ПО
        /// </summary>
        public override void printInfo()
        {
            Trace.WriteLine("Call CommercialSoftware method printInfo()");

            Console.WriteLine(baseInfo + "\nInstallation date: " + installationDate.ToString("dd.MM.yyyy") +
                "\nCost: " + cost + "\nUse period: " + usagePeriod);
        }

        /// <summary>
        /// Функция для проверки возможности использования ПО на нынешнюю дату
        /// </summary>
        /// <returns>true - можно пользоваться, false - нельзя пользоваться</returns>
        public override bool validate()
        {
            Trace.WriteLine("Call CommercialSoftware method validate()");

            return DateTime.Today.Subtract(installationDate).Days <= usagePeriod;
        }

        /// <summary>
        /// Функция для генерации XML-файла
        /// </summary>
        /// <param name="fileName">название файла для генерации XML</param>
        public override void serialize(string fileName)
        {
            Trace.WriteLine("Call CommercialSoftware method serialize() with file name: " + fileName);

            TextWriter writer = new StreamWriter(fileName, true);
            XmlSerializer serializer = new XmlSerializer(typeof(CommercialSoftware));
            serializer.Serialize(writer, this);
            writer.Close();
        }
    }
}
