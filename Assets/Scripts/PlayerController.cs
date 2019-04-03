using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject ball;
    Rigidbody ballRigidbody;
    Passing passScript;
    private Animator animator;
    AudioClip zombiVoice;
    AudioSource audioSource;
    Score scoreScript;
    GameObject scoreGUI;

    // Use this for initialization
    void Start()
    {
        ball = GameObject.Find("Ball");
        ballRigidbody = ball.GetComponent<Rigidbody>();
        passScript = ball.GetComponent<Passing>();
        animator = GetComponent<Animator>();
        zombiVoice = Resources.Load<AudioClip>("voc_monster_attack_rnd_04");
        audioSource = transform.GetComponent<AudioSource>();
        scoreGUI = GameObject.Find("Score GUI");
        scoreScript = scoreGUI.GetComponent<Score>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball" && passScript.isPass == true)
        {
            //Invoke("StopBall", 0.05f);
            Invoke("StopBall", 0f);
            passScript.isPass = false;
            // スコア処理を追加
            FindObjectOfType<Score>().AddPoint(1);
            if (scoreScript.score == 10 || scoreScript.score == 20 || scoreScript.score == 40 || scoreScript.score == 70)
            {
                audioSource.PlayOneShot(zombiVoice);
            }
        }
    }

    void StopBall()
    {
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
    }
}
