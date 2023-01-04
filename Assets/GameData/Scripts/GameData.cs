using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    public static GameData instance;

    // Start is called before the first frame update
    private void InitGame()
    {

        Debug.Log("Init Game");
    }
    /// <summary>
    /// 現在のゲームシーンを再読み込み
    /// </summary>
    /// <returns></returns>
    public IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1.0f);

        // 現在のゲームシーンを取得し、シーンの名前を使ってLoadScene処理を行う(再度、同じゲームシーンを呼び出す)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // 初期化 GameDataゲームオブジェクトはシーン遷移しても破棄されない設定になっていますので、ここで再度、初期化の処理を行う必要があります。
        InitGame();
    }
}
