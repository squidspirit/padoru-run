using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class StartPlayerController : MonoBehaviour {
    public float jumpSpeed;

    bool isJumped;
    Rigidbody2D rigid2D;
    Transform trans;

    void Start() {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Background").Length; i ++)
            GameObject.FindGameObjectsWithTag("Background")[i].GetComponent<BackgroundController>().enabled = false;
        rigid2D = this.gameObject.GetComponent<Rigidbody2D>();
        trans = this.gameObject.GetComponent<Transform>();
        isJumped = false;
    }

    void Update() {
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && !isJumped) {
            SoundManager.PlaySound("jump");
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpSpeed);
            isJumped = true;
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Ground" && isJumped) {
            StartCoroutine(Coroutine());
        }
    }

    IEnumerator Coroutine() {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("MainScenes");
    }
}
