using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCar : MonoBehaviour
{
    public Animator animator;
    public Material colorMaterial;

    public Color[] colors;

    public void ChangeColorOne(){
        ChangeCarColor(colors[0]);
    }

    public void ChangeColorTwo(){
        ChangeCarColor(colors[1]);
    }

    public void ChangeColorThree(){
        ChangeCarColor(colors[2]);
    }

    public void ChangeColorFour(){
        ChangeCarColor(colors[3]);
    }

    public void ChangeCarColor(Color newColor){
        colorMaterial.SetColor("_Color",newColor);
        if (animator) animator.SetTrigger("Reset");
    }
}
