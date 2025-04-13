using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Keys : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject[] keys;
    public GameObject selectedKey;
    public AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
     parentObject.GetComponent<InteractableObject>().DoInteraction.AddListener(StartInteraction);
    }

    // Update is called once per frame
    public void StartInteraction()
    {
        selectedKey = keys[Random.Range((int)0, keys.Length)];
        StartCoroutine(ClickAKey(selectedKey));
    }

    public IEnumerator ClickAKey(GameObject keyClicked)
    {
        float t = 0;
        //Color keyColour = new Color();
        while (t<1)
        {
            
            Color startColour = Color.white;
            //Color endColour = new Color(70,70,70,1);
            Color endColour = Color.grey;
            t += Time.deltaTime;
            //Color keyColour = new Color(Mathf.Lerp(255,70, curve.Evaluate(t)), Mathf.Lerp(255, 70, curve.Evaluate(t)), Mathf.Lerp(255, 70, curve.Evaluate(t)));
           // Color keyColour = new Color(curve.Evaluate(t)*10, curve.Evaluate(t) * 10, curve.Evaluate(t) * 10);
            keyClicked.GetComponent<SpriteRenderer>().color = Color.Lerp(startColour,endColour,curve.Evaluate(t));
           
            //keyClicked.transform.localScale = Vector3.one * curve.Evaluate(t);
            Debug.Log(t);
            yield return null;
        }
        //selectedKey.GetComponent<SpriteRenderer>().color = Color.white;

    }
}
