using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image baseImage;
    Image topImage;
    bool mouseOver = false;
    public UnityEvent onClick;
    public enum ButtonBehavior{
        POINTER,RETURN
    }
    public ButtonBehavior buttonBehavior = ButtonBehavior.POINTER;

    private void Awake()
    {
        baseImage = GetComponent<Image>();
        topImage = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData){
        topImage.color = Color.gray;
        mouseOver = true;
      
    }

    public void OnPointerExit(PointerEventData eventData){
        topImage.color = Color.white;
        mouseOver = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonBehavior == ButtonBehavior.POINTER){
            if (!mouseOver) return;
            if (Input.GetMouseButtonDown(0)) topImage.rectTransform.localPosition = Vector3.zero;
            if (Input.GetMouseButtonUp(0)) {
                topImage.rectTransform.localPosition = Vector3.up * 5f;
                onClick.Invoke();
            }
        }
        else{
            if (Input.GetButtonDown("Fire1")) topImage.rectTransform.localPosition = Vector3.zero;
            if (Input.GetButtonUp("Fire1")){
                topImage.rectTransform.localPosition = Vector3.up * 5f;
                onClick.Invoke();
            }
        }
    }
}
