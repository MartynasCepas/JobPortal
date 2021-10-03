using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Data.Dtos.Responses
{
    public record UpdateResponseDto([Required] string Message);
}
