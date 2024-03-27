using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PhxEngine2D;

public class Sample_Phx2D : MonoBehaviour {

    [SerializeField] GameObject circle;
    [SerializeField] GameObject floor;

    RBEntity rbCircle;
    RBEntity floorSquare;

    Phx2D phx;

    void Start() {

        phx = new Phx2D();

        rbCircle = phx.Add(1, ShapeType.Circle, new Vector2(1, 1));
        rbCircle.gravityScale = 1;
        rbCircle.position = circle.transform.position;

        floorSquare = phx.Add(2, ShapeType.Square, new Vector2(10, 1));
        floorSquare.gravityScale = 0;
        floorSquare.position = floor.transform.position;
        floorSquare.isStatic = true;

    }

    void Update() {

        float dt = Time.deltaTime;
        phx.Tick(dt);

        circle.transform.position = rbCircle.position;
        floor.transform.position = floorSquare.position;

    }

    // Unity 生命周期函数
    // 它只在 Editor 下生效
    void OnDrawGizmos() {
        rbCircle?.DrawGizmos();
        floorSquare?.DrawGizmos();
    }

}
