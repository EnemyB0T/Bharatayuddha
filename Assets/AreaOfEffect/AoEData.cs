using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AoEData", menuName = "Data/AoE", order = 2)]
public class AoEData : ScriptableObject
{
    public float cooldown;
    public int damage;
    public float lifeTime;
    
    //public float speed; //intended for slows enemy movement speed

   
}
