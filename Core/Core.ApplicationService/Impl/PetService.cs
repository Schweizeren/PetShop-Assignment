using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;
using PetShop_Assignment.Core.Core.DomainService;
using PetShop_Assignment.Core.Entity;

namespace PetShop_Assignment.Core.Core.ApplicationService.impl
{
    public class PetService : IPetService
    {
        IPetRepository _PetRepository;

        public PetService(IPetRepository petRepo)
        {
            _PetRepository = petRepo;
        }

        public Pet CreatePet(Pet pet)
        {
            return _PetRepository.CreatePet(pet);
        }

        public Pet DeletePet(Pet pet)
        {
            return _PetRepository.DeletePet(pet);
        }

        public List<Pet> GetFiveCheapestPets()
        {
            List<Pet> CheapestPets = new List<Pet>();
            IEnumerable<Pet> pets = _PetRepository.ReadPets().OrderBy(pet => pet.Price);
            List<Pet> petsordered = pets.ToList();
            foreach(Pet pet in petsordered)
            {
                if (CheapestPets.Count == 5)
                {
                    
                } else
                {
                    CheapestPets.Add(pet);
                }
            }
            return CheapestPets;
        }

        public Pet GetPet(int id)
        {
            return _PetRepository.readPet(id);
        }

        public List<Pet> GetPets()
        {
            return _PetRepository.ReadPets().ToList();
        }

        public List<Pet> GetPetsByOrderedPrice()
        {
            IEnumerable<Pet> pets = _PetRepository.ReadPets().OrderBy(pet => pet.Price);

            return pets.ToList();
        }

        public List<Pet> GetPetsByType(PetTypes type)
        {
            List<Pet> SortByType = new List<Pet>();
            List<Pet> pets = _PetRepository.ReadPets().ToList();
            foreach (Pet pet in pets)
            {
                if (type == pet.Type)
                {
                    SortByType.Add(pet);
                }
            }
            return SortByType;
        }

        public Pet UpdatePet(Pet petToUpdate, Pet updatedPet)
        {
            return _PetRepository.UpdatePet(petToUpdate, updatedPet);
        }
    }
}
