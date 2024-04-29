using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuffMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject[] cardPrefabs; // Array of card prefabs
     public GameObject[] cardPrefabs2; // Array of card prefabs
    public GameObject buffMenuUI;
     //public GameObject attackCard;
     // public GameObject healCard;
    private CardBuffs cb; // Reference to the CardBuffs script

    public Transform canvasTransform; // Reference to the Canvas transform
    private List<GameObject> spawnedCards = new List<GameObject>(); // List to keep track of all spawned cards

    void Start()
    {
        cb = FindObjectOfType<CardBuffs>(); // Find and store reference to the CardBuffs script
        buffMenuUI.SetActive(false); // Initially hide the buff menu
    }

    public void BuffMenuUI()
    {
        buffMenuUI.SetActive(true);
        Time.timeScale = 0.0f; // Pause the game
        GameIsPaused = true;
    }

    public void Resume()
    {
        buffMenuUI.SetActive(false);
        Time.timeScale = 1.0f; // Resume the game
        GameIsPaused = false;
    }

    void Pause()
    {
        buffMenuUI.SetActive(true);
        Time.timeScale = 0.0f; // Pause the game
        GameIsPaused = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0); // Load the main menu scene
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit the game application
    }

public void SpawnRandomCard()
{
    DestroyAllCards();  // Destroy all previously spawned cards

    // Spawn the first card
    int randomIndex1 = Random.Range(0, 4);
    GameObject randomCardGO1 = Instantiate(cardPrefabs[randomIndex1], canvasTransform, false);
    randomCardGO1.SetActive(true);
    spawnedCards.Add(randomCardGO1);  

    // Spawn the second card ensuring it is not the same as the first
    int randomIndex2;
    do
    {
        randomIndex2 = Random.Range(0, 4); 
    } while (randomIndex2 == randomIndex1 && cardPrefabs.Length > 1); 

    GameObject randomCardGO2 = Instantiate(cardPrefabs2[randomIndex2], canvasTransform, false); 
    randomCardGO2.SetActive(true);
    spawnedCards.Add(randomCardGO2);  
}


    public void DestroyAllCards()
    {
        // Destroy all cards in the spawnedCards list
        foreach (GameObject card in spawnedCards)
        {
            if (card != null)
                Destroy(card);  // Destroy the card
        }
        spawnedCards.Clear();  // Clear the list after all cards have been destroyed
    }
}
