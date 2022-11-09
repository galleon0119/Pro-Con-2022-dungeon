using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject player;   //(����)�ړ��������I�u�W�F�N�g��ݒ�
    public GameObject Enemy;
    private Enemy Enemycs;
    private GameObject Time_Text;
    private Vector2 movePosition;�@//�ړ����鋗�����i�[
    public int speed = 1; //1�}�X���Ɉړ�����X�s�[�h
                          //�ړ��X�s�[�h�Ɠ_�ł̊Ԋu

    [SerializeField]
    private float flashInterval ;
    [System.NonSerialized]
    public int HP;
    [System.NonSerialized]
    public int Score;
    [SerializeField]
    private float PenaTime ;
    Rigidbody2D rb2D;
    public GameObject UIManager;
    [System.NonSerialized]
    public Vector2 moveY = new Vector2(0, 0.5f); //(1�}�X����)Y���̈ړ�����
    [System.NonSerialized]
    public Vector2 moveX = new Vector2(0.5f, 0); //(1�}�X����)X���̈ړ�����

    //�_�ł�����Ƃ��̃��[�v�J�E���g
    [SerializeField] int loopCount;
    //�_�ł����邽�߂�SpriteRenderer
    SpriteRenderer sp;
    
  
    enum STATE    //�v���C���[�̏�ԗp�񋓌^�i�m�[�}���A�_���[�W�A���G��3��ށj
    {
        NOMAL,
        DAMAGED,
        MUTEKI
    }
    //STATE�^�̕ϐ�
    STATE state;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        Time_Text = GameObject.Find("Time_Text");
        Enemycs = Enemy.GetComponent<Enemy>(); 
    }

    void Update()
    {
        //�ړ��ꏊ�ݒ�
        
        
            if (Input.GetKeyDown("up"))
            {
                MoveUp();
            }
            if (Input.GetKeyDown("down"))
            {
                MoveDown();

        }
            if (Input.GetKeyDown("right"))
            {
                MoveRight();
        }
            if (Input.GetKeyDown("left"))
            {
                MoveLeft();

        }
        

       
    }
    private void FixedUpdate()
    {
     
         rb2D.MovePosition(rb2D.position +( movePosition));
           
         movePosition = new Vector3(0, 0, 0);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Gem")
        {
            Score += 100;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Enemy")
        {
            Time_Text.GetComponent<TimeUI>().time -= PenaTime;
            if (state != STATE.NOMAL)
            {
                return;
            }
            //�R���[�`�����J�n
            state = STATE.DAMAGED;
            StartCoroutine(_hit());
            Enemycs.PlaerHit();

        }
    }
    public void MoveUp()
    {
        movePosition = moveY;   
    }
    public void MoveDown()
    {
        movePosition = -moveY;
    }
    public void MoveRight()
    {
        movePosition = moveX;
    }
    public void MoveLeft()
    { 
        movePosition = -moveX;
    }
    //�_�ł����鏈��
    IEnumerator _hit()
    {

        //�_�Ń��[�v�J�n
        for (int i = 0; i < loopCount; i++)
        {
            //flashInterval�҂��Ă���
            yield return new WaitForSeconds(flashInterval);
            //spriteRenderer���I�t
            sp.enabled = false;

            //flashInterval�҂��Ă���
            yield return new WaitForSeconds(flashInterval);
            //spriteRenderer���I��
            sp.enabled = true;
        }

        //���[�v����������state��NOMAL�ɂ���
        state = STATE.NOMAL;
       
    }

}