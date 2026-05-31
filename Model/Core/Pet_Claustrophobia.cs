namespace Model.Core
{
    public abstract partial class Pet
    {
        public bool Claustrophobia { get; set; }

        protected Pet(string name, int age, double weight, string gender, bool claustrophobia)
            : this(name, age, weight, gender)
        {
            Claustrophobia = claustrophobia;
        }
    }
}