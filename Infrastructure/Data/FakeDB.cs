using Core.Entity;
using PetShop_Assignment.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class FakeDB
    {
        public static int id = 1;
        public static IEnumerable<Pet> PetList;

        public static void initializeData()
        {
            Pet pet = new Pet
            {
                ID = id++,
                Name = "Johnny Bravo",
                Type = PetTypes.BigBoy,
                Birthdate = new DateTime(2019, 4, 20),
                SoldDate = new DateTime(2019, 5, 10),
                Color = "Red",
                PreviousOwner = "Michael",
                Price = 1000
            };
            Pet pet2 = new Pet
            {
                ID = id++,
                Name = "Johnny English",
                Type = PetTypes.Cat,
                Birthdate = new DateTime(2018, 12, 18),
                SoldDate = new DateTime(2018, 12, 19),
                Color = "black",
                PreviousOwner = "Mathias",
                Price = 100
            };
            Pet pet3 = new Pet
            {
                ID = id++,
                Name = "Blacki",
                Type = PetTypes.Cat,
                Birthdate = new DateTime(2017, 4, 20),
                SoldDate = new DateTime(2018, 12, 19),
                Color = "black",
                PreviousOwner = "Kristian",
                Price = 5620
            };
            Pet pet4 = new Pet
            {
                ID = id++,
                Name = "Reddi",
                Type = PetTypes.BeardedDragon,
                Birthdate = new DateTime(2017, 4, 20),
                SoldDate = new DateTime(2018, 12, 19),
                Color = "Red",
                PreviousOwner = "Molo",
                Price = 9500
            };
            Pet pet5 = new Pet
            {
                ID = id++,
                Name = "Orangi",
                Type = PetTypes.Elephant,
                Birthdate = new DateTime(2017, 4, 20),
                SoldDate = new DateTime(2018, 12, 19),
                Color = "Orange",
                PreviousOwner = "Hej",
                Price = 2500
            };
            Pet pet6 = new Pet
            {
                ID = id++,
                Name = "Frederik",
                Type = PetTypes.BigBoy,
                Birthdate = new DateTime(2020, 4, 20),
                SoldDate = new DateTime(2019, 5, 10),
                Color = "Red",
                PreviousOwner = "Michael",
                Price = 3000
            };
            Pet pet7 = new Pet
            {
                ID = id++,
                Name = "Jørgen",
                Type = PetTypes.Goat,
                Birthdate = new DateTime(2018, 4, 20),
                SoldDate = new DateTime(2019, 5, 10),
                Color = "Purple",
                PreviousOwner = "Barbara",
                Price = 2000
            };
            Pet pet8 = new Pet
            {
                ID = id++,
                Name = "Mads",
                Type = PetTypes.Dog,
                Birthdate = new DateTime(2016, 4, 20),
                SoldDate = new DateTime(2019, 5, 10),
                Color = "White",
                PreviousOwner = "Jan",
                Price = 1500
            };

            PetList = new List<Pet> { pet, pet2, pet3, pet4, pet5, pet6, pet7, pet8};
        }
    }
}
        
