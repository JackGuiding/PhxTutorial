using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PhxEngine2D;

public class Sample_Phx2D : MonoBehaviour {

    [SerializeField] GameObject circle;
    RBEntity rbCircle;

    Phx2D phx;

    void Start() {

        phx = new Phx2D();

        rbCircle = phx.Add(1);
        rbCircle.gravityScale = 1;
        rbCircle.position = circle.transform.position;

    }

    void Update() {

        float dt = Time.deltaTime;
        phx.Tick(dt);

        circle.transform.position = rbCircle.position;

    }

}
