using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingSchool.Models.Base;

namespace DrivingSchool.Models
{
    public class Instructor : Entity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DriverLicenceNumber { get; set; }
        public string EMail { get; set; }
        public long ContactNumber { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

    }

}
