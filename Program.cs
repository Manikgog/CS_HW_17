using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_HW_17
{
    public delegate void Action(Flower flower);
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Задание: Система контроля за ростом цветов

            Тебе предстоит разработать систему, которая будет контролировать рост и состояние различных цветов. 
            Твоя программа должна иметь следующие возможности:

            Создание и управление цветами:

            Разработай класс "Flower" с полями для имени цветка, его высоты и уровня здоровья.
            Реализуй методы для увеличения высоты и изменения уровня здоровья цветка.
            Создай несколько цветов по умолчанию и добавь их в коллекцию.
            Интерфейс для отображения информации о цветках:

            Создай интерфейс с методом для отображения информации о цветке.
            Реализуй этот интерфейс в классе "Flower", чтобы можно было получать информацию о каждом цветке.
            Использование делегатов и лямбда-выражений:

            Создай делегат "Action" для выполнения операций с цветками, таких как полив или удобрение.
            Реализуй лямбда-выражения, чтобы выполнять эти операции над цветками.
            Обработка событий:

            Создай класс "Garden", который будет представлять собой сад с различными цветами.
            Реализуй событие "FlowerGrowthEvent", которое будет возникать при изменении высоты цветка.
            При возникновении события FlowerGrowthEvent, программа должна выводить сообщение о новой высоте цветка.
            Использование LINQ:

            Реализуй методы для фильтрации и сортировки цветов с использованием LINQ.
            Например, создай методы для отображения только цветов с высотой больше заданного значения или для сортировки цветов по уровню здоровья.
            Сохранение данных в формате JSON/XML:

            Реализуй методы для сохранения и загрузки информации о цветках в форматах JSON и XML.
            Данные о цветках должны сохраняться в файл и загружаться из файла при запуске программы.*/

            string path_input_json = "C:\\Users\\Maksim\\source\\repos\\CS_HW_17\\input_garden.json";
            string path_output_json = "C:\\Users\\Maksim\\source\\repos\\CS_HW_17\\output_garden.json";
            string path_input_xml = "C:\\Users\\Maksim\\source\\repos\\CS_HW_17\\input_garden.xml";
            string path_output_xml = "C:\\Users\\Maksim\\source\\repos\\CS_HW_17\\output_garden.xml";
            Garden garden = new Garden();
            //garden.ReadJsonFile(path_input_json);
            garden.ReadXMLFile(path_input_xml);
            //Flower flower = new Flower("пион", 30, 70);
            //garden.Add(flower);
            //garden.Add(new Flower("акация", 40, 56));
            //garden.Add(new Flower("гвоздика", 30, 45));
            //garden.Add(new Flower("гиацинт", 34, 70));
            //garden.Add(new Flower("тюльпан", 34, 75));
            //garden.Add(new Flower("мальва", 27, 60));
            //garden.Add(new Flower("флокс", 25, 65));



            Action watering = (Flower f) => { f.Height = f.Height + 1;  
                f.FlowerGrowthEvent += f.FlowerGrowthEventHandler(); };

            Action firtilizing = (Flower f) => { f.HealthLevel++;
                f.FlowerHealthLevelEvent += f.FlowerHealthEventHendler();
            };

            for (int i = 0; i < garden.Count(); i++)
            {
                garden[i].PrintInfo();
                
            }

            Console.WriteLine("+++++++++++++++++++++++++++++| Поливаем цветы |+++++++++++++++++++++++++++++++++");
            for (int i = 0; i < garden.Count(); i++)
            {
                
                watering(garden[i]);
                
                garden[i].PrintInfo();
            }
            Console.WriteLine("+++++++++++++++++++++++++++++++| Удобряем цветы |+++++++++++++++++++++++++++++++");
            for (int i = 0; i < garden.Count(); i++)
            {

                firtilizing(garden[i]);

                garden[i].PrintInfo();
            }
            Console.WriteLine("+++++++++++++++++++++++++++++++| Печатаем цветы с высотой 40 и более см |+++++++++++++++++++++++++++++++");
            garden.PrintFlowerByHeight(40);
            Console.WriteLine("+++++++++++++++++++++++++++++++| Сортировка списка цветов по уровню здоровья |+++++++++++++++++++++++++++++++");
            garden.SortByHealthLevel();
            for(int i = 0; i < garden.Count(); i++)
            {
                Console.WriteLine(garden[i].ToString());
            }

            //garden.WriteToJsonFile(path_output_json);
            garden.WriteToXMLFile(path_input_xml);
        }
    }
}
