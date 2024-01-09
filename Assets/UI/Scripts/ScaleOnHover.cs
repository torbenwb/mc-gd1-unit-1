using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScaleOnHover : MonoBehaviour, UIInteractableElement
{
    Vector3 defaultScale;
    public UnityEvent OnInteract = new UnityEvent();
    public float hoverScale = 1.1f;

    void Awake()
    {
        defaultScale = transform.localScale;
        
    }

    void OnEnable()
    {
        UICursor.ToggleInteractableElement(this, true);
    }

    void OnDisable()
    {
        UICursor.ToggleInteractableElement(this, false);
    }

    public Vector3 position => transform.position;

    public void ToggleSelect(bool select)
    {
        transform.localScale = select ? defaultScale * hoverScale : defaultScale;
    }

    public void ToggleInteraction(bool interact)
    {
        if (interact) OnInteract.Invoke();
    }
}
