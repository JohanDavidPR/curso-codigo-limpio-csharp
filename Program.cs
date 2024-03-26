namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; } = new List<string>();

        static void Main(string[] args)
        { 
            int opcionSelectMenu = 0;
            do
            {
                opcionSelectMenu = ShowMainMenu();
                switch(opcionSelectMenu) {
                    case OPCION_MENU.Add:
                        ShowMenuAdd();
                        break;
                    case OPCION_MENU.Remove:
                        ShowMenuRemove();
                        break;
                    case OPCION_MENU.List:
                        ShowMenuTaskList();
                        break;
                }
            } while (opcionSelectMenu != OPCION_MENU.Exit);
        }

        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            string numberOpcion = Console.ReadLine();
            return Convert.ToInt32(numberOpcion);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                PrintMenuTask();
                Console.WriteLine("----------------------------------------");

                string numberOpcion = Console.ReadLine();
                
                int indexToRemove = Convert.ToInt32(numberOpcion) - 1;

                if(indexToRemove > TaskList.Count || indexToRemove < 0) {
                    Console.WriteLine("La tarea no existe");
                }
                else {
                    string task = TaskList[indexToRemove];
                    TaskList.RemoveAt(indexToRemove);
                    Console.WriteLine($"Tarea {task} eliminada");
                }                
            }
            catch (Exception)
            {
                Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
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
            {
                Console.WriteLine("Ha ocurrido un error al agregar la tarea");
            }
        }

        public static void ShowMenuTaskList()
        {
            if (TaskList?.Count > 0)
            {
                Console.WriteLine("----------------------------------------");
                PrintMenuTask();
                Console.WriteLine("----------------------------------------");
            } 
            else Console.WriteLine("No hay tareas por realizar");
        }

        private static void PrintMenuTask() {
            int indexTask = 0;
            TaskList?.ForEach(task => Console.WriteLine($"{++indexTask}. {task}"));
        }

        private enum OPCION_MENU {
            Add = 1,
            Remove = 2,
            List = 3,
            Exit = 4
        }
    }
}
