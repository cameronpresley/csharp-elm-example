public enum CommandType
{
  Increment,
  Decrement,
  Reset,
  Quit,
  Unknown
}

public class IncrementCommand : Command<CommandType>
{
  public override CommandType Tag => CommandType.Increment;
  public int Value { get; init; }
  public IncrementCommand(int value)
  {
    Value = value;
  }
}

public class DecrementCommand : Command<CommandType>
{
  public override CommandType Tag => CommandType.Decrement;
  public int Value { get; init; }
  public DecrementCommand(int value)
  {
    Value = value;
  }
}

public class ResetCommand : Command<CommandType>
{
  public override CommandType Tag => CommandType.Reset;
}

public sealed class QuitCommand : Command<CommandType>
{
  public override CommandType Tag => CommandType.Quit;
}

public sealed class UnknownCommand : Command<CommandType>
{
  public override CommandType Tag => CommandType.Unknown;
}