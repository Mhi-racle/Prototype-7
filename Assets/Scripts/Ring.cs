using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private AudioManager audioManager;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > player.position.y)
        {
            audioManager.Play("whoosh");
            GameManager.numberOfPassedRings++;
            Destroy(gameObject);
        }
    }
}
