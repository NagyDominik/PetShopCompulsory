﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopCompulsory.Core.Entity
{
    public class Owner
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return "ID: " + ID + "  Name: " + FirstName + " " + LastName + "  Address: " + Address
                + "\nPhone number: " + PhoneNumber + "  Email: " + Email;
        }
    }
}
