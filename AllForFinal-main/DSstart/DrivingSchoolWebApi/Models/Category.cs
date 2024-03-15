
using System.Linq.Expressions;

namespace DrivingSchoolWebApi.Models
{
    public class Category : ENT
    {
        

        public string? NAME { get; set; }
        public decimal PRICE { get; set; }
        public string?  NUMBER_OF_TR_LECTURES { get; set; }
        public string? NUMBER_OF_DRIVING_LECTURES { get; set; }

       
    }
}
