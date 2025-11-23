public static class CounterRules
{
  public static int Update(int model, Command<CommandType> c)
  {
    return c.Tag switch
    {
      CommandType.Increment => model + (c as IncrementCommand)!.Value,
      CommandType.Decrement => model - (c as DecrementCommand)!.Value,
      CommandType.Reset => 0,
      CommandType.Quit => model,
      CommandType.Unknown => model,
      _ => model
    };
  }
}