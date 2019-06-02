using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Shop.Web.Models
{
    namespace DataAccessPostgreSqlProvider
    {
        public class ShopDbContext : DbContext
        {
            public ShopDbContext()
            {
                Database.EnsureCreated();
            }

            public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
            {

            }

            public DbSet<DbShop> Shops { get; set; }
           public static string ConnectionString { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(ShopDbContext.ConnectionString);
                base.OnConfiguring(optionsBuilder);
            }
        }

        public class DbShop
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

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
            public virtual Collection<DbSpecifications> Guns { get; set; }

            /// <summary>
            /// Контакты
            /// </summary>
            public string Contacts { get; set; }
        }

        public class DbSpecifications
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public int ShopId { get; set; }
            [ForeignKey("ShopId")]
            public virtual DbShop Shop { get; set; }


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
                return $"Название: {Name}, Дата изготовления: {ProductionDate} , Вид оружия: {GunType}, Калибр: {Caliber}, Цена: {Price}, Вес: {Weight}";
            }
        }
    }
}
