﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModelDDD.Domain.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public  string Email{ get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public bool SpecialClient(Client client)
        {
            return client.IsActive && DateTime.Now.Year - client.RegisterDate.Year >= 5;
        }
    }
}
