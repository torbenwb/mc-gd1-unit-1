using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUIControl : MonoBehaviour
{
    public List<MonoBehaviour> mouseAndKeyboard = new List<MonoBehaviour>();
    public List<UIGrid> controller = new List<UIGrid>();

    public Control control = Control.Controller;

    // Start is called before the first frame update
    void Start()
    {
        ToggleControl(control);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Mouse X") != 0f || Input.GetAxisRaw("Mouse Y") != 0f)
        {
            ToggleControl(Control.Mouse);
            return;
        }
        
        if (Input.GetAxisRaw("HorizontalController") != 0f || Input.GetAxisRaw("HorizontalController") != 0f)
        {
            ToggleControl(Control.Controller);
            return;
        }
    }

    void ToggleControl(Control newControl)
    {
        control = newControl;
        switch(control)
        {
            case Control.Controller:
                foreach(var i in mouseAndKeyboard) i.enabled = false;
                foreach(var i in controller) i.enabled = true;
                break;
            case Control.Mouse:
                foreach (var i in mouseAndKeyboard) i.enabled = true;
                foreach (var i in controller) i.enabled = false;
                break;
        }
    }
}
