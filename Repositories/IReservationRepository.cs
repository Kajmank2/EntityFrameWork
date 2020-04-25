using EntityFrameWork.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWork.Repositories
{
  interface IReservationRepository:IRepository<Reservation>
    {
        IEnumerable<Reservation> GetOneWhereStatus0();
    }
}
