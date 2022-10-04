using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRB;
    public float bounceForce = 6;
    public AudioSource bounceSound;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("Bounce");

        playerRB.velocity = new Vector3(playerRB.velocity.x, bounceForce, playerRB.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if (materialName == "Safe (Instance)")
        {
            //The ball has hit a safe area
        }
        else if (materialName == "Unsafe (Instance)")
        {
            //The ball has hit an unsafe area
            GameManager.gameOver = true;
            Debug.Log("Game Over");
            audioManager.Play("game over");
        }
        else if (materialName == "LastRing (Instance)" && !GameManager.levelCompleted)
        {
            //we completed the level
            GameManager.levelCompleted = true;
            Debug.Log("Level Completed");
            audioManager.Play("win level");
        }
    }
}
