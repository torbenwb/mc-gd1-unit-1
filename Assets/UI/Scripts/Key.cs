using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

[ExecuteInEditMode]
public class Key : MonoBehaviour, UIInteractableElement
{
    public enum Type
    {
        Character, Space, Backspace, Enter
    }

    public ControllerKeyboard keyboard;
    public Type keyType = Type.Character;
    public string text;

    private void Start()
    {
        keyboard = FindObjectOfType<ControllerKeyboard>();
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

    private void Update()
    {
        text = gameObject.name;
        GetComponentInChildren<TextMeshProUGUI>().text = text;
    }

    public void ToggleSelect(bool select)
    {
        if (select) transform.localScale = Vector3.one * 1.2f;
        else transform.localScale = Vector3.one;
    }

    public void ToggleInteraction(bool start)
    {
        switch(keyType)
        {
            case Type.Character: keyboard.AddTextToOutput(text); break;
            case Type.Space: keyboard.AddTextToOutput(" "); break;
            case Type.Backspace: keyboard.RemoveTextFromOutput(); break;
            case Type.Enter: keyboard.Submit(); break;
        }
    }
}
