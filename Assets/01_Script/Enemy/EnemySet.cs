using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySet : MonoBehaviour
{
    EnemySingle[] enemySingles;
    int enemyCount = 0;
    int leftEnemyCount = 0;
    Rigidbody2D rigid;
    Spawner spawner;
    int enemySingleHp;
    int enemySpeed;
    int enemySIngleScore;
    int enemySingleCoin;
    int bouncePower=2;



    Vector2 moveVector = Vector2.zero;

    private void Awake()
    {
        if(enemySingles == null)
        {
            FindEnemySingles();
        }
        rigid=GetComponent<Rigidbody2D>();
        spawner = transform.parent.GetComponent<Spawner>();
        
    }
    void FindEnemySingles()
    {
        enemySingles = new EnemySingle[transform.childCount];
        enemyCount = transform.childCount;
        leftEnemyCount = transform.childCount;
        for (int i = 0; i < enemyCount; i++)
        {
            enemySingles[i] = transform.GetChild(i).GetComponent<EnemySingle>();
        }
    }
    private void Start()
    {
        UIManager.instance.UiPrograssUpdate(0);
    }
    private void OnEnable()
    {
        if (spawner != null)
        {
            InitializeSetting();
        }
        else
        {
            
            InitializeSetting();
        }
    }
    void InitializeSetting()
    {
        if(enemySingles==null)
            FindEnemySingles();

        transform.position = spawner.GetStartPosition();
        enemySingleHp = spawner.GetHp();
        enemySingleCoin = spawner.GetCoin();
        enemySIngleScore = spawner.GetScore();
        enemySpeed = spawner.GetSpeed();
        moveVector = new(0, -enemySpeed);

        leftEnemyCount = transform.childCount;

        for (int i = 0; i < enemySingles.Length; i++)
        {
            enemySingles[i].enemySingleDie += EnemySingleCountDown;
            enemySingles[i].gameObject.SetActive(true);
            enemySingles[i].EnemySingleSetHp(enemySingleHp);
            enemySingles[i].EnemySingleSetCoin(enemySingleCoin);
            enemySingles[i].EnemySingleSetScore(enemySIngleScore);
        }

        if(UIManager.instance != null)
            UIManager.instance.UiPrograssUpdate(0);
    }
    void EnemySingleCountDown()
    {
        leftEnemyCount--;
        
        if(leftEnemyCount==0)
        {
            gameObject.SetActive(false);        //죽음 처리를 active false로 처리.
            UIManager.instance.UiPrograssUpdate(1);
        }
        else
        {
            UIManager.instance.UiPrograssUpdate( 1f - (float)leftEnemyCount / enemyCount);
        }
    }

    private void FixedUpdate()
    {
        if (rigid.velocity.y > moveVector.y)
        {
            //Debug.Log($"EnemySet.velocity : {rigid.velocity} / {(Vector2)transform.position + moveVector}");
            rigid.AddForce(moveVector * Time.fixedDeltaTime , ForceMode2D.Impulse);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < enemySingles.Length; i++)
            enemySingles[i].enemySingleDie -= EnemySingleCountDown;
        spawner.EnemySetDie();
    }

    public void EnemyBounce()
    {
        Debug.Log("Bounce");
        rigid.velocity = Vector2.zero;
        rigid.AddForce(-moveVector, ForceMode2D.Impulse);
    }
    public void EnemyTouch()
    {
        Debug.Log("Touch");
        rigid.velocity=Vector2.zero;
    }

    //자식이 disable될 때마다 카운터
}
