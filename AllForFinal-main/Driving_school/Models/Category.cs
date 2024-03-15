using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingSchool.Models.Base;

namespace DrivingSchool.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int NumberOfTRLectures { get; set; }
        public int NumberOfDrivingLectures { get; set; }

    }
}
