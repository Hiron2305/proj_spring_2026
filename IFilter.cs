namespace PetShelter;

public interface IFilter
{
    List<Pet> Filter(Type type);
}