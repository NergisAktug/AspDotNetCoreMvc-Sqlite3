using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjeCore.Models;

namespace ProjeCore.Controllers
{
    public class PersonelimController : Controller
    {
        Context c = new Context();
        [Authorize]
        public IActionResult Index()
        {
            var degerler = c.Personels.Include(x=>x.Birim).ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniPersonel()
        {
            List<SelectListItem> degerler = (from x in c.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.BirimAd, //Secmis oldugumuz Birimin textini frontend bolumune gonderece,
                                                 Value = x.BirimId.ToString()//Value'sını veritabanina kayit yapacak
                                             }).ToList();
            ViewBag.dgr = degerler;//degerleri on taraf yani YeniPersonel view'ine gonderiyoruz.
            return View();
        }
        public IActionResult YeniPersonel(Personel p)
        {
            var per = c.Birims.Where(x => x.BirimId == p.Birim.BirimId).FirstOrDefault();
            p.Birim = per;//personelin(p) birim ile iliskili alanına per'den gelen deger ekleniyor
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
      
    }
}
