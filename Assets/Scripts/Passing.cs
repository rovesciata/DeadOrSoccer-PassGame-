using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passing : MonoBehaviour
{

    AudioClip getBallSound;
    AudioSource audioSource;
    Vector2 startPos, endPos, direction;
    // x軸の強さを定義
    [SerializeField]
    float throwForceInX = 100f;
    // z軸の強さを定義
    [SerializeField]
    float throwForceInZ = 100f;
    Rigidbody rb;
    GameObject ball;
    GameObject player;
    GameObject player1;
    GameObject player2;
    GameObject player3;
    // パスしたか判定
    public bool isPass = false;
    private Animator animator;
    private Animator animator1;
    private Animator animator2;
    private Animator animator3;

    // Use this for initialization
    void Start()
    {
        getBallSound = Resources.Load<AudioClip>("Audio/ball_hit_rnd_01");
        audioSource = transform.GetComponent<AudioSource>();
        ball = GameObject.Find("Ball");
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        animator = player.GetComponent<Animator>();
        animator1 = player1.GetComponent<Animator>();
        animator2 = player2.GetComponent<Animator>();
        animator3 = player3.GetComponent<Animator>();
    }


    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2" || col.gameObject.tag == "Player3" && isPass == false)
        {
            //if (Input.GetKeyDown(KeyCode.RightArrow))
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startPos = Input.GetTouch(0).position;
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endPos = Input.GetTouch(0).position;
                direction = startPos - endPos;
                rb.isKinematic = false;
                // スワイプの方向にパスする
                //rb.AddForce(-direction.x * throwForceInX, 0f, -direction.y * throwForceInZ);
                if (Mathf.Abs(direction.y) < Mathf.Abs(direction.x))
                {
                    if (30 < direction.x)
                    {
                        if (col.gameObject.tag == "Player3")
                        {
                            Invoke("PassRight3", 0.2f);
                        }
                        // 右向きにフリック
                        Invoke("PassRight", 0.2f);
                    }
                    else if (-30 > direction.x)
                    {
                        if (col.gameObject.tag == "Player3")
                        {
                            Invoke("PassLeft3", 0.2f);
                        }
                        // 左向きにフリック
                        Invoke("PassLeft", 0.2f);
                    }
                }
                else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
                {
                    if (30 < direction.y)
                    {
                        if (col.gameObject.tag == "Player3")
                        {
                            Invoke("PassUp3", 0.2f);
                        }
                        // 上向きにフリック
                        Invoke("PassUp", 0.2f);
                    }
                    else if (-30 > direction.y)
                    {
                        if (col.gameObject.tag == "Player3")
                        {
                            Invoke("PassDown3", 0.2f);
                        }
                        // 下向きにフリック
                        Invoke("PassDown", 0.2f);
                    }
                }
                audioSource.PlayOneShot(getBallSound);
                if (col.gameObject.tag == "Player")
                {
                    animator.SetBool("Passing", true);
                }
                else if (col.gameObject.tag == "Player1")
                {
                    animator1.SetBool("Passing", true);
                }
                else if (col.gameObject.tag == "Player2")
                {
                    animator2.SetBool("Passing", true);
                }
                else if (col.gameObject.tag == "Player3")
                {
                    animator3.SetBool("Passing", true);
                }
                isPass = true;
                Invoke("PassingFalse", 0.1f);
            }
        }
    }

    void PassRight3()
    {
        rb.AddForce(-direction.x * throwForceInX * 1.5f, 1f, 0f);
    }

    void PassLeft3()
    {
        rb.AddForce(-direction.x * throwForceInX * 1.5f, 1f, 0f);
    }

    void PassUp3()
    {
        rb.AddForce(0f, 1f, -direction.y * throwForceInZ * 1.5f);
    }

    void PassDown3()
    {
        rb.AddForce(0f, 1f, -direction.y * throwForceInZ * 1.5f);
    }

    void PassRight()
    {
        rb.AddForce(-direction.x * throwForceInX, 1f, 0f);
    }

    void PassLeft()
    {
        rb.AddForce(-direction.x * throwForceInX, 1f, 0f);
    }

    void PassUp()
    {
        rb.AddForce(0f, 1f, -direction.y * throwForceInZ);
    }

    void PassDown()
    {
        rb.AddForce(0f, 1f, -direction.y * throwForceInZ);
    }

    void PassingFalse()
    {
        animator.SetBool("Passing", false);
        animator1.SetBool("Passing", false);
        animator2.SetBool("Passing", false);
        animator3.SetBool("Passing", false);
    }
}
