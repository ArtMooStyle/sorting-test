namespace Sorting.Domain;

public class ProductCategory
{
    public required string GroupId { get; set; }
    public string? ParentGroupId { get; set; }
    public required string Name { get; set; }
    public int Level { get; set; }
}