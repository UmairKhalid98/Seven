using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    Text text;
    float deltaTime;
    float count;
    float count2;
    void Start()
    {
        text = GetComponentInChildren<Text>();
        count = 60;

    }

    // Update is called once per frame
    void Update()
    {
        deltaTime = Time.deltaTime;
        if (count == 0)
        {
            // WHEN COUNT == 0, END THE GAME. GAME OVER
        }
        else
        {
            count -= deltaTime;
        }

        text.text = count.ToString("N0");
    }
}
