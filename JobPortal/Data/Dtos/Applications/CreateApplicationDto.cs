﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Data.Dtos.Applications
{
    public record CreateApplicationDto([Required] string ApplicantName, [Required] string Description);
}
