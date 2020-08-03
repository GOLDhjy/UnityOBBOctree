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
            throw new NotImplementedException();
        }

        public bool BoxCast(BoxCollider collider, int layer)
        {
            throw new NotImplementedException();
        }

        public void OverlapBox(BoxCollider collider, out List<BoxCollider> colliders)
        {
            throw new NotImplementedException();
        }

        public void OverlapBox(BoxCollider collider, out List<BoxCollider> colliders, int layer)
        {
            throw new NotImplementedException();
        }
    }
}
