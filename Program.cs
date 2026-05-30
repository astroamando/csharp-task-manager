using System;
using System.Collections.Generic;

// This program is a simple console-based Task Manager.
// It allows the user to add tasks, view tasks, mark tasks as complete,
// delete tasks, and exit the program.

List<string> tasks = new List<string>();
List<bool> completed = new List<bool>();

bool running = true;

while (running)
{
    ShowMenu();

    Console.Write("Choose an option: ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddTask(tasks, completed);
            break;

        case "2":
            ViewTasks(tasks, completed);
            break;

        case "3":
            CompleteTask(tasks, completed);
            break;

        case "4":
            DeleteTask(tasks, completed);
            break;

        case "5":
            running = false;
            Console.WriteLine("Goodbye! Thank you for using the Task Manager.");
            break;

        default:
            Console.WriteLine("Invalid option. Please choose a number from 1 to 5.");
            break;
    }
}

// This function displays the main menu for the user.
static void ShowMenu()
{
    Console.WriteLine("\n=== TASK MANAGER ===");
    Console.WriteLine("1. Add Task");
    Console.WriteLine("2. View Tasks");
    Console.WriteLine("3. Complete Task");
    Console.WriteLine("4. Delete Task");
    Console.WriteLine("5. Exit");
}

// This function adds a new task to the task list.
static void AddTask(List<string> tasks, List<bool> completed)
{
    Console.Write("Enter a new task: ");
    string? task = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(task))
    {
        Console.WriteLine("Task cannot be empty.");
        return;
    }

    tasks.Add(task);
    completed.Add(false);

    Console.WriteLine("Task added successfully.");
}

// This function shows all tasks and their completion status.
static void ViewTasks(List<string> tasks, List<bool> completed)
{
    Console.WriteLine("\n--- TASK LIST ---");

    if (tasks.Count == 0)
    {
        Console.WriteLine("No tasks available.");
        return;
    }

    for (int i = 0; i < tasks.Count; i++)
    {
        string status = completed[i] ? "Completed" : "Not completed";
        Console.WriteLine($"{i + 1}. {tasks[i]} - {status}");
    }
}

// This function marks a task as completed without deleting it.
static void CompleteTask(List<string> tasks, List<bool> completed)
{
    ViewTasks(tasks, completed);

    if (tasks.Count == 0)
    {
        return;
    }

    Console.Write("Enter the task number to mark as complete: ");
    string? input = Console.ReadLine();

    if (int.TryParse(input, out int taskNumber))
    {
        if (taskNumber > 0 && taskNumber <= tasks.Count)
        {
            completed[taskNumber - 1] = true;
            Console.WriteLine("Task marked as completed.");
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

// This function deletes a task from the task list.
static void DeleteTask(List<string> tasks, List<bool> completed)
{
    ViewTasks(tasks, completed);

    if (tasks.Count == 0)
    {
        return;
    }

    Console.Write("Enter the task number to delete: ");
    string? input = Console.ReadLine();

    if (int.TryParse(input, out int taskNumber))
    {
        if (taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks.RemoveAt(taskNumber - 1);
            completed.RemoveAt(taskNumber - 1);
            Console.WriteLine("Task deleted successfully.");
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