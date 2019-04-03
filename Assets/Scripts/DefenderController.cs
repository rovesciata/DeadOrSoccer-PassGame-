using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DefenderController : MonoBehaviour {

    public GameObject target;
    private NavMeshAgent agent;
    private float speed;
    private Animator animator;
    public GameObject ball;
    Score scoreScript;
    GameObject scoreGUI;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        speed = 1f;
        ball = GameObject.Find("Ball");
        scoreGUI = GameObject.Find("Score GUI");
        scoreScript = scoreGUI.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        // パス回数によってゾンビのスピードを変える
        if (Mathf.Abs(ball.transform.position.x - transform.position.x) < 3 || Mathf.Abs(ball.transform.position.z - transform.position.z) < 3)
        {
            if (scoreScript.score < 10)
            {
                // ターゲットの位置を目的地に設定する
                agent.destination = target.transform.position;
                agent.speed = 0.5f;
                //animator.SetBool("Running", true);
            }
            else if (scoreScript.score >= 10 && scoreScript.score < 20)
            {
                // ターゲットの位置を目的地に設定する
                agent.destination = target.transform.position;
                agent.speed = 1f;
                //animator.SetBool("Running", true);
            }
            else if (scoreScript.score >= 20 && scoreScript.score < 40)
            {
                agent.destination = target.transform.position;
                agent.speed = 5f;
                //animator.SetBool("Running", true);
                transform.localScale = new Vector3(2, 2, 2);
            }
            else if (scoreScript.score >= 40 && scoreScript.score < 70)
            {
                agent.destination = target.transform.position;
                agent.speed = 15f;
                //animator.SetBool("Running", true);
                transform.localScale = new Vector3(3, 3, 3);
            }
            else
            {
                agent.destination = target.transform.position;
                agent.speed = 200f;
                //animator.SetBool("Running", true);
                transform.localScale = new Vector3(4, 4, 4);
            }
        }
        else
        {
            if (scoreScript.score < 10)
            {
                // ターゲットの位置を目的地に設定する
                agent.destination = target.transform.position;
                agent.speed = 0.1f;
                //animator.SetBool("Running", true);
            }
            else if (scoreScript.score >= 10 && scoreScript.score < 20)
            {
                // ターゲットの位置を目的地に設定する
                agent.destination = target.transform.position;
                agent.speed = 0.5f;
                //transform.localScale = new Vector3(2, 2, 2);
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
                //animator.SetBool("Running", true);
                transform.localScale = new Vector3(4, 4, 4);
            }
        }
    }
    }
