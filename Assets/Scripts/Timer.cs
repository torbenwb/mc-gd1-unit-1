using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text[] texts;
    public float time = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 0f) return;
        time -= Time.deltaTime;
        foreach(Text t in texts){
            t.text = Mathf.FloorToInt(time).ToString();
        }
        
    }
}
