using Sorting.Domain;

namespace Sorting.Tests;

public static class ProductCategoryServiceResults
{
    public static List<ProductCategory> GetTopology()
    {
        return
        [
            new()
            {
                Name = "Базовая",
                GroupId = "G1",
                Level = 0
            },
            new()
            {
                Name = "Вложеная 1",
                GroupId = "G1-G1",
                ParentGroupId = "G1",
                Level = 1
            },
            new()
            {
                Name = "Вложеная 2",
                GroupId = "G1-G1-G1",
                ParentGroupId = "G1-G1",
                Level = 2
            },
            new()
            {
                Name = "Вложеная 1",
                GroupId = "G1-G2",
                ParentGroupId = "G1",
                Level = 1
            },
            new()
            {
                Name = "Вложеная 2",
                GroupId = "G1-G2-G1",
                ParentGroupId = "G1-G2",
                Level = 2
            },
            new()
            {
                Name = "Вложеная 2",
                GroupId = "G1-G2-G2",
                ParentGroupId = "G1-G2",
                Level = 2
            },
            new()
            {
                Name = "Вложеная 1",
                GroupId = "G1-G3",
                ParentGroupId = "G1",
                Level = 1
            },
            new()
            {
                Name = "Базовая",
                GroupId = "G2",
                Level = 0
            },
            new()
            {
                Name = "Базовая",
                GroupId = "G3",
                Level = 0
            },
            new()
            {
                Name = "Вложеная 1",
                GroupId = "G3-G1",
                ParentGroupId = "G3",
                Level = 1
            },
            new()
            {
                Name = "Вложеная 2",
                GroupId = "G3-G1-G1",
                ParentGroupId = "G3-G1",
                Level = 2
            }
        ];
    }
}