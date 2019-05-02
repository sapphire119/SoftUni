namespace p00.Intro.Animals
{
    public class Bunny : Animal
    {
        public Bunny()
        {
        }

        public Bunny(string name) : base(name)
        {
        }

        public override string SayHello()
        {
            throw new System.NotImplementedException();
        }

        //public override string SayHello()
        //{
        //    throw new System.Exception();
        //}
    }
}
