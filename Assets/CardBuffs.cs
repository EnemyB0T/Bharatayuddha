using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBuffs : MonoBehaviour
{
    private PauseMenu pm;
    private BuffMenu bm;
    private PlayerHealth playerHealth;
    public static bool isStealActive = false; // Static variable to check if steal is active

    void Start()
    {
        pm = FindObjectOfType<PauseMenu>();
        bm = FindObjectOfType<BuffMenu>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public void AttackCard()
    {
        pm.Resume();
        bm.DestroyAllCards();
        
    }

    public void HealCard()
    {
        pm.Resume();
        bm.DestroyAllCards();
        playerHealth.Heal(20);
    }

    public void SpeedCard()
    {
        pm.Resume();
        bm.DestroyAllCards();
    }

    public void StealCard()
    {
        pm.Resume();
        bm.DestroyAllCards();
        StartCoroutine(ActivateStealEffect());
    }

    IEnumerator ActivateStealEffect()
    {
        isStealActive = true;
        yield return new WaitForSeconds(5); // Steal effect lasts for 5 seconds
        isStealActive = false;
    }
}
