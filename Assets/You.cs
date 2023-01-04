using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class You : MonoBehaviour
{
    //playerスクリプトから関数を使えるようにする
    [SerializeField]
    private Player player;
    //GameDataスクリプトから"hidane"や"yagura"の情報を取ってこれるようにする
    [SerializeField]
    private GameData gameData;
    private Collider2D col;
    Rigidbody2D rb2D;
    string uptag, downtag, lefttag, righttag;
    Function func = new Function();



    void Start()
    {
        StartCoroutine(Set());//コルーチン（関数の呼び出しを待つ機能）を利用できるようにする
    }
    private void Update()
    {
        uptag = player.Uptag();
        downtag = player.Downtag();
        lefttag = player.Lefttag();
        righttag = player.Righttag();
    }
    private IEnumerator Set()
    {
        yield return new WaitUntil(() => Input.anyKeyDown);//必須。これがないとスタート画面の時点で関数が呼び出される

        ///////////////////////////////////この下にスクリプト書いてください
        /*func.Tryori();
        for(int i = 0;i<100;i++ )
        {
            if(righttag == "Gem"|| righttag == "Item1")
            {
                player.MoveRight();
                yield return new WaitForFixedUpdate();
            }
            else if(uptag == "wall")
            {
                player.MoveLeft();
                yield return new WaitForFixedUpdate();

            }
            else
            {
                player.MoveUp();
                yield return new WaitForFixedUpdate();
            }
        }*/


    }
}

