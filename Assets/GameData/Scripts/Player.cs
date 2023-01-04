using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject player;   //(操作)移動したいオブジェクトを設定
    public GameObject Enemy;
    private Enemy Enemycs;
    private GameObject Time_Text;
    private Vector2 movePosition;　//移動する距離を格納
    public int speed = 1; //1マス毎に移動するスピード
                          //移動スピードと点滅の間隔

    [SerializeField]
    private float flashInterval ;
    [System.NonSerialized]
    public int HP;
    [System.NonSerialized]
    static public int Score;
    [System.NonSerialized]
    static public float time;
    [SerializeField]
    private float PenaTime ;
    Rigidbody2D rb2D;
    public GameObject UIManager;
    [System.NonSerialized]
    public Vector2 moveY = new Vector2(0, 1f); //(1マス毎の)Y軸の移動距離
    [System.NonSerialized]
    public Vector2 moveX = new Vector2(1f, 0); //(1マス毎の)X軸の移動距離

    //点滅させるときのループカウント
    [SerializeField] int loopCount;
    //点滅させるためのSpriteRenderer
    SpriteRenderer sp;
    
  
    enum STATE    //プレイヤーの状態用列挙型（ノーマル、ダメージ、無敵の3種類）
    {
        NOMAL,
        DAMAGED,
        MUTEKI
    }
    //STATE型の変数
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
        //移動場所設定
        
        
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

        Uptag();
        Downtag();
        Lefttag();
        Righttag();
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Gem")
        {
            Score += 100;
            Debug.Log(Score);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Item1")
        {
            collision.GetComponent<SpriteRenderer>().enabled = false;//画像非表示
            collision.enabled = false;                               //あたり判定off　

            StartCoroutine(item1());//コルーチン利用

            Destroy(collision.gameObject);

        }
        else if(collision.gameObject.tag == "Enemy")
        {
            Time_Text.GetComponent<TimeUI>().time -= PenaTime;
            time = Time_Text.GetComponent<TimeUI>().time;
            if (state != STATE.NOMAL)
            {
                return;
            }
            //コルーチンを開始
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
    //点滅させる処理
    IEnumerator _hit()
    {

        //点滅ループ開始
        for (int i = 0; i < loopCount; i++)
        {
            //flashInterval待ってから
            yield return new WaitForSeconds(flashInterval);
            //spriteRendererをオフ
            sp.enabled = false;

            //flashInterval待ってから
            yield return new WaitForSeconds(flashInterval);
            //spriteRendererをオン
            sp.enabled = true;
        }

        //ループが抜けたらstateをNOMALにする
        state = STATE.NOMAL;
       
    }
    public string  Uptag()
    {
        Collider2D hitCollider;
        hitCollider =Physics2D.OverlapPoint(this.transform.position + new Vector3 (0,1));
        if(hitCollider == null)
        {
            return "error";
        }

        /*Debug.Log(hitCollider.gameObject.GetComponent<Collider2D>());
        Debug.Log(hitCollider.gameObject.transform.position);*/

        return (hitCollider.gameObject.tag);
       
    }
    public string Downtag()
    {
        Collider2D hitCollider;
        hitCollider = Physics2D.OverlapPoint(this.transform.position + new Vector3(0, -1));
        if (hitCollider == null)
        {
            return "error";
        }

        /*Debug.Log(hitCollider.gameObject.GetComponent<Collider2D>());
        Debug.Log(hitCollider.gameObject.transform.position);*/

        return (hitCollider.gameObject.tag);

    }
    public string Righttag()
    {
        Collider2D hitCollider;
        hitCollider = Physics2D.OverlapPoint(this.transform.position + new Vector3(1, 0));
        if (hitCollider == null)
        {
            return "error";
        }

        /*Debug.Log(hitCollider.gameObject.GetComponent<Collider2D>());
        Debug.Log(hitCollider.gameObject.transform.position);*/

        return (hitCollider.gameObject.tag);

    }
    public string Lefttag()
    {
        Collider2D hitCollider;
        hitCollider = Physics2D.OverlapPoint(this.transform.position + new Vector3(-1, 0));
        if (hitCollider == null)
        {
            return "error";
        }

        /*Debug.Log(hitCollider.gameObject.GetComponent<Collider2D>());
        Debug.Log(hitCollider.gameObject.transform.position);*/

        return (hitCollider.gameObject.tag);

    }
    IEnumerator item1()
    {
        Time.timeScale = 2;
        yield return new WaitForSeconds(3);
        Time.timeScale = 1;
    }
}