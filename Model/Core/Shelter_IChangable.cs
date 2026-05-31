using System;

namespace Model.Core
{
    public partial class Shelter : IChangeable
    {
        public void AddPet(Pet pet)
        {
            if (Pets.Count >= Capacity)
                throw new InvalidOperationException("Приют переполнен!");

            if (pet.Claustrophobia && !Openterritory)
                throw new InvalidOperationException($"Нельзя поместить питомца {pet.Name} с клаустрофобией в закрытый приют {Name}!");

            Pets.Add(pet);
        }

        public void RemovePet(Pet pet)
        {
            if (Pets.Contains(pet))
                Pets.Remove(pet);
            else
                throw new ArgumentException("Питомец не найден в этом приюте.");
        }
    }
}