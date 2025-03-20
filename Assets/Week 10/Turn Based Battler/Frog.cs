using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frog : MonoBehaviour
{
    public AnimationCurve growCurve;

    public Button growButton;

    //public Sprite mehFrog;
    //public Sprite intenseFrog;

    float t;
    // Start is called before the first frame update
    void Start()
    {
        
       // GetComponent<SpriteRenderer>().sprite = mehFrog;
    }

    // Update is called once per frame
    public void triggerFrogGrow()
    {
        StartCoroutine(GrowFrog());
    }

    private IEnumerator GrowFrog()
    {
        growButton.interactable = false;
        t = 0;
       // GetComponent<SpriteRenderer>().sprite = intenseFrog;
        while(t < 1)
        {
            t += Time.deltaTime;
            transform.localScale = new Vector2(10, 10) * growCurve.Evaluate(t);
            yield return null;
        }

        growButton.interactable = true;
       // GetComponent<SpriteRenderer>().sprite = mehFrog;
    }
}
