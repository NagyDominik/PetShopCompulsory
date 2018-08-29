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
        public string PreviousOwner { get; set; }
        public double Price { get; set; }
    }
}
