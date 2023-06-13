using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreColliders : MonoBehaviour
{
    void Start()
    {
        Physics2D.IgnoreLayerCollision(3, 8);
    }
}
