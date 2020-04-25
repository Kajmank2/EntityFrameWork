using EntityFrameWork.Data;
using EntityFrameWork.Model;
using EntityFrameWork.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameWork.Init
{
class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(CarRentalContext context):base(context)
        {
        }

        public IEnumerable<Reservation> GetOneWhereStatus0()
        {
            DateTime dt = DateTime.Now;
                return CarRentalContext.Reservations.Where(x => x.ReservationDateTime.AddMinutes(15)<dt || x.Status == 0);
        }
        public CarRentalContext CarRentalContext
        {
            get { return Context as CarRentalContext; }
        }
    }
}
