using PetShop_Assignment.Core.Core.DomainService;
using PetShop_Assignment.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        public Pet CreatePet(Pet pet)
        {
            pet.ID = FakeDB.id++;
            List<Pet> pets = FakeDB.PetList.ToList();
            pets.Add(pet);
            FakeDB.PetList = pets;
            return pet;
        }

        public Pet DeletePet(Pet pet)
        {
            List<Pet> pets = FakeDB.PetList.ToList();
            pets.Remove(pet);
            FakeDB.PetList = pets;
            return pet;
        }

        public Pet readPet(int id)
        {
            List<Pet> pets = FakeDB.PetList.ToList();
            foreach (Pet pet in pets)
            {
                if (id == pet.ID)
                {
                    return pet;
                }

            }

            return null;

        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.PetList;
        }

        public Pet UpdatePet(Pet petToUpdate, Pet updatedPet)
        {
            List<Pet> pets = FakeDB.PetList.ToList();
            foreach (Pet pet in pets)
            {
                if (pet.ID == petToUpdate.ID)
                {
                    pet.Name = updatedPet.Name;
                    pet.Type = updatedPet.Type;
                    pet.Birthdate = updatedPet.Birthdate;
                    pet.SoldDate = updatedPet.SoldDate;
                    pet.Color = updatedPet.Color;
                    pet.PreviousOwner = updatedPet.PreviousOwner;
                    pet.Price = updatedPet.Price;
                }
            }
            FakeDB.PetList = pets;
            return updatedPet;
        }
    }
}
