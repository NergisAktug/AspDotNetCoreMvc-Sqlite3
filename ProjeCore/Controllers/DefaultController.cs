using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjeCore.Models;

namespace ProjeCore.Controllers
{
    public class DefaultController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler = c.Birims.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniBirim()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniBirim(Birim b)
        {
            c.Birims.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimSil(int id)
        {
            var dep = c.Birims.Find(id);
            c.Birims.Remove(dep);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //oncelikle indexte buttona tiklandiginda  birimGetir  action'a istenen id'nin tum verleri veritabanindan bulunur.
        public IActionResult BirimGetir(int id)
        {
            var depart = c.Birims.Find(id);
            return View("BirimGetir", depart);//tum veriler BirimGetir adli  view'e gonderilir.
        }
        //birimGuncelle gelen veriler veritabanina kayit olur.
        public IActionResult BirimGuncelle(Birim d)
        {
            var dep = c.Birims.Find(d.BirimId);
            dep.BirimAd= d.BirimAd;
            c.SaveChanges();
            return RedirectToAction("index");

        }
        public IActionResult BirimDetay(int id)
        {
            //personel tablosunda disaridan gondersigimiz id'ye esit olan kisinin tum bilgileri getiriyor
            var degerler = c.Personels.Where(x => x.BirimId == id).ToList();
            var brmad = c.Birims.Where(x => x.BirimId == id).Select(y=>y.BirimAd).FirstOrDefault();
            ViewBag.brm = brmad;
            return View(degerler);

        }
    }
}
