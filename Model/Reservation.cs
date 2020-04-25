using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWork.Model
{
    class Reservation 
    {
        public int ReservationId { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public byte Status { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }

}

