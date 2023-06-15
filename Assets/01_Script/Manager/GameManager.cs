
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    PlayerController player;
    EnemySet enemySet;
    EnemySingle enemySingle;
    ParticleSystem[] particle;
    int particleIndex = 0;
    PlayerHitEffect[] hitEffects;
    int hitEffectIndex = 0;
    Spawner spawner;
    //---------------------------------------------------------------------------------------------------

    private void Awake()
    {
        if (instance == null)
            instance = this;
        particle = new ParticleSystem[transform.GetChild(0).childCount];
        for(int i=0;i< particle.Length;i++)
            particle[i] = transform.GetChild(0).GetChild(i).GetComponent<ParticleSystem>();

        hitEffects = new PlayerHitEffect[transform.GetChild(1).childCount];
        for(int i=0;i<hitEffects.Length;i++)
            hitEffects[i]=transform.GetChild(1).GetChild(i).GetComponent<PlayerHitEffect>();
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();

    }

    private void Start()
    {
        if (player == null)
            TakePlayerController();
        UIManager.instance.NextStageReady();
    }
    public PlayerController TakePlayerController()
    {
        if(player==null)
            player= FindObjectOfType<PlayerController>();
        
        return player;
    }
    public void RecivePlayerController(PlayerController player)
    {
        //PlayerController가 Awake단계에서 GameManager에게 player 자신을 넘겨주는데, 실패할 경우 Start에서 다시 찾을 예정
        this.player = player;
    }
    public PlayerController GivePlayerController()
    {
        if(player!=null)
            return this.player;
        else
            return TakePlayerController();
    }

    //-----------------------------------Player Behavior-------------------------------------------------
    public void PlayerAttack()
    {
        //Debug.Log("GameManager : PlayerAttack()");
        player.PlayerAttack();
        AudioManager.instance.PlayerAttackSound();
    }
    public void PlayerJump()
    {
        //Debug.Log("GameManager : PlayerJump()");
        player.PlayerJump();
    }
    public void PlayerGuard(bool behavior)
    {
        //Debug.Log("GameManager : PlayerShield()");
        if (behavior == true)
            player.PlayerGuardOn();
        else
            player.PlayerGuardOff();
    }
    public void PlayerLanding()
    {
        //Debug.Log("GameManager : PlayerLanding()");
        player.PlayerLanding();
    }
    public void PlayerUnLanding()
    {
        //Debug.Log("GameManager : PlayerUnLanding()");
        player.PlayerUnLanding();
    }
    
    public void PlayerGuardSuccess(GameObject obj,float cooltime)
    {
        //obj에는 가드에 성공한 게임 오브젝트가 넘어온다. 그 친구에게 접근해서 위로 튕길 수 있또록 해야 함

        if (enemySet == null)
            enemySet = obj.transform.parent.GetComponent<EnemySet>();
        else if (enemySet.gameObject != obj)
            enemySet = obj.transform.parent.GetComponent<EnemySet>();
        enemySet.EnemyBounce();
        AudioManager.instance.PlayerGuardSound();

        //쿨타임 적용할 것
        //UIManager에게 일임
        UIManager.instance.UiGuardCoolTimeEffect(cooltime);       //가드 쿨타임 적용.
        player.PlayerGuardOff();        //가드를 성공했으니, 가드 상태를 강제 종료시킴.

    }
    public void PlayerGuardFail(GameObject obj)
    {
        if (enemySet == null)
            enemySet = obj.transform.parent.GetComponent<EnemySet>();
        else if (enemySet.gameObject != obj)
            enemySet = obj.transform.parent.GetComponent<EnemySet>();
        //UIManager 에게 Heart감소 알림
        enemySet.EnemyBounce();
        AudioManager.instance.PlayerHitSound();
    }

    public void PlayerAttackEnemy(GameObject obj,int damage)
    {
        hitEffects[hitEffectIndex].transform.position =  obj.transform.position + new Vector3(Random.Range(-1f,1f),Random.Range(-0.5f,0.5f),0);
        hitEffects[hitEffectIndex].gameObject.SetActive(true);
        hitEffectIndex++;
        hitEffectIndex %= hitEffects.Length;

        if (enemySingle == null)
            enemySingle = obj.GetComponent<EnemySingle>();
        else if(enemySingle.gameObject != obj)
            enemySingle = obj.GetComponent<EnemySingle>();

        enemySingle.EnemySingleHit(damage);
    }

    public void PlayerTouchEnemy(GameObject obj)
    {

        if (enemySet == null)
            enemySet = obj.transform.parent.GetComponent<EnemySet>();
        else if (enemySet.gameObject != obj)
            enemySet = obj.transform.parent.GetComponent<EnemySet>();
        enemySet.EnemyTouch();
    }
    //-----------------------------------Player Behavior-------------------------------------------------
    public void EnemyDieEffect(Vector3 trans,int score, int coin)
    {
        UIManager.instance.UiScoreUpdate(score);
        UIManager.instance.UiCoinUpdate(coin);

        particle[particleIndex].transform.position = trans;
        particle[particleIndex].Play();
        particleIndex++;
        particleIndex %= particle.Length;
        AudioManager.instance.EnemyDieSound();
    }

    public void NextStageStart()
    {
        spawner.EnemySpawnStart();
    }


    public void GameRestart()
    {
        SceneManager.LoadScene(0);
    }
}
