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
                string input = Console.ReadLine().Trim();

                if (input == "")
                    continue;

                var items = input.Split();
                List list1 = StringArrayToItem(items);
                List list2 = StringArrayToItem(items);

                Console.WriteLine("Iterative Reverse: ");
                PrintList(Reverse(list1));

                Console.WriteLine("Recursive Reverse: ");
                PrintList(ReverseRecursion(list2));

                Console.WriteLine();
            }
        }

        static List Reverse(List list)
        {
            if (list == null || list.next == null)
            {
                return list;
            }

            
            var curr = list;
            List prev = null;
            while (curr != null)
            {
                List next;
                next = curr.next;
                curr.next = prev;

                prev = curr;
                curr = next;
            }
            return prev;
        }

        static List ReverseRecursion(List list)
        {
            if (list == null)
                return null;
            if (list.next == null)
                return list;

            var next = list.next;
            list.next = null;
            var tail = ReverseRecursion(next);
            next.next = list;
            return tail;
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
