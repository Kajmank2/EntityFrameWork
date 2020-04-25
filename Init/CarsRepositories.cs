using EntityFrameWork.Data;
using EntityFrameWork.Model;
using EntityFrameWork.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameWork.Init
{
    class CarsRepositories : Repository<Car>, ICarRepository
    {
        public CarsRepositories(CarRentalContext context): base(context)
        {

        }
        public IEnumerable<Car> GetCuttentPostion(double r , double positionX , double PositionY)
        {
            Console.WriteLine("Samochody w pobliżu Lokalizacji ");
            return CarRentalContext.Cars.Where(x => x.XPosition - positionX < r || x.YPosition - PositionY < r);
        }

        public IEnumerable<Car> GetKilometers()
        {
            Console.WriteLine("Wszystkie samochody z bieżącym dystansem większym niż 180 km");
            return CarRentalContext.Cars.Where(x => x.CurrentDistance > 180);
        }

        public IEnumerable<Car> GetStatus0()
        {
         return CarRentalContext.Cars.Where(x => x.CurrentDistance > 180);
        }

        public  CarRentalContext CarRentalContext
        {
            get { return Context as CarRentalContext; }
        }
    }
}
