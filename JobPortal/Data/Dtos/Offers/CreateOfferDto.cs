using System.ComponentModel.DataAnnotations;

namespace JobPortal.Data.Dtos.Topics
{

    public record CreateOfferDto([Required] string Name, [Required] string Description);

}
