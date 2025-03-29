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

        if (Input.GetMouseButtonDown(0) && GetComponent<SpriteRenderer>().bounds.Contains(mousePos))
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        {

        }
    }

    public void Speak()
    {
        Debug.Log(message);
    }
}
