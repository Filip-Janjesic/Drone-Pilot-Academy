using System.Linq.Expressions;

namespace DronePilotAcademyWebApi.Models
{
    public class Category : ENT
    {
        

        public string? NAME { get; set; }
        public decimal PRICE { get; set; }
        public string?  NUMBER_OF_TR_LECTURES { get; set; }
        public string? NUMBER_OF_FLYING_LECTURES { get; set; }

       
    }
}
