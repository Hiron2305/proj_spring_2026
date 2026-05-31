using System.Drawing;

namespace Model.Core
{
    public partial class Cat : Pet
    {
        public string Breed { get; set; }
        public bool Castrate { get; set; }

        public Cat() { }

        public Cat(string name, int age, double weight, string gender, string breed, bool castrate, bool claustrophobia = false)
            : base(name, age, weight, gender, claustrophobia)
        {
            Breed = breed;
            Castrate = castrate;
        }

        public override string PetDetails => $"Кот (Порода: {Breed}, Каст.: {Castrate}, Клаустрофобия: {Claustrophobia})";
    }

    public partial class Dog : Pet
    {
        public string Breed { get; set; }
        public bool Castrate { get; set; }

        public Dog() { }

        public Dog(string name, int age, double weight, string gender, string breed, bool castrate, bool claustrophobia = true)
            : base(name, age, weight, gender, claustrophobia)
        {
            Breed = breed;
            Castrate = castrate;
        }

        public override string PetDetails => $"Собака (Порода: {Breed}, Каст.: {Castrate}, Клаустрофобия: {Claustrophobia})";
    }

    public partial class Rabbit : Pet
    {
        public int Children { get; set; }
        public string Colour { get; set; }

        public Rabbit() { }

        public Rabbit(string name, int age, double weight, string gender, int children, string colour, bool claustrophobia)
            : base(name, age, weight, gender, claustrophobia)
        {
            Children = children;
            Colour = colour;
        }
        public override string PetDetails => $"Кролик (Дети: {Children}, Цвет: {Colour}, Клаустрофобия: {Claustrophobia})";
    }
}