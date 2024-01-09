using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private static CameraManager instance;
    public Camera followCamera;
    public Camera topDownCamera;
    static Perspective perspective = Perspective.Follow;

    public enum Perspective
    {
        Follow,
        TopDown
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdatePerspective();
    }

    public void UpdatePerspective()
    {
        switch (perspective)
        {
            case Perspective.Follow:
                followCamera.gameObject.SetActive(true);
                topDownCamera.gameObject.SetActive(false);
                break;
            case Perspective.TopDown:
                followCamera.gameObject.SetActive(false);
                topDownCamera.gameObject.SetActive(true);
                break;
        }
    }

    public static void SwitchToFollowCamera() => SwitchPerspective(Perspective.Follow);
    public static void SwitchToTopDownCamera() => SwitchPerspective(Perspective.TopDown);

    public static void SwitchPerspective(Perspective newPerspective)
    {
        perspective = newPerspective;
        if (!instance) return;
        instance.UpdatePerspective();
    }
}
