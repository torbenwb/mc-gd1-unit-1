using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ControllerKeyboard : MonoBehaviour
{
    public TextMeshProUGUI displayOutput;
    public string output { get; private set; } = "";
    public UnityEvent OnSubmit = new UnityEvent();

    public void AddTextToOutput(string text)
    {
        output += text;
        if (output.Length > 10)
        {
            output = output.Substring(0, 10);
        }
        displayOutput.text = output;
    }

    public void RemoveTextFromOutput(int count = 1)
    {
        if (output.Length == 0) return;

        output = output.Remove(output.Length - count);
        displayOutput.text = output;
    }

    public void Submit()
    {
        OnSubmit.Invoke();
    }

};
