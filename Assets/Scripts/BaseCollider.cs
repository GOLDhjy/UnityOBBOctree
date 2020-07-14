using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace MyOBBOctree
{
    
    public abstract class BaseCollider
    {
        private Vector3 min;
        private Vector3 max;
        private int deep;
        private int layer;
        private uint instanceID;

        private GameObject gameObject;
        private Transform transform;
        private Bounds bounds;

        protected BaseCollider(GameObject gameObject, Bounds bounds, uint instanceID, int layer)
        {
            this.layer = layer;
            this.instanceID = instanceID;
            this.gameObject = gameObject;
            this.bounds = bounds;
        }

        public virtual Vector3 Min { get => min; set => min = value; }
        public virtual Vector3 Max { get => max; set => max = value; }
        public int Deep { get => deep; set => deep = value; }
        public int Layer { get => layer; set => layer = value; }
        public uint InstanceID { get => instanceID; set => instanceID = value; }
        public GameObject GameObject { get => gameObject; set => gameObject = value; }
        public Transform Transform { get => transform; set => transform = value; }
        public Bounds Bounds { get => bounds; set => bounds = value; }

        public override bool Equals(object obj)
        {
            if (!(obj is BaseCollider))
            {
                return false;
            }
            BaseCollider collider = obj as BaseCollider;
            return instanceID == collider.instanceID;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("ID {0}",instanceID);
        }
        public abstract bool Intersects(BaseCollider baseCollider);
        public abstract Vector3 GetPosition();
    }

}
