using System;
using System.Linq;

namespace Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите значения информационных полей элементов списка через пробел: ");
                string input = Console.ReadLine();

                var items = input.Split();
                List list = StringArrayToItem(items);

                Console.WriteLine("ReverseData: ");
                PrintList(ReverseData(list));

                Console.WriteLine("ReverseDataRecursion: ");
                PrintList(ReverseDataRecursion(list));

                Console.WriteLine("Map: ");
                PrintList(list.map(s => new string(s.Reverse().ToArray())));

                Console.WriteLine();
            }
        }

        static List ReverseData(List list)
        {
            var currentList = list;
            var headItem = new List(new string(currentList.data.Reverse().ToArray()));
            var newItem = headItem;

            while (currentList.next != null)
            {
                currentList = currentList.next;
                newItem.next = new List(new string(currentList.data.Reverse().ToArray()));
                newItem = newItem.next;
            }

            return headItem;
        }

        static List ReverseDataRecursion(List list)
        {
            List newList = new List(new string(list.data.Reverse().ToArray()));
            if (list.next != null)
                newList.next = ReverseDataRecursion(list.next);
            return newList;
        }

        static List StringArrayToItem(string[] items)
        {
            List newList = new List(items.First());
            if (items.Length > 1)
                newList.next = StringArrayToItem(items.Skip(1).ToArray());
            return newList;
        }

        static void PrintList(List list)
        {
            if (list == null)
                Console.WriteLine("null");
            else
            {
                Console.Write($"{list.data}->");
                PrintList(list.next);
            }
        }
    }
}
