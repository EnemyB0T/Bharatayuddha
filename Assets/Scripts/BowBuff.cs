using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BowBuff : ScriptableObject
{
    public abstract void Apply(ArrowData arrow);
}