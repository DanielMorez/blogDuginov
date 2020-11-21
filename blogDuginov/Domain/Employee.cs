using blogDuginov.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogDuginov.Domain
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class Employee : Entity
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Адрес пользователя
        /// </summary>
        public string Address { get; set; }

        public string FullName {
            get => FirstName + " " + Surname;
        }
    }
}
