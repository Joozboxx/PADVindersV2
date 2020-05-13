﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day : MonoBehaviour
{
    public Event eventData;
    int DayOfWeek;
    Calendar calendar;
    GameObject eventInfoViewer;
    GameObject calendarUI;
    Week week;

    Button thisButton;
    Color startingColor;

    // Start is called before the first frame update
    public void Start()
    {
        calendar = this.GetComponentInParent<Calendar>();
        eventInfoViewer = GameObject.Find("Structured event change");
        calendarUI = GameObject.Find("calendarUI");
        week = this.GetComponentInParent<Week>();
        thisButton = this.GetComponent<Button>();
        startingColor = thisButton.colors.normalColor;

        //hierdoor luistert hij of er een week voorbij is
        calendar.advanceWeek.AddListener(AdvanceWeek);


        string dayText = transform.Find("Text").GetComponent<Text>().text.Trim();
        switch (dayText)
        {
            case ("Monday"):
                DayOfWeek = 0;
                break;
            case ("Theusday"):
                DayOfWeek = 1;
                break;
            case ("Wednesday"):
                DayOfWeek = 2;
                break;
            case ("Thursday"):
                DayOfWeek = 3;
                break;
            case ("Friday"):
                DayOfWeek = 4;
                break;
            case ("Saturday"):
                DayOfWeek = 5;
                break;
            case ("Sunday"):
                DayOfWeek = 6;
                break;
        }
    }

    void AdvanceWeek()
    {
        this.eventData = calendar.GetEventForDay((week.thisWeek*7) + DayOfWeek);

        //verander de kleur van dagen met ingeplande events
        ColorBlock buttonColor = thisButton.colors;
        if (this.eventData != null)
        {
            buttonColor.normalColor = Color.cyan;
        }
        else
        {
            buttonColor.normalColor = startingColor;
        }
        thisButton.colors = buttonColor;
    }

    public void ShowEventInfo()
    {
        if (this.eventData != null)
        {
            eventInfoViewer.SetActive(true);
            eventInfoViewer.GetComponent<ViewEventInfo>().ShowEvent(eventData);
            calendarUI.SetActive(false);
        }
    }
}
