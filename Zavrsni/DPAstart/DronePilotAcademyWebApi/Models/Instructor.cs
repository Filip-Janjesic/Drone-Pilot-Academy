using System.ComponentModel.DataAnnotations;


namespace DronePilotAcademyWebApi.Models
{
    public class Instructor : ENT
    {
        public string? FIRST_NAME { get; set; }
        public string? LAST_NAME { get; set; }
        public string? PILOT_LICENSE_NUMBER { get; set; }
        public string? EMAIL { get; set; }
        public string? CONTACT_NUMBER { get; set; }
    }
}
