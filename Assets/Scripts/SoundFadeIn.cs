using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFadeIn : MonoBehaviour {
    public float fadeTime;
    
    AudioSource audioSC;
    float volAcc;
    bool isPause = true, start = true;

    void Start() {
        audioSC = this.gameObject.GetComponent<AudioSource>();
        audioSC.volume = 0;
        audioSC.enabled = false;
        volAcc = 1f / (fadeTime * 60f);
    }

    void Update() {
        if (start) StartCoroutine(Coroutine());
        if (!isPause) {
            audioSC.volume += volAcc;
            if (audioSC.volume >= 1)
                this.enabled = false;
        }
    }

    IEnumerator Coroutine() {
        start = false;
        yield return new WaitForSeconds(0.3f);
        audioSC.enabled = true;
        isPause = false;
    }
}
