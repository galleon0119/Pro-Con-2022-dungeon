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

        void Start()
        {
            StartCoroutine(Set());//コルーチン（関数の呼び出しを待つ機能）を利用できるようにする
        }
        private IEnumerator Set()
        {
            yield return new WaitUntil(() => Input.anyKeyDown);//必須。これがないとスタート画面の時点で関数が呼び出される

        }
    }

