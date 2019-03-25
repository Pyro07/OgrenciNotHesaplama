using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        double ortalama;
        // GET: Home
        public ActionResult Index()
        {
            using (MyDB dataBase = new MyDB())
            {
                
                List<Ders> DersListe = dataBase.Dersler.ToList();
                List<Ogrenci> OgrenciListe = dataBase.Ogrenciler.ToList();

                ViewBag.dersler = DersListe;
                ViewBag.ogrenciler = OgrenciListe;
                return View();
            }
        }

        public ActionResult OgrenciKaydet()
        {
            Ogrenci model = BolumDoldur();
            return View(model);
        }

        [HttpPost]
        public ActionResult OgrenciKaydet(Ogrenci model)
        {
            using (MyDB dataBase = new MyDB())
            {
                Ogrenci ogrenci = new Ogrenci();
                ogrenci.OgrenciNumarasi = model.OgrenciNumarasi;
                ogrenci.Ad = model.Ad;
                ogrenci.Soyad = model.Soyad;

                model.DersList = BolumDoldur().DersList;
                var SecilenDers = model.DersList.Find(s => s.Value == model.DersId.ToString());
                ogrenci.DersinAdi = SecilenDers.Text;

                ogrenci.DersId = model.DersId;
                ogrenci.Vize = model.Vize;
                ogrenci.Final = model.Final;
                ortalama = (ogrenci.Vize * 0.3) + (ogrenci.Final * 0.7);
                ogrenci.Ortalama = ortalama;
                dataBase.Ogrenciler.Add(ogrenci);
                dataBase.SaveChanges();
                return RedirectToAction("Index",model);
            }
        }

        public ActionResult OgrenciSil(int? id)
        {
            using (MyDB dataBase = new MyDB())
            {
                Ogrenci ogrenci = dataBase.Ogrenciler.Where(d => d.Id == id).SingleOrDefault();
                dataBase.Ogrenciler.Remove(ogrenci);
                dataBase.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult DersEkle(int? id)
        {
            using (MyDB dataBase = new MyDB())
            {
                if (id == 1)
                {
                    ViewBag.Hata("Ders içerisinde öğrenciler kayıtlı olduğu için silinemiyor.");
                }

                List<Ders> _dersler = dataBase.Dersler.ToList();
                ViewBag.dersler = _dersler;
            }
            return View();
        }

        [HttpPost]
        public ActionResult DersEkle(Ders model)
        {
            using (MyDB dataBase = new MyDB())
            {
                if (dataBase.Dersler.Count(d => d.DersAdi == model.DersAdi) > 0)
                {
                    ViewBag.Mesaj = "Böyle bir ders kaydı mevcut!";
                    ModelState.Clear();
                }
                else
                {
                    Ders ders = new Ders();
                    ders.DersAdi = model.DersAdi;
                    dataBase.Dersler.Add(ders);
                    dataBase.SaveChanges();
                    ViewBag.Sonuc = "Ders kaydı başarı ile eklendi.";
                }
                
                return RedirectToAction("DersEkle",model);
            }
        }

        public ActionResult DersSil(int? id)
        {
            using (MyDB dataBase = new MyDB())
            {
                if (dataBase.Dersler.Count(d => d.Id == id) > 0)
                {
                    return RedirectToAction("DersEkle/1");
                }
                else
                {
                    Ders ders = dataBase.Dersler.Where(d => d.Id == id).SingleOrDefault();
                    dataBase.Dersler.Remove(ders);
                    dataBase.SaveChanges();
                    return RedirectToAction("DersEkle");
                }
            }
        }

        private static Ogrenci BolumDoldur()
        {
            using (MyDB dataBase = new MyDB())
            {
                Ogrenci model = new Ogrenci();
                model.DersList = (from ders in dataBase.Dersler.ToList()
                                  select new SelectListItem
                                  {
                                      Selected = false,
                                      Text = ders.DersAdi,
                                      Value = ders.Id.ToString()
                                  }).ToList();
                model.DersList.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Value = "",
                    Text = "seçiniz"
                });

                return model;
            }
        }
    }
}