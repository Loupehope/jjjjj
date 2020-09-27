using System;

namespace Suhomlinov_Lab2
{
    /// <summary>
    /// Абстрактный класс ПО.
    /// </summary>
    public abstract class AbstractSoftware
    {
        /// <summary>
        /// Переменная для хранения объектов ПО
        /// </summary>
        public string name;

        /// <summary>
        /// Переменная для хранения объектов ПО
        /// </summary>
        public string manufacturer;

        /// <summary>
        /// Переменная для вывода базовой информации о ПО
        /// </summary>
        public string baseInfo
        {
            get
            {
                return "Programm name: " + name + "\nManufacturer: " + manufacturer;
            }
        }

        /// <summary>
        /// Конструктор абстрактного класса
        /// </summary>
        /// <param name="name">Название ПО</param>
        /// <param name="manufacturer">Производитель</param>
        public AbstractSoftware(string name, string manufacturer)
        {
            this.name = name;
            this.manufacturer = manufacturer;
        }

        /// <summary>
        /// Функция вывода в консоль информации о ПО
        /// </summary>
        public abstract void printInfo();

        /// <summary>
        /// Функция для проверки возможности использования ПО на нынешнюю дату
        /// </summary>
        /// <returns>true - можно пользоваться, false - нельзя пользоваться</returns>
        public abstract bool validate();

        /// <summary>
        /// Функция для генерации XML-файла
        /// </summary>
        /// <param name="fileName">название файла для генерации XML</param>
        public abstract void serialize(string fileName);
    }
}