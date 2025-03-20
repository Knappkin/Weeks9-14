using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public AnimationCurve growCurve;

    //public Sprite mehFrog;
    //public Sprite intenseFrog;

    float t;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GrowFrog());
       // GetComponent<SpriteRenderer>().sprite = mehFrog;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator GrowFrog()
    {
        t = 0;
       // GetComponent<SpriteRenderer>().sprite = intenseFrog;
        while(t < 1)
        {
            t += Time.deltaTime;
            transform.localScale = new Vector2(10, 10) * growCurve.Evaluate(t);
            yield return null;
        }
       // GetComponent<SpriteRenderer>().sprite = mehFrog;
    }
}
