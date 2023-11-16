using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_HW_17
{
    public class Flower : IGetFlowerInformation, IComparable<Flower>
    {
        public event Action FlowerGrowthEvent;
        public event Action FlowerHealthLevelEvent;
        public string Name { get; set; }
        public int Height { get; set; }
        public int HealthLevel { get; set; }

        public Flower() { }
        public Flower(string name, int height, int healthLevel) { 
            Name = name;
            Height = height;
            HealthLevel = healthLevel;
        }

       

        public override string ToString()
        {
            return "Название цветка: " + Name +
                    "; Высота: " + Height +
                    "; Уровень здоровья: " + HealthLevel; 
        }

        public void PrintInfo()
        {
            Console.WriteLine(this.ToString());
        }

       
        public Action FlowerGrowthEventHandler()
        {
            Console.WriteLine("Цветок - " + Name + " вырос, его высота - " + Height + " см.");
            return null;
        }

        public Action FlowerHealthEventHendler()
        {
            Console.WriteLine("Уровень здоровья цветка - " + Name + " повысился - " + HealthLevel + ".");
            return null;
        }

       
        public int CompareTo(Flower obj)
        {
           return HealthLevel.CompareTo(obj.HealthLevel);
        }
    }
}
