using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Models
{
    public class ReturnEvent : BookEvent
    {
        public DateTime ReturnDate { get; set; }
    }
}
