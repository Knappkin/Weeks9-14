using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Frog : MonoBehaviour
{
    public AnimationCurve jumpCurve;

    public Button jumpButton;

    public UnityEvent<Button> SwitchAttackButtons;

    //public Sprite mehFrog;
    //public Sprite intenseFrog;

    float t;
    // Start is called before the first frame update
    void Start()
    {
       // GetComponent<SpriteRenderer>().sprite = mehFrog;
    }

    // Update is called once per frame
    public void triggerFrogJump()
    {
        StartCoroutine(JumpFrog());
    }

    private IEnumerator JumpFrog()
    {
        Vector2 pos = transform.position;
        jumpButton.interactable = false;
        t = 0;
       // GetComponent<SpriteRenderer>().sprite = intenseFrog;
        while(t < 1)
        {
            t += Time.deltaTime;
            pos.y = jumpCurve.Evaluate(t*2);
            transform.position = pos;
            yield return null;
        }

        SwitchAttackButtons.Invoke(jumpButton);
       // GetComponent<SpriteRenderer>().sprite = mehFrog;
    }
}
