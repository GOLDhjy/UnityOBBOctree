using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOBBOctree
{
    public class OBBOctree : IOBB
    {
        public bool OBBCheckBox(BoxCollider collider)
        {
            throw new NotImplementedException();
        }

        public bool OBBCheckBox(BoxCollider collider, int layer)
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
