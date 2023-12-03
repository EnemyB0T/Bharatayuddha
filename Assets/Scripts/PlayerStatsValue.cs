using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsValue : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shield;
    public void ActivateShield()
    {
        shield.SetActive(true);
    }

    public void DeactivateShield()
    {
        shield.SetActive(false);
    }

}
