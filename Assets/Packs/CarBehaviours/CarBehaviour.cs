using System.Data.Common;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    Rigidbody rigidbody;

    [Tooltip("A float value determining the max speed this car can go forwards or backwards.")]
    [SerializeField] private float maxSpeed = 5f;
    [Tooltip("A float value determining how fast the car accelerates.")]
    [Range(0,1)]
    [SerializeField] private float acceleration = 1f;
    [Tooltip("A float value determining how fast the car decelerates.")]
    [Range(0,1)]
    [SerializeField] private float turnAcceleration = 1f;
    [Tooltip("A float value determining how fast the car can turn to the left or right.")]
    [SerializeField] private float turnRate = 4f;

    private float turnInput, driveInput;

    public float turnAmount
    {
        get { return turnInput * turnRate; }
    }

    public float speed => Vector3.Dot(transform.forward, rigidbody.velocity);

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.maxAngularVelocity = turnRate;
    }

    public void DriveInput(float amount) => driveInput = amount;
    public void TurnInput(float amount) => turnInput = amount;

    // Update is called once per frame
    void FixedUpdate()
    {
        float targetSpeed; // Target speed to accelerate / decelerate towards.

        targetSpeed = driveInput * maxSpeed;

        float friction = 1f;
        float angularDrag = 1f;
        rigidbody.AddForce(-rigidbody.velocity * friction);
        rigidbody.AddForce(transform.forward * acceleration * targetSpeed);
        rigidbody.AddTorque(-rigidbody.angularVelocity * angularDrag);
        rigidbody.AddTorque(transform.up * turnInput * turnAcceleration * turnRate * Mathf.Clamp01(speed));
    }
}
