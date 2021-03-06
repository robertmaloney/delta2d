#if !DELTA2D_AABB
#define DELTA2D_AABB

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace delta2d
{
    /**
     * Axis-Aligned Bounding Box
     */
    public class AABB
    {
        private Vector2 m_topleft;
        private Vector2 m_botright;

        public Vector2 Min
        {
            get
            {
                return m_topleft;
            }
            set
            {
                m_topleft = value;
            }
        }
        public Vector2 Max
        {
            get
            {
                return m_botright;
            }
            set
            {
                m_botright = value;
            }
        }
        
        public AABB()
        {
            m_topleft = new Vector2(0, 0);
            m_botright = new Vector2(0,0);
        }

        public AABB(Vector2 tl, Vector2 br)
        {
            m_topleft = tl;
            m_botright = br;
        }

        public bool contains(Vector2 p)
        {
            return (p.X >= m_topleft.X && p.X <= m_botright.X &&
                    p.Y <= m_topleft.Y && p.Y >= m_botright.Y);
        }

        public bool intersects(AABB other)
        {
            Vector2 tl = other.Min, br = other.Max;
            if (tl.X > m_botright.X || br.X < m_topleft.X) return false;
            if (tl.Y > m_botright.Y || br.Y < m_topleft.Y) return false;

            return true;
        }

        public static AABB operator *(AABB bounds, float scalar) {
            return new AABB(bounds.Min*scalar, bounds.Max*scalar);
        }
    }
};

#endif