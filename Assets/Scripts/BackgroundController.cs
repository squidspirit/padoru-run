using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
    public float speedMultiplier;
    public float moveSpeedBase;
    public float layer;
    public GameObject backgroundPrefab;

    float moveSpeed;
    bool passedHalf = false;

    void Start() {
        
    }

    void Update() {
        moveSpeed = ((float)PlayerController.Score * speedMultiplier + 1.0f) * moveSpeedBase;
        this.gameObject.transform.position += new Vector3(-moveSpeed * Time.deltaTime * 60, 0, 0);
        if (this.gameObject.transform.position.x < 0 && !passedHalf) {
            Instantiate(backgroundPrefab, new Vector3(this.gameObject.transform.position.x + 19.2f, 0.25f, layer), Quaternion.identity);
            passedHalf = true;
        }
        else if (this.gameObject.transform.position.x < -19.2f) {
            Destroy(this.gameObject);
        }
    }
}
