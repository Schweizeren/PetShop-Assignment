﻿using PetShop_Assignment.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop_Assignment.Core.Core.DomainService
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPets();
        Pet CreatePet(Pet pet);
        Pet DeletePet(Pet pet);
        Pet UpdatePet(Pet petToUpdate, Pet updatedPet);
        Pet readPet(int id);
    }
}
