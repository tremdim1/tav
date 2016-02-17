using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VM.Models
{
    public class PurseClient
    {
        // ID кошелька клиента
        public int PurseClientId { get; set; }
        // Достоинство монет
        public int Dignity { get; set; }
        // Количество монет
        public int Quantity { get; set; }
    }
}