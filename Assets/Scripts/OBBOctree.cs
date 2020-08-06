using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace MyOBBOctree
{
    public class OBBOctree : Octree<BoxCollider>, IOBB
    {
        public OBBOctree(Bounds bounds) : base(bounds)
        {
        }

        public OBBOctree(Vector3 center, float length) : base(center, length)
        {
        }

        public bool BoxCast(BoxCollider collider)
        {
            return root.Check(collider);
        }

        public bool BoxCast(BoxCollider collider, int layer)
        {
            return root.Check(collider, layer);
        }

        public void OverlapBox(BoxCollider collider, out List<BoxCollider> colliders)
        {
            colliders = new List<BoxCollider>();
            root.OverlapColliders(collider, colliders);
        }

        public void OverlapBox(BoxCollider collider, out List<BoxCollider> colliders, int layer)
        {
            colliders = new List<BoxCollider>();
            root.OverlapColliders(collider, colliders,layer);
        }
    }
}
