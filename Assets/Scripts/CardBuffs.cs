using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBuffs : MonoBehaviour
{
    private PauseMenu pm;
    private BuffMenu bm;
    private PlayerHealth playerHealth;
    private PlayerController playerController;
    [SerializeField] private AttackArea attackArea;
    [SerializeField] private FireAoEFriendly fAoE;
    [SerializeField] private float dotBuff;
    public static bool isStealActive = false;

    void Start()
    {
        pm = FindObjectOfType<PauseMenu>();
        bm = FindObjectOfType<BuffMenu>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerController = FindObjectOfType<PlayerController>();
    }

    public bool isLifeSteal()
    {
        return isStealActive;
    }

    public void AttackCard()
    {
        pm.Resume();
        bm.DestroyAllCards();
        attackArea.damage += 3;
        fAoE.damageOverTime += dotBuff;
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
        playerController.SpeedBuff(3.5f, 10);
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
        yield return new WaitForSeconds(5);
        isStealActive = false;
    }
}
