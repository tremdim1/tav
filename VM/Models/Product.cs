using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VM.Models
{
    public class Product
    {
        // ID товара
        public int ProductId { get; set; }
        // Название товара
        public string Name { get; set; }
        // Стоимсоть
        //Если купюроприемник имеет возвожность принимать копейки, то необходимо изменить тип на Double
        public int Cost { get; set; }
        // Остаток
        public int Residue { get; set; }
    }
}