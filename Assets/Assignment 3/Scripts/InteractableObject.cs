using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{

    public string message;

    public Controller controller;


    // Reference to which object to run the coroutine of (phone, keys, papers)
    public Sprite neutralSprite;
    public Sprite possessedSprite;

    public UnityEvent<GameObject> OnClick;
    public UnityEvent DoInteraction;

    public float cooldown;

    public int wakeAmount;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = neutralSprite;
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && GetComponent<SpriteRenderer>().bounds.Contains(mousePos) && controller.isPossessed == false)
        {
            getPossessed();
        }
        if (Input.GetMouseButtonDown(1) && controller.isPossessed == true && controller.objectPossessed == gameObject)
        {
            leaveObject();
        }
        
    }

    public void getPossessed()
    {
        //GetComponent<SpriteRenderer>().color = Color.yellow;
        Debug.Log("Im still playinnnnnng");
        //GetComponent<SpriteRenderer>().color = Color.blue;
        controller.InteractPressed.AddListener(doAction);
        controller.isPossessed = true;
        controller.objectPossessed = gameObject;
        GetComponent<SpriteRenderer>().sprite = possessedSprite;
    }

    public void leaveObject()
    {
        Debug.Log("GOOOODBYEEEEEEEEE");
        GetComponent<SpriteRenderer>().color = Color.white;
        controller.isPossessed = false;
        controller.InteractPressed.RemoveAllListeners();

        controller.objectPossessed = null;
        GetComponent<SpriteRenderer>().sprite = neutralSprite;
    }

    public void doAction()
    {
        DoInteraction.Invoke();
        //GetComponent<SpriteRenderer>().color = Color.blue;
        Debug.Log(message);
    }
}
