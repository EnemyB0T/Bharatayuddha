using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthValue : MonoBehaviour
{
    [SerializeField] PlayerHealth ph;
    [SerializeField] TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp.text = ph.health.ToString();
    }

    public void UpdateHealth()
    {
        tmp.text = ph.health.ToString();
    }
}
