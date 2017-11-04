using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace Sudoku
{
    public static class Program
    {
        
        public static void Main(string[] args)
        {
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "input_sudoku.txt");
            try
            {
                var lines = GetLinesFromFile(path);
                int[,] grid = CreateIntGrid(lines);

                var sudoku = new SudokuValidate(grid);
                if (sudoku.ValidateRows() && sudoku.ValidateColumns() && sudoku.ValidateSquares())
                    Console.WriteLine("Sudoku is valid");
                else
                    Console.WriteLine("Sudoku is not valid");
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading from {0}. Message = {1}", path, e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }
            Console.ReadLine();
        }

        public  static string[] GetLinesFromFile(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            return lines.Where(x => !string.IsNullOrEmpty(x)).ToArray();
        }

        public static int[,] CreateIntGrid(string[] lines)
        {
            int[,] gridNumbers = new int[9, 9];
            for (int i = 0; i < 9; ++i)
            {
                int[] lineNumbers = lines[i].ToCharArray().Select(x => (int)(x - '0')).ToArray();
                for (int j = 0; j < 9; ++j)
                {
                    gridNumbers[i, j] = Convert.ToInt32(lineNumbers[j]);
                }
            }
            return gridNumbers;
        }

    }

    public class SudokuValidate
    {
        private int[,] grid;

        public SudokuValidate(int[,] grid)
        {
            this.grid = grid;
        }


        public bool ValidateRows()
        {
            for (int j = 0; j < 9; j++)
            {
                int[] row = Enumerable.Range(0, 9).Select(i => grid[j, i]).ToArray();
                if (!IsValid(row))
                    return false;
            }
            return true;
        }

        public bool ValidateColumns()
        {
            for (int j = 0; j < 9; j++)
            {
                int[] column = Enumerable.Range(0, 9).Select(i => grid[i, j]).ToArray();
                if (!IsValid(column))
                    return false;
            }
            return true;
        }

        public  bool ValidateSquares()
        {
            var squares = GetSquares().ToArray();

            for (int i = 0; i < 9; i++)
            {
                if (!IsValid(squares[i]))
                     return false;
            }
            return true;
        }

        private IEnumerable<int[]> GetSquares()
        {
            return 
                from i in Enumerable.Range(0, 3)
                from j in Enumerable.Range(0, 3)
                select GetSquare(i, j).ToArray();
        }

        private IEnumerable<int> GetSquare(int i, int j)
        {
            return
                from x in Enumerable.Range(0, 3)
                from y in Enumerable.Range(0, 3)
                select grid[i * 3 + x, j * 3 + y];
        }

        public static bool IsValid(int[] values)
        {
            int flag = 0;
            foreach (int value in values)
            {
                if (value != 0)
                {
                    int bit = 1 << value;
                    if ((flag & bit) != 0) return false;
                    flag |= bit;
                }
            }
            return true;
        }
    }
}
