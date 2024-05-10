using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour
{
    [SerializeField] Text timeText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeCheck();
    }

    private void TimeCheck()
    {
        timeText.text = DateTime.Now.ToString("HH:mm");
    }
}
