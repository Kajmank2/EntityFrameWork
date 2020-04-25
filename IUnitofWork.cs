using EntityFrameWork.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWork
{
    interface IUnitofWork : IDisposable
    {
        ICarRepository Cars { get;}
        IReservationRepository Reservations { get; }
        int Complete();
        void GetDistance();
    }
}
