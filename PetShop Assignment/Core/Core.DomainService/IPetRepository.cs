using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop_Assignment.Core.Core.DomainService
{
    interface IPetRepository
    {
        public IEnumerable<Pet> ReadPets;
    }
}
