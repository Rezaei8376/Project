using System;
namespace project
{
    class SudokuSolver
    {
        private int[,] board;

        public SudokuSolver()
        {
            board = new int[9, 9];
            Random rand = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (rand.Next(2) == 0)
                    {
                        board[i, j] = rand.Next(1, 10);
                    }
                }
            }
        }

        public void Solve()
        {

        }

        public void PrintBoard()
        {
            Console.WriteLine("  1 2 3   4 5 6   7 8 9");
            Console.WriteLine(" +-------+-------+-------+");

            for (int i = 0; i < 9; i++)
            {
                Console.Write((i + 1) + "| ");

                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board[i, j] + " ");

                    if ((j + 1) % 3 == 0)
                    {
                        Console.Write("| ");
                    }
                }

                Console.WriteLine();

                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine(" +-------+-------+-------+");
                }
            }
        }

        public void FillEmptyCells()
        {
            Console.WriteLine("Please enter the row and column numbers (separated by a space) of the empty cells, followed by the number you want to fill in each cell (separated by a space). Enter 'q' to quit.");

            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                string[] parts = input.Split(' ');

                if (parts.Length != 3)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }

                int row, col, num;

                if (!int.TryParse(parts[0], out row) || !int.TryParse(parts[1], out col) || !int.TryParse(parts[2], out num))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }

                if (row < 1 || row > 9 || col < 1 || col > 9 || num < 1 || num > 9)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }

                if (board[row - 1, col - 1] != 0)
                {
                    Console.WriteLine("That cell is already filled. Please choose another cell.");
                    continue;
                }

                board[row - 1, col - 1] = num;
                PrintBoard();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SudokuSolver solver = new SudokuSolver();
            Console.WriteLine("Initial board:");
            solver.PrintBoard();
            solver.FillEmptyCells();
        }
    }
}