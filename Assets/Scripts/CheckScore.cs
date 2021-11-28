using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckScore : MonoBehaviour
{
    int collection, target;
    Text Msg;
    // Start is called before the first frame update
    void Start()
    {
        collection = GameManager.instance.ObstacleCollected;
        target = GameManager.instance.ObstacleCount;
        Msg = gameObject.GetComponent<Text>();
        if (collection > (target - 3)) {
            //
        }
        else
        {
            if(!GameManager.instance.attacked)
            Msg.text = "NOT ENOUGH CASH";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
