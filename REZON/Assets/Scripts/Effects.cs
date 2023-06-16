using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    [SerializeField] private GameObject _bloodEffect;
    
    public void EffectPlay(Vector2 position)
    {
        Instantiate(_bloodEffect, position, Quaternion.identity);
    }
}
