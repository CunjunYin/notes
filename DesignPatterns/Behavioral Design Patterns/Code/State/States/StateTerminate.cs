namespace State.States;

public class StateTerminate : IState
{
    public void Action(Context context)
    {

        if (context.Value.Equals("active"))
        {
            context.SetState(new StateActive());
            context.Action();
        }
        else
        {
            Console.WriteLine("State Terminated");
        }
    }
}