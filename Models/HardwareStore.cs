namespace EFCoreDemo.Models;

// Here we got two entities to start with, Tool and Brand
// Entities consist of attributes, with data types and keys

public class Tool
{
    public int ID { get; set; }// This is the primary key attribute
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public virtual Brand? Brand { get; set; } // This is the foreign key attribute
}
public class Brand
{
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;

    public virtual List<Tool>? Tools { get; set; } // This is a navigation property, it allows us to browse from brand to all its tools
}

