using System;
using System.Collections.Generic;

// Create a list to store tasks
List<string> tasks = new List<string>();

bool running = true;

while (running)
{
    Console.WriteLine("\n=== TASK MANAGER ===");
    Console.WriteLine("1. Add Task");
    Console.WriteLine("2. View Tasks");
    Console.WriteLine("3. Complete Task");
    Console.WriteLine("4. Exit");

    Console.Write("Choose an option: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddTask(tasks);
            break;

        case "2":
            ViewTasks(tasks);
            break;

        case "3":
            CompleteTask(tasks);
            break;

        case "4":
            running = false;
            Console.WriteLine("Goodbye!");
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

// Function to add a task
static void AddTask(List<string> tasks)
{
    Console.Write("Enter a new task: ");
    string task = Console.ReadLine();

    tasks.Add(task);

    Console.WriteLine("Task added successfully.");
}

// Function to view all tasks
static void ViewTasks(List<string> tasks)
{
    Console.WriteLine("\n--- TASK LIST ---");

    if (tasks.Count == 0)
    {
        Console.WriteLine("No tasks available.");
        return;
    }

    for (int i = 0; i < tasks.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {tasks[i]}");
    }
}

// Function to complete and remove a task
static void CompleteTask(List<string> tasks)
{
    ViewTasks(tasks);

    if (tasks.Count == 0)
    {
        return;
    }

    Console.Write("Enter task number to remove: ");

    if (int.TryParse(Console.ReadLine(), out int taskNumber))
    {
        if (taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks.RemoveAt(taskNumber - 1);
            Console.WriteLine("Task completed and removed.");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }
    else
    {
        Console.WriteLine("Please enter a valid number.");
    }
}