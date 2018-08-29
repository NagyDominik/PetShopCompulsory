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
                "Remove pet",
                "Exit"
            };
            int selection = WriteMenu(defaultmenu);

            switch (selection) {
                case 1:
                break;

                case 2:
                break;

                case 3:
                break;

                case 4:
                break;

                case 5:
                break;

                default:
                break;
            }
        }

        int WriteMenu(string[] elements)
        {
            int num = 1;
            Console.WriteLine("Select an option");
            foreach (var e in elements) {
                Console.WriteLine(num++ + ". " + e);
            }
            bool passed = false;
            int selection = 0;
            while (!passed) {
                selection = ToNumber();
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

        void ListPets(List<Pet> pets)
        {
            Console.WriteLine("Id, Name, Type");

            foreach (var pet in pets) {
                Console.WriteLine(pet.ToString());
            }
        }

        int ToNumber()
        {
            int a = 0;
            while (!int.TryParse(Console.ReadLine(), out a)) {
                Console.WriteLine("Non-numeric input");
                Console.Write("New: ");
            }
            return a;
        }

        #endregion
    }
}
