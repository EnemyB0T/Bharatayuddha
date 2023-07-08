using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowReset : MonoBehaviour
{
    public ArrowData baseArrow;
    public ArrowData appliedArrow;

    private void Awake()
    {
        appliedArrow = baseArrow;
    }
}
