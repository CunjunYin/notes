namespace State.States;

public class StateActive : IState
{
    public void Action(Context context)
    {
        if (context.Value.Equals("Pause"))
        {
            context.SetState(new StatePause());
            context.Action();
        }
        else
        {
            Console.WriteLine("State Activated");
        }
    }
}