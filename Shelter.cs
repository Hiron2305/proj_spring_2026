namespace PetShelter;

public class Shelter : ICountable, IFilter
{
    
    private string _name;
    private int _capacity;
    private bool _openterritory;
    
    public string Name => _name;
    public int Capacity => _capacity;
    public bool Openterritory => _openterritory;

    public Shelter(string name, int capacity, bool openterritory)
    {
        _name = name;
        _capacity = capacity;
        _openterritory = openterritory;
    }

    public int Count()
    {
        return 0;
    }

    public int Count(Type type)
    {
        return 0;
    }

    public int Percentage(Type type)
    {
        return 0;
    }

    public void Filter(Type type)
    {

    }
}