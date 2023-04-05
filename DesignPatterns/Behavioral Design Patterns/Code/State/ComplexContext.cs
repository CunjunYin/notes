namespace State;
public class ComplexContext
{
    private string State = "Initial";

    public string Value
    {
        get { return State; }
        set { SetState(value); }
    }

    public ComplexContext()
    {
    }

    public void SetState(string value)
    {
        if (this.Value.Equals("Initial"))
        {
            if (value.Equals("Active"))
            {
                this.State = value;
            }
        }
        else if (this.Value.Equals("Active"))
        {
            if (value.Equals("Pause"))
            {
                this.State = value;
            }
        }
        else if (this.Value.Equals("Pause"))
        {
            if (value.Equals("Active"))
            {
                this.State = value;
            }
            else if (value.Equals("Terminate"))
            {
                this.State = value;
            }
        }
        else if (this.Value.Equals("Terminate"))
        {
            if (value.Equals("Active"))
            {
                this.State = value;
            }
        }
    }

    public void Action()
    {
        if (this.Value.Equals("Active"))
        {
            Console.WriteLine("State Activated");
        }

        if (this.Value.Equals("Pause"))
        {
            Console.WriteLine("State Paused");
        }

        if (this.Value.Equals("Terminate"))
        {
            Console.WriteLine("State Terminated");
        }
    }
}