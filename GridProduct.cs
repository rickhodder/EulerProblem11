namespace EulerProblem11;
public class GridProduct
{
    public int[,] ParseGrid(string gridContents)
    {

        var tempGrid = gridContents.Split(new char[] { '\r', '\n' }, options: StringSplitOptions.RemoveEmptyEntries);

        var rows = tempGrid.Length;
        var columns = tempGrid[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

        var grid = new int[rows, columns];

        for (int row = 0; row < tempGrid.Length; row++)
        {
            var rowContents = tempGrid[row].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int column = 0; column < rowContents.Length; column++)
            {
                grid[row, column] = int.Parse(rowContents[column]);
            }
        }

        return grid;
    }

    public int CalculateMaxProduct(string gridContents, int GROUP_SIZE = 4)
    {
        var grid = ParseGrid(gridContents);
        var result = 0;
        for (int row = 0; row < grid.GetLength(0); row++)
            for (int column = 0; column < grid.GetLength(1); column++)
            {          
                var enoughColumns = column < (grid.GetLength(1) - GROUP_SIZE + 1);
                var enoughRows = row < (grid.GetLength(0) - GROUP_SIZE + 1);

                if (enoughColumns)
                    result = Math.Max(result, CalculateHorizontalProduct(grid, row, column, GROUP_SIZE));

                if (enoughRows) 
                    result = Math.Max(result, CalculateVerticalProduct(grid, row, column, GROUP_SIZE));

                if (enoughColumns && enoughRows) 
                {
                    result = Math.Max(result, CalculateDiagonalRightProduct(grid, row, column, GROUP_SIZE));
                    result = Math.Max(result, CalculateDiagonalLeftProduct(grid, row, column, GROUP_SIZE));
                }
            }
        return result;
    }

    public int CalculateHorizontalProduct(int[,] grid, int row, int column, int groupSize)
    {
        var result = 1;

        for (int i = column; i < column + groupSize; i++)
        {
            result *= grid[row, i];
        }
        return result;
    }

    public int CalculateVerticalProduct(int[,] grid, int row, int column, int groupSize)
    {
        var result = 1;

        for (int i = row; i < row + groupSize; i++)
        {
            result *= grid[i, column];
        }
        return result;
    }

    public int CalculateDiagonalRightProduct(int[,] grid, int row, int column, int groupSize)
    {
        var result = 1;

        for (int i = 0; i < groupSize; i++)
        {
            result *= grid[row + i, column + i];

        }

        return result;
    }

    public int CalculateDiagonalLeftProduct(int[,] grid, int row, int column, int groupSize)
    {
        var result = 1;

        for (int i = 0; i < groupSize; i++)
        {
            result *= grid[row + i, column + groupSize - i - 1];
        }

        return result;
    }

}
