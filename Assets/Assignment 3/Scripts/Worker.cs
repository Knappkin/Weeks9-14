using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Worker : MonoBehaviour
{

    //Boolean used to make wakeUp only get called once when the the slider value reaches max.
    //It is set to false on WakeUp, and then set back to true when worker goes back to sleep
    private bool canWake;

    //Curve for controlling the snoring animation of the worker when asleep
    public AnimationCurve sleepCurve;

    //Curve for controlling the rotation of the worker when he wakes up (looks back and forth)
    public AnimationCurve awakeCurve;

    //Slider that represents worker's level of awakeness. When bar reaches full, triggers WakeUp() function
    public Slider wakeUpBar;

    //Sprites of the sleeping and awake symbols
    public Sprite sleepIMG;
    public Sprite awakeIMG;

    //Actual gameobject, it displays whichever symbol sprite is needed
    public GameObject statusImage;

    //Reference to the controller script, so that this script can change the canInteract bool when the worker wakes up, so that the player can't interact while awake
    public Controller controller;

    //The base scale of the worker, which is then added to using the sleeping curve while the worker is asleep
    Vector2 baseScale;

    void Start()
    {
        //Setting the starting values. base scale is set to the beginning local scale
        baseScale = transform.localScale;
        canWake = true;
        //Call the fallAsleep function, which sets other values. fallAsleep is called again whenever those values need to be reset (aka after waking up)
        fallAsleep();


    }

    void Update()
    {
        //Conditional to check if the slider is full. canWake boolean so it will only run through it once per "wake up"
        //Calls the WakeUp function
        if (wakeUpBar.value >= 100 && canWake == true)
        {
            WakeUp();
            canWake = false;
        }
    }

    //fallAsleep function is called at start, and again at the end of the look around coroutine (which is run every time the worker wakes up)
    public void fallAsleep()
    {
        //sets the canInteract bool on the controller script to true, since the worker is asleep
        controller.canInteract = true;
        // Resets the slider back to 0, both at the start and then any time the worker goes back to sleep
        wakeUpBar.value = 0;
        //Setting the status object to the sleeping image
        statusImage.GetComponent<SpriteRenderer>().sprite = sleepIMG;
        //Start the sleeping coroutine, which loops indefinitely so long as the worker is asleep
        StartCoroutine(SleepingRoutine());
        //Reseting the canWake boolean to true so that the condition can be met again in the update function
        canWake = true;
    }


    //WakeUp function is called in update when the slider is filled. It changes the character status image to awake
    //Stops the sleeping animation coroutine, and then starts the look around coroutine
    public void WakeUp()
    {
        //Sets the controller script to not be able to interact
        controller.canInteract = false;
        //Set status image to the awake sprite
        statusImage.GetComponent<SpriteRenderer>().sprite = awakeIMG;
        //Stopping the current coroutine (sleeping)
        StopAllCoroutines();
        //Starting the look around coroutine
        StartCoroutine(WakeLookAround());
    }

    //Sleeping coroutine runs the snoring animation as long as the worker is asleep
    //It uses the sleeping animation curve, as well as a local t float for time
    private IEnumerator SleepingRoutine()
    {
        //Declaring t and setting to 0
        float t = 0;

        //While true so that it will keep running until it is stopped by the WakeUp function
        while (true)
        {
            //adding deltatime to t. It is multiplied by 0.5 to slow down the animation
            t += Time.deltaTime * 0.5f;

            //if time is longer than 1 (the length of the animation curve), reset it to 0. This is done before changing the scale
            if (t > 1)
            {
                t = 0;
            }

            //Set local scale to the beginning scale set in start + the value of the sleep curve at t. Multiplied by 0.5 to change how much is added
            transform.localScale = baseScale + Vector2.one * sleepCurve.Evaluate(t) * 0.5f;

            yield return null;
        }

    }

    //Look around coroutine is started as soon as the bar is filled and the player wakes up
    //They "look around" by changing the y rotation of the worker
    private IEnumerator WakeLookAround()
    {
        //Declaring t
        float t = 0;
        //Declaring a counter (since t is looped, but I want the coroutine to end after 5 loops)
        float counter = 0;
        Vector3 rot = transform.localEulerAngles;
        //While loop will run 5 cycles of looking back and forth
        while (counter < 5)
        {
            //adding delta time
            t += Time.deltaTime *0.5f;
            
            //resetting t to restart the animation curve
            if (t > 1)
            {
                t = 0;
            }

            //The y rotation is Lerped between 80 and -80, so that it looks like they are looking back and forth. The curve starts and ends at 0
            rot.y = Mathf.Lerp(80, -80, awakeCurve.Evaluate(t));
            transform.localEulerAngles = rot;
            //adding to the counter at the same rate as t, so that it lasts 5 seconds/loops
            counter += Time.deltaTime*0.5f;
            yield return null;
        }
        //Once coroutine finishes, set back to sleeping
        fallAsleep();
    }
}
