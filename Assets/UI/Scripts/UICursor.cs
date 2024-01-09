using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum Control { Mouse, Controller, Touch };
public class UICursor : MonoBehaviour
{
    public float moveSpeed = 5f;
    public UIInteractableElement interactableElement { get; private set; }
    static List<UIInteractableElement> registeredInteractableElements = new List<UIInteractableElement>();

    public static void ToggleInteractableElement(UIInteractableElement interactableElement, bool register)
    {
        if (register)
        {
            if (!registeredInteractableElements.Contains(interactableElement))
            {
                registeredInteractableElements.Add(interactableElement);
            }
        }
        else
        {
            registeredInteractableElements.Remove(interactableElement);
        }
    }

    
    public Control control = Control.Controller;
    public bool jumpToNextElement = true;

    private void Start()
    {
        transform.localPosition = Vector3.zero;
    }

    private void OnEnable()
    {
        GetComponent<Image>().enabled = true;
    }

    private void OnDisable()
    {
        GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.SetAsLastSibling();
        switch (control)
        {
            case Control.Mouse: MouseUpdate(); break;
            case Control.Controller: ControllerUpdate(); break;
        }

        
        bool mouseInput = (Mathf.Abs(Input.GetAxis("Mouse X")) > 0.1f || Mathf.Abs(Input.GetAxis("Mouse Y")) > 0.1f);
        bool controllerInput = Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f;

        if (mouseInput)
        {
            control = Control.Mouse;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (controllerInput)
        {
            Cursor.lockState = CursorLockMode.Locked;
            control = Control.Controller;
        }

        if (!GetTargetInteractable()) return;

        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1"))
        {
            interactableElement.ToggleInteraction(true);
        }
    }

    void MouseUpdate()
    {
        transform.position = Input.mousePosition;
    }

    void ControllerUpdate()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);

        if (interactableElement != null)
        {
            if (moveDirection.magnitude <= 0.1f)
            {
                moveDirection = (interactableElement.position - transform.position);
                float distance = (moveDirection.magnitude);
                moveDirection = moveDirection.normalized * Mathf.Clamp(distance, 0f, Mathf.Min(distance, moveSpeed * Time.deltaTime));
                transform.position += moveDirection;
                return;
            }
        }

        FreeMovement();

        void FreeMovement()
        {
            moveDirection.Normalize();
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }

        void GridMovement()
        {
            int x = Mathf.RoundToInt(moveDirection.x);
            int y = Mathf.RoundToInt(moveDirection.y);
        }
    }

    bool GetTargetInteractable()
    {
        var results = new List<RaycastResult>();
        var eventData = new PointerEventData(EventSystem.current);
        eventData.position = transform.position;

        EventSystem.current.RaycastAll(eventData, results);
        UIInteractableElement newInteractable = null;

        
        foreach (var r in results)
        {
            newInteractable = r.gameObject.GetComponent<UIInteractableElement>();
            if (newInteractable != null) break;
        }

        if (newInteractable != interactableElement)
        {
            if (interactableElement != null) interactableElement.ToggleSelect(false);
            interactableElement = newInteractable;
            if (interactableElement != null) interactableElement.ToggleSelect(true);
        }

        return interactableElement != null;
    }
}
