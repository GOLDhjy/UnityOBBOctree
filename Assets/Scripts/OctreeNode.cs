using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace MyOBBOctree
{
    public class OctreeNode<T> where T : BaseCollider
    {
        public const int MaxDeep = 5;
        public const int MaxObjCount = 10;

        private Bounds bounds;
        private int deep;
        private Vector3 center;
        private float length;
        private List<T> objects = new List<T>();
        private OctreeNode<T>[] childs;

        /// <summary>
        /// 构造一个Bounds，Bounds必须为正方体
        /// </summary>
        /// <param name="bounds"></param>
        /// <param name="deep"></param>
        public OctreeNode(Bounds bounds, int deep)
        {
            this.bounds = bounds;
            this.deep = deep;
            this.center = bounds.Center;
            this.length = bounds.Extents.x;
        }

        public int Deep { get => deep; set => deep = value; }
        public List<T> Objects { get => objects; set => objects = value; }
        public OctreeNode<T>[] Childs { get => childs; set => childs = value; }
        public Bounds Bounds { get => bounds; set => bounds = value; }
        public void Spilt()
        {

        }
        public int GetChildIndex(Vector3 pos)
        {
            throw new NotImplementedException();
        }
        public bool Add(T collider)
        {
            throw new NotImplementedException();

        }
        public bool Remove(T collider)
        {
            throw new NotImplementedException();

        }
        public bool Remove(uint insId)
        {
            throw new NotImplementedException();

        }
        public void GetColliders(T collider,List<T> list,int layer)
        {

        }
        public bool Check(T collider,int layer = -1)
        {
            throw new NotImplementedException();

        }
        public bool Encapsulates(T collider)
        {
            throw new NotImplementedException();

        }
    }
}
