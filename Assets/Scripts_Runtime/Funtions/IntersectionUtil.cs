using UnityEngine;

namespace PhxEngine2D {

    public static class IntersectionUtil {

        // AABB & AABB
        public static bool IsIntersected_AABB_AABB(Vector2 aMin, Vector2 aMax, Vector2 bMin, Vector2 bMax) {
            return aMin.x <= bMax.x && aMax.x >= bMin.x && aMin.y <= bMax.y && aMax.y >= bMin.y;
        }

    }

}