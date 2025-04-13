using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Worker : MonoBehaviour
{

    //bool to check if worker is awake
    private bool isAwake;
    private bool canWake;
    //Curve for controlling the snoring animation of the worker when asleep
    public AnimationCurve sleepCurve;

    public AnimationCurve awakeCurve;
    //Slider that represents worker's level of awakeness. When bar reaches full, triggers WakeUp() function
    public Slider wakeUpBar;

    //Sprites of the sleeping or awake symbols
    public Sprite sleepIMG;
    public Sprite awakeIMG;

    //Actual ui image, it displays whichever symbol sprite is needed
    public GameObject statusImage;

    public Controller controller;
    Vector2 baseScale;
    // Start is called before the first frame update
    void Start()
    {
        baseScale = transform.localScale;
        isAwake = false;
        canWake = true;
        fallAsleep();


    }

    // Update is called once per frame
    void Update()
    {
        if (wakeUpBar.value >= 100 && canWake == true)
        {
            WakeUp();
            canWake = false;
        }
    }

    public void fallAsleep()
    {
        controller.canInteract = true;
        wakeUpBar.value = 0;
        statusImage.GetComponent<SpriteRenderer>().sprite = sleepIMG;
        StartCoroutine(SleepingRoutine());
        canWake = true;
    }

    public void WakeUp()
    {
        controller.canInteract = false;
        statusImage.GetComponent<SpriteRenderer>().sprite = awakeIMG;
        StopAllCoroutines();
        StartCoroutine(WakeLookAround());
        Debug.Log("this is getting called");
    }

    private IEnumerator SleepingRoutine()
    {
        float t = 0;

        while (!isAwake)
        {

            t += Time.deltaTime * 0.5f;

            if (t > 1)
            {
                t = 0;
            }

            transform.localScale = baseScale + Vector2.one * sleepCurve.Evaluate(t) * 0.5f;

            yield return null;
        }

    }

    private IEnumerator WakeLookAround()
    {
        float t = 0;
        float counter = 0;
        Vector3 rot = transform.localEulerAngles;
        while (counter < 5)
        {
            t += Time.deltaTime *0.5f;
            
            if (t > 1)
            {
                t = 0;
            }

            rot.y = Mathf.Lerp(80, -80, awakeCurve.Evaluate(t));
            transform.localEulerAngles = rot;
            counter += Time.deltaTime*0.5f;
            yield return null;
        }
        fallAsleep();
    }
}
