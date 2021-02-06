using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using HotDogGame.Collisions;


namespace HotDogGame.Collisions
{
    public struct BoundingCircle
    {
        public Vector2 Center;

        public float Radius;

        /// <summary>
        /// Hitbox consisting in the shape of a circle
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        public BoundingCircle(Vector2 center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        /// <summary>
        /// Helper method to call Collides from Collision heler
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool CollidesWith(BoundingCircle other)
        {
            return CollisionHelper.Collides(this, other);
        }
    }
}
