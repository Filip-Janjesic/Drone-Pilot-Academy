using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DronePilotAcademy.Models.Base;

namespace DronePilotAcademy.Models
{
    public class Instructor : Entity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PilotLicenceNumber { get; set; }
        public string EMail { get; set; }
        public long ContactNumber { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

    }

}
