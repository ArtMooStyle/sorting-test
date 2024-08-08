using Sorting.Domain;

namespace Sorting.Services;

public sealed class ProductCategoryService
{
    /// <summary>
    /// Сортировка происходит по имени и уровню вложенности
    /// Как должно быть :
    /// Сначала сортируем массив по левелу и имени
    /// Дальше выстаиваем иерархию таким образом
    /// R01 - LEVEL0
    /// R01-01 - LEVEL1
    /// R01-01-01 LEVEL2
    /// R01-01-02 LEVEl2
    /// R01-02 LEVEL1
    /// R02 - LEVEL0
    /// R02-01 -LEVEl1
    /// R02-01-01 LEVEl2
    /// R02-01-02 LEVEl2
    /// R03
    /// </summary>
    /// <param name="sample"></param>
    /// <returns></returns>
    public List<ProductCategory> GetProductCategoryTopology(List<ProductCategory> sample)
    {
        throw new InvalidOperationException();
    }
    /// <summary>
    /// Для каждого элемента нужно найти крайних детей
    /// Например по структуре
    /// R01 - LEVEL0
    /// R01-01 - LEVEL1
    /// R01-01-01 LEVEL2
    /// R01-01-02 LEVEl2
    /// R01-02 LEVEL1
    /// R02 - LEVEL0
    /// R02-01 -LEVEl1
    /// R02-01-01 LEVEl2
    /// R02-01-02 LEVEl2
    /// R03
    /// Если мы передаем  R01-01 - то ответ будет R01-01-01, R01-01-02
    /// Если мы передаем R01 - то ответ будет R01-01-01, R01-01-02, R01-02
    /// </summary>
    /// <param name="groupIds"></param>
    /// <param name="productCategories"></param>
    /// <returns></returns>
    public List<string> GetLastСhildren(string[] groupIds, List<ProductCategory> productCategories)
    {
        throw new InvalidOperationException();
    }
}