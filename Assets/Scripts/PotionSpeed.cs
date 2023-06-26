using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buff/SpeedPotion")]
public class PotionSpeed : Buff
{
    public float speed;
    public int buffDuration;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerController>().SpeedBuff(speed, buffDuration);
        
    }

}
