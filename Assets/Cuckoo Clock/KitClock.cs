using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KitClock : MonoBehaviour
{
    public float timeAnHourTakes = 5;

    public float t;
    public int hour = 0;

    public Transform hourHand;
    public Transform minuteHand;

    public UnityEvent<int> OnTheHour;

    Coroutine moveClockRoutine;
    IEnumerator moveOneHourRoutine;

    void Start()
    {
        moveClockRoutine = StartCoroutine(MoveTheClock());

    }

    private IEnumerator MoveTheClock()
    {
        while (true)
        {
            moveOneHourRoutine = MoveClockHandOneHour();
            yield return StartCoroutine(moveOneHourRoutine);
        }
    }

   private IEnumerator MoveClockHandOneHour()
    {
        t = 0;
        while (t < timeAnHourTakes)
        {
            t += Time.deltaTime;
            minuteHand.Rotate(0, 0, -(360 / timeAnHourTakes) * Time.deltaTime);
            hourHand.Rotate(0, 0, -(30 / timeAnHourTakes) * Time.deltaTime);
            yield return null;
        }

        hour++;
        if(hour == 13) 
        {
            hour = 1;
        }
        OnTheHour.Invoke(hour);
    }

    public void StopTheClock()
    {
        if (moveClockRoutine != null)
        {
            StopCoroutine(moveClockRoutine);
        }

        if (moveClockRoutine != null)
        {
            StopCoroutine(moveOneHourRoutine);
        }
    }
}
