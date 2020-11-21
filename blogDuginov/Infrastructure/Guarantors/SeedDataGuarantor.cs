using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using blogDuginov.Domain.Model;
using blogDuginov.Security;
using blogDuginov.Domain.DB;
using blogDuginov.Domain;

namespace blogDuginov.Infrastructure.Guarantors
{
    /// <summary>
    /// Заполнение данных для DbContext
    /// </summary>
    public class SeedDataGuarantor : IStartupPreConditionGuarantor
    {
        private readonly IServiceProvider _serviceProvider;
        public SeedDataGuarantor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Проверка данных
        /// </summary>
        public async Task EnsureAsync()
        {
            var context = _serviceProvider.GetService<BlogDbContext>();
            var userManager = _serviceProvider.GetService<UserManager<blogDuginov.Domain.User>>();
            var roleManager = _serviceProvider.GetService<RoleManager<IdentityRole<int>>>();

            await AssertRoleExistenceAsync(roleManager, context);

            context.SaveChanges();

            var adminUser = userManager.FindByNameAsync(SecurityConstants.AdminUserName).Result;
            if (adminUser == null)
            {

                var profile = new Employee
                {
                    FirstName = SecurityConstants.AdminFirstName,
                    Surname = SecurityConstants.AdminSurName
                };

                adminUser = new User
                {
                    Email = SecurityConstants.AdminEmail,
                    UserName = SecurityConstants.AdminUserName,
                    Employee = profile
                };

                var passwordHasher = new PasswordHasher<User>();

                adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, SecurityConstants.AdminPassword);

                await userManager.CreateAsync(adminUser);
            }

            if (!userManager.IsInRoleAsync(adminUser, SecurityConstants.AdminRole).Result)
                userManager.AddToRoleAsync(adminUser, SecurityConstants.AdminRole).Wait();


            context.SaveChanges();
        }
        private static async Task AssertRoleExistenceAsync(RoleManager<IdentityRole<int>> roleManager, BlogDbContext context)
        {
            var roles = new List<IdentityRole<int>>
            {
                new IdentityRole<int> { Name = SecurityConstants.AdminRole, NormalizedName = "ADMIN" },
                new IdentityRole<int> { Name = SecurityConstants.СustomerRole, NormalizedName = "CUSTOMER" }
            };

            foreach (var role in roles)
            {
                var roleExit = await roleManager.RoleExistsAsync(role.Name);
                if (!roleExit)
                {
                    context.Roles.Add(role);
                    context.SaveChanges();
                }
            }

        }

        public void Ensure(IServiceProvider services)
        {
            throw new NotImplementedException();
        }
    }
}
