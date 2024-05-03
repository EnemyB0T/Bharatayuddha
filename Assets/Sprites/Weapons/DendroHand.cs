using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DendroHand : MonoBehaviour
{

    //private GameObject dendroSpike = default;
    [SerializeField] private List<GameObject> dendroSpike  = new List<GameObject>();
    [SerializeField] private int numberOfSpikes = 3;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(transform.childCount);
        //attackArea = transform.GetChild(0).gameObject;
        /*
        GameObject area1 = GameObject.Find("SpikeAreaTop");
        GameObject area2 = GameObject.Find("SpikeAreaMid");
        GameObject area3 = GameObject.Find("SpikeAreaLow");

        dendroSpike.Add(area1);
        dendroSpike.Add(area2);
        dendroSpike.Add(area3);

        Debug.Log(dendroSpike.Count);
        */

    }

    // Update is called once per frame
    void Update()
    {
        //foreach (GameObject obj in dendroSpike)
            //obj.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                //attackArea.SetActive(attacking);
                foreach (GameObject area in dendroSpike)
                {
                    area.SetActive(attacking);
                }
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        //attackArea.SetActive(attacking);
        foreach (GameObject area in dendroSpike)
        {
            area.SetActive(attacking);
        }
    }
}
