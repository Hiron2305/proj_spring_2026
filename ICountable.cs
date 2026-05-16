namespace PetShelter;

public interface ICountable
{
    //просто инфа о числе животных
    int Count();
    
    //колличество животных коткретного типа
    int Count(Type type);
    
    //процент от общего числа животных для конкретного типа
    int Percentage(Type type);
    
    
}