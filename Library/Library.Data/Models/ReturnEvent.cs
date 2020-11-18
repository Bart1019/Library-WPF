using System;

namespace Library.Data
{
    public class ReturnEvent : BookEvent
    {
        public DateTime ReturnDate { get; set; }
    }
}