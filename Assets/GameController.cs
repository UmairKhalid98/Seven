using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text diaglogue;
    public Button button1;
    public Button button2;
    public Image character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onButtonClick1()
    {
        diaglogue.text = "THE LAND OF MORDOR, WHERE SHADOWS DIE";
        character.color = Color.blue;
    }
    public void onButtonClick2()
    {
        diaglogue.text = "Mr and Mrs Dursley of number four, privet drive were proud to say, they were completey mad. Thank you very much.";
        character.color = Color.green;
    }
}
