using System;

namespace DellChallenge.B
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given the classes and interface below, please constructor the proper hierarchy.
            // Feel free to refactor and restructure the classes/interface below.
            // (Hint: Not all species and Fly and/or Swim)
        }
    }

    public interface ISpecies
    {
        void Eat();
        void Drink();
    }

    public interface ICanFly
    {
        void Fly();
    }

    public interface ICanSwim
    {
        void Swim();
    }

    public abstract class Species : ISpecies
    {
        public abstract void Drink();

        public abstract void Eat();

        public virtual void GetSpecies()
        {
            Console.Write($"I am a ");
        }
    }

    public class Human : Species
    {
        public override void Drink()
        {
            Console.WriteLine("I drink ginger beer.");
        }

        public override void Eat()
        {
            Console.WriteLine("I eat spaghetti.");
        }

        public override void GetSpecies()
        {
            base.GetSpecies();
            Console.WriteLine("human.");
        }
    }

    public class Bird : Species, ICanFly
    {
        public override void Drink()
        {
            Console.WriteLine("I drink water when I find it.");
        }

        public override void Eat()
        {
            Console.WriteLine("I eat insects.");
        }

        public void Fly()
        {
            Console.WriteLine("I can flyyyyyyy!");
        }

        public override void GetSpecies()
        {
            base.GetSpecies();
            Console.WriteLine("bird.");
        }
    }

    public class Fish : Species, ICanSwim
    {
        public override void Drink()
        {
            Console.WriteLine("I drink water.");
        }

        public override void Eat()
        {
            Console.WriteLine("I eat smaller fishes.");
        }

        public void Swim()
        {
            Console.WriteLine("I can swimmmmm!");
        }

        public override void GetSpecies()
        {
            base.GetSpecies();
            Console.WriteLine("fish.");
        }
    }
}