using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour
{

    // 時間設定
    public int timeCount;

    // Start is called before the first frame update
    void Start()
    {
        // 任意に設定した時間後、GoTitleメソッドを呼び出す(ポイント)
        Invoke("GoTitle", timeCount);
    }

    void GoTitle()
    {
        SceneManager.LoadScene("GameStart");
    }
}
