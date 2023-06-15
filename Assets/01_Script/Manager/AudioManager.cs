using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioSource backAudio;
    [SerializeField] AudioSource playerAudio;
    [SerializeField] AudioSource enemyAudio;
    public AudioClip backgroudClip;
    public AudioClip playerAttackClip;
    public AudioClip playerGuardClip;
    public AudioClip gameoverClip;
    public AudioClip enemyDieclip;
    public AudioClip PlayerJumpClip;
    public AudioClip PlayerHitClip;
    private void Awake()
    {
        if(instance == null)
            instance = this;
    }
    public void PlayerHitSound()
    {
        playerAudio.clip = PlayerHitClip;
        playerAudio.Play();
    }
    public void EnemyDieSound()
    {
        enemyAudio.clip = enemyDieclip;
        enemyAudio.Play();
    }
    public void GameOverSoune()
    {
        backAudio.clip = gameoverClip;
        backAudio.Play();
    }
    public void PlayerJumpSound()
    {
        playerAudio.clip = PlayerJumpClip;
        playerAudio.Play();
    }
    public void PlayerGuardSound()
    {
        playerAudio.clip = playerGuardClip;
        playerAudio.Play();
    }
    public void PlayerAttackSound()
    {
        playerAudio.clip = playerAttackClip;
        playerAudio.Play();
    }
    public void Start()
    {
        backAudio.clip = backgroudClip;
        backAudio.Play();
    }

}
