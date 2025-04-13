using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PaperSheet : MonoBehaviour
{

    public AnimationCurve fallCurve;
    public AnimationCurve curve2;
    public GameObject parentObject;
    public GameObject paperPrefab;

    public Slider wakeUpBar;
    
    // Start is called before the first frame update
    void Start()
    {
       parentObject.GetComponent<InteractableObject>().DoInteraction.AddListener(StartInteraction);
    }


    public void StartInteraction()
    {
        GameObject paperInstance = Instantiate(paperPrefab);
        StartCoroutine(PrintPaper(paperInstance));
    }

    public IEnumerator PrintPaper(GameObject prefab)
    {
        parentObject.GetComponent<InteractableObject>().DoInteraction.RemoveListener(StartInteraction);
        wakeUpBar.value += parentObject.GetComponent<InteractableObject>().wakeAmount;
        float t = 0;
        bool canRelisten = true;
        Vector2 pos = transform.position;

        while (t < 1)
        {

            t += Time.deltaTime * 0.5f;

            if (t> 0.5f && canRelisten)
            {
                parentObject.GetComponent<InteractableObject>().DoInteraction.AddListener(StartInteraction);
                canRelisten = false;
            }
           // pos.x -= Random.Range(0, 0.1f);
            //pos.x = Mathf.Lerp(3,-3,fallCurve.Evaluate(t)*0.5f);
            //pos.y -= 0.02f;
            pos.y -= fallCurve.Evaluate(t)* 0.08f;
            pos.x -= curve2.Evaluate(t) * 0.06f;

            prefab.transform.position = pos;
            yield return null;
        }
        Destroy(prefab);
    }


    
    }
