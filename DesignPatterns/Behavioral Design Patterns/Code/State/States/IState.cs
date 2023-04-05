namespace State.States;

public interface IState
{
    public void Action(Context context);
}