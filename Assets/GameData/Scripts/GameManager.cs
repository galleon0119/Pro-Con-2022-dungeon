using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Linq;                 // ☆　<=　追加します
using UnityEngine.Events;



public class GameManager : MonoBehaviour
{//スタート、プレイ中、ゲームオーバーの切替えを行う
   
        //ゲームの場面を配列として準備
        enum GAME_STATE
        {
            TITLE,
            GAME_PLAY,
            GAME_CLEAR,
            GAME_OVER,
        }
        //場面変更とtextをいじれるようにする
        [SerializeField]
        private GAME_STATE state;
        [SerializeField]
        private Text stateText;
        
        [SerializeField]
        private Player player;
 
        [SerializeField]
        private TimeUI TimeUI;
        //初期設定時間
        public int initTime = 30;
        int time;

    [SerializeField]
    private ResultPopUp resultPopUp;


    //キーを押す行為を関数としてしまう
    private WaitUntil WaitAnyKey => new WaitUntil(() => Input.anyKeyDown);
        private WaitForSeconds WaitNext => new WaitForSeconds(5.0f);


        // Start is called before the first frame update
        void Start()
        {
            state = GAME_STATE.TITLE;
            StartCoroutine(GameLoop());
        }

        private IEnumerator GameLoop()
        {
            while (true)
            {
                switch (state)
                {
                    case GAME_STATE.TITLE:
                        stateText.text = "GAME START";
                        yield return WaitAnyKey;
                        state = GAME_STATE.GAME_PLAY;
                        break;
                    case GAME_STATE.GAME_PLAY:
                        stateText.text = "";

                    if (TimeUI.time <=  0 )
                        {
                            state = GAME_STATE.GAME_OVER;
                        TimeUI.time = 0.0f;

                        }
                        //TODO　クリアさせるならコメント外しelse if(player.score >=100)
                        break;
                    case GAME_STATE.GAME_CLEAR:
                        stateText.text = "GAME CLEAR";
                        yield return WaitNext;
                        break;
                    case GAME_STATE.GAME_OVER:
                        stateText.text = "GAME OVER";
                        //timescareはdeltatimeをストップする0,1で切替え、オブジェクトをストップする
                        Time.timeScale = 0;
                        Debug.Log("リザルト内容を表示します");
                        
                        yield return WaitAnyKey;
                        SceneManager.LoadScene(0);
                        
                        Time.timeScale = 1;
                        break;
                }
                yield return null;
            }
        }
   
}


