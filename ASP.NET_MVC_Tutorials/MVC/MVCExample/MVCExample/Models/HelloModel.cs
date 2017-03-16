using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCExample.Models
{
    public class HelloModel
    {
        public static List<Car> GetCars()
        {
            List<Car> cars = new List<Car>
            {
                new Car { Id = 1, Make = "Audi", Model="R8" },
                new Car{ Id = 2, Make="Lamborghini", Model="Murcielago" },
                new Car{ Id = 3, Make="Ferrari", Model= "Enzo" },
            };
            return cars;
        }
    }

    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}