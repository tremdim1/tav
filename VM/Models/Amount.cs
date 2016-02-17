using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VM.Models
{
    public class Amount
    {
        public int AmountId { get; set; }
        //Если купюроприемник имеет возвожность принимать копейки, то необходимо изменить тип на Double
        public int amount { get; set; }
    }
}