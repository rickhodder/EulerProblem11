namespace EulerProblem11;

public class UnitTest1
{
    const string _testGrid = @"1 2 3 4
    5 6 7 8
    9 10 11 12
    13 14 15 16";

    [Fact]
    public void ParseGrid_ParsesGroupSize4()
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
    public void CalculateHorizontalProduct_ReturnsProductOf4()
    {
        var gridProduct = new GridProduct();
        var grid = gridProduct.ParseGrid(_testGrid);
        var product = gridProduct.CalculateHorizontalProduct(grid, 0, 0, 4);
        Assert.Equal(1 * 2 * 3 * 4, product);
    }

    [Fact]
    public void CalculateVerticalProduct_ReturnsProductOf4()
    {
        var gridProduct = new GridProduct();
        var grid = gridProduct.ParseGrid(_testGrid);
        var product = gridProduct.CalculateVerticalProduct(grid, 0, 0, 4);
        Assert.Equal(1 * 5 * 9 * 13, product);
    }

    [Fact]
    public void CalculateDiagonalRightProduct_ReturnsProductOf4()
    {
        var gridProduct = new GridProduct();
        var grid = gridProduct.ParseGrid(_testGrid);
        var product = gridProduct.CalculateDiagonalRightProduct(grid, 0, 0, 4);
        Assert.Equal(1 * 6 * 11 * 16, product);
    }

    [Fact]
    public void CalculateDiagonalLeftProduct_ReturnsProductOf4()
    {
        var gridProduct = new GridProduct();
        var grid = gridProduct.ParseGrid(_testGrid);
        var product = gridProduct.CalculateDiagonalLeftProduct(grid, 0, 0, 4);
        Assert.Equal(4 * 7 * 10 * 13, product);
    }
}