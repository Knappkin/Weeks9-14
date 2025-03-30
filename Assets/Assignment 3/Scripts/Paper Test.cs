using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperTest : MonoBehaviour
{

    public AnimationCurve fallCurve;
    public AnimationCurve curve2;
    
    // Start is called before the first frame update
    float t;
    void Start()
    {
       t = 0f;
    }

    // Update is called once per frame
    void Update()
    {
  
        t += Time.deltaTime*0.5f;

        if (t > 1)
        {
            t = 0;
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 pos = transform.position;


        // pos.x -= Random.Range(0, 0.1f);
        //pos.x = Mathf.Lerp(3,-3,fallCurve.Evaluate(t)*0.5f);
        //pos.y -= 0.02f;
        pos.y -= fallCurve.Evaluate(t)*0.08f;
        pos.x -= curve2.Evaluate(t) * 0.06f;

        //Debug.Log(t);
     
        //transform.position = mousePos;
        transform.position = pos;
    }
}
