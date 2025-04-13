using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    // Character UI - follows the mouse when object not possessed
    public GameObject character;

    // Reference to current object that is possessed // When object is left, reference is set to null in the InteractableObject script
    public GameObject objectPossessed;

    // Event to be called when the interact button is pressed: interactable objects subscribe to it when they are clicked and no other object is currently possessed
    public UnityEvent InteractPressed;

    // Bool that is used to determine whether to invoke the interaction when the key is pressed. Will only invoke if an object is currently possessed
    public bool isPossessed;
    // Bool that is controlled
    public bool canInteract;

    void Start()
    {
        character.SetActive(true);
        isPossessed = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isPossessed)
        {
            character.SetActive(false);
        }
        else
        {
            character.SetActive(true);
        }
       
        if (Input.GetKeyDown(KeyCode.Space) && isPossessed && canInteract)
        {
            //character.SetActive(false);
            InteractPressed.Invoke();
            //wakeUpBar.value += wakeAmount;
        }

        if (character != null)
        {
            character.transform.position = Input.mousePosition;
        }
    }
}
