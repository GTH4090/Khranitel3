using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khranitel.Models
{
    public partial class Employee
    {
        public string FullName { get => $"{LastName} {FirstName} {Patronomic}"; }
    }
}
