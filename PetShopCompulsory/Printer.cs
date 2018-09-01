using PetShopCompulsory.Core;
using PetShopCompulsory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopCompulsory
{
    class Printer : IPrinter
    {
        readonly IPetService _petservice;
        readonly string[] defaultmenu =
        {
                "Add pet",
                "List pets",
                "Update pet",
                "Remove pet",
                "List pets by type",
                "Pets by price",
                "5 cheapest pets\n",
                "Owner options\n",
                "Exit\n"
        };
        readonly string[] ownermenu =
        {
                "Add owner",
                "List owner",
                "Update owner",
                "Remove owner\n",
                "Exit"
        };

        public Printer(IPetService petService)
        {
            _petservice = petService;
        }

        public void StartUp()
        {
            int selection = 0;
            while (selection != 9)
            {
                Console.Clear();
                Console.WriteLine("Select an option");
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
                        ListElements(_petservice.GetAllPets());
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
                        PetsByType();
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.WriteLine("Listing pets by price");
                        PetsByPrice();
                        Console.ReadLine();
                        break;
                    case 7:
                        Console.WriteLine("5 cheapest pets");
                        PetsTopCheap();
                        Console.ReadLine();
                        break;
                    case 8:
                        Console.Clear();
                        OwnerMenu();
                        break;
                    default:
                        break;
                }
            }
        }

        int WriteMenu(string[] elements)
        {
            int num = 1;
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

        #region Owner
        void OwnerMenu()
        {
            int selection = 0;
            while (selection != 5)
            {
                Console.Clear();
                Console.WriteLine("Select an option");
                selection = WriteMenu(ownermenu);
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Adding owner");
                        AddOwner();
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Owners:");
                        ListElements(_petservice.GetAllOwners());
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Updating owner");
                        UpdateOwner();
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Removing owner");
                        RemoveOwner();
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
            }
        }

        void AddOwner()
        {
            Owner newOwner = CreateNewOwner();
            if (newOwner != null)
                Console.Write("New owner created... ");
            else
            {
                Console.WriteLine("Something went wrong. Please try again!");
                return;
            }

            Owner savedOwner = _petservice.SaveNewOwner(newOwner);
            if (savedOwner != null)
                Console.Write("New owner saved!");
        }

        void UpdateOwner()
        {
            int id = SelectOwner();
            if (id == 0)
                return;
            Owner ownerUpdate = CreateNewOwner();
            ownerUpdate.ID = id;
            if (ownerUpdate != null)
                Console.Write("Updating...");
            else
            {
                Console.WriteLine("Something went wrong. Please try again!");
                return;
            }
            Owner result = _petservice.UpdateOwner(ownerUpdate);
            if (result != null)
                Console.Write("Updated!");
        }

        void RemoveOwner()
        {
            int id = SelectOwner();
            if (id == 0)
                return;
            Owner result = _petservice.RemoveOwner(id);
            if (result != null)
                Console.Write("Deleted!");
            else
            {
                Console.WriteLine("Something went wrong. Please try again!");
                return;
            }
        }
        #endregion

        #region Pet
        void AddPet()
        {
            Pet newPet = CreateNewPet();
            if (newPet != null)
                Console.Write("New pet created... ");
            else
            {
                Console.WriteLine("Something went wrong. Please try again!");
                return;
            }

            Pet savedPet = _petservice.SaveNewPet(newPet);
            if (savedPet != null)
                Console.Write("New pet saved!");
        }

        void UpdatePet()
        {
            int id = SelectPet();
            if (id == 0)
                return;
            Pet petUpdate = CreateNewPet();
            petUpdate.ID = id;
            if (petUpdate != null)
                Console.Write("Updating... ");
            else
            {
                Console.WriteLine("Something went wrong. Please try again!");
                return;
            }
            Pet result = _petservice.UpdatePet(petUpdate);
            if (result != null)
                Console.Write("Updated!");
        }

        void RemovePet()
        {
            int id = SelectPet();
            if (id == 0)
                return;
            Pet result = _petservice.RemovePet(id);
            if (result != null)
                Console.Write("Deleted!");
            else
            {
                Console.WriteLine("Something went wrong. Please try again!");
                return;
            }
        }

        void PetsByType()
        {
            string[] typesasstring = Enum.GetNames(typeof(Types));
            Console.WriteLine("Select a pet type(ID)");
            int selection = WriteMenu(typesasstring);
            Types selectionType = ToType(typesasstring[selection - 1]);
            List<Pet> pets = _petservice.GetPetsByType(selectionType);
            ListElements(pets);
        }

        void PetsByPrice()
        {
            string order = "";
            while (order != "Asc" && order != "Desc")
            {
                order = QuestionInput("Select the order of listing (Asc/Desc): ");
            }
            List<Pet> pets = _petservice.GetPetsPriceOrdered(order);
            ListElements(pets);
        }

        void PetsTopCheap()
        {
            List<Pet> pets = _petservice.GetPetsTopCheap(5);
            ListElements(pets);
        }
        #endregion

        #region Tools

        int SelectPet()
        {
            List<Pet> petList = _petservice.GetAllPets();
            if (petList.Count == 0)
            {
                Console.WriteLine("There are no pets!");
                return 0;
            }
            Console.WriteLine("Please select the pet(ID):");
            ListElements(petList);
            int id = ToNumberInt(QuestionInput("ID: "));
            while (!petList.Exists(p => p.ID == id))
            {
                Console.WriteLine("Wrong ID!");
                id = ToNumberInt(QuestionInput("New: "));
            }
            return id;
        }

        int SelectOwner()
        {
            List<Owner> ownerList = _petservice.GetAllOwners();
            if (ownerList.Count == 0)
            {
                Console.WriteLine("There are no owners!");
                return 0;
            }
            Console.WriteLine("Please select the owner(ID):");
            ListElements(ownerList);
            int id = ToNumberInt(QuestionInput("ID: "));
            while (!ownerList.Exists(o =>o.ID == id))
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

        void ListElements<T>(List<T> list)
        {
            foreach (var e in list)
            {
                Console.WriteLine(e.ToString());
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
                a = ToType(FirstLetterToCapital(Console.ReadLine()));
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
            if (input != null && input != "")
                return char.ToUpper(input[0]) + input.Substring(1);
            return null;
        }

        Pet CreateNewPet()
        {
            string name = QuestionInput("Name: ");
            Types type = ToType(QuestionInput("Type: "));
            DateTime birthdate = ToDateTime(QuestionInput("Birthdate (YYYY-MM-DD): "));
            DateTime solddate = ToDateTime(QuestionInput("Date of Selling (YYYY-MM-DD): "));
            string color = QuestionInput("Color: ");
            int ownerID = -1;
            while (!int.TryParse(QuestionInput("PreviousOwnerID: "), out ownerID) || !_petservice.GetAllOwners().Exists(o => o.ID == ownerID))
            {
                Console.WriteLine("Incorrect ID!");
            }
            Owner prevOwner = _petservice.GetOwnerByID(ownerID);
            double price = ToNumberDouble(QuestionInput("Price: "));

            Pet newPet = _petservice.CreatePet(name, type, birthdate, solddate, color, prevOwner, price);
            if (newPet != null)
                return newPet;
            return null;
        }

        Owner CreateNewOwner()
        {
            string fname = QuestionInput("Firstname: ");
            string lname = QuestionInput("Lastname: ");
            string address = QuestionInput("Address: ");
            string pnum = QuestionInput("Phone number: ");
            Console.Write("Email: ");
            string email = Console.ReadLine();

            Owner newOwner = _petservice.CreateOwner(fname, lname, address, pnum, email);
            if (newOwner != null)
                return newOwner;
            return null;
        }
        #endregion
    }
}