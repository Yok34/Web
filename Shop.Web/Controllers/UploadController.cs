using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Web.Models.DataAccessPostgreSqlProvider;

namespace Shop.Web.Controllers
{
    public class UploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoUpload(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                var xs = new XmlSerializer(typeof(GunShop.Shop));
                var shop = (GunShop.Shop)xs.Deserialize(stream);

                using (var db = new ShopDbContext())
                {
                    var dbs = new DbShop()
                    {
                        Name = shop.Name,
                        Address = shop.Address,
                        Photo = shop.Photo,
                        Contacts = shop.Contacts,
                    };
                    dbs.Guns = new Collection<DbSpecifications>();
                    foreach (var specifications in shop.Guns )
                    {
                        dbs.Guns.Add(new DbSpecifications()
                        {
                            Name = specifications.Name,
                            ProductionDate = specifications.ProductionDate,
                            GunType = specifications.GunType,
                            Caliber = specifications.Caliber,
                            Price = specifications.Price,
                            Weight = specifications.Weight,
                        });
                    }
                    db.Shops.Add(dbs);
                    db.SaveChanges();
                }
                return View(shop);
            }
        }
        
        public ActionResult Image(int id)
        {
            using (var db = new ShopDbContext())
            {
                return base.File(db.Shops.Find(id).Photo, "image/jpg");
            }
        }

        public ActionResult List()
        {
            List<DbShop> list;
            using (var db = new ShopDbContext())
            {
                list = db.Shops.Include(s => s.Guns).ToList();
            }
            return View(list);
        }   

    }
}