using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;





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


    //�L�[�������s�ׂ��֐��Ƃ��Ă��܂�
    private WaitUntil WaitAnyKey => new WaitUntil(() => Input.anyKeyDown);
    private WaitForSeconds WaitNext => new WaitForSeconds(5.0f);


    // Start is called before the first frame update
    void Start()
    {
        state = GAME_STATE.TITLE;
        StartCoroutine(GameLoop());
        EnemySpawn();
        CreateObject("player", new Vector3(0, 0, 0));

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

                    if (TimeUI.time <= 0)
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
                    yield return WaitAnyKey;
                    //��ʂ����Z�b�g����using��scenemamagment���K�v
                    SceneManager.LoadScene(0);
                    Time.timeScale = 1;
                    break;
            }
            yield return null;
        }
    }
    void CreateObject(string PrefabObjectName, Vector3 vector3)
    {
        // �v���n�u��GameObject�^�Ŏ擾
        GameObject obj = (GameObject)Resources.Load(PrefabObjectName);
        // �v���n�u�����ɁA�����̍��W�ɃC���X�^���X�𐶐��A
        Instantiate(obj, vector3, Quaternion.identity);
    }
    void EnemySpawn()
    {
        int randam = Random.Range(0, 4);
        if (randam == 0)
        {
            CreateObject("eagle", new Vector3(-7.5f, 3.5f, 0f));
        }
        else if (randam == 1)
        {
            CreateObject("eagle", new Vector3(-7.5f, -3.5f, 0f));
        }
        else if (randam == 2)
        {
            CreateObject("eagle", new Vector3(7.5f, 3.5f, 0f));
        }
        else
        {
            CreateObject("eagle", new Vector3(7.5f, -3.5f, 0f));
        }
    }
}


