using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Models
{
    public class RentalEvent : BookEvent
    {
        public DateTime RentalDate { get; set; }
    }
}
