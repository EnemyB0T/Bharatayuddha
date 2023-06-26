using UnityEngine;
using System.Collections;
 
public class OpponentController : MonoBehaviour {
 
    [SerializeField]
    public int opponentsLeft = 0;
 
    public void opponentHasDied()
    {
        opponentsLeft--;
    }
 
    public void opponentHasAppeared()
    {
        opponentsLeft++;
    }
}