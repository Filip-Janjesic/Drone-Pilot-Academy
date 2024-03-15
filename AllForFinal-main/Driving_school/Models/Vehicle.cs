using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingSchool.Models.Base;

namespace DrivingSchool.Models
{
    public class Vehicle : Entity
    {
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
