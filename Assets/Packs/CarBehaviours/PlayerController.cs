using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static float driveSensitivity = 1f;
    public static float turnSensitivity = 1f;
    public static bool inMenu = false;

    CarBehaviour carBehaviour;

    void Awake()
    {
        carBehaviour = GetComponent<CarBehaviour>();
    }

    void Update()
    {
        if (!carBehaviour) return;
        if (inMenu) return;

        float driveInput = Input.GetAxisRaw("Fire1") - Input.GetAxisRaw("Fire2");
        float turnInput = Input.GetAxisRaw("Horizontal");
        if (driveInput == 0f) driveInput = Input.GetAxisRaw("Vertical");

        carBehaviour.DriveInput(driveInput * driveSensitivity);
        carBehaviour.TurnInput(turnInput * turnSensitivity);
    }
}
