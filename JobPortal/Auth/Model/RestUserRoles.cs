using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Auth.Model
{
    public static class RestUserRoles
    {
        public const string Recruiter = nameof(Recruiter);
        public const string Applicant = nameof(Applicant);

        public static readonly IReadOnlyCollection<string> All = new[] {Recruiter, Applicant};
    }
}
