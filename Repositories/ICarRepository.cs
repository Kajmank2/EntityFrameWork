using EntityFrameWork.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWork.Repositories
{
     interface ICarRepository :IRepository<Car>
    {
        IEnumerable<Car> GetKilometers();
        IEnumerable<Car> GetCuttentPostion(double r , double positionx , double positiony);
        IEnumerable<Car> GetStatus0();
    }
}
