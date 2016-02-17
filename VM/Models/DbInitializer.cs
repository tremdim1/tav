using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VM.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext db)
        {
            //Заполняем БД начальными данными
            db.PurseClient1.Add(new PurseClient { Dignity = 1, Quantity = 10 });
            db.PurseClient1.Add(new PurseClient { Dignity = 2, Quantity = 30 });
            db.PurseClient1.Add(new PurseClient { Dignity = 5, Quantity = 20 });
            db.PurseClient1.Add(new PurseClient { Dignity = 10, Quantity = 15 });

            db.PurseVM1.Add(new PurseVM { Dignity = 1, Quantity = 100 });
            db.PurseVM1.Add(new PurseVM { Dignity = 2, Quantity = 100 });
            db.PurseVM1.Add(new PurseVM { Dignity = 5, Quantity = 100 });
            db.PurseVM1.Add(new PurseVM { Dignity = 10, Quantity = 100 });

            db.Product1.Add(new Product { Name = "Чай", Cost = 13, Residue = 10 });
            db.Product1.Add(new Product { Name = "Кофе", Cost = 18, Residue = 20 });
            db.Product1.Add(new Product { Name = "Кофе с молоком", Cost = 21, Residue = 20 });
            db.Product1.Add(new Product { Name = "Сок", Cost = 35, Residue = 15 });

            db.Amount1.Add(new Amount { AmountId = 1, amount = 0 });

            base.Seed(db);
        }
    }
}