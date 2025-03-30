using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperTest : MonoBehaviour
{

    public AnimationCurve fallCurve;
    // Start is called before the first frame update
    float t;
    void Start()
    {
       t = 0f;
    }

    // Update is called once per frame
    void Update()
    {
  
        t += Time.deltaTime;

        if (t > 1)
        {
            t = 0;
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 pos = transform.position;

        // pos.x -= Random.Range(0, 0.1f);
       // pos.x = Mathf.Lerp(2,-2,fallCurve.Evaluate(t));
        pos.y -= Mathf.Lerp(-0.01f,0.02f,fallCurve.Evaluate(t));
        //transform.position = mousePos;
        transform.position = pos;
    }
}
