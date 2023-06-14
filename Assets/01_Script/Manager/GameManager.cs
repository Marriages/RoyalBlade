using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    PlayerController player;
    EnemyBase eb;
    //---------------------------------------------------------------------------------------------------

    private void Awake()
    {
        if (instance == null)
            instance = this;

    }

    private void Start()
    {
        if (player == null)
            TakePlayerController();
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
        if(eb==null)
            eb = obj.GetComponent<EnemyBase>();
        if (eb.gameObject!=obj)
            eb = obj.GetComponent<EnemyBase>();
        eb.EnemyBounce();

        //쿨타임 적용할 것
        //UIManager에게 일임
        UIManager.instance.UiGuardCoolTimeEffect(cooltime);       //가드 쿨타임 적용.
        player.PlayerGuardOff();        //가드를 성공했으니, 가드 상태를 강제 종료시킴.

    }
    public void PlayerGuardFail(GameObject obj)
    {
        if (eb.gameObject != obj)
            eb = obj.GetComponent<EnemyBase>();
        //UIManager 에게 Heart감소 알림
        eb.EnemyBounce();
    }

    public void PlayerAttackEnemy(GameObject obj,int damage)
    {
        if (eb == null)
            eb = obj.GetComponent<EnemyBase>();
        if (eb.gameObject != obj)
            eb = obj.GetComponent<EnemyBase>();
        eb.EnemyHit(damage);
    }

    public void PlayerTouchEnemy(GameObject obj)
    {
        if (eb == null)
            eb = obj.GetComponent<EnemyBase>();
        if (eb.gameObject != obj)
            eb = obj.GetComponent<EnemyBase>();
        eb.EnemyTouch();
    }
    //-----------------------------------Player Behavior-------------------------------------------------

}
