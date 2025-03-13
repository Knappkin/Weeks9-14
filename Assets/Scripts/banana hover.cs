using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class bananahover : MonoBehaviour
{
    public Image banana;
    public GameObject heart;

    public RectTransform banaRect;

    public UnityEvent OnTimerIsUp;

    public float timerLength = 3f;

    public float t = 0f;
    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if (t > timerLength)
        {
            OnTimerIsUp.Invoke();
            t = 0f;
        }
    }

    public void hoverBanana()
    {
        Debug.Log("Woohoo!");
        heart.SetActive(true);
        banaRect.localScale = Vector3.one * 1.2f;
    }

    public void leaveBanana()
    {
        Debug.Log("Boo!");
        heart.SetActive(false);
        banaRect.localScale = Vector3.one;
    }
}
