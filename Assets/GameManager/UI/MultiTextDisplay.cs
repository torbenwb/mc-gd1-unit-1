using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiTextDisplay : MonoBehaviour
{
    Text[] textComponents;
    private string currentText;

    private void Awake()
    {
        textComponents = GetComponentsInChildren<Text>();
    }

    public void SetText(string newText){
        if (currentText == newText) return;

        foreach(Text t in textComponents){
            t.text = newText;
        }

        currentText = newText;
    }

    private void Update()
    {
        
    }
}
