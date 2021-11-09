using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortal.Data.Entities;

namespace JobPortal.Data.Dtos.Applications
{
    public record ApplicationDto(int Id, string ApplicantName, string Description, int offer_id);
}
