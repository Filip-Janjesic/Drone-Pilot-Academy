using System.ComponentModel.DataAnnotations;


namespace DrivingSchoolWebApi.Models
{
    public class Vehicle : ENT
    {
        public string TYPE { get; set; }
        public string? BRAND { get; set; }
        public string? MODEL { get; set; }
        public DateTime? PURCHASE_DATE { get; set; }
        public DateTime? DATE_OF_REGISTRATION { get; set; }
    }
}
