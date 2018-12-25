using System;

namespace Sample.DesignPatterns._01Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            Duck mallardDuck = new MallardDuck();
            mallardDuck.Display();
            mallardDuck.performQuack();
            mallardDuck.performFly();
            mallardDuck.Swim();

            Duck modelDuck = new ModelDuck();
            modelDuck.Display();
            modelDuck.performFly();
            modelDuck.SetFlyBehavior(new FlyRocketPowered());
            modelDuck.performFly();
        }
    }

    #region 飞行接口及实现类
    public interface FlyBehavior
    {
        void Fly();
    }
    public class FlyWithWings : FlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying");
        }
    }
    public class FlyNoWay : FlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I can't fly");
        }
    }
    public class FlyRocketPowered : FlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying with a rocket!");
        }
    }
    #endregion

    #region 叫声行为接口及实现类
    public interface QuackBehavior
    {
        void Quack();
    }
    public class CommonQuack : QuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("quack");
        }
    }
    public class MuteQuack : QuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("silence");
        }
    }
    public class Squeak : QuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("squeak");
        }
    }
    #endregion

    public abstract class Duck
    {
        protected FlyBehavior flyBehavior;
        protected QuackBehavior quackBehavior;

        public Duck()
        {
        }

        public abstract void Display();

        public void performFly()
        {
            flyBehavior.Fly();
        }
        public void performQuack()
        {
            quackBehavior.Quack();
        }
        public void Swim()
        {
            Console.WriteLine("swiming");
        }

        public void SetFlyBehavior(FlyBehavior fb)
        {
            flyBehavior = fb;
        }
        public void SetQuackBehavior(QuackBehavior qb)
        {
            quackBehavior = qb;
        }
    }

    public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            flyBehavior = new FlyWithWings();
            quackBehavior = new CommonQuack();
        }
        public override void Display()
        {
            Console.WriteLine("I'm a real Mallard duck");
        }
    }

    public class ModelDuck : Duck
    {
        public ModelDuck()
        {
            flyBehavior = new FlyNoWay();
            quackBehavior = new CommonQuack();
        }

        public override void Display()
        {
            Console.WriteLine("I'm a model duck");
        }
    }
}
