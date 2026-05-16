namespace PetShelter;

abstract public class Pet
{
    private string _name;
    private int _age;
    private double _weight;
    private string _gender;
    
    public string Name => _name;
    public int Age => _age;
    public double Weight => _weight;
    public string Gender => _gender;

    public Pet(string name, int age, double weight,  string gender)
    {
        _name = name;
        _age = age;
        _weight = weight;
        _gender = gender;
    }
}

public class Cat : Pet
{
    //добовляю породу и кастрирована иль нет
    private string _breed;
    private bool _castrate;
    
    public string Breed => _breed;
    public bool Castrate => _castrate;

    public Cat(string name, int age, double weight, string gender,  string breed, bool castrate) : base(name, age, weight,  gender)
    {
        _breed = breed;
        _castrate = castrate;
    }
}

public class Dog : Pet
{
    //так же как у коти
    private string _breed;
    private bool _castrate;
    
    public string Breed => _breed;
    public bool Castrate => _castrate;
    
    public Dog(string name, int age, double weight, string gender, string breed, bool castrate) : base(name, age, weight, gender)
    {
        _breed = breed;
        _castrate = castrate;
    }
}

public class Rabbit: Pet
{
    //скока детей и цыет
    private int _children;
    private string _colour;
    
    public int Children => _children;
    public string Colour => _colour;

    public Rabbit(string name, int age, double weight, string gender, int children, string colour) : base(name, age, weight, gender)
    {
        _children = children;
        _colour = colour;
    }
}

