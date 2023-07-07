using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextController : MonoBehaviour {
    public static Text scoreText;

    static int scoreLevel, flashCount;
    static float timer;
    static bool hasPlayed;

    void Start() {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        timer = 20;
        scoreLevel = 1;
        flashCount = 5;
        hasPlayed = false;
    }

    void Update() {
        
    }

    public static void ShowScore(int score) {
        if (score >= scoreLevel * 100) {
            if (!hasPlayed) {
                SoundManager.PlaySound("levelup");
                scoreText.text = "Score: " + (scoreLevel * 100);
                hasPlayed = true;
            }
            if (timer > 0)
                timer -= Time.deltaTime * 60;
            else if (flashCount > 0) {
                if (flashCount % 2 == 1) scoreText.text = "";
                else scoreText.text = "Score: " + (scoreLevel * 100);
                flashCount --;
                timer = 20;
            }
            else {
                timer = 20;
                flashCount = 5;
                hasPlayed = false;
                scoreLevel ++;
            }
        }
        else scoreText.text = "Score: " + score;
    }
}
