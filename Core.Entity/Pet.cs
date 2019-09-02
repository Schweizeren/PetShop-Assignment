using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop_Assignment.Core.Entity
{
    public class Pet
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
        public PetTypes Type { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public string PreviousOwner{ get; set; }
        public double Price { get; set; }
    }
}
