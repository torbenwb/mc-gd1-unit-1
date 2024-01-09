using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyVelocityPitch : MonoBehaviour
{
    public Rigidbody rigidbody;
    public AudioSource audioSource;


    public float pitchMin = 1f;
    public float pitchMax = 1.2f;
    public float rigidbodyVelocityMax = 15f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float rbRatio = rigidbody.velocity.magnitude / rigidbodyVelocityMax;
        float pitchRatio = (pitchMax - pitchMin) * rbRatio;
        float pitch = pitchMin + pitchRatio;
        audioSource.pitch = pitch;
    }
}
