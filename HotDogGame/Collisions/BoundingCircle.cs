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

        public BoundingCircle(Vector2 center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        public bool CollidesWith(BoundingCircle other)
        {
            return CollisionHelper.Collides(this, other);
        }
    }
}
