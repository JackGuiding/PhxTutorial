using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhxEngine2D {

    // 对现实的模拟
    // 在游戏当中, 通常对圆、矩形、(多边形)等进行模拟
    public class Phx2D {

        SortedList<int, RBEntity> all;

        HashSet<ulong> intersectedSet;

        public Vector2 gravity;

        public Action<RBEntity, RBEntity> OnIntersectEnterHandle; // 交叉开始
        public Action<RBEntity, RBEntity> OnIntersectStayHandle; // 交叉持续
        public Action<RBEntity, RBEntity> OnIntersectExitHandle; // 交叉结束

        public Phx2D() {
            gravity = new Vector2(0, -9.8f);
            intersectedSet = new HashSet<ulong>();
            all = new SortedList<int, RBEntity>();
        }

        public void Tick(float dt) {

            // 1. 应用引力
            foreach (RBEntity rb in all.Values) {
                // 速度
                if (rb.isStatic) {
                    continue;
                }
                rb.velocity += gravity * rb.gravityScale * dt;
            }

            // 2. 根据速度更新位置
            // s = 1/2 * g * t^2
            foreach (RBEntity rb in all.Values) {
                rb.position += rb.velocity * dt;
            }

            // 3. 交叉检测
            // AABB OBB Circle
            // 两两握手式遍历
            for (int i = 0; i < all.Count; i += 1) {
                RBEntity a = all.Values[i];
                for (int j = i + 1; j < all.Count; j += 1) {
                    RBEntity b = all.Values[j];

                    // a & b 之间检测
                    Intersect_RB_RB(a, b);

                }
            }
            // 4. 交叉检测事件触发
            // 5. 穿透恢复
            // 6. 穿透恢复事件触发

        }

        // 添加刚体
        public RBEntity Add(int id, ShapeType shapeType, Vector2 size) {
            RBEntity rb = new RBEntity();
            rb.id = id;
            rb.shapeType = shapeType;
            rb.size = size;
            all.Add(id, rb);
            return rb;
        }

        // 移除刚体

        // 查找刚体

        // RB & RB 检测
        void Intersect_RB_RB(RBEntity a, RBEntity b) {
            if (a.shapeType == ShapeType.Circle && b.shapeType == ShapeType.Circle) {
                // Circle & Circle
                bool isIntersected = IntersectionUtil.IsIntersected_Circle_Circle(a.position, a.size.x, b.position, b.size.x);
                if (isIntersected) {
                    // 本次交叉
                    a.isIntersected = true;
                    b.isIntersected = true;

                    ulong key = GetCombineKey(a.id, b.id);
                    if (intersectedSet.Contains(key)) {
                        // 如果上次交叉, 那么触发Stay
                        OnIntersectStayHandle.Invoke(a, b);
                    } else {
                        // 如果上次没有交叉, 那么触发Enter
                        intersectedSet.Add(key);
                        OnIntersectEnterHandle.Invoke(a, b);
                    }

                } else {
                    // 本次没交叉
                    // 如果上次交叉了, 那么触发Exit
                    ulong key = GetCombineKey(a.id, b.id);
                    if (intersectedSet.Contains(key)) {
                        intersectedSet.Remove(key);
                        OnIntersectExitHandle.Invoke(a, b);
                    }
                    a.isIntersected = false;
                    b.isIntersected = false;
                }
            } else if (a.shapeType == ShapeType.Square && b.shapeType == ShapeType.Square) {
                // Square & Square
            } else if (a.shapeType == ShapeType.Circle && b.shapeType == ShapeType.Square) {
                // Circle & Square
            } else if (a.shapeType == ShapeType.Square && b.shapeType == ShapeType.Circle) {
                // Square & Circle
            } else {
                Debug.LogError($"未知的形状{a.shapeType.ToString()} & {b.shapeType.ToString()}");
            }
        }

        // 二进制编码
        // 高级
        ulong GetCombineKey(int a, int b) {
            uint a_ = (uint)a;
            uint b_ = (uint)b;
            uint min = Math.Min(a_, b_);
            uint max = Math.Max(a_, b_);
            return ((ulong)min << 32) | max;
        }

    }

}