using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldDisplayCount : MonoBehaviour
{
    public PlayerHealth ph;
    public TextMeshProUGUI tmp;

    public int shield;

    // Start is called before the first frame update
    void Start()
    {
        shield = ph.shield;
        tmp.text = shield.ToString();
    }

    void Update()
    {
        shield = ph.shield;
        tmp.text = shield.ToString();
    }
}
