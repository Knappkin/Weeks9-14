using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{

    public AnimationCurve jumpCurve;
    public GameObject parentObject;

    public Slider wakeUpBar;

    Vector2 startingPos;
   
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        //StartCoroutine(RingThePhone());
        parentObject.GetComponent<InteractableObject>().DoInteraction.AddListener(StartInteraction);
    }


    public void StartInteraction()
    {
        StartCoroutine(RingThePhone());
    }
    private IEnumerator RingThePhone()
    {
        parentObject.GetComponent<InteractableObject>().DoInteraction.RemoveListener(StartInteraction);
      
        int counter = 0;
        Vector2 pos = transform.position;
        float t = 0;
        Debug.Log("I LISTENED");
        while (counter < 5)
        {

            t += Time.deltaTime;

            if (t > 1)
            {
                t = 0;
                counter++;
                wakeUpBar.value += parentObject.GetComponent<InteractableObject>().wakeAmount;
            }

            pos.y = startingPos.y + jumpCurve.Evaluate(t*1.5f);
            transform.position = pos;
            yield return null;
        }

        parentObject.GetComponent<InteractableObject>().DoInteraction.AddListener(StartInteraction);
    }
}
