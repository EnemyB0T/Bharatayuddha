using System.Collections;
using System.Collections.Generic;

using UnityEngine;


//This is a comment
public abstract class Buff : ScriptableObject
{

    public abstract void Apply(GameObject target);
}