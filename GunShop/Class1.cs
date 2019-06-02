using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunShop
{
    /// <summary>
    /// Магазин
    /// </summary>
    public class Shop
    {
        /// <summary>
        /// Название магазина
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес магазина
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Фото магазина
        /// </summary>
        public byte[] Photo { get; set; }

        /// <summary>
        /// Оружие
        /// </summary>
        public List<Specifications> Guns { get; set; }
        
        /// <summary>
        /// Контакты
        /// </summary>
        public string Contacts { get; set; }
       
    }

    /// <summary>
    /// Характеристики
    /// </summary>
    public class Specifications
    {
        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Дата изготовления
        /// </summary>
        public DateTime ProductionDate { get; set; }

        /// <summary>
        /// Вид оружия
        /// </summary>
        public string GunType { get; set; }

        /// <summary>
        /// Калибр
        /// </summary>
        public string Caliber { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; set; }

        public override string ToString()
        {
            return $"Название: {Name}, Дата изготовления: {ProductionDate} , Вид оружия: {GunType}, Калибр: {Caliber}, Цена: {Price}, Вес: {Weight}" ;
        }

    }

  
}
