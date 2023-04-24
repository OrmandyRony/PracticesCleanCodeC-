List<string> TaskList = new List<string>();


int menuSelected = 0;
do
{
    menuSelected = ShowMainMenu();
    if ((Menu)menuSelected == Menu.Add)
    {
        ShowMenuAdd();
    }
    else if ((Menu)menuSelected == Menu.Remove)
    {
        ShowMenuRemove();
    }
    else if ((Menu)menuSelected == Menu.List)
    {
        ShowMenuTaskList();
    }
} while ((Menu)menuSelected != Menu.Exit);

int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    string option = Console.ReadLine();
    return Convert.ToInt32(option);
}


void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        ShowMenuTaskList();

        string numberTaskRemove = Console.ReadLine();

        // Remove one position because the array starts in 0
        int indexToRemove = Convert.ToInt32(numberTaskRemove) - 1;
        if (indexToRemove > -1 && TaskList.Count > 0 && indexToRemove < TaskList.Count)
        {
            string taskToRemove = TaskList[indexToRemove];
            TaskList.RemoveAt(indexToRemove);
            Console.WriteLine($"Tarea {taskToRemove} eliminada");

        }
        else
        {
            Console.WriteLine("Numero de tarea invalido");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
        // para el desarrolladorex.Message;
    }
}

/// Muestra el mensaje para agregar una tarea
void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string newTask = Console.ReadLine();
        if (newTask.Length > 0)
        {
            TaskList.Add(newTask);
            Console.WriteLine("Tarea registrada");
        }
        else
        {
            Console.WriteLine("Tarea vacia, no se puede ingresar.");
        }

    }
    catch (Exception ex)
    {
        throw ex;
    }
}

void ShowMenuTaskList()
{
    if (TaskList?.Count > 0)
    {
        Console.WriteLine("----------------------------------------");
        var indexTask = 1;
        TaskList.ForEach(task => Console.WriteLine($"{indexTask++} .  {task}"));

        Console.WriteLine("----------------------------------------");
    }
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}




public enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}
