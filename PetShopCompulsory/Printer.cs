using PetShopCompulsory.Core;
using PetShopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopCompulsory
{
    class Printer : IPrinter
    {
        readonly IPetService _petservice;

        public Printer(IPetService petService)
        {
            _petservice = petService;
        }

        public void StartUp()
        {
            string[] defaultmenu = {
                "Add pet",
                "List pets",
                "Update pet",
                "Remove pet\n",
                "List pets by type",
                "Pets by price",
                "5 cheapest pets\n",
                "Exit\n"
            };

            int selection = 0;
            while (selection != 8)
            {
                selection = WriteMenu(defaultmenu);
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Adding pet");
                        AddPet();
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Pets:");
                        ListPets(_petservice.GetAllPets());
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Updating pet");
                        UpdatePet();
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Removing pet");
                        RemovePet();
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine("Listing pets by type");

                        Console.ReadLine();
                        break;
                    case 6:
                        Console.WriteLine("Listing pets by price");

                        Console.ReadLine();
                        break;
                    case 7:
                        Console.WriteLine("5 cheapest pets");

                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
            }

        }

        int WriteMenu(string[] elements)
        {
            Console.Clear();
            int num = 1;
            Console.WriteLine("Select an option");
            foreach (var e in elements)
            {
                Console.WriteLine(num++ + ". " + e);
            }
            bool passed = false;
            int selection = 0;
            while (!passed)
            {
                selection = ToNumberInt(Console.ReadLine());
                if (selection > elements.Length || selection < 1)
                    Console.WriteLine("Invalid selection! Please select an existing menu item");
                else
                    passed = true;
            }
            return selection;
        }

        void AddPet()
        {
            Pet newPet = CreateNewPet();
            if (newPet != null)
                Console.Write("New pet created... ");

            Pet savedPet = _petservice.SaveNewPet(newPet);
            if (savedPet != null)
                Console.Write("New pet saved!");
        }

        void UpdatePet()
        {
            int id = SelectPet();
            Pet petUpdate = CreateNewPet();
            petUpdate.ID = id;
            if (petUpdate != null)
                Console.Write("Updating... ");

            Pet result = _petservice.UpdatePet(petUpdate);
            if (result != null)
                Console.Write("Updated!");
        }

        void RemovePet()
        {
            int id = SelectPet();
            Pet result = _petservice.RemovePet(id);
            if (result != null)
                Console.Write("Deleted!");
        }

        #region Tools

        int SelectPet()
        {
            Console.WriteLine("Please select the pet(ID):");
            List<Pet> petList = _petservice.GetAllPets();
            ListPets(petList);
            int id = ToNumberInt(QuestionInput("ID: "));
            while (id > _petservice.GetAllPets().Count)
            {
                Console.WriteLine("Wrong ID!");
                id = ToNumberInt(QuestionInput("New: "));
            }
            return id;
        }

        string QuestionInput(string question)
        {
            Console.Write(question);
            return FirstLetterToCapital(Console.ReadLine());
        }

        void ListPets(List<Pet> pets)
        {
            foreach (var pet in pets) {
                Console.WriteLine(pet.ToString());
                Console.WriteLine();
            }
        }

        int ToNumberInt(string numInt)
        {
            if (!int.TryParse(numInt, out int a))
            {
                Console.WriteLine("Non-numeric input");
                Console.Write("New: ");
                a = ToNumberInt(Console.ReadLine());
            }
            return a;
        }

        double ToNumberDouble(string numDouble)
        {
            if (!double.TryParse(numDouble, out double a))
            {
                Console.WriteLine("Non-numeric input");
                Console.Write("New: ");
                a = ToNumberDouble(Console.ReadLine());
            }
            return a;
        }

        Types ToType(string type)
        {
            if (!Types.TryParse(type, out Types a))
            {
                Console.WriteLine("The type does not exist");
                Console.Write("New: ");
                a = ToType(Console.ReadLine());
            }
            return a;
        }

        DateTime ToDateTime(string datetime)
        {
            if (!DateTime.TryParse(datetime, out DateTime a))
            {
                Console.WriteLine("Incorrect format (YYYY-MM-DD)");
                Console.Write("New: ");
                a = ToDateTime(Console.ReadLine());
            }
            return a;
        }

        string FirstLetterToCapital(string input)
        {
            if (input != null)
                return char.ToUpper(input[0]) + input.Substring(1);
            return null;
        }

        Pet CreateNewPet()
        {
            string name = QuestionInput("Name: ");
            Types type = ToType(QuestionInput("Type: "));
            DateTime birthdate = ToDateTime(QuestionInput("Birthdate (YYYY-MM_DD): "));
            DateTime solddate = ToDateTime(QuestionInput("Date of Selling (YYYY-MM-DD): "));
            string color = QuestionInput("Color: ");
            string prevOwner = QuestionInput("PreviousOwner: ");
            double price = ToNumberDouble(QuestionInput("Price: "));

            Pet newPet = _petservice.CreatePet(name, type, birthdate, solddate, color, prevOwner, price);
            if (newPet != null)
                return newPet;
            return null;
        }
        #endregion
    }
}
