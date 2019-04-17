using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passing : MonoBehaviour
{
    // ボールの音を入れる変数
    AudioClip getBallSound;
    AudioSource audioSource;
    // スワイプの方向
    Vector2 startPos, endPos, direction;
    // x軸の強さを定義
    [SerializeField]
    float throwForceInX = 100f;
    // z軸の強さを定義
    [SerializeField]
    float throwForceInZ = 100f;
    // ボールのRigidbodyを入れる変数
    Rigidbody rb;
    // ボールを入れる変数
    GameObject ball;
    // Playerを入れる変数
    GameObject player;
    GameObject player1;
    GameObject player2;
    GameObject player3;
    // パスしたか判定
    public bool isPass = false;
    // Animatorを入れる変数
    private Animator animator;
    private Animator animator1;
    private Animator animator2;
    private Animator animator3;

    // Use this for initialization
    void Start()
    {
        // ボールの音を取得
        getBallSound = Resources.Load<AudioClip>("Audio/ball_hit_rnd_01");
        audioSource = transform.GetComponent<AudioSource>();
        // ボールを取得
        ball = GameObject.Find("Ball");
        // ボールのRigidbodyを取得
        rb = GetComponent<Rigidbody>();
        // プレイヤーを取得
        player = GameObject.Find("Player");
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        // Animatorを取得
        animator = player.GetComponent<Animator>();
        animator1 = player1.GetComponent<Animator>();
        animator2 = player2.GetComponent<Animator>();
        animator3 = player3.GetComponent<Animator>();
    }

    // パス(トラップした後パスできる)
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2" || col.gameObject.tag == "Player3" && isPass == false)
        {
            // タッチ開始時
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // タッチ開始時の位置を取得
                startPos = Input.GetTouch(0).position;
            }
            // 指を離した時
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                // 指を離した時の位置を取得
                endPos = Input.GetTouch(0).position;
                // スワイプの方向を取得(タッチ開始時 - 指を離した位置)
                direction = startPos - endPos;
                // 物理演算の影響を無効
                rb.isKinematic = false;

                // スワイプの長さがY軸よりX軸の方に長い時
                if (Mathf.Abs(direction.y) < Mathf.Abs(direction.x))
                {
                    // 右向きにフリック
                    if (30 < direction.x)
                    {
                        if (col.gameObject.tag == "Player3")
                        {
                            Invoke("PassRight3", 0.2f);
                        }
                        Invoke("PassRight", 0.2f);
                    }
                    // 左向きにフリック
                    else if (-30 > direction.x)
                    {
                        if (col.gameObject.tag == "Player3")
                        {
                            Invoke("PassLeft3", 0.2f);
                        }
                        Invoke("PassLeft", 0.2f);
                    }
                }
                // スワイプの長さがX軸よりY軸の方に長い時
                else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
                {
                    // 上向きにフリック
                    if (30 < direction.y)
                    {
                        if (col.gameObject.tag == "Player3")
                        {
                            Invoke("PassUp3", 0.2f);
                        }
                        Invoke("PassUp", 0.2f);
                    }
                    // 下向きにフリック
                    else if (-30 > direction.y)
                    {
                        if (col.gameObject.tag == "Player3")
                        {
                            Invoke("PassDown3", 0.2f);
                        }
                        Invoke("PassDown", 0.2f);
                    }
                }
                // ボールの音を鳴らす
                audioSource.PlayOneShot(getBallSound);

                // パスのアニメーションを実行
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

                // パスを有効
                isPass = true;
                // 0.1秒後にパスのアニメーションを無効
                Invoke("PassingFalse", 0.1f);
            }
        }
    }

    // 右へパス
    void PassRight3()
    {
        rb.AddForce(-direction.x * throwForceInX * 1.5f, 1f, 0f);
    }

    // 左へパス
    void PassLeft3()
    {
        rb.AddForce(-direction.x * throwForceInX * 1.5f, 1f, 0f);
    }

    // 上へパス
    void PassUp3()
    {
        rb.AddForce(0f, 1f, -direction.y * throwForceInZ * 1.5f);
    }

    // 下へパス
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

    // パスのアニメーションを無効
    void PassingFalse()
    {
        animator.SetBool("Passing", false);
        animator1.SetBool("Passing", false);
        animator2.SetBool("Passing", false);
        animator3.SetBool("Passing", false);
    }
}
