using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Data.Entities
{
    public class Response
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }

        public DateTime CreationTimeUtc { get; set; }
    }
}
