using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    // ゾンビに当たればゲームオーバー
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Defender")
        {
            // ハイスコアの保存
            FindObjectOfType<Score>().Save();
            Invoke("GoToGameOver", 1f);
        }
    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
