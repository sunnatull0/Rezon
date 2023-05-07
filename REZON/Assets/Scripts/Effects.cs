using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    [SerializeField] GameObject blood;
    
    public void EffectPlay(Vector2 position)
    {
        Instantiate(blood, position, Quaternion.identity);
    }
}
