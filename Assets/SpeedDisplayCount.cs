using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedDisplayCount : MonoBehaviour
{
    public PlayerController pc;
    public TextMeshProUGUI tmp;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = pc.moveSpeed;
        tmp.text = speed.ToString();
    }

    void Update()
    {
        speed = pc.moveSpeed;
        tmp.text = speed.ToString();
    }
}
