using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolWebApi.Models.DTO
{
    public class CourseDTO
    {
        public  int ID { get; set; }

        public  int Number_of_students { get; set; }

        public DateTime? START_DATE { get; set; }

        [Key]
        public  int  IDCategory { get; set; }
        [Key]
        public  int IDInstructor { get; set; }
        [Key]
        public int IDVehicle { get; set; }
        
       
    }
}
