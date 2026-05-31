using System.Xml.Serialization;

namespace Model.Core
{
    [XmlInclude(typeof(Cat))]
    [XmlInclude(typeof(Dog))]
    [XmlInclude(typeof(Rabbit))]
    public abstract partial class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string Gender { get; set; }

        protected Pet() { }

        protected Pet(string name, int age, double weight, string gender)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Gender = gender;
        }

        public virtual string PetDetails => "Неизвестный питомец";
    }
}