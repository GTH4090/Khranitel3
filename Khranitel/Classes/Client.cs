using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khranitel.Models
{
    public partial class Client
    {
        public string FullName { get => $"{LastName} {FirstName} {Patronomic}"; }

        public string Contacts { get => $"{Email}; {Phone}"; }
    }
}
