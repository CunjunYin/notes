public abstract class Component
{
    protected string State;
    public abstract string Operation();
}

public class ConcreteComponent : Component
{
    public override string Operation()
    {
        State = "BaseComponent";
        return this.State;
    }
}

public abstract class Decorator : Component
{
    protected Component component;

    public Decorator(Component component)
    {
        this.component = component;
    }

    public void SetComponent(Component component)
    {
        this.component = component;
    }

    public override string Operation()
    {
        if (this.component != null)
        {
            this.State = this.component.Operation();
            return this.State;
        }
        return string.Empty;
    }
}

public class ConcreteDecorator : Decorator
{
    public ConcreteDecorator(Component component) : base(component)
    {
    }

    public override string Operation()
    {
        base.Operation();
        AdditionalFunctionality();
        return this.State;
    }

    public void AdditionalFunctionality()
    {
        this.State += "-> Concrete Decorator:AdditionalFunctionality()";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var component = new ConcreteComponent();
        Console.WriteLine(component.Operation());

        var decortor = new ConcreteDecorator(component);
        Console.WriteLine(decortor.Operation());
    }
}