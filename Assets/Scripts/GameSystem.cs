using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    // KICK OFFボタンを押したら実行する
    public void GameStart()
    {
        // ゲーム画面へ移動
        SceneManager.LoadScene("Main");
    }
}

