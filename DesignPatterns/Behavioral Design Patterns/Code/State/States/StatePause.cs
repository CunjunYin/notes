namespace State.States;

public class StatePause: IState
{
    public void Action(Context context)
    {
        if (context.Value.Equals("Pause"))
        {
            Console.WriteLine("State paused");
        }
        else if (context.Value.Equals("Active"))
        {
            context.SetState(new StateActive());
            context.Action();
        }
        else if (context.Value.Equals("Terminate"))
        {
            context.SetState(new StateTerminate());
            context.Action();
        }
    }
}