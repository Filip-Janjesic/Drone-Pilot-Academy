namespace DrivingSchoolWebApi.Models
{
    public class Student : ENT
    {
        public string? FIRST_NAME { get; set; }
        public string? LAST_NAME { get; set; }
        public string? ADDRESS { get; set; }
        public string? OIB { get; set; }
        public string? CONTACT_NUMBER { get; set; }
        public DateTime DATE_OF_ENROLLMENT { get; set; }

        public ICollection<Course> Courses { get; } = new List<Course>();


        enum Status
        {
            Withdraw = -1,              //-1
            ListeningTR = 0,            //0
            WaitingTRTest = 1,          //1
            LiFirstAid = 2,             //2
            WaFirstAidTest = 3,         //3
            WaDrivingLessons = 4,       //4
            Driving = 5,                //5
            WaDrivingLessonsTest = 6,   //6
            WaHAK = 7,                  //7
            PassedAll = 8               //8
        }




    }
}
