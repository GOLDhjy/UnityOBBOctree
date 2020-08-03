using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace MyOBBOctree
{
    public class Octree<T> where T:BaseCollider
    {
        protected OctreeNode<T> root;
        public Octree(Bounds bounds)
        {
            root = new OctreeNode<T>(bounds, 0);
        }
        public Octree(Vector3 center,float length)
        {
            Bounds bounds = new Bounds(center, new Vector3(length, length, length));
            root = new OctreeNode<T>(bounds,0);
        }
        public bool AddNode(T collider)
        {
            throw new NotImplementedException();
        }
        public bool RemoveNode(T collider)
        {
            throw new NotImplementedException();

        }
        public bool RemoveNode(uint id)
        {
            throw new NotImplementedException();
        }
        public bool ContainPoint(Vector3 point)
        {
            throw new NotImplementedException();
        }
        public void DrawBounds()
        {

        }
        public void DrawObjects()
        {

        }
        public void DebugLog()
        {

        }

        public void Destroy()
        {
            root.Clear();
        }
    }
}
