using System;

namespace Library.Data.Models
{
    public class RentalEvent : BookEvent
    {
        public BookState BookInLibrary { get; set; }
        public DateTime RentalDate { get; set; }
    }
}