using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BowDisplayDamage : MonoBehaviour
{
    public ArrowData ad;
    public TextMeshProUGUI tmp;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        damage = ad.damage;
        tmp.text = damage.ToString();
    }

    void Update()
    {
        damage = ad.damage;
        tmp.text = damage.ToString();
    }
}
