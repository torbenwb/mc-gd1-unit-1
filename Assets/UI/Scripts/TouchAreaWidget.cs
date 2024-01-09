using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TouchAreaWidget : MonoBehaviour
{
    public RectTransform area;
    public RectTransform icon;
    public float radius;
    public Vector3 touchPosition;
    public Vector3 output { get; private set; }

    public CarBehaviour car;

    private void Awake()
    {
        car = FindObjectOfType<CarBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
        {
            touchPosition = area.position;
            car.DriveInput(0f);
            return;
        }
        else
        {
            touchPosition = Input.GetTouch(0).position;
        }

        var toTouchPosition = touchPosition - area.position;
        icon.position = area.position + toTouchPosition.normalized * Mathf.Clamp(toTouchPosition.magnitude, 0f, radius);

        float turn = toTouchPosition.x / radius;
        turn *= PlayerController.driveSensitivity;
        turn = Mathf.Clamp(turn, -1f, 1f);

        car.DriveInput(1f);
        car.TurnInput(turn);
    }
}
