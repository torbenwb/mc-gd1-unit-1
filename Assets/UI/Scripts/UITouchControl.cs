using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UICursor))]
public class UITouchControl : MonoBehaviour
{
    UICursor cursor;

    private void Awake()
    {
        cursor = GetComponent<UICursor>();
        cursor.control = Control.Touch;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0) return;

        Touch touch0 = Input.GetTouch(0);
        cursor.transform.position = touch0.position;
    }
}
