using UnityEngine;
using TMPro;
using System;
public class Clock : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        int hour = DateTime.Now.Hour;
        int minute = DateTime.Now.Minute;
        bool AM = hour < 12;

        text.text = ((hour%12) == 0 ? 12 : (hour%12)).ToString() + ":" + (minute >= 10 ? minute.ToString() : "0" + minute.ToString()) + (AM ? "AM" : "PM");
    }
   
}
