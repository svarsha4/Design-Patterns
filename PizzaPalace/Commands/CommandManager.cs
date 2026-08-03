namespace PizzaPalace.Commands;

public class CommandManager
{
    private readonly Stack<ICommand> _history = new();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _history.Push(command);
    }

    public void UndoLastCommand()
    {
        if (_history.Count == 0)
        {
            Console.WriteLine("Nothing to undo.");
            return;
        }

        var lastCommand = _history.Pop();
        lastCommand.Undo();
    }
}