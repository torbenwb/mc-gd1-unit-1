using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UICursor))]
public class UICursorArea : MonoBehaviour
{
    UICursor cursor;
    public Vector2 areaBounds;

    private void Awake()
    {
        cursor = GetComponent<UICursor>();
    }

    private void Update()
    {
        
    }
}
