﻿using PetShopCompulsory.Core;
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
                "Remove pet",
                "Exit"
            };

            int selection = 0;
            while (selection != 5)
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
                        ListPets(_petservice.GetPets());
                        Console.ReadLine();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }
            }

        }

        void AddPet()
        {
            string name = QuestionInput("Name: ");
            Types type = ToType(QuestionInput("Type: "));
            DateTime birthdate = ToDateTime(QuestionInput("Birthdate (YYYY-MM_DD): "));
            DateTime solddate = ToDateTime(QuestionInput("Date of Selling (YYYY-MM_DD): "));
            string color = QuestionInput("Color: ");
            string prevOwner = QuestionInput("PreviousOwner: ");
            double price = ToNumberDouble(QuestionInput("Price: "));

            Pet newPet = _petservice.CreatePet(name, type, birthdate, solddate, color, prevOwner, price);
            if (newPet != null)
            {
                Console.Write("New pet created... ");
            }
            Pet savedPet = _petservice.SaveNewPet(newPet);
            if (savedPet != null)
            {
                Console.Write("New pet saved");
            }
        }

        int WriteMenu(string[] elements)
        {
            Console.Clear();
            int num = 1;
            Console.WriteLine("Select an option");
            foreach (var e in elements) {
                Console.WriteLine(num++ + ". " + e);
            }
            bool passed = false;
            int selection = 0;
            while (!passed) {
                selection = ToNumberInt(Console.ReadLine());
                if (selection > elements.Length || selection < 1) {
                    Console.WriteLine("Invalid selection! Please select an existing menu item");
                }
                else {
                    passed = true;
                }
            }
            return selection;
        }

        #region Tools

        string QuestionInput(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
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
            int a;
            if (!int.TryParse(numInt, out a)) {
                Console.WriteLine("Non-numeric input");
                Console.Write("New: ");
                ToNumberInt(Console.ReadLine());
            }
            return a;
        }

        double ToNumberDouble(string numDouble)
        {
            double a;
            if (!double.TryParse(numDouble, out a))
            {
                Console.WriteLine("Non-numeric input");
                Console.Write("New: ");
                ToNumberDouble(Console.ReadLine());
            }
            return a;
        }

        Types ToType(string type)
        {
            Types a;
            if (!Types.TryParse(type[0].ToString().ToUpper() + type.Substring(1), out a))
            {
                Console.WriteLine("The type does not exist");
                Console.Write("New: ");
                ToType(Console.ReadLine());
            }
            return a;
        }

        DateTime ToDateTime(string datetime)
        {
            DateTime a;
            if (!DateTime.TryParse(datetime, out a))
            {
                Console.WriteLine("Incorrect format (YYYY-MM-DD)");
                Console.Write("New: ");
                ToDateTime(Console.ReadLine());
            }
            return a;
        }
        #endregion
    }
}
