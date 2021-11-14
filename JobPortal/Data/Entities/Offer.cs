using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JobPortal.Auth;
using JobPortal.Data.Dtos.Auth;

namespace JobPortal.Data.Entities
{
    public class Offer : IUserOwnedResource
    {
        public int Id {  get; set; }   
        public string Name {  get; set; }
        public string Description {  get; set; }
        public double Price { get; set; }

        public DateTime CreationTimeUtc {  get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
