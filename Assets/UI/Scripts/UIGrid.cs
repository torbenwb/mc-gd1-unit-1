using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class UIGrid : MonoBehaviour
{
    public List<HorizontalLayoutGroup> rows = new List<HorizontalLayoutGroup>();

    public int rowIndex = 0;
    public int columnIndex = 0;

    float inputDelay = 0;
    UIInteractableElement targetElement = null;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (targetElement != null)
            {
                targetElement.ToggleInteraction(true);
            }
        }

        if (inputDelay > 0)
        {
            inputDelay -= Time.deltaTime;
            return;
        }

        rowIndex += Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));
        columnIndex += Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));

        if (rowIndex < 0) rowIndex = rows.Count - 1;
        if (rowIndex >= rows.Count) rowIndex = 0;

        if (columnIndex < 0) columnIndex = rows[rowIndex].transform.childCount - 1;
        if (columnIndex >= rows[rowIndex].transform.childCount) columnIndex = 0;


        var newTarget = rows[rowIndex].transform.GetChild(columnIndex).GetComponent<UIInteractableElement>();
        if (newTarget != targetElement)
        {
            if (targetElement != null) targetElement.ToggleSelect(false);
            targetElement = newTarget;
            targetElement.ToggleSelect(true);

            inputDelay = 0.2f;
        }

        
    }
}
