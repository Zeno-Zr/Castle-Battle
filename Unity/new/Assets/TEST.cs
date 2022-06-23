using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TEST : MonoBehaviour
{
    public TextMeshProUGUI touchcount;
    // Update is called once per frame
    void Update()
    {
        int count = Input.touchCount;
        if (count == 1)
        {
            Debug.Log("touch is 1");
            touchcount.text = count.ToString();
        }
        else if (count > 1)
        {
            Debug.Log("touch more than 1");
            touchcount.text = count.ToString();
        }
        else if (count == 0)
        {
            Debug.Log("touch equal 0");
            touchcount.text = count.ToString();

        }
        
    }
}
