﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewEventInfo : MonoBehaviour
{

    Text eventTitle;
    Text weekDescription;

    void Start()
    {
        eventTitle = transform.Find("Title").GetComponent<Text>();
        weekDescription = transform.Find("Description").GetComponent<Text>();
    }

    public void ShowEvent(Event eventInfo)
    {
        eventTitle.text = eventInfo.title;
        weekDescription.text = eventInfo.body;
    }
}
