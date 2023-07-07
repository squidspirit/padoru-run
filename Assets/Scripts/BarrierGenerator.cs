using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierGenerator : MonoBehaviour {
    public int generateChance;
    public float randomTimeSpeed;
    public float generateBreakTime;
    public GameObject barrierPrefab;

    float breakTimeLeft = 0;
    float timer = 0;

    void Start() {
        
    }

    void Update() {
        if (generateChance < 0) generateChance = 0;
        if (timer <= 0) {
            timer = randomTimeSpeed;
            if (Random.Range(0, generateChance) == 0 && breakTimeLeft <= 0) {
                Instantiate(barrierPrefab, new Vector3(10f, -2.4f, 0), Quaternion.identity);
                breakTimeLeft = generateBreakTime;
            }
        }
        if (breakTimeLeft > 0)
            breakTimeLeft -= Time.deltaTime * 60.0f;
        timer -= Time.deltaTime * 60.0f;
    }
}
