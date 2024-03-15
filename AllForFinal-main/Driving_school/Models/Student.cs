using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingSchool.Models.Base;

namespace DrivingSchool.Models
{
    public class Student : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int OIB { get; set; }
        public long ContactNumber { get; set; }
        public DateTime DateOfEnrolment { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
