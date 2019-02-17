using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test3.Models;


namespace Test3.Controllers
{
    public class HomeController : Controller
    {
        double ortalama;
        // GET: Home
        public ActionResult Index()
        {
            using (OgrenciListeDB dataBase = new OgrenciListeDB())
            {
                IndexModel model = new IndexModel();
                model.Ogrenciler = dataBase.Ogrenci.ToList();
                return View(model);
            }
                
        }

        public ActionResult Listele()
        {
            using (OgrenciListeDB dataBase = new OgrenciListeDB())
            {
                //List<Ogrenci> OgrenciList;
                IndexModel model = new IndexModel();
                model.Ogrenciler = dataBase.Ogrenci.ToList();
                
                return View(model);
            }   
        }

        public ActionResult DersEkle()
        {
            return View();
        }

        public ActionResult OgrenciKaydet(string ad, string soyad, int numara, string ders, double vize, double final)
        {
            using (OgrenciListeDB database = new OgrenciListeDB())
            {
                Ogrenci ogrenci = new Ogrenci();
                ogrenci.Ad = ad;
                ogrenci.Soyad = soyad;
                ogrenci.Numara = numara;
                ogrenci.Ders = ders;
                ogrenci.Vize = vize;
                ogrenci.Final = final;
                ortalama = (vize * 0.3) + (final * 0.7);
                ogrenci.Ortalama = ortalama;
                database.Ogrenci.Add(ogrenci);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}