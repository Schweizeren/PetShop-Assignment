using Core.Entity;
using PetShop_Assignment.Core.Entity;
using System.Collections.Generic;

namespace PetShop_Assignment.Core.Core.ApplicationService
{
    public interface IPetService
    {
        List<Pet> GetPets();
        Pet DeletePet(Pet pet);
        Pet CreatePet(Pet pet);
        Pet UpdatePet(Pet petToUpdate, Pet updatedPet);
        Pet GetPet(int id);
        List<Pet> GetPetsByOrderedPrice();
        List<Pet> GetPetsByType(PetTypes type);
        List<Pet> GetFiveCheapestPets();
    }
}
