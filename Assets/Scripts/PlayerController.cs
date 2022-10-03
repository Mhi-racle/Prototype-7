using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRB;
    public float bounceForce = 6;
    public void OnCollisionEnter(Collision collision)
    {
        playerRB.velocity = new Vector3(playerRB.velocity.x, bounceForce, playerRB.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if (materialName == "Safe (Instance)")
        {
            //The ball has hit a safe area
        }
        else if (materialName == "Unsafe (Instance)")
        {
            //The ball has hit an unsafe area
            Debug.Log("Game Over");
        }
        else if (materialName == "LastRing (Instance)")
        {
            //we completed the level
            Debug.Log("Level Completed");
        }
    }
}
