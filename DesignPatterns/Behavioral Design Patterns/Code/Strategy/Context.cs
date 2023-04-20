namespace Strategy;

public class Context
{
    private IStrategy strategy { get; set; }

    public Context()
    { }

    public void SetStrategy(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void ExecuteStrategy()
    {
        this.strategy.Algorithm();
    }
}