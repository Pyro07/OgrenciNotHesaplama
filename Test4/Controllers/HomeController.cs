using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test4.Models;

namespace Test4.Controllers
{
    public class HomeController : Controller
    {
        double ortalama;
        // GET: Home
        public ActionResult Index()
        {
            using (OgrenciListeleriDB dataBase = new OgrenciListeleriDB())
            {
                IndexModel model = new IndexModel();
                List<Ders> dersListesi;
                //if(TempData["DersListesi"]!=null)
                //{
                //    dersListesi = (List<Ders>)TempData["DersListesi"];
                //}
                //else
                //{
                //    dersListesi = new List<Ders>();
                //}
                //model._Ogrenciler = dataBase.Ogrenciler.ToList();
                model._Dersler = dataBase.Dersler.ToList();
                //model._Dersler = dersListesi;
                return View(model);
            }
                
        }

        public ActionResult DersleriEkle(string dersAdi)
        {
            using (OgrenciListeleriDB dataBase = new OgrenciListeleriDB())
            {
                Ders ders = new Ders();
                ders.DersAdi = dersAdi;
                dataBase.Dersler.Add(ders);
                dataBase.SaveChanges();
                return View();
            }
                
        }

        public ActionResult OgrenciKaydet(string ad, string soyad, int numara, Ders ders, double vize, double final)
        {
            using (OgrenciListeleriDB dataBase = new OgrenciListeleriDB())
            {
                Ogrenci ogrenci = new Ogrenci();
                ogrenci.Ad = ad;
                ogrenci.Soyad = soyad;
                ogrenci.Numara = numara;
                ogrenci.DersinAdi = ders;
                ogrenci.Vize = vize;
                ogrenci.Final = final;
                ortalama = (vize * 0.3) + (final * 0.7);
                ogrenci.Ortalama = ortalama;
                dataBase.Ogrenciler.Add(ogrenci);
                dataBase.SaveChanges();
                return View();
            }
            
        }
    }
}