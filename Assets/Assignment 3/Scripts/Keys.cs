using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    //This script executes the coroutine on the keys

    //Reference to the keyboard object
    public GameObject parentObject;

    //Keys were created as individual objects, each children of the keyboard object
    //They were then added to this array of keys in the inspector
    public GameObject[] keys;
    //Reference to which key out of the array is chosen for the coroutine
    public GameObject selectedKey;

    //curve for the animation of the key press
    //Changes colour
    public AnimationCurve curve;

    //reference to the wake up slider so that it can add to the value when coroutine is run
    public Slider wakeUpBar;
   

    void Start()
    {
     //Adding startinteraction as a listener to the keyboard's interaction event at the start
     parentObject.GetComponent<InteractableObject>().DoInteraction.AddListener(StartInteraction);
    }

   //Function to start the interaction
   //Is called by the event on the parent object
    public void StartInteraction()
    {
        //Sets a key from the array to be selected
        selectedKey = keys[Random.Range((int)0, keys.Length)];
        //Starts the coroutine on that specified key
        //key sent as argument so that the selected key object reference can be changed while this coroutine is still running
        //Won't disrupt the coroutine, multiple can execute at once
        StartCoroutine(ClickAKey(selectedKey));
    }

    //Coroutine for the interaction (simulates the clicking of keys)
    public IEnumerator ClickAKey(GameObject keyClicked)
    {
        //Declare t
        float t = 0;
        //Add the value specified on the parent object (keyboard) to the wake up bar
        wakeUpBar.value += parentObject.GetComponent<InteractableObject>().wakeAmount;
       
        //Runs through the loop once
        while (t<1)
        {
            //declaring the starting colour
            Color startColour = Color.white;
            //declaring the ending colour
            Color endColour = Color.grey;
            //adding delta time to t
            t += Time.deltaTime;
            //The colour of the selected key is lerped between white and grey by the value of the curve at t
            keyClicked.GetComponent<SpriteRenderer>().color = Color.Lerp(startColour,endColour,curve.Evaluate(t));
           
            yield return null;
        }

    }
}
