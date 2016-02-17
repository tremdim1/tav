using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VM.Models;

namespace VM.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        DBContext db = new DBContext();

        public ActionResult Index()
        {
            //qweasdzxc
            // получаем из бд все объекты PurseClient
            IEnumerable<PurseClient> pc = db.PurseClient1;
            // передаем все полученный объекты в динамическое свойство
            ViewBag.PurseClient1 = pc;


            IEnumerable<PurseVM> pvm = db.PurseVM1;
            ViewBag.PurseVM1 = pvm;

            IEnumerable<Product> p = db.Product1;
            ViewBag.Product1 = p;

            IEnumerable<Amount> a = db.Amount1;
            ViewBag.Amount1 = a;

            // возвращаем представление
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int? id)
        {
            if (id == null)
            {
                //Возможно включить другую обработку - возврат сообщения
                return RedirectToAction("Index");
            }

            Product p = db.Product1.Find(id);

            if (p == null)
            {
                return RedirectToAction("Index");
            }

            //В дальнейшем так же необходимо учитывать обработки значений на null описанные выше
            Amount a = db.Amount1.First();

            if (a.amount < p.Cost)
            {
                //сообщение недостаточно средств
                return RedirectToAction("Index");
            }

            if (p.Residue == 0)
            {
                //сообщение товара нет
                return RedirectToAction("Index");
            }
            
            p.Residue = p.Residue - 1;
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();

            a.amount = a.amount - p.Cost;
            db.Entry(a).State = EntityState.Modified;
            db.SaveChanges();

            //сообщение спасибо
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditPC(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            PurseClient pc = db.PurseClient1.Find(id);

            if (pc == null)
            {
                return RedirectToAction("Index");
            }

            if (pc.Quantity == 0)
            {
                return RedirectToAction("Index");
            }

            pc.Quantity = pc.Quantity - 1;
            db.Entry(pc).State = EntityState.Modified;
            db.SaveChanges();

            Amount a = db.Amount1.First();
            a.amount = a.amount + pc.Dignity;
            db.Entry(a).State = EntityState.Modified;
            db.SaveChanges();

            PurseVM pvm = db.PurseVM1.Single(p => p.Dignity == pc.Dignity);
            pvm.Quantity = pvm.Quantity + 1;
            db.Entry(pvm).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Letting(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Amount a = db.Amount1.Find(id);

            if (a == null)
            {
                return RedirectToAction("Index");
            }

            if (a.amount == 0)
            {
                return RedirectToAction("Index");
            }

            //Данный массив желательно вынести в конфигурационный файл - удобство изменения достоинства монет
            int[] x = { 10, 5, 2, 1 };

            foreach (int item in x)
            {
                PurseVM pvm = db.PurseVM1.Single(p => p.Dignity == item);
                int b2 = Convert.ToInt32(Math.Truncate(Convert.ToDouble(a.amount / item)));
                if ((pvm.Quantity > 0) & (b2 > 0))
                {
                    if (pvm.Quantity < b2) b2 = pvm.Quantity;
                    
                    pvm.Quantity = pvm.Quantity - b2;
                    db.Entry(pvm).State = EntityState.Modified;
                    db.SaveChanges();

                    PurseClient pc = db.PurseClient1.Single(p => p.Dignity == item);
                    pc.Quantity = pc.Quantity + b2;
                    db.Entry(pc).State = EntityState.Modified;
                    db.SaveChanges();

                    a.amount = a.amount - b2 * item;
                }
            }

            db.Entry(a).State = EntityState.Modified;
            db.SaveChanges();


            return RedirectToAction("Index");
        }
    }        
}
