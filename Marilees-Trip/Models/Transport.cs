using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marilees_Trip.Models
{
    public class Transport
    {
       
        public virtual int TransportID { get; set; }
        public virtual string Title { get; set; }
        public virtual string FromCity { get; set; }
        public virtual string ToCity { get; set; }
        public virtual DateTime DepartAt { get; set; }
        public virtual DateTime ArriveAt { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string TransportType { get; set; }
        public virtual string Vendor { get; set; }

    }
}