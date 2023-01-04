using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Linq;                 // ���@<=�@�ǉ����܂�
using UnityEngine.Events;



public class GameManager : MonoBehaviour
{//�X�^�[�g�A�v���C���A�Q�[���I�[�o�[�̐ؑւ����s��
   
        //�Q�[���̏�ʂ�z��Ƃ��ď���
        enum GAME_STATE
        {
            TITLE,
            GAME_PLAY,
            GAME_CLEAR,
            GAME_OVER,
        }
        //��ʕύX��text���������悤�ɂ���
        [SerializeField]
        private GAME_STATE state;
        [SerializeField]
        private Text stateText;
        
        [SerializeField]
        private Player player;
 
        [SerializeField]
        private TimeUI TimeUI;
        //�����ݒ莞��
        public int initTime = 30;
        int time;

    [SerializeField]
    private ResultPopUp resultPopUp;


    //�L�[�������s�ׂ��֐��Ƃ��Ă��܂�
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
                        //TODO�@�N���A������Ȃ�R�����g�O��else if(player.score >=100)
                        break;
                    case GAME_STATE.GAME_CLEAR:
                        stateText.text = "GAME CLEAR";
                        yield return WaitNext;
                        break;
                    case GAME_STATE.GAME_OVER:
                        stateText.text = "GAME OVER";
                        //timescare��deltatime���X�g�b�v����0,1�Őؑւ��A�I�u�W�F�N�g���X�g�b�v����
                        Time.timeScale = 0;
                        Debug.Log("���U���g���e��\�����܂�");
                        
                        yield return WaitAnyKey;
                        SceneManager.LoadScene(0);
                        
                        Time.timeScale = 1;
                        break;
                }
                yield return null;
            }
        }
   
}


