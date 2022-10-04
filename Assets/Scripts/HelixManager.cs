using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] helixRings;
    public float ySpawn;
    public float ringsDistance = 5;
    public int numberOfRings;

    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.DeleteAll();
        numberOfRings = GameManager.currentLevelIndex + 5; //determines the numer of rings to instantiate based on the level number
        //spawn first ring
        SpawnRing(0);

        //spawn rings exluding the last ring
        for (int i = 1; i < numberOfRings; i++)
        {
            SpawnRing(Random.Range(1, helixRings.Length - 1));
        }

        //spawn last ring
        SpawnRing(helixRings.Length - 1);
    }

    public void SpawnRing(int ringIndex)
    {
        GameObject ring = Instantiate(helixRings[ringIndex], transform.up * ySpawn, Quaternion.identity);
        ring.transform.parent = transform;
        ySpawn -= ringsDistance;
    }
}
