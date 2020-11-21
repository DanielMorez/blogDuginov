using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogDuginov.Domain
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User : IdentityUser<int>
    {
        /// <summary>
        /// Профиль пользователя
        /// </summary>
        public Employee Employee { get; set; }
    }
}
