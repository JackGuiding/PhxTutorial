using UnityEngine;

namespace PhxEngine2D {

    public static class IntersectionUtil {

        // AABB & AABB
        public static bool IsIntersected_AABB_AABB(Vector2 aMin, Vector2 aMax, Vector2 bMin, Vector2 bMax) {
            return aMin.x <= bMax.x && aMax.x >= bMin.x && aMin.y <= bMax.y && aMax.y >= bMin.y;
        }

        // Cirlce & Circle
        public static bool IsIntersected_Circle_Circle(Vector2 aCenter, float aRadius, Vector2 bCenter, float bRadius, out float intersectedLen) {
            Vector2 diff = aCenter - bCenter;
            float dis = diff.magnitude;
            float r = aRadius + bRadius;
            intersectedLen = r - dis; // 交叉长度
            return dis <= r;
        }

        // Circle & AABB

        // Circle & OBB

        // OBB & OBB

    }

}