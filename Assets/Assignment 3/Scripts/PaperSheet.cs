using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PaperSheet : MonoBehaviour
{
    //This script executes the coroutine for the printer object

    //Animation curves for the vertical and horizontal movement of the paper
    //Vertical
    public AnimationCurve fallCurve;
    //Horizontal
    public AnimationCurve curve2;

    //Reference to which object is the parent (in this case the printer)
    //Done so that it can call to that specific instance of the interactable object script
    public GameObject parentObject;
    //Reference to the paper prefab which gets spawned on interaction
    //The prefab is an empty object with a trail renderer, so it looks like a sheet of paper
    public GameObject paperPrefab;

    //reference to the wake up slider so that it can add to the value when coroutine is run
    public Slider wakeUpBar;
    
    // Start is called before the first frame update
    void Start()
    {
        //Adds the start interaction function as a listener to the parentobject's script
       parentObject.GetComponent<InteractableObject>().DoInteraction.AddListener(StartInteraction);
    }


    //Start interaction creates instance of the paper prefab
    //Starts the coroutine
    public void StartInteraction()
    {
        //creating instance
        GameObject paperInstance = Instantiate(paperPrefab);
        //Starts coroutine, sending the instance as the object to be effected by the coroutine
        StartCoroutine(PrintPaper(paperInstance));
    }

    //Coroutine run any time interaction is started
    //Uses the prefab gameobject as an argument to tell specifically which instance of paper to execute on
    public IEnumerator PrintPaper(GameObject prefab)
    {
        //Start interaction is removed as listener so that the coroutine can't be spammed
        parentObject.GetComponent<InteractableObject>().DoInteraction.RemoveListener(StartInteraction);
        //Adds the amount to the slider bar
        //The amount is the int set in the inspector on the parent object
        wakeUpBar.value += parentObject.GetComponent<InteractableObject>().wakeAmount;

        //Declare t to be used on the animation curves
        float t = 0;
        //A bool to make sure startinteraction is only added back as a listener once when the t value reaches 0.5
        bool canRelisten = true;
        //Gets the position of 
        Vector2 pos = transform.position;

        //Runs through one cycle of the animation curve
        while (t < 1)
        {
            //add delta time to t
            // *0.5 to slow it down
            t += Time.deltaTime * 0.5f;

            //When t first passes 0.5, readds the listener so that a new coroutine can be started
            //this means there can be multiple papers at once, but with padding between when they can be created
            if (t> 0.5f && canRelisten)
            {
                parentObject.GetComponent<InteractableObject>().DoInteraction.AddListener(StartInteraction);
                canRelisten = false;
            }
           // subtracts the values of the curves from the position
           //Multiplied by a decimal to slow it down
            pos.y -= fallCurve.Evaluate(t)* 0.08f;
            pos.x -= curve2.Evaluate(t) * 0.06f;

            //applying the transform to the prefab instance
            prefab.transform.position = pos;
            yield return null;
        }
        //After the coroutine finishes, the paper is destroyed (by then it is offscreen)
        Destroy(prefab);
    }


    
    }
