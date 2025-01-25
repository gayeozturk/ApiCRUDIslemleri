using Microsoft.AspNetCore.Mvc;
using EFCRUD.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFCRUD.Controllers
{
    public class KullaniciYonetimiController : Controller
    {
        DbefcrudContext db = new DbefcrudContext();
        public IActionResult Index()
        {


            var users = db.Kullanicis.ToList();
            return View(users);
        }




        public IActionResult Create()
        {


            ViewBag.IlId =
                new SelectList(
                    db.Illers.ToList(),
                    "Id",
                    "Sehir");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Kullanici model)
        {
            ViewBag.IlId =
               new SelectList(
                   db.Illers.ToList(),
                   "Id",
                   "Sehir",model.IlId); // formda secili olan il tekrar secili geri dönsün
            try
            {
                //Aynı mail adresinden birden fazla kayıt olmasın kodu
                if (db.Kullanicis.Any(h => h.Email == model.Email))
                {

                    ViewData["mesaj"] = "Bu mail adresi kayıtlıdır";
                    return View(model);
                }


                db.Kullanicis.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                return View(model);
            }



        }


        public IActionResult Edit(int Id)
        {
            
            using (DbefcrudContext db = new DbefcrudContext())
            {
                var user = db.Kullanicis.Find(Id);
                ViewBag.IlId =
              new SelectList(
                  db.Illers.ToList(),
                  "Id",
                  "Sehir", user.IlId);
                return View(user);
            }

        }

        [HttpPost]
        public IActionResult Edit(Kullanici model)
        {

            ViewBag.IlId =
               new SelectList(
                   db.Illers.ToList(),
                   "Id",
                   "Sehir", model.IlId);
            try
            {

               

                db.Kullanicis.Update(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View();
            }
        }


        public IActionResult Delete(int Id)
        {
            using (DbefcrudContext db = new DbefcrudContext())
            {
                var user = db.Kullanicis.Find(Id);
                return View(user);
            }

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int Id)
        {
            try
            {
                db.Kullanicis.Remove(db.Kullanicis.Find(Id));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View();
            }
        }
    }
}
