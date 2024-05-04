using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DendroShootPoint : MonoBehaviour
{
    public float offset;
    //public List<GameObject> projectiles = new List<GameObject>();
    public VineData data;
    public Transform shotPoint;
    public float area;
    private float timeBetweenShots;
    public float startTimeBetweenShots;
    private MusicSFX fx;
    void Start()
    {
        fx = FindObjectOfType<MusicSFX>();
    }

    private void Update()
    {
        //weapon position
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        bool rotate = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().movingLeft;
        if (rotate)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        }
        

        if (timeBetweenShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                /*
                foreach (GameObject p in projectiles)
                {
                    float temp = area;
                    Instantiate(p, shotPoint.position, transform.rotation);
                    timeBetweenShots = startTimeBetweenShots;
                }

                */

                Instantiate(data, shotPoint.position, transform.rotation);
                timeBetweenShots = startTimeBetweenShots;
                
                fx.src.clip = fx.FireSFX;
                fx.src.Play();
            }
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}
