using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{
    bool active = true;


    public AudioClip scoreSound;

    private AudioSource scoreAudio;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.gameObject.tag == "Player")
        {
            active = false;

            ScoreManager.score++;

            PlatformerPlayerController playerController = collision.gameObject.GetComponent<PlatformerPlayerController>();

            playerController.PlayCoinSound();

            Destroy(gameObject);
        }
    }


}
