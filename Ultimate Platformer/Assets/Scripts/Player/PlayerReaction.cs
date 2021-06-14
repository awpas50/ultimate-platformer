using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerReaction : MonoBehaviour
{
    public Score scoreBoard;
    private PlayerHack playerHack;
    private PlayerState playerState;
    
    void Start()
    {
        scoreBoard = FindObjectOfType<Score>();
        playerHack = GetComponent<PlayerHack>();
        playerState = FindObjectOfType<PlayerState>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //11.PlayerDeadZone
        //12.PlayerMustDeadZone
        if (collision.collider.gameObject.layer == 12) 
        {
            AudioManager.instance.Play(SoundList.DieInSpike);
            playerState.dead = true;
            Destroy(gameObject, 0.1f);
        }
        if((collision.collider.gameObject.layer == 11 && !playerHack.invincible))
        {
            AudioManager.instance.Play(SoundList.DieInLava);
            playerState.dead = true;
            Destroy(gameObject, 0.1f);
        }
    }
}
