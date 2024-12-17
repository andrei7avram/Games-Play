using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TMPCurrentTime : MonoBehaviour
{
    [SerializeField] TMP_Text currentTime;
    [SerializeField] TMP_Text currentDate;

    // Update is called once per frame
    void Update()
    {
        currentTime.text = DateTime.Now.ToLongTimeString();
        currentDate.text = DateTime.Now.ToLongDateString();
    }


}
