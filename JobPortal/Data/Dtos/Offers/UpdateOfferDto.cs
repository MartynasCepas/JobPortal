using System.ComponentModel.DataAnnotations;

namespace JobPortal.Data.Dtos.Topics
{
    public record UpdateOfferDto([Required] string Name);
}
