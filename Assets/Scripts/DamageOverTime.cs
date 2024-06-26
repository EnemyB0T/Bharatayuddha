using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageOverTime : ScriptableObject
{
    public float damageOverTime;
    public float cooldown;
    public GameObject effect;
    public int timeToLive;
    public abstract void Apply(GameObject target);
}
