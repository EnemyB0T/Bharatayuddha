using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBuffs : MonoBehaviour
{
     private PauseMenu pm;
     private BuffMenu bm;

     
    // Start is called before the first frame update
    void Start()
    {
 
    pm = FindObjectOfType<PauseMenu>();
    bm = FindObjectOfType<BuffMenu>();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AttackCard(){
       
        pm.Resume();
        bm.DestroyAllCards();
    }

      public void HealCard(){
         
        pm.Resume();
        bm.DestroyAllCards();
         
    }


}
