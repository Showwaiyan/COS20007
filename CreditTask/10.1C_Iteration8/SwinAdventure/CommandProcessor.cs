namespace SwinAdventure
{
  public class CommandProcessor
  {
    private List<Command> _commands;

    public CommandProcessor() 
    {
      _commands = new List<Command>();
    }

    public void AddCommand(Command command)
    {
      _commands.Add(command);
    }

    public string Execute(Player p,string input)
    {
      string[] inputArr = input.Split(' ');
      foreach (Command command in _commands)
      {
        if (command.AreYou(inputArr[0])) return command.Execute(p,inputArr);
      }
      return $"I don\'t understand {inputArr[0]}";
    }
  }
}
