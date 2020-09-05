using System;
using TODO_lib.Controller;

namespace TODO_cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("\t Текущие задачи:");
                TaskController tc = new TaskController();
                Console.WriteLine("-------------------------------------");
                for (int i = 0; i < tc.Tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}\t" + tc.Tasks[i].Status + " \t " + tc.Tasks[i].String);
                }
                Console.WriteLine("-------------------------------------");

                Console.WriteLine("\t Добавить задачу? (1)");
                Console.WriteLine("\t Изменить стутус? (2)");
                Console.WriteLine("\t Удалить задачу? (3)");

                int aChoose = 0;
                int k = 0;
                if (Int32.TryParse(Console.ReadLine(), out aChoose))
                {                  
                    switch (aChoose)
                    {
                        case 1:
                            Console.WriteLine("Вводи задачу");
                            tc = new TaskController(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("Вводи номер задачи");
                            Int32.TryParse(Console.ReadLine(), out k);
                            tc.ChangeStatus(k - 1);
                            break;
                        case 3:
                            Console.WriteLine("Вводи номер задачи");
                            Int32.TryParse(Console.ReadLine(), out k);
                            tc.RemoveTask(k - 1);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный формат ввода или такого действия не существует");
                    Console.WriteLine("Для продолжения жми любую кнопку");
                    Console.ReadKey();
                }
            }
            //Console.ReadKey();
        }
    }
}