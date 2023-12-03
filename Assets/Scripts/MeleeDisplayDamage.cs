using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeleeDisplayDamage : MonoBehaviour
{
    public AttackArea ae;
    public TextMeshProUGUI tmp;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        damage = ae.damage;
        tmp.text = damage.ToString();
    }

    void Update()
    {
        damage = ae.damage;
        tmp.text = damage.ToString();
    }
}
