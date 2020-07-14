using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MyOBBOctree
{
    public class BoxCollider : BaseCollider
    {
        public BoxCollider(GameObject gameObject, Bounds bounds, uint instanceID, int layer) : base(gameObject, bounds, instanceID, layer)
        {
        }

        public override Vector3 GetPosition()
        {
            throw new NotImplementedException();
        }

        public override bool Intersects(BaseCollider baseCollider)
        {
            throw new NotImplementedException();
        }
    }
}
