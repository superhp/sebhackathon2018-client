using System;
using System.Collections.Generic;
using System.Text;

namespace SebHackathon2018.Dtos
{
    public class CustomerDto
    {
        public Guid ClientId { get; set; }
        public string CompanyName { get; set; }
        public string RedirectUrl { get; set; }
    }
}
