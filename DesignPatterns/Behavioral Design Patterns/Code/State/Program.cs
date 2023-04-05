namespace State;

public class Program
{
    private static void Main(string[] args)
    {
        //ComplexContext context = new ComplexContext();
        Context context = new Context();
        context.Value = "Active";
        context.Action();

        context.Value = "Pause";
        context.Action();

        context.Value = "Active";
        context.Action();

        context.Value = "Terminate";
        context.Action();

        context.Value = "Pause";
        context.Action();

        context.Value = "Terminate";
        context.Action();
    }
}