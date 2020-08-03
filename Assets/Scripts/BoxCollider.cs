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
        public Vector3 Point0 { get { return Transform.TransformPoint(new Vector3(-0.5f, -0.5f, -0.5f)); } }
        public Vector3 Point1 { get { return Transform.TransformPoint(new Vector3(0.5f, -0.5f, -0.5f)); } }
        public Vector3 Point2 { get { return Transform.TransformPoint(new Vector3(0.5f, 0.5f, -0.5f)); } }
        public Vector3 Point3 { get { return Transform.TransformPoint(new Vector3(-0.5f, 0.5f, -0.5f)); } }
        public Vector3 Point4 { get { return Transform.TransformPoint(new Vector3(-0.5f, -0.5f, 0.5f)); } }
        public Vector3 Point5 { get { return Transform.TransformPoint(new Vector3(0.5f, -0.5f, 0.5f)); } }
        public Vector3 Point6 { get { return Transform.TransformPoint(new Vector3(0.5f, 0.5f, 0.5f)); } }
        public Vector3 Point7 { get { return Transform.TransformPoint(new Vector3(-0.5f, 0.5f, 0.5f)); } }

        public Vector3 XAxis { get { return Transform.right; } }
        public Vector3 YAxis { get { return Transform.up; } }
        public Vector3 ZAxis { get { return Transform.forward; } }

        public override Vector3 Min 
        {
            get
            {
                return new Vector3()
                {
                    x = Mathf.Min(Point0.x, Point1.x, Point2.x, Point3.x, Point4.x, Point5.x, Point6.x, Point7.x),
                    y = Mathf.Min(Point0.y, Point1.y, Point2.y, Point3.y, Point4.y, Point5.y, Point6.y, Point7.y),
                    z = Mathf.Min(Point0.z, Point1.z, Point2.z, Point3.z, Point4.z, Point5.z, Point6.z, Point7.z),
                };
            }
            set => base.Min = value;
        }
        public override Vector3 Max 
        { 
            get
            {
                return new Vector3()
                {
                    x = Mathf.Max(Point0.x, Point1.x, Point2.x, Point3.x, Point4.x, Point5.x, Point6.x, Point7.x),
                    y = Mathf.Max(Point0.y, Point1.y, Point2.y, Point3.y, Point4.y, Point5.y, Point6.y, Point7.y),
                    z = Mathf.Max(Point0.z, Point1.z, Point2.z, Point3.z, Point4.z, Point5.z, Point6.z, Point7.z),
                };
            }
                
            set => base.Max = value; 
        }

        public BoxCollider(GameObject gameObject, Bounds bounds, uint instanceID, int layer) : base(gameObject, bounds, instanceID, layer)
        {
        }

        public override Vector3 GetPosition()
        {
            return Transform.position + Bounds.Center;
        }

        public override bool Intersects(BaseCollider baseCollider)
        {
            if (!(baseCollider is BoxCollider))
            {
                Debug.LogError("传入类型错误");
                return false;
            }
            var other = baseCollider as BoxCollider;
            var isNotIntersect = false;
            isNotIntersect |= ProjectionIsNotIntersect(this, other, XAxis);
            isNotIntersect |= ProjectionIsNotIntersect(this, other, YAxis);
            isNotIntersect |= ProjectionIsNotIntersect(this, other, ZAxis);
            isNotIntersect |= ProjectionIsNotIntersect(this, other, other.XAxis);
            isNotIntersect |= ProjectionIsNotIntersect(this, other, other.YAxis);
            isNotIntersect |= ProjectionIsNotIntersect(this, other, other.ZAxis);

            isNotIntersect |= ProjectionIsNotIntersect(this, other, Vector3.Cross(XAxis, other.XAxis).normalized);
            isNotIntersect |= ProjectionIsNotIntersect(this, other, Vector3.Cross(XAxis, other.YAxis).normalized);
            isNotIntersect |= ProjectionIsNotIntersect(this, other, Vector3.Cross(XAxis, other.ZAxis).normalized);

            isNotIntersect |= ProjectionIsNotIntersect(this, other, Vector3.Cross(YAxis, other.XAxis).normalized);
            isNotIntersect |= ProjectionIsNotIntersect(this, other, Vector3.Cross(YAxis, other.YAxis).normalized);
            isNotIntersect |= ProjectionIsNotIntersect(this, other, Vector3.Cross(YAxis, other.ZAxis).normalized);

            isNotIntersect |= ProjectionIsNotIntersect(this, other, Vector3.Cross(ZAxis, other.XAxis).normalized);
            isNotIntersect |= ProjectionIsNotIntersect(this, other, Vector3.Cross(ZAxis, other.YAxis).normalized);
            isNotIntersect |= ProjectionIsNotIntersect(this, other, Vector3.Cross(ZAxis, other.ZAxis).normalized);

            return !isNotIntersect;
        }
        bool ProjectionIsNotIntersect(BoxCollider l, BoxCollider r, Vector3 axis)
        {
            var x_p0 = GetSignProjectValue(l.Point0, axis);
            var x_p1 = GetSignProjectValue(l.Point1, axis);
            var x_p2 = GetSignProjectValue(l.Point2, axis);
            var x_p3 = GetSignProjectValue(l.Point3, axis);
            var x_p4 = GetSignProjectValue(l.Point4, axis);
            var x_p5 = GetSignProjectValue(l.Point5, axis);
            var x_p6 = GetSignProjectValue(l.Point6, axis);
            var x_p7 = GetSignProjectValue(l.Point7, axis);

            var y_p0 = GetSignProjectValue(r.Point0, axis);
            var y_p1 = GetSignProjectValue(r.Point1, axis);
            var y_p2 = GetSignProjectValue(r.Point2, axis);
            var y_p3 = GetSignProjectValue(r.Point3, axis);
            var y_p4 = GetSignProjectValue(r.Point4, axis);
            var y_p5 = GetSignProjectValue(r.Point5, axis);
            var y_p6 = GetSignProjectValue(r.Point6, axis);
            var y_p7 = GetSignProjectValue(r.Point7, axis);

            var xMin = Mathf.Min(x_p0, Mathf.Min(x_p1, Mathf.Min(x_p2, Mathf.Min(x_p3, Mathf.Min(x_p4, Mathf.Min(x_p5, Mathf.Min(x_p6, x_p7)))))));
            var xMax = Mathf.Max(x_p0, Mathf.Max(x_p1, Mathf.Max(x_p2, Mathf.Max(x_p3, Mathf.Max(x_p4, Mathf.Max(x_p5, Mathf.Max(x_p6, x_p7)))))));
            var yMin = Mathf.Min(y_p0, Mathf.Min(y_p1, Mathf.Min(y_p2, Mathf.Min(y_p3, Mathf.Min(y_p4, Mathf.Min(y_p5, Mathf.Min(y_p6, y_p7)))))));
            var yMax = Mathf.Max(y_p0, Mathf.Max(y_p1, Mathf.Max(y_p2, Mathf.Max(y_p3, Mathf.Max(y_p4, Mathf.Max(y_p5, Mathf.Max(y_p6, y_p7)))))));

            if (yMin >= xMin && yMin <= xMax) return false;
            if (yMax >= xMin && yMax <= xMax) return false;
            if (xMin >= yMin && xMin <= yMax) return false;
            if (xMax >= yMin && xMax <= yMax) return false;

            return true;
        }
        float GetSignProjectValue(Vector3 point, Vector3 axis)
        {
            var projectPoint = Vector3.Project(point, axis);
            var result = projectPoint.magnitude * Mathf.Sign(Vector3.Dot(projectPoint, axis));

            return result;
        }
        public override void Destroy()
        {
            UnityEngine.GameObject.Destroy(GameObject);
        }
    }
}
