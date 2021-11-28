using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SleekRender;
public class ColorChange : MonoBehaviour
{

    public Color32 colorBW,color;
    public float timeLerp;
    public SleekRenderSettings SRS;
    bool lerp;
    // Start is called before the first frame update
    void Start()
    {
        lerp = false;

        SRS.colorize = colorBW;
        StartCoroutine(BlackWhite());
       
    }

    // Update is called once per frame
    void Update()
    {
        if (lerp)
        {
            SRS.colorize = Color32.Lerp(colorBW, color, Time.time*0.5f); ;

        }
    }
    IEnumerator BlackWhite() {
        yield return new WaitForSeconds(1.5f);
        lerp = true;

    }
}
