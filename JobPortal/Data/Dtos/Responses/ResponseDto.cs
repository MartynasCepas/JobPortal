using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Data.Dtos.Responses
{
    public record ResponseDto(int Id, string Message, string Status);
}
