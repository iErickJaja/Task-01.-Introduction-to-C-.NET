using System;
using System.Collections.Generic;

// --- STEP 2 & 6: Constants ---
const int MaxDailyTasks = 10;
const string AppName = "Student Task Manager";

// --- STEP 5: Using simple methods ---
ShowTitle();
ShowMessage("Application started.");

// --- STEP 1: Personal Data ---
Console.WriteLine("\n--- Developer Info ---");
Console.WriteLine("Name: Erick Eduardo Macias Rodriguez");
Console.WriteLine("Favorite Programming Language: C#");
Console.WriteLine("Reason to learn .NET: To build robust, high-performance backend systems.");
Console.WriteLine("----------------------\n");

// --- STEP 2: Variables and input ---
Console.Write("Enter your name: ");
string name = Console.ReadLine() ?? "";

Console.Write("How many tasks do you want to complete today? ");
int.TryParse(Console.ReadLine(), out int taskGoal);

Console.Write("How many hours do you have available? ");
double.TryParse(Console.ReadLine(), out double availableHours);

Console.Write("Enter your age: ");
int.TryParse(Console.ReadLine(), out int studentAge);

Console.Write("Enter your course name: ");
string courseName = Console.ReadLine() ?? "";

Console.Write("Do you already know C#? (yes/no): ");
string knowsCSharpInput = Console.ReadLine() ?? "";
bool knowsCSharp = knowsCSharpInput.ToLower() == "yes";

// Printing all values using string interpolation
Console.WriteLine();
Console.WriteLine($"Hello {name}!");
Console.WriteLine($"Age: {studentAge}");
Console.WriteLine($"Course: {courseName}");
Console.WriteLine($"Already knows C#: {knowsCSharp}");
Console.WriteLine($"Your goal is {taskGoal} tasks.");
Console.WriteLine($"You have {availableHours} hours available.");
Console.WriteLine($"Application: {AppName}");
Console.WriteLine($"Maximum recommended daily tasks: {MaxDailyTasks}\n");

// --- STEP 3: if and else (completed tasks logic) ---
Console.Write("How many tasks have you completed today? ");
int.TryParse(Console.ReadLine(), out int completedTasks);

if (completedTasks == 0)
{
    Console.WriteLine("Time to get started!");
}
else if (completedTasks < 3)
{
    Console.WriteLine("Good start. Keep going!");
}
else
{
    Console.WriteLine("Great progress!");
}

// --- STEP 6: Use an enum with switch ---
Console.WriteLine("\n--- Task Priority Example ---");
TaskPriority priority = TaskPriority.High;
Console.WriteLine($"Example task priority is: {priority}");
switch (priority)
{
    case TaskPriority.Low:
        Console.WriteLine("This task can wait.");
        break;
    case TaskPriority.Medium:
        Console.WriteLine("Try to finish this task today.");
        break;
    case TaskPriority.High:
        Console.WriteLine("Prioritize this task.");
        break;
}
Console.WriteLine("-----------------------------\n");

// --- STEP 4 & 5: Lists, loops, and Methods ---
List<string> tasks = new List<string>
{
    "Review C# variables",
    "Practice loops",
    "Create a Console application"
};

bool running = true;

while (running)
{
    ShowMenu();
    Console.Write("Choose an option: ");
    int.TryParse(Console.ReadLine(), out int option);

    switch (option)
    {
        case 1:
            AddTask(tasks, MaxDailyTasks);
            break;

        case 2:
            ShowTasks(tasks);
            break;

        case 3:
            RemoveTask(tasks);
            break;

        case 4:
            ShowTaskCount(tasks, MaxDailyTasks);
            break;

        case 0:
            running = false;
            Console.WriteLine("Goodbye!");
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}


// ==========================================
//                 METHODS
// ==========================================

void ShowTitle()
{
    Console.WriteLine("Student Task Manager");
    Console.WriteLine("====================");
}

void ShowMessage(string message)
{
    Console.WriteLine($"[INFO] {message}");
}

void ShowMenu()
{
    Console.WriteLine();
    Console.WriteLine("1. Add task");
    Console.WriteLine("2. View tasks");
    Console.WriteLine("3. Remove task");
    Console.WriteLine("4. Show task count"); // From Step 6
    Console.WriteLine("0. Exit");
}

int GetTaskCount(List<string> taskList)
{
    return taskList.Count;
}

void ShowTasks(List<string> taskList)
{
    if (taskList.Count == 0)
    {
        Console.WriteLine("No tasks available.");
        return;
    }

    for (int i = 0; i < taskList.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {taskList[i]}");
    }
}

void AddTask(List<string> taskList, int maxLimit)
{
    // Step 6: Constant check
    if (taskList.Count >= maxLimit)
    {
        Console.WriteLine("Maximum number of tasks reached.");
        return;
    }

    Console.Write("Enter task: ");
    string newTask = Console.ReadLine() ?? "";
    taskList.Add(newTask);
    ShowMessage("Task added."); // Using the method from Step 5
}

void RemoveTask(List<string> taskList)
{
    ShowTasks(taskList);
    Console.Write("\nTask to remove: ");
    if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= taskList.Count)
    {
        taskList.RemoveAt(index - 1);
        ShowMessage("Task removed successfully.");
    }
    else
    {
        Console.WriteLine("Invalid task number.");
    }
}

void ShowTaskCount(List<string> taskList, int maxLimit)
{
    // Step 5 & 6 combo: GetTaskCount method usage
    int currentTasks = GetTaskCount(taskList); 
    Console.WriteLine($"You currently have {currentTasks} tasks.");
    Console.WriteLine($"Maximum allowed: {maxLimit}");
    Console.WriteLine($"Remaining capacity: {maxLimit - currentTasks}");
}

// ==========================================
//                  ENUMS
// ==========================================

// Step 6: Enum creation
enum TaskPriority
{
    Low,
    Medium,
    High
}