using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOBBOctree
{
    public interface IOBB
    {
        
        bool BoxCast(BoxCollider collider);
        bool BoxCast(BoxCollider collider,int layer);
        void OverlapBox(BoxCollider collider ,out List<BoxCollider> colliders);
        void OverlapBox(BoxCollider collider, out List<BoxCollider> colliders,int layer);

    }
}
