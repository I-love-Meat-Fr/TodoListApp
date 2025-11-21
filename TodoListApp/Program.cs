using TodoListApp.Services;

var service = new TaskService();

while (true)
{
    Console.WriteLine("\n=== TODO LIST ===");
    Console.WriteLine("1. Add Task");
    Console.WriteLine("2. Delete Task");
    Console.WriteLine("3. Show Tasks");
    Console.WriteLine("4. Exit");
    Console.Write("Choose: ");

    var choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            Console.Write("Enter task: ");
            service.AddTask(Console.ReadLine());
            break;

        case "2":
            Console.Write("Enter ID to delete: ");
            service.DeleteTask(int.Parse(Console.ReadLine()));
            break;

        case "3":
            var tasks = service.GetTasks();
            Console.WriteLine("\nCurrent tasks:");
            foreach (var t in tasks)
                Console.WriteLine($"{t.Id}. {t.Title} | Done: {t.IsDone}");
            break;

        case "4":
            return;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

//using System;
//string filePath = "Data/task.txt";

//if (File.Exists(filePath))
//{
//    File.Delete(filePath);
//    Console.WriteLine("File đã được xóa.");
//}
//else
//{
//    Console.WriteLine("File không tồn tại.");
//}