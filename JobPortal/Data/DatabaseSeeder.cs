using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortal.Auth.Model;
using JobPortal.Data.Dtos.Auth;
using Microsoft.AspNetCore.Identity;

namespace JobPortal.Data
{
    public class DatabaseSeeder
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DatabaseSeeder(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            foreach (var role in RestUserRoles.All)
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var newRecruiterUser = new User
            {
                UserName = "recruiter",
                Email = "test@test.com"
            };
            var existingRecruiterUser = await _userManager.FindByEmailAsync(newRecruiterUser.Email);
            if (existingRecruiterUser == null)
            {
                var createRecruiterUserResult = await _userManager.CreateAsync(newRecruiterUser, "Password1!");
                if (createRecruiterUserResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newRecruiterUser, RestUserRoles.Recruiter);
                }
            }


            var newApplicantUser = new User
            {
                UserName = "applicant",
                Email = "applicant@test.com"
            };
            var existingApplicantUser = await _userManager.FindByEmailAsync(newApplicantUser.Email);
            if (existingApplicantUser == null)
            {
                var createApplicantUserResult = await _userManager.CreateAsync(newApplicantUser, "Password1!");
                if (createApplicantUserResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newApplicantUser, RestUserRoles.Applicant);
                }
            }
        }
    }
}
