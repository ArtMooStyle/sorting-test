using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Sorting.Domain;
using Sorting.Services;

namespace Sorting.Tests;

[TestClass]
public class ProductCategoryServiceTest
{
    private ServiceCollection _serviceCollection;
    private ServiceProvider _serviceProvider;
    [TestInitialize()]
    public void Init()
    {
        _serviceCollection = new ServiceCollection();
        _serviceCollection.TryAddSingleton<ProductCategoryService>();
        try
        {
            _serviceProvider = _serviceCollection.BuildServiceProvider(new ServiceProviderOptions()
            {
                ValidateOnBuild = true,
                ValidateScopes = true
            });
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }
    [TestMethod()]
    public void GetProductCategoryTopology()
    {
        using var scope = _serviceProvider.CreateScope();
        var productCategoryService = scope.ServiceProvider.GetService<ProductCategoryService>();
        if (productCategoryService == null)
            throw new Exception($"Unable to load {nameof(ProductCategoryService)}");

        var sample = GenerateProductCategories();
        var topology = productCategoryService.GetProductCategoryTopology(sample);
        Assert.IsTrue(topology.Count == sample.Count);
        Assert.IsTrue(JsonConvert.SerializeObject(topology) == JsonConvert.SerializeObject(ProductCategoryServiceResults.GetTopology()));
    }
    [TestMethod()]
    public void GetLastChildren()
    {
        using var scope = _serviceProvider.CreateScope();
        var productCategoryService = scope.ServiceProvider.GetService<ProductCategoryService>();
        if (productCategoryService == null)
            throw new Exception($"Unable to load {nameof(ProductCategoryService)}");

        var sample = GenerateProductCategories();
        var topology = productCategoryService.GetLastСhildren(["G1-G2"], sample);
        Assert.IsTrue(topology.Count == 2);
        
        topology = productCategoryService.GetLastСhildren(["G1"], sample);
        Assert.IsTrue(topology.Count == 4);
        
        topology = productCategoryService.GetLastСhildren(["G1", "G1-G2"], sample);
        Assert.IsTrue(topology.Count == 4);
        
        topology = productCategoryService.GetLastСhildren(["G2"], sample);
        Assert.IsTrue(topology.Count == 1);
        
        topology = productCategoryService.GetLastСhildren(["G3"], sample);
        Assert.IsTrue(topology.Count == 1);
        
        topology = productCategoryService.GetLastСhildren(["G3", "G1"], sample);
        Assert.IsTrue(topology.Count == 5);
        
        topology = productCategoryService.GetLastСhildren(["G3", "G1", "G2"], sample);
        Assert.IsTrue(topology.Count == 6);
    }
    private List<ProductCategory> GenerateProductCategories()
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
                GroupId = "G1-G1",
                ParentGroupId = "G1",
                Level = 1
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
                Name = "Вложеная 1",
                GroupId = "G1-G3",
                ParentGroupId = "G1",
                Level = 1
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
                GroupId = "G1-G1-G1",
                ParentGroupId = "G1-G1",
                Level = 2
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
                Name = "Вложеная 2",
                GroupId = "G3-G1-G1",
                ParentGroupId = "G3-G1",
                Level = 2
            }
        ];
    }
}