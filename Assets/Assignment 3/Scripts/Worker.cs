using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Worker : MonoBehaviour
{

    //bool to check if worker is awake
    private bool isAwake;
    //Curve for controlling the snoring animation of the worker when asleep
    public AnimationCurve sleepCurve;
    //Slider that represents worker's level of awakeness. When bar reaches full, triggers WakeUp() function
    public Slider wakeUpBar;

    //Sprites of the sleeping or awake symbols
    public Sprite sleepIMG;
    public Sprite awakeIMG;

    //Actual ui image, it displays whichever symbol sprite is needed
    public Image statusUI;

    Vector2 baseScale;
    // Start is called before the first frame update
    void Start()
    {
        baseScale = transform.localScale;
        isAwake = false;
        fallAsleep();

       

        Debug.Log(baseScale);

    }

    // Update is called once per frame
    void Update()
    {
        if(wakeUpBar.value >= 100)
        {
            WakeUp();
        }
    }
    private IEnumerator SleepingRoutine()
    {
        float t = 0;

        while(!isAwake)
        {

            t+= Time.deltaTime * 0.5f;
           
            if (t > 1)
            {
                t = 0;
            }

            transform.localScale = baseScale + Vector2.one * sleepCurve.Evaluate(t) * 0.5f;

            yield return null;
        }
        
    }
    public void fallAsleep()
    {
        statusUI.sprite = sleepIMG;
        StartCoroutine(SleepingRoutine());
    }

    public void WakeUp()
    {
        statusUI.sprite = awakeIMG;
        StopAllCoroutines();
        Debug.Log("this is getting called");
    }
   // IEnumerator
}
