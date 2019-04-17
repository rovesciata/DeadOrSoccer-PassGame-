using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DefenderController : MonoBehaviour {

    // ターゲットを入れる変数
    public GameObject target;
    // NavMeshAgentを入れる変数
    private NavMeshAgent agent;
    // ゾンビのスピードを入れる変数
    private float speed;
    // Animatorを入れる変数
    private Animator animator;
    // ボールを入れる変数
    public GameObject ball;
    // Scoreクラスを入れる変数
    Score scoreScript;
    // スコアGUIを入れる変数
    GameObject scoreGUI;

    // Use this for initialization
    void Start()
    {
        // NavMeshAgentを取得
        agent = GetComponent<NavMeshAgent>();
        // Animatorを取得
        animator = GetComponent<Animator>();
        // ゾンビのスピード初期値
        speed = 1f;
        // ボールを取得
        ball = GameObject.Find("Ball");
        // Score GUIを取得
        scoreGUI = GameObject.Find("Score GUI");
        // Scoreクラスを取得
        scoreScript = scoreGUI.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        // ボールとゾンビの距離が3以下ならゾンビのスピードを早くする
        if (Mathf.Abs(ball.transform.position.x - transform.position.x) < 3 || Mathf.Abs(ball.transform.position.z - transform.position.z) < 3)
        {
            // パス回数によってゾンビのスピードを変える
            if (scoreScript.score < 10)
            {
                // ターゲットの位置を目的地に設定する
                agent.destination = target.transform.position;
                agent.speed = 0.5f;
            }
            else if (scoreScript.score >= 10 && scoreScript.score < 20)
            {
                agent.destination = target.transform.position;
                agent.speed = 1f;
            }
            else if (scoreScript.score >= 20 && scoreScript.score < 40)
            {
                agent.destination = target.transform.position;
                agent.speed = 5f;
                // ゾンビが巨大化する
                transform.localScale = new Vector3(2, 2, 2);
            }
            else if (scoreScript.score >= 40 && scoreScript.score < 70)
            {
                agent.destination = target.transform.position;
                agent.speed = 15f;
                transform.localScale = new Vector3(3, 3, 3);
            }
            else
            {
                agent.destination = target.transform.position;
                agent.speed = 200f;
                transform.localScale = new Vector3(4, 4, 4);
            }
        }
        // ボールとゾンビの距離が3以上ならゾンビは通常スピードで動く
        else
        {
            if (scoreScript.score < 10)
            {
                agent.destination = target.transform.position;
                agent.speed = 0.1f;
            }
            else if (scoreScript.score >= 10 && scoreScript.score < 20)
            {
                agent.destination = target.transform.position;
                agent.speed = 0.5f;
            }
            else if (scoreScript.score >= 20 && scoreScript.score < 40)
            {
                agent.destination = target.transform.position;
                agent.speed = 1f;
                transform.localScale = new Vector3(2, 2, 2);
            }
            else if (scoreScript.score >= 40 && scoreScript.score < 70)
            {
                agent.destination = target.transform.position;
                agent.speed = 20f;
                transform.localScale = new Vector3(3, 3, 3);
            }
            else
            {
                agent.destination = target.transform.position;
                agent.speed = 150f;
                transform.localScale = new Vector3(4, 4, 4);
            }
        }
    }
    }
