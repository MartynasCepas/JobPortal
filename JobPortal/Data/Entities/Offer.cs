using System;

namespace JobPortal.Data.Entities
{
    public class Offer
    {
        public int Id {  get; set; }   
        public string Name {  get; set; }
        public string Description {  get; set; }

        public DateTime CreationTimeUtc {  get; set; }
    }
}
