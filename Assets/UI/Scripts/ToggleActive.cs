using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActive : MonoBehaviour
{
    public bool active;

    public void toggleActive()
    {
        active = !active;
        gameObject.SetActive(active);
    }
}
