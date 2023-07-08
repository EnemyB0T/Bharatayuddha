using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBow : MonoBehaviour
{
    public BowBuff buff; //Which Buff to apply
    public ArrowData arrow; //Which arrow to apply

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            buff.Apply(arrow);

            Destroy(gameObject);
        }

    }
}