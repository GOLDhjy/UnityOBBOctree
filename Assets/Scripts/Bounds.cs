using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MyOBBOctree
{
    /// <summary>
    /// 轴对齐的边界框或简称AABB
    /// </summary>
    public class Bounds
    {
        private Vector3 center;
        private Vector3 extents;
        private Vector3 size;
        private Vector3 min;
        private Vector3 max;
        

        public Bounds(Vector3 center, Vector3 size)
        {
            this.center = center;
            this.size = size;
            this.extents = size / 2;
        }

        public Vector3 Center { get => center; set => center = value; }
        public Vector3 Extents { get => extents; set => extents = value; }
        public Vector3 Size { get => size; set => size = value; }
        public Vector3 Min 
        {
            get
            {
                min = center - extents;
                return min;
            }
            set => min = value; 
        }
        public Vector3 Max 
        {
            get
            {
                max = center + extents;
                return max;
            }
            set => max = value; 
        }


        public bool Intersects(Bounds bounds)
        {
            throw new NotImplementedException();
        }
        public bool IntersectRay(Ray ray)
        {
            throw new NotImplementedException();
        }
        public bool Contains(Vector3 point)
        {
            throw new NotImplementedException();
        }
        public void Encapsulate(Vector3 point)
        {
            throw new NotImplementedException();
        }
        public void Encapsulate(Bounds bounds)
        {
            throw new NotImplementedException();
        }
    }
}
