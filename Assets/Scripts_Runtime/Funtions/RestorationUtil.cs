using UnityEngine;

namespace PhxEngine2D {

    public static class RestorationUtil {

        // Circle & Circle
        public static void RestorePenetration_Circle_Circle(RBEntity a, RBEntity b) {

            // 需要力的方向
            bool isIntersected = IntersectionUtil.IsIntersected_Circle_Circle(a.position, a.size.x, b.position, b.size.x, out float intersectedLen);
            if (!isIntersected) {
                return;
            }

            Vector2 b2a_dir = (a.position - b.position).normalized;
            Vector2 a2b_dir = -b2a_dir;

            if (a.isStatic && !b.isStatic) {
                b.position += a2b_dir * intersectedLen;
            } else if (!a.isStatic && b.isStatic) {
                a.position += b2a_dir * intersectedLen;
            } else {
                a.position += b2a_dir * intersectedLen / 2;
                b.position += a2b_dir * intersectedLen / 2;
            }

        }

        // AABB & AABB

        // Circle & AABB

        // Circle & OBB

        // OBB & OBB

    }
}