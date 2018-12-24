using System;

namespace Sample.DesignPatterns._01Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            MallardDuck mallardDuck = new MallardDuck();
            mallardDuck.Display();
            mallardDuck.Quack();
            mallardDuck.Swim();

            RubberDuck rubberDuck = new RubberDuck();
            rubberDuck.Display();
            rubberDuck.Quack();
            rubberDuck.Fly();
        }
    }
    public abstract class Duck
    {
        public void Quack()
        {
            // 所有的鸭子都会呱呱叫，由Duck类负责实现
            Console.WriteLine("呱呱叫...");
        }
        public void Swim()
        {
            // 所有鸭子都会游泳，由Duck类负责实现
            Console.WriteLine("游泳中...");
        }
        public void Fly()
        {
            // 部分鸭子会飞
            Console.WriteLine("飞行中...");
        }
        public abstract void Display();    // 每个鸭子的子类负责实现自己的display
    }
    public class MallardDuck : Duck
    {
        public override void Display()
        {
            Console.WriteLine("我是绿头鸭.");
        }
    }
    public class RedheadDuck : Duck
    {
        public override void Display()
        {
            Console.WriteLine("我是红头鸭子.");
        }
    }
    public class RubberDuck : Duck
    {
        public new void Quack()
        {
            Console.WriteLine("吱吱叫...");
        }
        public override void Display()
        {
            Console.WriteLine("我是橡皮鸭子.");
        }
    }
}
