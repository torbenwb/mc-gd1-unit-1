using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenWipe : MonoBehaviour
{
    public Image image;
    float timeIn = 1.0f;
    float delay = .2f;
    float timeOut = 1f;

    float totalTime = 0f;
    
    string loadSceneName = "";

    public void Run(string sceneName){
        totalTime = 0f;
        loadSceneName = sceneName;
        StartCoroutine(run());
    }

    IEnumerator run(){
        image.fillClockwise = true;
        while(totalTime < timeIn){
            totalTime += Time.deltaTime;
            image.fillAmount += Time.deltaTime / timeIn;
            yield return null;
        }
        while(totalTime < timeIn + delay){
            totalTime += Time.deltaTime;
            yield return null;
        }
        image.fillAmount = 1f;
        GameManager.LoadScene(loadSceneName);
        yield return new WaitForSeconds(0.1f);
        image.fillAmount = 0f;
        
        
    }
}
