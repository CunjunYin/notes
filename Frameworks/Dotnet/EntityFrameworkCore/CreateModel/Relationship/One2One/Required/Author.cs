﻿namespace Relationship.One2One.Required;

// Principal (parent)
public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Profile? Profile { get; set; }// Reference navigation to dependent
}