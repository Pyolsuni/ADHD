using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class OutofBounds : MonoBehaviour
{
    private GameObject arrowin;
    public AudioClip MissSound;
    public int MissPoint = -10;
    void Update()
    {
        if (arrowin != null)
        {
            arrowin.GetComponent<ArrowMovement>().Delete(MissSound, MissPoint, 0);
            Counter.Instance.Combo = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        arrowin = other.gameObject;
    }
}
