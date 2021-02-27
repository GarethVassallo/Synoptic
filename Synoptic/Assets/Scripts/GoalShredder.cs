using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalShredder : MonoBehaviour
{
    [SerializeField] int scorevalue = 1;
    [SerializeField] AudioClip footballGoalAudio;
    [SerializeField] [Range(0, 1)] float footballGoalAudioVolume = 0.50f;
    GameSession gameSession;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Football>() != null)
        {
            FindObjectOfType<GameSession>().AddToScore(scorevalue);
            AudioSource.PlayClipAtPoint(footballGoalAudio, Camera.main.transform.position, footballGoalAudioVolume);
        }


    }
}
