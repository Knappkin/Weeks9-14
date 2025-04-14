using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    //This script executes the phone coroutine

    //Animation curve to control the y position of the phone
    public AnimationCurve jumpCurve;
    //Reference to the phone machine object
    public GameObject parentObject;

    //reference to the wake up slider so that it can add to the value when coroutine is run
    public Slider wakeUpBar;

    //vector2 to store the starting position of the object
    Vector2 startingPos;
   
    // Start is called before the first frame update
    void Start()
    {
        //Sets the starting position at the start
        startingPos = transform.position;
        //Adding start interaction as a listener to the phone machine's interactableobject script
        parentObject.GetComponent<InteractableObject>().DoInteraction.AddListener(StartInteraction);
    }

    //function to start the coroutine on the phone
    //Since only the one phone exists and is pre-existing in scene, it does not need to be instantiated or sent as argument
    public void StartInteraction()
    {
        StartCoroutine(RingThePhone());
    }

    //Coroutine for the phone
    private IEnumerator RingThePhone()
    {
        //Removes the listener from the parent object so that the coroutine can't be started again until this one has finished
        parentObject.GetComponent<InteractableObject>().DoInteraction.RemoveListener(StartInteraction);
      
        //Counter of how many loops have run, desired is 5
        int counter = 0;
        //Setting the initial position
        Vector2 pos = transform.position;
        //declaring t
        float t = 0;
        
        //Runs through the 5 loops
        while (counter < 5)
        {
            //adding delta time
            t += Time.deltaTime;

            //restarting t when it reaches 1
            if (t > 1)
            {
                t = 0;
                //Adding to the counter at this point
                counter++;
                //Wake up amount is added here so that it will be added in increments for each cycle of the phone ringing, instead of all at once
                wakeUpBar.value += parentObject.GetComponent<InteractableObject>().wakeAmount;
            }

            //Setting the y position to the starting position plus the curve value at t
            pos.y = startingPos.y + jumpCurve.Evaluate(t*1.5f);
            transform.position = pos;
            yield return null;
        }
        //Readding the listener after the coroutine has finished
        parentObject.GetComponent<InteractableObject>().DoInteraction.AddListener(StartInteraction);
    }
}
