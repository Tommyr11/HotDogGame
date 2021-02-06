using System;
using System.Collections.Generic;
using System.Text;

namespace HotDogGame.Collisions
{
    public static class CollisionHelper
    {
        public static bool Collides(BoundingCircle A, BoundingCircle B)
        {
            return Math.Pow(A.Radius + B.Radius, 2) >=
                Math.Pow(A.Center.X - B.Center.X, 2) +
                Math.Pow(A.Center.Y - B.Center.Y, 2);
        }
    }
}
