using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    // Character UI - follows the mouse when object not possessed
    public GameObject character;

    // Reference to current object that is possessed
    public GameObject objectPossessed;

    // Event to be called when the interact button is pressed: interactable objects subscribe to it when they are clicked and no other object is currently possessed
    public UnityEvent InteractPressed;


    public Slider wakeUpBar;

    public int wakeAmount;

    public bool isPossessed;
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
       
        if (Input.GetKeyDown(KeyCode.Space) && isPossessed)
        {
            //character.SetActive(false);
            InteractPressed.Invoke();
            wakeUpBar.value += wakeAmount;
        }

        if (character != null)
        {
            character.transform.position = Input.mousePosition;
        }
    }
}
