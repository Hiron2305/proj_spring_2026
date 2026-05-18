namespace PetShelter;

public class Shelter : ICountable, IFilter
{
    
    private string _name;
    private int _capacity;
    private bool _openterritory;
    private List<Pet> _pets;
    
    public string Name => _name;
    public int Capacity => _capacity;
    public bool Openterritory => _openterritory;

    public Shelter(string name, int capacity, bool openterritory)
    {
        _name = name;
        _capacity = capacity;
        _openterritory = openterritory;
        _pets = new List<Pet>();
    }

    public int Count()
    {
        return _pets.Count;
    }

    public int Count(Type type)
    {
        int c = 0;
        for (int i = 0; i < _pets.Count; i++)
        {
            if (type == _pets[i].GetType())
            {
                c++;
            }
        }
        return c;
    }

    public int Percentage(Type type)
    {
        int all = Count();
        int typecount = Count(type);
        
        if (all == 0) return 0;
        
        return (int)Math.Round((double)typecount / all * 100);
    }

    public List<Pet> Filter(Type type)
    {
        List<Pet> pets = new List<Pet>();
        for (int i = 0; i < _pets.Count; i++)
        {
            if (type == _pets[i].GetType())
            {
                pets.Add(_pets[i]);
            }

            if (Count(type) == 0)
            {
                Console.WriteLine("Nothing found");
            }
        }
        return pets;
    }
}