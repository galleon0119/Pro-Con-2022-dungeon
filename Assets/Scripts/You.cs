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

        void Start()
        {
            StartCoroutine(Set());//�R���[�`���i�֐��̌Ăяo����҂@�\�j�𗘗p�ł���悤�ɂ���
        }
        private IEnumerator Set()
        {
            yield return new WaitUntil(() => Input.anyKeyDown);//�K�{�B���ꂪ�Ȃ��ƃX�^�[�g��ʂ̎��_�Ŋ֐����Ăяo�����

        }
    }

