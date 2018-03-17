using SebHackathon2018.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SebHackathon2018.Db
{
    public static class CustomersRepository
    {
        private static List<CustomerDto> _customerDtos = new List<CustomerDto>();

        public static void Add(CustomerDto customer)
        {
            _customerDtos.Add(customer);
        }

        public static CustomerDto Get(string clientId)
        {
            return _customerDtos.FirstOrDefault(c => c.ClientId.ToString() == clientId);
        }
    }
}
