using State.States;

namespace State;

public class Context
{
    private IState State;
    public string Value = "Initial";

    public Context()
    {
        this.State = new StateActive();
    }

    public void SetState(IState state)
    {
        this.State = state;
    }

    public void Action()
    {
        if (State == null)
        {
            Console.WriteLine("State not avtivated");
        }
        this.State?.Action(this);
    }
}