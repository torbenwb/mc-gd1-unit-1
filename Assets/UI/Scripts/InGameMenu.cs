using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public Slider driveSensitivitySlider;
    public Slider turnSensitivitySlider;

    void OnEnable()
    {
        driveSensitivitySlider.onValueChanged.AddListener(ChangeDriveSensitivity);
        turnSensitivitySlider.onValueChanged.AddListener(ChangeTurnSensitivity);

        driveSensitivitySlider.value = PlayerController.driveSensitivity;
        turnSensitivitySlider.value = PlayerController.turnSensitivity;

        //Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }

    void OnDisable()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }   

    void ChangeDriveSensitivity(float amount)
    {
        PlayerController.driveSensitivity = amount;
    }

    void ChangeTurnSensitivity(float amount)
    {
        PlayerController.turnSensitivity = amount;
    }
}
