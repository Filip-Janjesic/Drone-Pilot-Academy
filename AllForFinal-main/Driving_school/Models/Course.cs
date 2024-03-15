using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingSchool.Models.Base;

namespace DrivingSchool.Models
{
    public class Course : Entity
    {
        public DateTime StartDate { get; set; }

        public int InstructorId { get; set; }

        public int StudentId { get; set; }

        public int VehicleId { get; set; }

        public int CategoryId { get; set; }

    }
}
