using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameWork.Model
{
    class Car
    {
        public int CarId { get; set; }
        public string RegistrationNumber { get; set; }
        public double XPosition { get; set; }
        public double YPosition { get; set; }
        public int CurrentDistance { get; set; }
        public int TotalDistance { get; set; }
        public byte Status { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

        //public  void Update(Car car)
        //{
        //    Console.WriteLine("Wyszukaj Rejstrację do Zmiany Położenia Samochodu");
        //    string place = Console.ReadLine();
        //    if (car.RegistrationNumber == place)
        //    {
        //        Console.WriteLine("Wprowadz Xpostion");
        //        int x = Convert.ToInt32(Console.ReadLine());
        //        car.XPosition = x;

        //        Console.WriteLine("Wprowadz Ypostion");
        //        int y = Convert.ToInt32(Console.ReadLine());
        //        car.YPosition = x;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Nie odnaleziono samochodu o tej rejstracji");
        //    }
        }
    }
