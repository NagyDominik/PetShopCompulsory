using System;

namespace PetShopCompulsory.Core.Entity
{
    public enum Types { Cat, Dog, Snake, Goat, Fish, Turtle, Hamster, Parrot, Rabbit, Hedgehog}

    public class Pet
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Types Type { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public Owner PreviousOwner { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return "ID: " + ID + "  Name: " + Name +"  Type: " + Type + "  Birthdate: " + Birthdate + "\n" +
                   "SoldDate: " + SoldDate + "  Color: " + Color + "  PreviousOwner: " + PreviousOwner.ID +
                   ". " + PreviousOwner.FirstName + " " + PreviousOwner.LastName + "  Price: " + Price;
        }
    }
}
