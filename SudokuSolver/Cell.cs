using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace SudokuSolver
{
    public class Cell
    {
        public int X { get; }
        public int Y { get; }

        public int Value { get; set; }

        public Cell(int x, int y, int value)
        {
            X = x;
            Y = y;
            Value = value;
        }

        public static bool operator ==(Cell a, Cell b)
        {
            return a.X == b.X && a.Y == b.Y && a.Value == b.Value;
        }

        public static bool operator !=(Cell a, Cell b)
        {
            return a.X != b.X || a.Y != b.Y || a.Value != b.Value;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Cell))
            {
                return false;
            }

            var cell = (Cell)obj;
            return X == cell.X &&
                   Y == cell.Y &&
                   Value == cell.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Value);
        }
    }
}
