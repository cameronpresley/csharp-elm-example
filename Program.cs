internal class Program
{
  private static void Main(string[] args)
  {
    var startCounter = 0;
    Framework.Run(View, CounterRules.Update, startCounter);
  }

  public static Command<CommandType> View(int model)
  {
    Console.WriteLine("Counter: " + model);
    Console.WriteLine("Please enter a command:");
    Console.WriteLine("(I)ncrement, (D)ecrement, (R)eset, (Q)uit");
    var input = Console.ReadLine() ?? "";
    return ConvertStringToCommand(input);
  }

  private static Command<CommandType> ConvertStringToCommand(string s) => (s ?? "").ToLower().Trim() switch
  {
    "i" => new IncrementCommand(2),
    "d" => new DecrementCommand(1),
    "r" => new ResetCommand(),
    "q" => new QuitCommand(),
    _ => new UnknownCommand(),
  };
}