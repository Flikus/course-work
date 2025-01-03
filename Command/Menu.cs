class Menu
{
    public string NameCommand() { return "help"; }
    public void Command(List<ICommand> listCommand)
    {
        for(int i = 0; i < listCommand.Count(); i++)
        {
           Console.WriteLine(listCommand[i].NameCommand() + listCommand[i].DescriptionCommand()); 
        }

        Console.WriteLine("ESC - завершити виконанння поточної команди");
        Console.WriteLine("exit  - завершити виконанння програми");
    }
}