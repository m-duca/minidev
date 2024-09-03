using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DateAndTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textTime;
    [SerializeField] private TextMeshProUGUI textDate;

    private void Update()
    {
        SetTime();
        SetDate();
    }

    private void SetTime() 
    {
        DateTime utcNow = DateTime.UtcNow;

        TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

        DateTime brTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, timeZone);

        string time = brTime.ToString("HH:mm");

        textTime.text = time;
    }

    private void SetDate() 
    {
        DateTime utcNow = DateTime.UtcNow;

        TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

        DateTime brTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, timeZone);

        string date = brTime.ToString("dd/MM/yyyy");

        textDate.text = date;
    }
}
