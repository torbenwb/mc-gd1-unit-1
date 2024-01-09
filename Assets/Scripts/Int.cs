using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Int : ScriptableObject
{
    [SerializeField] private int defaultValue = 0;

    public int RuntimeValue = 0;
}
