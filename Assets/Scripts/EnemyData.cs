using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Enemy", order = 1)]
public class EnemyData : ScriptableObject {
    public int hp;
    public int damage;
    public float speed;
    public float exp;
    public int element; //0 - Hydro, 1 - Pyro, 2 - Dendro
}

