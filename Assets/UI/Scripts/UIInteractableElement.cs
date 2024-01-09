using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UIInteractableElement
{
    public void ToggleSelect(bool select);
    public void ToggleInteraction(bool start);

    public Vector3 position { get; }
}
