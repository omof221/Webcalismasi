using Microsoft.AspNetCore.Mvc;
using WebHafta05.Web.Models;

namespace WebHafta05.Web.Controllers
{
    public class UrunController : Controller
    {
        public IActionResult Index()
        {
            List<UrunViewModel> liste = new List<UrunViewModel>()
            {
                new UrunViewModel(1,"kalem","kurşun kalem",50.5),
                new UrunViewModel(2,"defter","80 yaprak",100.5),
                new UrunViewModel(3,"silgi","yumuşak",30.5),
                new UrunViewModel(4,"kalemtraş","lapalı kutu",20.5),
            };
            return View(liste);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            UrunViewModel bosmodel = new UrunViewModel();
            return View(bosmodel);
        }

        [HttpPost]
        public IActionResult Ekle(int id, string adi, string aciklama)
        {
            return View();
        }
        // ✏️ 3) GÜNCELLEME (GET)
        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            var urun = _urunler.Find(x => x.Id == id);
            if (urun == null)
                return NotFound();

            return View(urun);
        }

        // ✏️ 3) GÜNCELLEME (POST)
        [HttpPost]
        public IActionResult Guncelle(int id, string adi, string aciklama, double fiyat)
        {
            var urun = _urunler.Find(x => x.Id == id);
            if (urun != null)
            {
                urun.Adi = adi;
                urun.Aciklama = aciklama;
                urun.Fiyat = fiyat;
            }

            return RedirectToAction("Index");
        }

        // 🗑️ 4) SİLME (TEK ACTION)
        [HttpGet]
        public IActionResult Sil(int id)
        {
            var urun = _urunler.Find(x => x.Id == id);
            if (urun != null)
            {
                _urunler.Remove(urun);
            }

            return RedirectToAction("Index");
        }
    }
}
