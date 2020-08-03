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


        public int Deep { get => deep; set => deep = value; }
        public List<T> Objects { get => objects; set => objects = value; }
        public OctreeNode<T>[] Childs { get => childs; set => childs = value; }
        public Bounds Bounds { get => bounds; set => bounds = value; }
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

        /// <summary>
        /// 划分顺序为从做往右，从下往上
        /// </summary>
        public void Spilt()
        {
            if (deep >= MaxDeep)
            {
                return;
            }
            float childLen = length / 2;
            int childDeep = this.deep + 1;
            float quarter = length / 4;
            Vector3 size = new Vector3(childLen, childLen, childLen);

            childs = new OctreeNode<T>[8];
            childs[0] = new OctreeNode<T>(new Bounds(center + new Vector3(-quarter, -quarter, -quarter), size), childDeep);
            childs[1] = new OctreeNode<T>(new Bounds(center + new Vector3(quarter, -quarter, -quarter), size), childDeep);
            childs[2] = new OctreeNode<T>(new Bounds(center + new Vector3(-quarter, -quarter, quarter), size), childDeep);
            childs[3] = new OctreeNode<T>(new Bounds(center + new Vector3(quarter, -quarter, quarter), size), childDeep);
            childs[4] = new OctreeNode<T>(new Bounds(center + new Vector3(-quarter, quarter, -quarter), size), childDeep);
            childs[5] = new OctreeNode<T>(new Bounds(center + new Vector3(quarter, quarter, -quarter), size), childDeep);
            childs[6] = new OctreeNode<T>(new Bounds(center + new Vector3(-quarter, quarter, quarter), size), childDeep);
            childs[7] = new OctreeNode<T>(new Bounds(center + new Vector3(quarter, quarter, quarter), size), childDeep);

        }
        public void Clear()
        {

        }
        public int GetChildIndex(Vector3 pos)
        {
            return (pos.x <= center.x ? 0 : 1) + (pos.y >= center.y ? 4 : 0) + (pos.z <= center.z ? 0 : 2);
        }
        public bool Add(T collider)
        {
            if (objects.Count<=MaxObjCount || deep >=MaxDeep)
            {
                if (!objects.Contains(collider))
                {
                    objects.Add(collider);
                }
                else
                {
                    Debug.LogError($"八叉树已经包含此节点:{collider.InstanceID}");
                    return false;
                }
            }
            else
            {
                int bestFitChild;
                if (childs == null)
                {
                    Spilt();
                    if (childs == null)
                    {
                        objects.Add(collider);
                        return true;
                    }
                    for (int i = objects.Count-1; i >=0; i--)
                    {
                        bestFitChild = GetChildIndex(objects[i].GetPosition());
                        if (childs[bestFitChild].Encapsulates(objects[i]))
                        {
                            childs[bestFitChild].Add(objects[i]);
                            objects.RemoveAt(i);
                        }
                    }
                }
                bestFitChild = GetChildIndex(collider.GetPosition());
                if (childs[bestFitChild].Encapsulates(collider))
                {
                    childs[bestFitChild].Add(collider);
                }
                else
                {
                    if (!objects.Contains(collider))
                    {
                        objects.Add(collider);
                    }
                    else
                    {
                        Debug.LogError($"八叉树已经包含此节点:{collider.InstanceID}");
                        return false;
                    }
                }
            }
            return true;

        }
        public bool Remove(T collider)
        {
            throw new NotImplementedException();

        }
        public bool Remove(uint insId)
        {
            throw new NotImplementedException();

        }
        public void OverlapColliders(T collider, List<T> list, int layer)
        {

        }
        public void OverlapColliders(T collider, List<T> list)
        {

        }
        public bool Check(T collider, int layer = -1)
        {
            throw new NotImplementedException();

        }
        public bool Encapsulates(T collider)
        {
            throw new NotImplementedException();

        }

        public void GetAllObjects(List<T> res)
        {

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
    }
}
