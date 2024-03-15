

namespace DrivingSchoolWebApi.Models.DTO
{
    public class StudentDTO
    {
       
            public int ID { get; set; }
            public string? FIRST_NAME  { get; set; }
            public  string?  LAST_NAME { get; set; }
            public  string?  ADDRESS { get; set; }
            public  string? OIB { get; set; }
            public  string?  CONTACT_NUMBER { get; set; }
            public  DateTime DATE_OF_ENROLLMENT { get; set; }
        
    }
}
