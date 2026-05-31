using System;
using System.Collections.Generic;

namespace Model.Core
{
    public interface ICountable
    {
        int Count();    
        int Count(Type type);
        int Percentage(Type type);
    }

    public interface IFilter
    {
        List<Pet> Filter(Type type);
        List<Pet> Filter(Type type, bool hasClaustrophobia);
    }

    public interface IChangeable
    {
        void AddPet(Pet pet);
        void RemovePet(Pet pet);
    }
}