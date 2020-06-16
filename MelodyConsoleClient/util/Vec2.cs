using System;
using System.Collections.Generic;
using System.Text;

namespace MelodyConsoleClient
{
    public struct Vec2
    {
        public int x, y;

        public Vec2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vec2 operator +(Vec2 _1, Vec2 _2)
        {
            return new Vec2(_1.x + _2.x, _1.y + _2.y);
        }
        public static Vec2 operator *(Vec2 _1, int f)
        {
            return new Vec2(_1.x * f, _1.y * f);
        }
    }
}
