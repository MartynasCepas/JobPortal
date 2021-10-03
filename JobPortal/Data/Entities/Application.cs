using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Data.Entities
{
    public class Application
    {
        public int Id { get; set; }
        public string ApplicantName { get; set; }
        public string Description { get; set; }

        public DateTime CreationTimeUtc { get; set; }
    }
}
