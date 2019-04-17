using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ボールを入れる変数
    public GameObject ball;
    // ボールのRigidbodyを入れる変数
    Rigidbody ballRigidbody;
    // Passingクラスを入れる変数
    Passing passScript;
    // Animatorを入れる変数
    private Animator animator;
    // ゾンビの声を入れる変数
    AudioClip zombiVoice;
    AudioSource audioSource;
    // Scoreクラスを入れる変数
    Score scoreScript;
    // スコアGUIを入れる変数
    GameObject scoreGUI;

    // Use this for initialization
    void Start()
    {
        // ボールを取得
        ball = GameObject.Find("Ball");
        // ボールのRigidbodyを取得
        ballRigidbody = ball.GetComponent<Rigidbody>();
        // Passingクラスを取得
        passScript = ball.GetComponent<Passing>();
        // Animatorを取得
        animator = GetComponent<Animator>();
        // ゾンビの声を取得
        zombiVoice = Resources.Load<AudioClip>("voc_monster_attack_rnd_04");
        audioSource = transform.GetComponent<AudioSource>();
        // Score GUIを取得
        scoreGUI = GameObject.Find("Score GUI");
        // Scoreクラスを取得
        scoreScript = scoreGUI.GetComponent<Score>();
    }

    // トラップ(ボールがプレイヤーに当たったら止める)
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball" && passScript.isPass == true)
        {
            // ボールを止める
            Invoke("StopBall", 0f);
            passScript.isPass = false;
            // スコアを１追加
            FindObjectOfType<Score>().AddPoint(1);
            // 一定のスコアに到達すれば、ゾンビが声を出す
            if (scoreScript.score == 10 || scoreScript.score == 20 || scoreScript.score == 40 || scoreScript.score == 70)
            {
                audioSource.PlayOneShot(zombiVoice);
            }
        }
    }

    // ボールを止める
    void StopBall()
    {
        // ボールのスピードを0にする
        ballRigidbody.velocity = Vector3.zero;
        // ボールの回転を0にする
        ballRigidbody.angularVelocity = Vector3.zero;
    }
}
