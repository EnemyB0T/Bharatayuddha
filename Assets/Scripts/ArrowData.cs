using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArrowData", menuName = "Data/Arrow", order = 1)]
public class ArrowData : ScriptableObject
{
    public float speed;
    public int damage;
    public float lifeTime;

    // public abstract void Apply(GameObject gameObject);
}
