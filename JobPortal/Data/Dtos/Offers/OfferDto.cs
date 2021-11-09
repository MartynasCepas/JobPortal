using System.Collections.Generic;
using JobPortal.Data.Entities;

namespace JobPortal.Data.Dtos.Topics
{
    public record OfferDto(int Offer_Id,  string Name, string Description);
}
