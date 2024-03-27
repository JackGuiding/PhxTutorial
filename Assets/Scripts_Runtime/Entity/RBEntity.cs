using UnityEngine;

namespace PhxEngine2D {

    // RB(Rigidbody) 刚体
    public class RBEntity {

        // ID
        public int id;

        // 形状
        public ShapeType shapeType;
        public Vector2 size;

        // 坐标
        public Vector2 position;

        // 速度
        public Vector2 velocity;

        // 引力倍数
        public float gravityScale;

        public RBEntity() { }

    }

}