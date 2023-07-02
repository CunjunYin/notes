namespace AutoMapperDemo.Models;

public class FlatteningOrder
{
    private readonly IList<FlatteningOrderLineItem> _orderLineItems = new List<FlatteningOrderLineItem>();

    public FlatteningCustomer Customer { get; set; }

    public FlatteningOrderLineItem[] GetOrderLineItems()
    {
        return _orderLineItems.ToArray();
    }

    public void AddOrderLineItem(FlatteningProduct product, int quantity)
    {
        _orderLineItems.Add(new FlatteningOrderLineItem(product, quantity));
    }

    public decimal GetTotal()
    {
        return _orderLineItems.Sum(li => li.GetTotal());
    }
}

public class FlatteningProduct
{
    public decimal Price { get; set; }
    public string Name { get; set; }
}

public class FlatteningOrderLineItem
{
    public FlatteningOrderLineItem(FlatteningProduct product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public FlatteningProduct Product { get; private set; }
    public int Quantity { get; private set; }

    public decimal GetTotal()
    {
        return Quantity * Product.Price;
    }
}

public class FlatteningCustomer
{
    public string Name { get; set; }
}

public class FlatteningOrderDto
{
    public string CustomerName { get; set; }
    public decimal Total { get; set; }
}

#region Include Members
public class FlatteningSource
{
    public string Name { get; set; }
    public FlatteningInnerSource InnerSource { get; set; }
    public FlatteningOtherInnerSource OtherInnerSource { get; set; }
}
public class FlatteningInnerSource
{
    public string Name { get; set; }
    public string Description { get; set; }
}
public class FlatteningOtherInnerSource
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
}
public class FlatteningDestination
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
}
#endregion