using System.ComponentModel.DataAnnotations.Schema;


namespace DrivingSchoolWebApi.Models
{
    public class Course : ENT
    {


        [ForeignKey("ID_Instructor")]
        public  Instructor? Instructor { get; set; }


        [ForeignKey("ID_Vehicle")]
        public  Vehicle? Vehicle { get; set; }


        [ForeignKey("ID_Category")]
        public Category? Category { get; set; }


        public  DateTime? START_DATE { get; set; }

        public List<Student> Students { get; set; } = new();




    }
}
