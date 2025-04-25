using System.CommandLine;
using System.CommandLine.Invocation;
using task_cli.CLI;
TaskManager manager = new TaskManager();

var rootCommand = new RootCommand("Task CLI Line");

//Descripciones de los comandos generales
var descAddArgument = new Argument<string>("tarea", "Add a new task");
var descDeleteArgument = new Argument<int>("id", "Delete a task");
var descUpdateArgument = new Argument<int>("id", "Update a task by id");

//Marks
var deskMarkDoneArgument = new Argument<int>("id", "Mark a task as done");
var descMarkProgressArgument = new Argument<int>("id", "Mark a task as in-progress");
var descMarkTodoArgument = new Argument<int>("id", "Mark a task as todo");

//List Options task
var doneOption = new Option<bool>("--done", "List task by status done");
var inProgressOption = new Option<bool>("--in-progress", "List task by status in-progress");
var todoOption = new Option<bool>("--todo", "List task by status todo");
var allOption = new Option<bool>("--all", "List all tasks");



//Comandos de la CLI
var addTask = new Command("add", "Add a new task");
var deleteTask = new Command("delete", "Delete a task by id");
var updateTask = new Command("update", "Update a task by id");
var listTask = new Command("list", "List tasks by status:\n" +
                                   "  --done          Show completed tasks\n" +
                                   "  --in-progress   Show tasks in progress\n" +
                                   "  --todo   Show tasks in progress\n" +
                                   "  --all           Show all tasks");
var markDoneTask = new Command("mark-done", "Mark a task as done");
var markInProgressTask = new Command("mark-in-progress", "Mark a task as in-progress");
var markTodoTask = new Command("mark-todo", "Mark a task as todo");


//Comando List
listTask.AddOption(doneOption);
listTask.AddOption(inProgressOption);
listTask.AddOption(todoOption);
listTask.AddOption(allOption);

//Agregar las descripciones a los comandos
addTask.AddArgument(descAddArgument);
deleteTask.AddArgument(descDeleteArgument);
updateTask.AddArgument(descUpdateArgument);

addTask.SetHandler(async (string description) =>
{
    await manager.InitializeId();
    await manager.AddTask(description);
}, descAddArgument);

deleteTask.SetHandler(async (int id) =>
{
    await manager.DeleteTask(id);
}, descDeleteArgument);

updateTask.SetHandler(async (int id) =>
{
    await manager.DeleteTask(id);
}, descUpdateArgument);

markDoneTask.SetHandler(async (int id) =>
{
    await manager.MarkDoneTask(id);
}, deskMarkDoneArgument);

markInProgressTask.SetHandler(async (int id) =>
{
    await manager.MarkInProgressTask(id);
}, descMarkProgressArgument);
markTodoTask.SetHandler(async (int id) =>
{
    await manager.MarkTodoTask(id);
}, descMarkTodoArgument);

listTask.SetHandler(async (bool done, bool inProgress, bool todo, bool all) =>
{
    if (done)
    {
        await manager.ListAllTask("done");
    }
    else if (inProgress)
    {
        await manager.ListAllTask("in-progress");
    }
    else if (todo)
    {
        await manager.ListAllTask("todo");
    }
    else if (all)
    {
        await manager.ListAllTask();
    }
    else
    {
        Console.WriteLine("Especifica un filtro: --done, --in-progress, --todo o --all");
    }
}, doneOption, inProgressOption,todoOption, allOption);

rootCommand.AddCommand(addTask);
rootCommand.AddCommand(deleteTask);
rootCommand.AddCommand(updateTask);
rootCommand.AddCommand(listTask);
//Ejecutar la CLI
string[] arg = { "add", "Pizza 2" };
await rootCommand.InvokeAsync(arg);