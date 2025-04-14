using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{

    //reference to the controller script
    public Controller controller;


    //Sprites for when the object isn't possessed (neutral), or when they are (possessed)
    //Public so that each object this is attached to can have separate sprites set in the inspector
    public Sprite neutralSprite;
    public Sprite possessedSprite;

    //Unity event to tell the connected object (keys manager, phone, printer manager) to start their coroutine
    public UnityEvent DoInteraction;

    //Public int of how much to add to the slider per interaction.
    //Each use of the script has the number set in the inspector
    public int wakeAmount;

    private void Start()
    {
        //setting the sprite to neutral at start
        GetComponent<SpriteRenderer>().sprite = neutralSprite;
    }

    void Update()
    {
        //Keeping track of the mouse position
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Checking if the object is clicked
        //makes sure isPossessed is false so that only one object can be possessed at a time
        //calls the getPossessed function
        if (Input.GetMouseButtonDown(0) && GetComponent<SpriteRenderer>().bounds.Contains(mousePos) && controller.isPossessed == false)
        {
            getPossessed();
        }

        //Exits the object if right click is clicked and the object this script is attached to is currently possessed
        //Makes sure it's this object so that it won't be called on all interactableobjects on each right click
        if (Input.GetMouseButtonDown(1) && controller.isPossessed == true && controller.objectPossessed == gameObject)
        {
            leaveObject();
        }
        
    }

    //getPossessed adds this script as a listener to the controller, so when interaction is pressed it will execute the interaction
    public void getPossessed()
    {
        //Adds the doAction function as a listener to the controller InteractPressed event
        controller.InteractPressed.AddListener(doAction);
        //Tells the controller that an object is being possessed
        controller.isPossessed = true;
        //Tells the controller that it is this object
        controller.objectPossessed = gameObject;
        //Changes the sprite to the possessed version
        GetComponent<SpriteRenderer>().sprite = possessedSprite;
    }

    //leaveObject removes this object from the interaction event, tells controller that no object is possessed
    public void leaveObject()
    {
        //Tells controller that nothing is possessed anymore
        controller.isPossessed = false;
        //Removes listeners from interaction
        controller.InteractPressed.RemoveAllListeners();
        //Sets the possessed object on the controller to null to prevent any errors of not having an attached game object
        controller.objectPossessed = null;
        //Sets the sprite back to neutral
        GetComponent<SpriteRenderer>().sprite = neutralSprite;
    }

    //Function to invoke the dointeraction event (listeners are the keys, papersheet and phone scripts)
    //Listeners are added on their individual scripts
    public void doAction()
    {
        DoInteraction.Invoke();
    }
}
