namespace p00.Intro.Animals
{
    public abstract class Animal
    {
        //Един абстактен клас може да има конструктор и
        //Абстрактни методи.

        //констана никой не може да я променя
        private const int NumberOfEyes = 2;

        //Ако е readonly някоя променлива онзача,че конструктора МОЖЕ да я променя.
        private readonly int NumberOfLegs = 4;

        public Animal() { }

        public Animal(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        //Може и да е виртуален метода SayHello(), ако ни е нужна някаква обща имплементация, която след това да допълним.
        //public virtual string SayHello()
        //{
        //    return "Hi my name is: ";
        //}
        public abstract string SayHello();
    }
}
