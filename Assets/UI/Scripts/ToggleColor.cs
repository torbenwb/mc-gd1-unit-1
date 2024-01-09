using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ToggleColor : MonoBehaviour
{
    Image image;
    public bool a = true;
    public Color colorA;
    public Color colorB;

    private void Awake()
    {
        image = GetComponent<Image>();
        if (a) image.color = colorA;
        else image.color = colorB;
    }
    
    public void SwitchColor()
    {
        a = !a;
        if (a) image.color = colorA;
        else image.color = colorB;
    }

    public void ColorA()
    {
        a = true;
        if (a) image.color = colorA;
        else image.color = colorB;
    }

    public void ColorB()
    {
        a = false;
        if (a) image.color = colorA;
        else image.color = colorB;
    }
}
