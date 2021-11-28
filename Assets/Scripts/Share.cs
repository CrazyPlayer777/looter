using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Share : MonoBehaviour
{
    [Header("Share")]
    public string subject;
    public string Body;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ShareClick()
    {
        StartCoroutine(StartShare());
    }

    IEnumerator StartShare()
    {
        yield return new WaitForEndOfFrame();
        new NativeShare().SetSubject(subject).SetText(Body).Share();
    }

}
