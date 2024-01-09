using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPlayerController : MonoBehaviour
{
    public static float driveSensitivity = 1f;
    public static float turnSensitivity = 1f;

    CarBehaviour carBehaviour;

    void Awake()
    {
        carBehaviour = GetComponent<CarBehaviour>();
    }

    void Update()
    {
        int touchCount = Input.touchCount;
        if (touchCount == 0) return;

        var touch0 = Input.GetTouch(0);
        Debug.Log($"Touch Position:{touch0.position}");
    }
}
