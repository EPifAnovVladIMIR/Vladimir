using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IDKWHYUSTCMT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = Convert.ToInt32(Console.ReadLine());


            ElementsControl elementsControl = new ElementsControl(size);

            elementsControl.Fill();



        }
    }

    public class Elements
    {
        public string Name;
        public int Age;
        public string Surname;
        public int birth;

        public Elements(string Name, int Age, string Surname, int birth) // Тип для хранения данных
        {
            this.Name = Name;
            this.Age = Age;
            this.Surname = Surname;
            this.birth = birth;
        }
    }


    public class ElementsControl
    {
        // Хранение массива, сортировки и вывода в файл. Работает с классом PrintToFile

        int Elements;
        public Elements[] FullInfo;


        public ElementsControl(int FullInfos)
        {
            this.Elements = FullInfos;
            FullInfo = new Elements[FullInfos];
        }


        public void Fill() // Функция диаологового заполнения
        {
            string Name;
            int Age;
            string Surname;
            int birth;


            for (int i = 0; i < this.Elements; i++)
            {

                Console.WriteLine("Введите имя:");
                Name = Console.ReadLine();
                Console.WriteLine("Введите фамилию:");
                Surname = Console.ReadLine();
                Console.WriteLine("Введите день рождения:");
                birth = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите сколько лет:");
                Age = Convert.ToInt32(Console.ReadLine());
                this.FullInfo[i] = new Elements(Name, Age, Surname, birth);
            }

        }

        public void ViewPersons()
        {
            foreach (Elements person in FullInfo)
                Console.WriteLine($"Фамилия: {person.Surname} Имя: {person.Name} Возраст: {person.Age} День рождения {person.birth}");
        }



        public void Sort() => Array.Sort(FullInfo, (x, y) => (x.Surname + " " + x.Name).CompareTo(y.Surname + " " + y.Name));



        public void Save()
        {
            string path = $"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\Persons.txt";
            using (StreamWriter writer = new StreamWriter(File.Open(path, FileMode.Create)))
            {
                foreach (Elements person in FullInfo)
                    Console.WriteLine($"Фамилия: {person.Surname} Имя: {person.Name} Возраст: {person.Age} День рождения {person.birth}");
            }
        }
    }
}
        


