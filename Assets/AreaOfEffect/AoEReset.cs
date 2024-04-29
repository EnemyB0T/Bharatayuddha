using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEReset : MonoBehaviour
{
    public FireAoEFriendly baseFire;
    public FireAoEFriendly appliedFire;

    private void Awake()
    {
        appliedFire.damageOverTime = baseFire.damageOverTime;
        appliedFire.cooldown = baseFire.cooldown;
        appliedFire.timeToLive = baseFire.timeToLive;
    }
}
