using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    public class Sudoku
    {
        private readonly List<Cell> _cells;

        public IReadOnlyCollection<Cell> Cells => _cells;

        public Sudoku(int[,] values)
        {
            _cells = new List<Cell>();

            for (var y = 0; y <= values.GetUpperBound(0); y++)
            {
                for (var x = 0; x <= values.GetUpperBound(1); x++)
                {
                    _cells.Add(new Cell(x, y, values[y,x]));
                }
            }
        }

        public IReadOnlyCollection<Cell> GetCellRow(Cell cell) 
            => Cells.Where(c => c.Y == cell.Y).ToImmutableArray();

        public IReadOnlyCollection<Cell> GetCellColumn(Cell cell) 
            => Cells.Where(c => c.X == cell.X).ToImmutableArray();

        public IReadOnlyCollection<Cell> GetCellBox(Cell cell) 
            => Cells.Where(c => c.Y / 3 == cell.Y / 3 && c.X / 3 == cell.X / 3).ToImmutableArray();

        public IReadOnlyCollection<Cell> GetEmptyCells() 
            => Cells.Where(c => c.Value == 0).ToImmutableArray();

        public IReadOnlyCollection<Cell> GetBox(int index)
        {
            var lookup = new List<Cell>
            {
                _cells.First(),
                _cells.Find(c => c.X == 4 && c.Y == 0),
                _cells.Find(c => c.X == 7 && c.Y == 0),
                _cells.Find(c => c.X == 1 && c.Y == 4),
                _cells.Find(c => c.X == 4 && c.Y == 4),
                _cells.Find(c => c.X == 7 && c.Y == 4),
                _cells.Find(c => c.X == 1 && c.Y == 7),
                _cells.Find(c => c.X == 4 && c.Y == 7),
                _cells.Last()
            };

            return GetCellBox(lookup[index]);
        }

        public IReadOnlyCollection<Cell> GetRow(int index) 
            => Cells.Where(c => c.Y == index).ToImmutableArray();

        public IReadOnlyCollection<Cell> GetColumn(int index) 
            => Cells.Where(c => c.X == index).ToImmutableArray();

        public bool AllFilled() 
            => Cells.All(c => c.Value != 0);

        public bool ValuePossible(Cell cell, int value) =>
            !GetCellRow(cell).Select(c => c.Value).Contains(value) &&
            !GetCellColumn(cell).Select(c => c.Value).Contains(value) &&
            !GetCellBox(cell).Select(c => c.Value).Contains(value);

        public int[,] ToMultiArray()
        {
            var returnArray = new int[9,9];

            for (var y = 0; y < 9; y++)
            {
                for (var x = 0; x < 9; x++)
                {
                    returnArray[y, x] = _cells.First(c => c.X == x && c.Y == y).Value;
                }
            }

            return returnArray;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            StringBuilder PrintRow(StringBuilder b, IReadOnlyCollection<Cell> cells)
            {
                var count = 0;
                foreach (var c in cells)
                {
                    b.Append($"{c.Value} {(++count % 3 == 0 && count != 9 ? "| " : "")}");
                }

                return b;
            }

            PrintRow(builder, GetRow(0));
            builder.AppendLine();
            PrintRow(builder, GetRow(1));
            builder.AppendLine();
            PrintRow(builder, GetRow(2));
            builder.AppendLine();

            builder.AppendLine("- - - + - - - + - - -");

            PrintRow(builder, GetRow(3));
            builder.AppendLine();
            PrintRow(builder, GetRow(4));
            builder.AppendLine();
            PrintRow(builder, GetRow(5));
            builder.AppendLine();

            builder.AppendLine("- - - + - - - + - - -");

            PrintRow(builder, GetRow(6));
            builder.AppendLine();
            PrintRow(builder, GetRow(7));
            builder.AppendLine();
            PrintRow(builder, GetRow(8));
            builder.AppendLine();

            return builder.ToString();
        }

        public static bool operator ==(Sudoku a, Sudoku b)
        {
            if (ReferenceEquals(a, null))
            {
                if (ReferenceEquals(b, null))
                {
                    return true;
                }

                return false;
            }

            if (ReferenceEquals(b, null))
            {
                if (ReferenceEquals(a, null))
                {
                    return true;
                }

                return false;
            }

            for (var ai = 0; ai < a.Cells.Count; ai++)
            {
                if (a.Cells.ElementAt(ai) != b.Cells.ElementAt(ai))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator !=(Sudoku a, Sudoku b)
        {
            for (var ai = 0; ai < a.Cells.Count; ai++)
            {
                if (a.Cells.ElementAt(ai) == b.Cells.ElementAt(ai))
                {
                    return false;
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Sudoku))
            {
                return false;
            }

            var sudoku = (Sudoku)obj;
            return this == sudoku;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_cells, Cells);
        }

        public static Sudoku Empty =>
            new Sudoku(new int[,]
            {
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
            });
    }
}
