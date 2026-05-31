using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Core
{
    public partial class Shelter : ICountable, IFilter
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public bool Openterritory { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>();

        public Shelter() { }

        public Shelter(string name, int capacity, bool openterritory)
        {
            Name = name;
            Capacity = capacity;
            Openterritory = openterritory;
        }

        public int Count() => Pets.Count;
        public int Count(Type type) => Pets.Count(p => p.GetType() == type);
        public int Percentage(Type type) => Count() == 0 ? 0 : (int)Math.Round((double)Count(type) / Count() * 100);

        public List<Pet> Filter(Type type) => Pets.Where(p => p.GetType() == type).ToList();

        public List<Pet> Filter(Type type, bool onlyClaustrophobic)
        {
            Predicate<Pet> filterPredicate = p =>
                (type == null || p.GetType() == type) &&
                (!onlyClaustrophobic || p.Claustrophobia == true);

            return Pets.FindAll(filterPredicate);
        }

        public static Shelter operator +(Shelter shelter, Pet pet)
        {
            shelter.AddPet(pet);
            return shelter;
        }
    }
}