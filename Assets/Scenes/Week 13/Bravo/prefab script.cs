using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prefabscript : MonoBehaviour
{

    public Slider scaleSlider;
    // Start is called before the first frame update
    void Start()
    {
       scaleSlider.onValueChanged.AddListener(startScaleChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startScaleChange()
    {

    }
    public IEnumerator changeSize()
    {
        float currentSize;
        float goalSize;
        float t = 0;
        //while(goalSize - currentSize > 0)
        //{

       // }
        yield return null;
    }
}
