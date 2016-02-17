using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VM.Models
{
    public class PurseVM
    {
        // ID кошелька VM
        public int PurseVMId { get; set; }
        // Достоинство монет
        public int Dignity { get; set; }
        // Количество монет
        public int Quantity { get; set; }
    }
}