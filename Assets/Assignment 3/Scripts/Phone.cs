using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{

    public AnimationCurve jumpCurve;
    Vector2 startingPos;
   
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        StartCoroutine(RingThePhone());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartInteraction()
    {

    }
    private IEnumerator RingThePhone()
    {
        int counter = 0;
        Vector2 pos = transform.position;
        float t = 0;
        while (counter < 5)
        {

            t += Time.deltaTime;

            if (t > 1)
            {
                t = 0;
                counter++;
            }

            pos.y = startingPos.y + jumpCurve.Evaluate(t*1.5f);
            transform.position = pos;
            yield return null;
        }

    }
}
