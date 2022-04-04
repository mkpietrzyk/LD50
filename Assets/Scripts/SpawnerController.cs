using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject[] boxesPrefabs;
    [SerializeField] private GameObject chosenBox;
    public BoolVariable gameStarted;

    public void SpawnObject()
    {
        if (gameStarted.Value)
        {
            chosenBox = boxesPrefabs[0];
            GameObject block = Instantiate(chosenBox, transform.position, Quaternion.identity);
            block.GetComponentInChildren<TextMeshPro>().text = "";    
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            int randomIndex = Random.Range(0, 20);

            if (randomIndex % 10 == 0)
            {
                chosenBox = boxesPrefabs[3];
            }
            else if (randomIndex % 5 == 0)
            {
                chosenBox = boxesPrefabs[2];
            }
            else if (randomIndex % 4 == 0)
            {
                chosenBox = boxesPrefabs[1];
            }
            else
            {
                chosenBox = boxesPrefabs[0];
            }
            
            GameObject block = Instantiate(chosenBox, transform.position, Quaternion.identity);
            block.GetComponentInChildren<TextMeshPro>().text = "";
        }
    }
}