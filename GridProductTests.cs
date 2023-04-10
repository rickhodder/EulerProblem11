using Xunit.Abstractions;

namespace EulerProblem11;

public class GridProductTests
{
    private ITestOutputHelper _output;

    const string _testGrid = @"1 2 3 4
    5 6 7 8
    9 10 11 12
    13 14 15 16";

    public GridProductTests(ITestOutputHelper output)
    {
        _output = output;
    }
    

    [Fact]
    public void ParseGrid_ParsesGroupSize()
    {
        var gridProduct = new GridProduct();
        var grid = gridProduct.ParseGrid(_testGrid);
        Assert.Equal(4, grid.GetLength(0));
        Assert.Equal(4, grid.GetLength(1));
    }

    [Fact]
    public void CalculateMaxProduct_ReturnsMaxProduct()
    {
        var gridProduct = new GridProduct();
        var result = gridProduct.CalculateMaxProduct(_testGrid);
        Assert.Equal(16 * 15 * 14 * 13, result);
    }

    [Fact]
    public void CalculateHorizontalProduct_ReturnsProduct()
    {
        var gridProduct = new GridProduct();
        var grid = gridProduct.ParseGrid(_testGrid);
        var product = gridProduct.CalculateHorizontalProduct(grid, 0, 0, 4);
        Assert.Equal(1 * 2 * 3 * 4, product);
        product = gridProduct.CalculateHorizontalProduct(grid, 1, 0, 4);
        Assert.Equal(5 * 6 * 7 * 8, product);
        product = gridProduct.CalculateHorizontalProduct(grid, 2, 0, 4);
        Assert.Equal(9 * 10 * 11 * 12, product);
        product = gridProduct.CalculateHorizontalProduct(grid, 3, 0, 4);
        Assert.Equal(13 * 14 * 15 * 16, product);

    }

    [Fact]
    public void CalculateVerticalProduct_ReturnsProduct()
    {
        var gridProduct = new GridProduct();
        var grid = gridProduct.ParseGrid(_testGrid);
        var product = gridProduct.CalculateVerticalProduct(grid, 0, 0, 4);
        Assert.Equal(1 * 5 * 9 * 13, product);
        product = gridProduct.CalculateVerticalProduct(grid, 0, 1, 4);
        Assert.Equal(2 * 6 * 10 * 14, product);
        product = gridProduct.CalculateVerticalProduct(grid, 0, 2, 4);
        Assert.Equal(3 * 7 * 11 * 15, product);
        product = gridProduct.CalculateVerticalProduct(grid, 0, 3, 4);
        Assert.Equal(4 * 8 * 12 * 16, product);
    }

    [Fact]
    public void CalculateDiagonalRightProduct_ReturnsProduct()
    {
        var gridProduct = new GridProduct();
        var grid = gridProduct.ParseGrid(_testGrid);
        var product = gridProduct.CalculateDiagonalRightProduct(grid, 0, 0, 4);
        Assert.Equal(1 * 6 * 11 * 16, product);
        product = gridProduct.CalculateDiagonalRightProduct(grid, 0, 1, 4);
        Assert.Equal(0, product);
    }

    [Fact]
    public void CalculateDiagonalLeftProduct_ReturnsProduct()
    {
        var gridProduct = new GridProduct();
        var grid = gridProduct.ParseGrid(_testGrid);
        var product = gridProduct.CalculateDiagonalLeftProduct(grid, 0, 0, 4);
        Assert.Equal(4 * 7 * 10 * 13, product);
    }
}