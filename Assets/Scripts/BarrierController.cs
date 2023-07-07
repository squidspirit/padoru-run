using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour {
    public float speedMultiplier;
    public float moveSpeedBase;

    float moveSpeed;

    void Start() {
        
    }

    void Update() {
        moveSpeed = ((float)PlayerController.Score * speedMultiplier + 1.0f) * moveSpeedBase;
        this.gameObject.transform.position += new Vector3(-moveSpeed * Time.deltaTime * 60, 0, 0);
        if (this.gameObject.transform.position.x < -10)
            Destroy(this.gameObject);
    }
}
