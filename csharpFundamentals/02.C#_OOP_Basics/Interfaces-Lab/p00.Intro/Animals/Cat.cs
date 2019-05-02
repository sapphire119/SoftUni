namespace p00.Intro.Animals
{
    public class Cat : Animal
    {
        //Sealed означава (Който презаписвал презаписвал от тук насетне никой не може да презаписва SayHello())
        //Sealed class означава, клас който не може да се наследи (последен от веригата)

        public sealed override string SayHello()
        {
            return "Meow";
        }
    }
}
