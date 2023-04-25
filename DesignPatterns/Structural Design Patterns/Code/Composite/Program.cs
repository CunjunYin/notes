// This is the abstract base class that defines the interface for both leaf and composite objects.
public abstract class Component
{
    protected string name;
    protected bool IsLeaf = false;

    public Component(string name)
    {
        this.name = name;
    }

    public abstract string Operation();

    public virtual void Add(Component component)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(Component component)
    {
        throw new NotImplementedException();
    }
}

// This is the concrete class that represents a group of elements in the tree structure.
// It contains a collection of child components, which can be either leaf or composite objects.
public class Composite : Component
{
    protected List<Component> Children = new List<Component>();

    public Composite(string name) : base(name)
    {
    }

    public override void Add(Component component)
    {
        Children.Add(component);
    }

    public override void Remove(Component component)
    {
        Children.Remove(component);
    }

    public override string Operation()
    {
        return $"Composite: {name}";
    }
}

// This is the concrete class that represents a single element in the tree structure.
public class Leaf : Component
{
    public Leaf(string name) : base(name)
    {
        IsLeaf = true;
    }

    public override string Operation()
    {
        return $"Leaf: {name}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var root = new Composite("Root");
        root.Add(new Leaf("Leaf A"));
        root.Add(new Leaf("Leaf B"));

        var composite = new Composite("composite");
        root.Add(new Leaf("Composite Leaf A"));
        root.Add(new Leaf("Composite Leaf B"));

        root.Add(composite);
    }
}