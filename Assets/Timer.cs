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
    void Start()
    {
        text = GetComponentInChildren<Text>();
        count = 0;

    }

    // Update is called once per frame
    void Update()
    {
        deltaTime = Time.deltaTime;
        count += deltaTime;
        text.text = count.ToString("N0");
    }
}
