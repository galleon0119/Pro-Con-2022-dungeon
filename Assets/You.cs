using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class You : MonoBehaviour
{
    //player�X�N���v�g����֐����g����悤�ɂ���
    [SerializeField]
    private Player player;
    //GameData�X�N���v�g����"hidane"��"yagura"�̏�������Ă����悤�ɂ���
    [SerializeField]
    private GameData gameData;
    private Collider2D col;
    Rigidbody2D rb2D;
    string uptag, downtag, lefttag, righttag;
    Function func = new Function();



    void Start()
    {
        StartCoroutine(Set());//�R���[�`���i�֐��̌Ăяo����҂@�\�j�𗘗p�ł���悤�ɂ���
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
        yield return new WaitUntil(() => Input.anyKeyDown);//�K�{�B���ꂪ�Ȃ��ƃX�^�[�g��ʂ̎��_�Ŋ֐����Ăяo�����

        ///////////////////////////////////���̉��ɃX�N���v�g�����Ă�������
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

