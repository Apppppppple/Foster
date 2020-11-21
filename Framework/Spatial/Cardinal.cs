﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foster.Framework
{
    public struct Cardinal
    {
        static public readonly Cardinal Right = new Cardinal(1, 0);
        static public readonly Cardinal Left = new Cardinal(-1, 0);
        static public readonly Cardinal Up = new Cardinal(0, -1);
        static public readonly Cardinal Down = new Cardinal(0, 1);

        public int X { get; private set; }
        public int Y { get; private set; }

        private Cardinal(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Cardinal Reverse => new Cardinal(-X, -Y);
        public Cardinal NextClockwise => new Cardinal(-Y, X);
        public Cardinal NextCounterClockwise => new Cardinal(Y, -X);

        static public implicit operator Point2(Cardinal c) => new Point2(c.X, c.Y);
    }
}
