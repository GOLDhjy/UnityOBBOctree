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
            if (!root.Encapsulates(collider))
            {
                Debug.LogError($"此节点超过八叉树范围，添加失败{collider.InstanceID}");
                return false;
            }
            return root.Add(collider);
        }
        public bool RemoveNode(T collider)
        {
            return root.Remove(collider);

        }
        public bool RemoveNode(uint id)
        {
            return root.Remove(id);
        }
        public bool ContainPoint(Vector3 point)
        {
            return root.Bounds.Contains(point);
        }
        public void DrawBounds()
        {
            root.DrawBounds();
        }
        public void DrawObjects()
        {
            root.DrawObjects();
        }
        public void DebugLog()
        {
            root.DebugLog();
        }

        public void Destroy()
        {
            root.Clear();
        }
    }
}
