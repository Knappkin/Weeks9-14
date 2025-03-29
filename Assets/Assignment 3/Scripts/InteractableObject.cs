using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{

    public string message;

    public Controller controller;

    public UnityEvent<GameObject> OnClick;
    // Start is called before the first frame update
    void Start()
    {
        controller.sayHi.AddListener(Speak);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && GetComponent<SpriteRenderer>().bounds.Contains(mousePos) && controller.isPossessed == false)
        {
            getPossessed();
        }
        if (Input.GetMouseButtonDown(1) && controller.isPossessed == true)
        {
            leaveObject();
        }
        
    }

    public void Speak()
    {
        Debug.Log(message);
    }

    public void getPossessed()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow;
        controller.isPossessed = true;
    }

    public void leaveObject()
    {
        controller.isPossessed = false;
    }
}
