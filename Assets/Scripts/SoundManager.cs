using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static AudioClip jumpSound, dieSound, levelupSound;
    static AudioSource audioSrc;
    
    void Start() {
        jumpSound = Resources.Load<AudioClip>("jump");
        dieSound = Resources.Load<AudioClip>("die");
        levelupSound = Resources.Load<AudioClip>("levelup");
        audioSrc = GetComponent<AudioSource>();
    }

    void Update() {
        
    }

    public static void PlaySound(string clip) {
        switch (clip) {
        case "jump":
            audioSrc.PlayOneShot(jumpSound, 5);
            break;
        case "die":
            audioSrc.PlayOneShot(dieSound);
            break;
        case "levelup":
            audioSrc.PlayOneShot(levelupSound);
            break;
        default:
            break;
        }
    }
}
