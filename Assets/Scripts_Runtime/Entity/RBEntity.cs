using UnityEngine;

namespace PhxEngine2D {

    // RB(Rigidbody) 刚体
    public class RBEntity {

        // ID
        public int id;

        // 形状
        public ShapeType shapeType;
        public Vector2 size; // 圆: x半径, y无效; 矩形: x宽, y高

        // 面向
        public float rotation; // 0, shapeType == Square -> AABB

        // 坐标
        public Vector2 position; // 中心点

        // 速度
        public Vector2 velocity;

        // 引力倍数
        public float gravityScale;

        // 是否静态
        public bool isStatic;

        public RBEntity() { }

#if UNITY_EDITOR
        public void DrawGizmos() {
            Gizmos.color = Color.green;
            if (shapeType == ShapeType.Square) {
                Vector2 halfSize = size * 0.5f;
                Vector2 a = new Vector2(halfSize.x, halfSize.y);
                Vector2 b = new Vector2(-halfSize.x, halfSize.y);
                Vector2 c = new Vector2(-halfSize.x, -halfSize.y);
                Vector2 d = new Vector2(halfSize.x, -halfSize.y);
                a = Rotate(a, rotation) + position;
                b = Rotate(b, rotation) + position;
                c = Rotate(c, rotation) + position;
                d = Rotate(d, rotation) + position;
                Gizmos.DrawLine(a, b);
                Gizmos.DrawLine(b, c);
                Gizmos.DrawLine(c, d);
                Gizmos.DrawLine(d, a);
            } else if (shapeType == ShapeType.Circle) {
                Gizmos.DrawWireSphere(position, size.x * 0.5f);
            }
        }

        Vector2 Rotate(Vector2 v, float angle) {
            float rad = angle * Mathf.Deg2Rad;
            float cos = Mathf.Cos(rad);
            float sin = Mathf.Sin(rad);
            return new Vector2(v.x * cos - v.y * sin, v.x * sin + v.y * cos);
        }
#endif

    }

}