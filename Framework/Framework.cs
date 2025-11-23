public abstract class Command<T> where T : Enum
{
  public abstract T Tag { get; }
}

public static class Framework
{
  public static void Run<TModel, TCommandType>(
      Func<TModel, Command<TCommandType>> view,
      Func<TModel, Command<TCommandType>, TModel> update,
      TModel model)
  where TCommandType : Enum
  {
    if (!Enum.IsDefined(typeof(TCommandType), "Quit"))
    {
      throw new InvalidOperationException("Command must have a Quit option");
    }
    var quitCommand = Enum.Parse(typeof(TCommandType), "Quit");

    var currentModel = model;
    Command<TCommandType> command;

    do
    {
      Console.Clear();
      command = view(currentModel);
      currentModel = update(currentModel, command);
    } while (!command.Tag.Equals(quitCommand));
  }
}