using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(UICursor))]
public class KeyboardCursor : MonoBehaviour
{
    Key targetKey;

    private void Update()
    {
        var results = new List<RaycastResult>();
        var eventData = new PointerEventData(EventSystem.current);
        eventData.position = transform.position;

        EventSystem.current.RaycastAll(eventData, results);

        Key newTargetKey = null;

        foreach(var r in results)
        {
            newTargetKey = r.gameObject.GetComponent<Key>();
            if (newTargetKey) break;
        }

        if (newTargetKey != targetKey)
        {
            if (targetKey) targetKey.ToggleSelect(false);
            targetKey = newTargetKey;
            if (targetKey) targetKey.ToggleSelect(true);
        }

        if (!targetKey) return;

        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1"))
        {
            targetKey.ToggleInteraction(true);
        }
    }
}
