using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PhxEngine2D;

public class Sample_Phx2D : MonoBehaviour {

    [SerializeField] GameObject circle;
    [SerializeField] GameObject circle2;
    [SerializeField] GameObject floor;

    RBEntity rbCircle;
    RBEntity rbCircle2;
    RBEntity floorSquare;

    Phx2D phx;

    void Start() {

        phx = new Phx2D();
        phx.OnIntersectEnterHandle = (a, b) => {
            Debug.Log("OnIntersectEnter: " + a.id + " & " + b.id);
        };

        phx.OnIntersectStayHandle = (a, b) => {
            Debug.Log("OnIntersectStay: " + a.id + " & " + b.id);
        };

        phx.OnIntersectExitHandle = (a, b) => {
            Debug.Log("OnIntersectExit: " + a.id + " & " + b.id);
        };

        rbCircle = phx.Add(1, ShapeType.Circle, new Vector2(2, 1));
        rbCircle.gravityScale = 1;
        rbCircle.position = circle.transform.position;

        rbCircle2 = phx.Add(2, ShapeType.Circle, new Vector2(2, 1));
        rbCircle2.gravityScale = 1;
        rbCircle2.position = circle2.transform.position;
        rbCircle2.isStatic = true;

        floorSquare = phx.Add(3, ShapeType.Square, new Vector2(10, 1));
        floorSquare.gravityScale = 0;
        floorSquare.position = floor.transform.position;
        floorSquare.isStatic = true;

    }

    void Update() {

        float dt = Time.deltaTime;
        phx.Tick(dt);

        circle.transform.position = rbCircle.position;
        circle2.transform.position = rbCircle2.position;
        floor.transform.position = floorSquare.position;

    }

    // Unity 生命周期函数
    // 它只在 Editor 下生效
    void OnDrawGizmos() {
        rbCircle?.DrawGizmos();
        rbCircle2?.DrawGizmos();
        floorSquare?.DrawGizmos();
    }

}
