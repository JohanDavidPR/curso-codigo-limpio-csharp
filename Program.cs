using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            int opcionSelectMenu = 0;
            do
            {
                opcionSelectMenu = ShowMainMenu();
                if (opcionSelectMenu == OPCION_MENU.Add)
                {
                    ShowMenuAdd();
                }
                else if (opcionSelectMenu == OPCION_MENU.Remove)
                {
                    ShowMenuRemove();
                }
                else if (opcionSelectMenu == OPCION_MENU.List)
                {
                    ShowMenuTaskList();
                }
            } while (opcionSelectMenu != OPCION_MENU.Exit);
        }

        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string numberOppcion = Console.ReadLine();
            return Convert.ToInt32(numberOppcion);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                PrintMenuTask();
                Console.WriteLine("----------------------------------------");

                string numberOppcion = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(numberOppcion) - 1;
                if (indexToRemove > -1 && TaskList.Count > 0)
                {
                    string task = TaskList[indexToRemove];
                    TaskList.RemoveAt(indexToRemove);
                    Console.WriteLine("Tarea " + task + " eliminada");
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                TaskList.Add(task);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            { }
        }

        public static void ShowMenuTaskList()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                Console.WriteLine("----------------------------------------");
                PrintMenuTask();
                Console.WriteLine("----------------------------------------");
            }
        }

        private static void PrintMenuTask() {
            int indexTask = 0;
            TaskList.ForEach(task => Console.WriteLine((++indexTask) + ". " + task));
        }

        private enum OPCION_MENU {
            Add = 1,
            Remove = 2,
            List = 3,
            Exit = 4
        }
    }
}
