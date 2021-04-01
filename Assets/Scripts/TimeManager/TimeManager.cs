using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Rendering;

public class TimeManager : MonoBehaviour
{
    [Range(1f, 10f)]
    public int timeScale;

    private System.DateTime date;

    public TextMeshProUGUI dateText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI writtenDateText;

    [Range(0, 86400)]
    public int second;
    [Range(0, 60)]
    private int minute;
    [Range(0, 24)]
    public int hour;
    private int day;
    private int month;
    private int year;

    public int monthDays;
    public string monthName;

    [Range(0, 86400)]
    public float dayTimeInSeconds;

    private System.TimeSpan timeSpan;


    public float counter;

    private void Start()
    {
        timeScale = 1;
        minute = 0;
        hour = 12;
        counter = hour * 3600;
        dayTimeInSeconds = hour * 3600;
        //day = System.DateTime.Now.Day;
        day = 29;
        month = System.DateTime.Now.Month;
        year = System.DateTime.Now.Year;

        MonthSwitch();
        TimeTextUpdate();
        DateTextUpdate();
    }

    // Update is called once per frame
    private void Update()
    {
        CalculateTime();
        if (Math.Abs(Time.timeScale - timeScale) > Utility.tolerance)
            Time.timeScale = timeScale;
    }

    private void CalculateTime()
    {
        counter += Time.deltaTime * timeScale;

        timeSpan = System.TimeSpan.FromSeconds(counter);
        second = timeSpan.Seconds;
        minute = timeSpan.Minutes;
        hour = timeSpan.Hours;

        if (counter >= 86400)
        {
            counter %= 86400;
            DayCounter();
        }

        TimeTextUpdate();
    }

    private void DayCounter()
    {
        day++;
        if (day > monthDays)
        {
            MonthCounter();
            day = 1;
        }

        DateTextUpdate();
    }

    private void MonthCounter()
    {
        month++;
        MonthSwitch();
        if (month > 12)
        {
            YearCounter();
            month = 1;
        }

        DateTextUpdate();
    }

    private void YearCounter()
    {
        year++;
        DateTextUpdate();
    }

    private void TimeTextUpdate()
    {
        timeText.SetText(hour.ToString("D2") + ":" + minute.ToString("D2") + ":" + second.ToString("D2"));
    }

    private void DateTextUpdate()
    {
        dateText.SetText(month.ToString("D2") + "/" + day.ToString("D2") + "/" + year);
        writtenDateText.SetText(monthName + " " + day.ToString() + ", " + year.ToString());
    }

    private void MonthSwitch()
    {
        switch (month)
        {
            case 1:
                monthName = "January";
                monthDays = 31;
                break;
            case 2:
                monthName = "February";
                monthDays = 28;
                break;
            case 3:
                monthName = "March";
                monthDays = 31;
                break;
            case 4:
                monthName = "April";
                monthDays = 30;
                break;
            case 5:
                monthName = "May";
                monthDays = 31;
                break;
            case 6:
                monthName = "June";
                monthDays = 30;
                break;
            case 7:
                monthName = "July";
                monthDays = 31;
                break;
            case 8:
                monthName = "August";
                monthDays = 31;
                break;
            case 9:
                monthName = "September";
                monthDays = 30;
                break;
            case 10:
                monthName = "October";
                monthDays = 31;
                break;
            case 11:
                monthName = "November";
                monthDays = 30;
                break;
            case 12:
                monthName = "December";
                monthDays = 31;
                break;
        }
    }
}
