using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DronePilotAcademy.Models.Base;

namespace DronePilotAcademy.Models
{
    public class Course : Entity
    {
        public DateTime StartDate { get; set; }

        public int InstructorId { get; set; }

        public int StudentId { get; set; }

        public int DroneId { get; set; }

        public int CategoryId { get; set; }

    }
}
