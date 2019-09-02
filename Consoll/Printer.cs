using Core.Entity;
using PetShop_Assignment.Core.Core.ApplicationService;
using PetShop_Assignment.Core.Core.ApplicationService.impl;
using PetShop_Assignment.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consoll
{
    public class Printer : IPrinter
    {
        String[] Items;
        IPetService _PetService;

        public Printer(IPetService petservice)
        {
            _PetService = petservice;
            Items = new string[]
            {
                "List of pets",
                "Search by type",
                "Create a pet",
                "Delete a pet",
                "Update a pet",
                "Show a list of pets ordered by price",
                "Show the five cheapest pets",
                "Exit Application"
            };
        }


        public void RunUI()
        {
            Console.WriteLine("Welcome to the Pet Shop!");

            OpenMenu();

            int selection = ParseUserSelection();

            while (selection != Items.Length)
            {
                Pet pet;
                switch (selection)
                {
                    case 1:
                        PrintPets(_PetService.GetPets());
                        break;
                    case 2:
                        PrintPetsType();
                        break;
                    case 3:
                        pet = CreatePet();
                        Console.WriteLine("The pet {0} was added to the system", pet.Name);
                        
                        break;
                    case 4:
                        PrintPets(_PetService.GetPets());
                        pet = DeletePet();
                        if (pet == null)
                        {
                            Console.WriteLine("Did not find any pet with that id!");
                        }
                        else
                        {
                            Console.WriteLine("The pet {0} has been deleted", pet.Name);
                        }
                        break;
                    case 5:
                        pet = UpdatePets();
                        if (pet == null)
                        {
                            Console.WriteLine("Did not find a pet with that id!");
                        }
                        else
                        {
                            Console.WriteLine("The pet was updated");
                        }
                        break;
                    case 6:
                        PrintPets(_PetService.GetPetsByOrderedPrice());
                        break;
                    case 7:
                        PrintPets(_PetService.GetFiveCheapestPets());
                        break;
                }
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Console.Clear();
                OpenMenu();
                selection = ParseUserSelection();
            }
            Console.WriteLine("Closing Application");

        }

        private void OpenMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Pet Shop Menu:");
            for (int i = 0; i < Items.Length; i++)
            {
                Console.WriteLine("{0}.{1}", i + 1, Items[i]);
            }
        }

        private int parseInteger()
        {
            int parse;
            while (!int.TryParse(Console.ReadLine(), out parse))
            {
                Console.Write("");
                Console.WriteLine("Type a number: ");
                Console.Write("Number: ");
            }
            return parse;
        }

        private int ParseUserSelection()
        {
            Console.WriteLine("");
            Console.Write("Type a number: ");
            int selection = parseInteger();
            while (1 > selection || Items.Length < selection)
            {
                Console.WriteLine("Pick a number between 1-{0}", Items.Length);
                Console.Write("Number: ");
                selection = parseInteger();
            }

            return selection;
        }

        private Pet DeletePet()
        {
            Console.Write("Enter id of the pet you want deleted: ");
            int petId = parseInteger();
            Pet pet = _PetService.GetPet(petId);
            if (pet != null)
            {
                return _PetService.DeletePet(pet);
            }
            else
            {
                return null;
            }
        }

        private Pet UpdatePets()
        {
            Console.Clear();
            PrintPets(_PetService.GetPets());
            Console.Write("Enter id of the pet you want updated: ");
            int petId = parseInteger();
            Pet petToUpdate = _PetService.GetPet(petId);
            if (petToUpdate != null)
            {
                Console.WriteLine("Please type the new informations for this pet to update it:");
                Pet updatedPet = CreatePet();
                return _PetService.UpdatePet(petToUpdate, updatedPet);
            }
            else
            {
                return null;
            }
        }



        private void PrintPets(List<Pet> pets)
        {
            Console.Clear();
            if (pets.Count == 0)
            {
                Console.WriteLine("There are no pets in the system");
            }
            else
            {
                foreach (Pet pet in pets)
                {
                    Console.WriteLine();
                    Console.WriteLine("ID: " + pet.ID);
                    Console.WriteLine("Name: " + pet.Name);
                    Console.WriteLine("Type: " + pet.Type);
                    Console.WriteLine("Birthday: " + pet.Birthdate);
                    Console.WriteLine("Date of sale: " + pet.SoldDate);
                    Console.WriteLine("Previous Owner: " + pet.PreviousOwner);
                    Console.WriteLine("Price: " + pet.Price);
                    Console.WriteLine();
                }
            }
        }
        private void PrintPetsType()
        {
            Console.Clear();
            printAllTypes();
            Console.Write("Please enter a type: ");
            PetTypes type = getPetType();
            List<Pet> petsByType = _PetService.GetPetsByType(type);
            if (petsByType.Count == 0)
            {
                Console.WriteLine("No pets with that type could be found");
            }
            else
            {
                PrintPets(petsByType);
            }
        }

        private PetTypes getPetType()
        {
            PetTypes type;
            while (!Enum.TryParse(Console.ReadLine(), out type))
            {
                Console.WriteLine("The type does not exist");
                printAllTypes();
            }
            return type;
        }
        private void printAllTypes()
        {
            Console.WriteLine("These are alle the existing types of pets");
            string[] types = Enum.GetNames(typeof(PetTypes));
            foreach (string type in types)
            {
                Console.Write("| " + type + " ");
            }
            Console.WriteLine();
        }

        private Pet CreatePet()
        {
            Console.Clear();
            Pet pet = CreatePetObject();
            return _PetService.CreatePet(pet);
        }

        private Pet CreatePetObject()
        {
            Console.Write("Enter the pet's name: ");
            string name = Console.ReadLine();
            Console.Write("Enter the pet's type: ");
            PetTypes type = getPetType();
            Console.Write("Enter the pet's birth date: ");
            DateTime birthDate = validateTime();
            Console.Write("Enter the pet's sales date: ");
            DateTime soldDate = validateTime();
            Console.Write("Enter the pet's color/colors: ");
            string color = Console.ReadLine();
            Console.Write("Enter the pet's previous owner or \"none\": ");
            string previousOwner = Console.ReadLine();
            Console.Write("Enter the pet's price: ");
            double price = parseDouble();

            Pet pet = new Pet
            {
                Name = name,
                Type = type,
                Birthdate = birthDate,
                SoldDate = soldDate,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price
            };

            return pet;
        }

        private DateTime validateTime()
        {
            DateTime dato;
            while (!DateTime.TryParse(Console.ReadLine(), out dato))
            {
                Console.WriteLine("Enter a date using the format dd/mm/yyyy");
                Console.Write("Enter a new date");
            }
            return dato;
        }

        private double parseDouble()
        {
            double doubleToParse;
            while (!double.TryParse(Console.ReadLine(), out doubleToParse))
            {
                Console.WriteLine("Enter a new number");
                Console.WriteLine("Number: ");
            }
            return doubleToParse;
        }
    }
}
