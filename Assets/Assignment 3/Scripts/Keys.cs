using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Keys : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject[] keys;
    public GameObject selectedKey;
    // Start is called before the first frame update
    void Start()
    {
     parentObject.GetComponent<InteractableObject>().DoInteraction.AddListener(StartInteraction);
    }

    // Update is called once per frame
    public void StartInteraction()
    {
        selectedKey = keys[Random.Range((int)0, keys.Length)];
        StartCoroutine(ClickAKey());
    }

    private IEnumerator ClickAKey()
    {
        while (true)
        {
            selectedKey.GetComponent<SpriteRenderer>().color = Color.red;
            yield return null;
        }
        
    }
}
