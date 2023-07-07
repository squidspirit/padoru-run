using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {
    public float jumpSpeed;

    static int score;
    bool onGround, isDead, isPause;
    float timeAccumulate, backgroundPos;
    Rigidbody2D rigid2D;
    Transform trans;

    void Start() {
        rigid2D = this.gameObject.GetComponent<Rigidbody2D>();
        trans = this.gameObject.GetComponent<Transform>();
        score = 0;
        isDead = false;
        isPause = false;
        timeAccumulate = Time.time;
    }

    void Update() {
        if (!isDead) {
            if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && onGround) {
                SoundManager.PlaySound("jump");
                rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpSpeed);
                onGround = false;
            }
            if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && !onGround)
                rigid2D.velocity = new Vector2(rigid2D.velocity.x, -jumpSpeed);
            if (trans.position.x > 8.9f)
                trans.position = new Vector3(trans.position.x - 17.8f, trans.position.y, trans.position.z);
            if (trans.position.x < -8.9f)
                trans.position = new Vector3(trans.position.x + 17.8f, trans.position.y, trans.position.z);
            score = (int)((Time.time - timeAccumulate) * 12.0f);
            ScoreTextController.ShowScore(score);
        }
        else if (!isPause){
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) {
                SceneManager.LoadScene("MainScenes");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Ground")
            onGround = true;
        if (coll.gameObject.tag == "Barrier") {
            SoundManager.PlaySound("die");
            GameObject.Find("Ground").GetComponent<BarrierGenerator>().enabled = false;
            GameObject.Find("BGM").GetComponent<AudioSource>().enabled = false;
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Barrier").Length; i ++)
                GameObject.FindGameObjectsWithTag("Barrier")[i].GetComponent<BarrierController>().enabled = false;
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Background").Length; i ++)
                GameObject.FindGameObjectsWithTag("Background")[i].GetComponent<BackgroundController>().enabled = false;
            GameObject.Find("Score").GetComponent<Text>().text = "Score: " + score;
            rigid2D.velocity = new Vector2(0, 0);
            rigid2D.isKinematic = true;
            isDead = true;
            StartCoroutine(Coroutine());
        }
    }

    public static int Score {
        get { return score; }
        set { score = value; }
    }

    IEnumerator Coroutine() {
        isPause = true;
        yield return new WaitForSeconds(1);
        isPause = false;
    }
}
