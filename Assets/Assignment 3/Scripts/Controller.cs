using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    // Character UI - follows the mouse when object not possessed.
    // It is enabled when no object is possessed, then disabled when an object is possessed.
    public GameObject character;

    // Reference to current object that is possessed 
    // When object is left, reference is set to null in the InteractableObject script
    public GameObject objectPossessed;

    // Event to be called when the interact button is pressed
    // interactable objects subscribe to it when they are clicked and no other object is currently possessed
    public UnityEvent InteractPressed;

    // Bool that is used to determine whether to invoke the interaction when the key is pressed. Will only invoke if an object is currently possessed
    public bool isPossessed;
    // Bool that is controlled by the worker script: Is set to true when worker is asleep, false when awake. Is used alongside isPossessed to determine whether to invoke the event
    public bool canInteract;

    void Start()
    {
        //Setting the beginning values: Character is active since no object begins possessed, isPossessed is false
        character.SetActive(true);
        isPossessed = false;
    }

    void Update()
    {
        //If/else statement to control the character ui image. It is disabled when object possessed, otherwise it is enabled
        if (isPossessed)
        {
            character.SetActive(false);
        }
        else
        {
            character.SetActive(true);
        }
       
        //When the interaction key (spacebar) is pressed, if an object is possessed and the player can interact, InteractPressed is invoked.
        //The listener is on the interactable object script. Each use of the script subscribes on its own when it is first possessed
        //Each use of that script can invoke another event on the specific object attached to it (phone, paper manager, keysmanager). This starts the specific coroutine.
        if (Input.GetKeyDown(KeyCode.Space) && isPossessed && canInteract)
        {
            //Invoking the event
            InteractPressed.Invoke();
        }

        //If no object is possessed, character is enabled and follows the position of the mouse
        if (character != null)
        {
            character.transform.position = Input.mousePosition;
        }
    }
}
