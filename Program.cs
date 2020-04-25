using EntityFrameWork.Data;
using EntityFrameWork.Init;
using EntityFrameWork.Model;
using System;
using System.Linq;

namespace EntityFrameWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Enitiy");
            Console.WriteLine("Operation Create [PRESS ENTER]");
            Console.ReadKey();
            //CREATE ! 
            using CarRentalContext context = new CarRentalContext();
            #region Create
            Reservation rs = new Reservation()
            {
                ReservationId = 0,
                ReservationDateTime = new DateTime(2020, 03, 27, 08, 34, 20),
                Status = 0,
                CarId = 1
            };

            DateTime ReservationDate = rs.ReservationDateTime;
            var reservationNumber = context.Reservations.Where(x => x.ReservationDateTime == ReservationDate);
            int doubleReservation = 0;
            foreach (var item in reservationNumber)
            {
                Console.WriteLine("Rezerwacja o Dacie {0} aktualnie znajduje się w bazie", item.ReservationDateTime);
                doubleReservation++;
            }
            if (doubleReservation == 0)
                context.Reservations.Add(rs);

            Car car1 = new Car()
            {
                RegistrationNumber = "WLI15AL",
                CurrentDistance = 105,
                Status = 1,
                XPosition = 12.2332,
                YPosition = 13.2112,
                TotalDistance = 1200000,
            };
            string carRegistration = car1.RegistrationNumber;
            var registionNum = context.Cars.Where(x => x.RegistrationNumber == carRegistration);
            int doubleRegistion = 0;
            foreach (var item in registionNum)
            {
                Console.WriteLine("Samochód o numerze resjstracyjnym {0} aktualnie znajduje się w bazie", item.RegistrationNumber);
                doubleRegistion++;
            }
            if (doubleRegistion == 0)
                context.Cars.Add(car1);



            Car car2 = new Car()
            {
                RegistrationNumber = "KRKF0AL",
                XPosition = 12.3221,
                YPosition = 1233.211,
                TotalDistance = 1200000,
                CurrentDistance = 190,
                Status = 0
            };
            string carRegistration2 = car2.RegistrationNumber;
            var registionNum2 = context.Cars.Where(x => x.RegistrationNumber == carRegistration2);
            int doubleRegistion2 = 0;
            foreach (var item in registionNum2)
            {
                Console.WriteLine("Samochód o numerze resjstracyjnym {0} aktualnie znajduje się w bazie", item.RegistrationNumber);
                doubleRegistion2++;
            }
            if (doubleRegistion2 == 0)
                context.Cars.Add(car2);
            #endregion
            //Read
            #region READ
            Console.WriteLine("Wczytuje Samochody o Wartośc 0 [PRESS ENTER]");
            Console.ReadKey();
            int i = 1;
            var Status0Linq = context.Cars.Where(x => x.Status == 0).ToList();
            foreach (var item in Status0Linq)
            {
                Console.WriteLine("Samochód nr {0} o statusie równym 0 (wolny)", i);
                Console.WriteLine("NUMER REJSTRACYJNY {0}",item.RegistrationNumber);
                Console.WriteLine("BIEŻĄCY DYSTANS {0}",item.CurrentDistance);
                Console.WriteLine("CALKOWITY PRZEBIEG {0} ",item.TotalDistance);
                Console.WriteLine("POZYCJA X GPS  {0}", item.XPosition);
                Console.WriteLine("POZYCJA Y GPS {0}" , item.YPosition);
                Console.WriteLine("STATUS SAMOCHODU ((0 – wolny, 1, zarezerwowany, 2 – wypożyczony))");
                Console.WriteLine(item.Status);
            }
            #endregion
            Update();
            Delete();
            context.SaveChanges();
            #region Repozytorium 
            CarsRepositories rss = new CarsRepositories(context);
            var x = rss.GetKilometers();
            Console.WriteLine("POJAZD GDZIE BIEŻĄCY PRZEBIEG JEST WIEKSZY NIZ 180 ");
            Console.WriteLine("[PRESS ANY KEY...]");
            Console.ReadKey();
            foreach (var item in x)
            {
                Console.WriteLine("NUMER REJESTRACYJNY {0}", item.RegistrationNumber);
                Console.WriteLine("STATUS SAMOCHODU {0}", item.Status);
                Console.WriteLine("BIEŻĄCY DYSTANS {0}", item.CurrentDistance);
            }

            var xy = rss.GetCuttentPostion(5, 12, 14);
            Console.WriteLine("SAMOCHOD ODDALONY O PROMIEN OD WPISANYCH WSPOLRZEDNYCH");
            Console.WriteLine("PRESS ANY KEY...");
            Console.ReadKey();
            foreach (var item in xy)
            {
                Console.WriteLine("NUMER REJESTRACYJNY - {0}",item.RegistrationNumber);
                Console.WriteLine("STATUS SAMOCHODU - {0}",item.Status);
                Console.WriteLine("PRZEBYTY CALKOWITY DYSTANS = {0}",item.TotalDistance);
            }
            ReservationRepository reservation = new ReservationRepository(context);
            Console.WriteLine("WCZYTUJE SAMOCHOD GDZIE STATUS WYNOSI 0 PO UPLYNIECIU 15 MIN ");
            Console.WriteLine("[PRESS ANY KEY...]");
            Console.ReadKey();
            var xzzz = reservation.GetOneWhereStatus0();
            foreach (var item in xzzz)
            {
                Console.WriteLine("Data Rezerwacji {0}", item.ReservationDateTime);
                Console.WriteLine("ID SAMOCHODU OBEJMUJACEGO REZERWACJE {0}" ,item.CarId);
                Console.WriteLine("STATUS SAMOCHODU - {0}",item.Status);

            }
            context.SaveChanges();
            #endregion

            Console.WriteLine("Wczytuje UNITY OF WORK {PRESS ENTER}");
            Console.ReadKey();
            //////////////////UNITYOFWORK
            using (var unityOfWork = new UnitOfWorks(new CarRentalContext()))
            {
                //EXAMPLE 1
                Console.WriteLine("WCZYTUJE WSZYSTKIE SAMOCHODY");
                var cars = unityOfWork.Cars.GetAll();
                foreach (var item in cars)
                {
                    Console.WriteLine("NUMER REJESTRACYJNY = {0}", item.RegistrationNumber);
                    Console.WriteLine("STATUS = {0}", item.Status);
                    Console.WriteLine("=======================================");
                    Console.WriteLine();
                }
                //EXAMPLE READ IN UNITY
                var status0 = unityOfWork.Cars.GetStatus0();
                Console.WriteLine("Operacja READ in UnityOfWork");
                Console.WriteLine();
                foreach (var item in status0)
                {
                    Console.WriteLine("Car RegistrationNumber {0} ",item.RegistrationNumber);
                    Console.WriteLine("STATUS {0}",item.Status);
                }
                Console.WriteLine("Dodaje SAmochod");
                Car cr = new Car()
                {
                    Status = 1,
                    RegistrationNumber = "FIRMA KRK"
                };
                unityOfWork.Cars.Add(cr);
                unityOfWork.Complete();
            }
           
            Console.ReadLine();
        }
        static void Update()
        {
            using (var db = new CarRentalContext())
            {
                Console.WriteLine("Wyszukaj Rejstrację do Zmiany Położenia Samochodu");
                string place = Console.ReadLine();
                Car car = db.Cars.Where(x => x.RegistrationNumber == place).FirstOrDefault();
                if (car != null)
                {
                    Console.WriteLine("Wprowadz Xpostion");
                    double x = Convert.ToDouble(Console.ReadLine());
                    car.XPosition = x;

                    Console.WriteLine("Wprowadz Ypostion");
                    double y = Convert.ToDouble(Console.ReadLine());
                    car.YPosition = x;

                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Nie odnaleziono samochodu o tym numerze rejstracyjnym");
                }

            }
            return;
        }

        static void Delete()
        {
            using (var db = new CarRentalContext())
            {

                Console.WriteLine("Wyszukaj Rejstrację do Zmiany Położenia Samochodu");
                string place = Console.ReadLine();
                Car car = db.Cars.Where(x => x.RegistrationNumber == place).FirstOrDefault();
                if (car != null)
                {
                    db.Cars.Remove(car);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Nie odnaleziono samochodu o tym numerze rejstracyjnym");
                }
            }
            return;
        }
    }

}
