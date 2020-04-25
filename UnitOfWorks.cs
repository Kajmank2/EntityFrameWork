using EntityFrameWork.Data;
using EntityFrameWork.Init;
using EntityFrameWork.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameWork
{
    class UnitOfWorks : IUnitofWork
    {
        private readonly CarRentalContext _context;
        public ICarRepository Cars { get; set; }

        public IReservationRepository Reservations { get; set; }

        public UnitOfWorks(CarRentalContext context)
        {
            _context = context;
            Cars = new CarsRepositories(_context);
            Reservations = new ReservationRepository(_context);
        }
        
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();

        }

        public void GetDistance()
        {
            _context.Cars.Where(x => x.CurrentDistance > 180);
        }
    }
}
