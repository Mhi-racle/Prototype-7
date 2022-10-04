using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] character;
    private int selectedCharacter = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject ch in character)
        {
            ch.SetActive(false);
        }

        character[selectedCharacter].SetActive(true);
    }

    public void ChangeCharacter(int newCharacter)
    {
        character[selectedCharacter].SetActive(false);
        character[newCharacter].SetActive(true);
        selectedCharacter = newCharacter;
    }
}
