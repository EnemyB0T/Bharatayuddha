using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buff/Shield")]
public class ShieldBuff : Buff
{
    public int shield;
    Color color;
    public override void Apply(GameObject target)
    {
        if(ColorUtility.TryParseHtmlString("#FFFF9F", out color))
            {
                target.GetComponent<PlayerHealth>().shield += shield;
                target.GetComponent<SpriteRenderer>().color = color;
            }
        
    }
}
