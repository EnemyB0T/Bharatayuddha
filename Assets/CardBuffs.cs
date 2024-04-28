using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBuffs : MonoBehaviour
{
     private PauseMenu pm;
    // Start is called before the first frame update
    void Start()
    {
    pm = FindObjectOfType<PauseMenu>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AttackCard(){
       
        pm.Resume();
        
    }

      public void HealCard(){
         
        pm.Resume();
         
    }

}
