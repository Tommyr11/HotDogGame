using System;
using System.Collections.Generic;
using System.Text;

namespace HotDogGame.Collisions
{
    public static class CollisionHelper
    {
        /// <summary>
        /// Using the distance formula this method communicates between sprite's hit boxes to either acknowledge a collision or not
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns>boolean for whether or not there was a collision</returns>
        public static bool Collides(BoundingCircle A, BoundingCircle B)
        {
            return Math.Pow(A.Radius + B.Radius, 2) >=
                Math.Pow(A.Center.X - B.Center.X, 2) +
                Math.Pow(A.Center.Y - B.Center.Y, 2);
        }
    }
}
