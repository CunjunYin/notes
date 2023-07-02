namespace AutoMapperDemo.Models;

public class InheritancePerson
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class InheritanceEmployee : InheritancePerson
{
    public string EmployeeId { get; set; }
    public decimal Salary { get; set; }
}

public class InheritancePersonDto
{
    public string Name { get; set; }
}

public class InheritanceEmployeeDto : InheritancePersonDto
{
    public string EmployeeId { get; set; }
    public decimal Salary { get; set; }
}