using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        //global entity objesi olusturup tblkategorileri ulasildi.
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORI.ToList();
            return View(degerler);
        }

        //Httpget yazinca sadece sayfa yüklendiginde calissin diyoruz
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        //Sayfaya gönderme islemi gerceklesince (bir seye tıklanınca) calisiyor.
        [HttpPost]
        public ActionResult KategoriEkle(TBLKATEGORI p)
        {
            db.TBLKATEGORI.Add(p);
            db.SaveChanges();
            return View();
        }


        //Tıklayinca bir id alip o id'yi db de aratiyoruz esleseni silip saveliyoruz.
        //Sonra tekrardan indexe yönlendiriyor.
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLKATEGORI.Find(id);
            db.TBLKATEGORI.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Kategori Güncelleme İşlemi
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TBLKATEGORI.Find(id);
            return View("KategoriGetir", ktg);
        }

        //birden cok deger icerdigi icin kategori objesi (p) olusturup
        //idsini bulduk sonra adini bu gelen objedeki degerle degistirdik.
        public ActionResult KategoriGuncelle(TBLKATEGORI p)
        {
            var ktg = db.TBLKATEGORI.Find(p.ID);
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}