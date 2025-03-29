using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Controller : MonoBehaviour
{

    // Character UI - follows the mouse when object not possessed
    public GameObject character;

    public UnityEvent sayHi;
    void Start()
    {
        character.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            //character.SetActive(false);
            sayHi.Invoke();
        }

        if (character != null)
        {
            character.transform.position = Input.mousePosition;
        }
    }
}
