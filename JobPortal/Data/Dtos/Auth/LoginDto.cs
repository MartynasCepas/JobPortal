using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Data.Dtos.Auth
{
    public record LoginDto(string Email, string Password);
}
