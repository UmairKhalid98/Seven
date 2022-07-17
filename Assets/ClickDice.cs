using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ClickDice : MonoBehaviour
{
    private Text text;
    int randomNumber;
    SpriteRenderer sprite;
    string[] sins;
    public float red;
    public float green;
    public float blue;
    public float alpha;
    //we will need to check the size of this data structure later with another script to see if the game ends or not
    /*
     * Also we can put a meter
     */
    HashSet<string> sinChecker;
    private string diceText;
    private void Start()
    {
        text = GetComponentInChildren<Text>();
        sprite = GetComponent<SpriteRenderer>();
        randomNumber = 0;
        sins = new string[7] { "Pride", "Greed", "Wrath", "Envy", "Lust", "Gluttony", "Sloth" };
        sinChecker = new HashSet<string>();
        diceText = null;
        //USED FOR TESTING
        //--------------------
        //red = 1f;
        //green = 1f;
        //blue = 1f;
        //alpha = 1f;
        // --------------------

    }
    private void Update()
    {
        //USED FOR TESTING
        //---------------------------
        //Color c = new Color(red, green, blue, alpha);
        //sprite.color = c;
        //----------------------------
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                //rollDice();
                rollDice();
                if (sinChecker.Add(getDiceText()))
                {
                    //transition to another screen;
                    //
                    Debug.Log("DOES NOT CONTAIN:" + getDiceText());

                }
                else
                {
                    //keep rolling
                    Debug.Log("CONTAINS:" + getDiceText());
                    rollDice();
                }
                //just to check the hashset
                foreach (string s in sinChecker)
                {
                    Debug.Log("SIN:" + s);
                }

            }
        }


    }
    /*
     
    Will program in a number randomizing animation later
     
     */
    private void rollDice()
    {


        //this returns integers 0 to 7

        randomNumber = Random.Range(0, 7);
        switch (randomNumber)
        {
            case 0:
                sprite.color = new Color(1f, 0.3f, 0.49f, 1f);
                break;
            case 1:
                sprite.color = new Color(1f, 1f, 0f, 1f);
                break;
            case 2:
                sprite.color = new Color(1f, 0f, 0.2f, 1f);
                break;
            case 3:
                sprite.color = new Color(0f, 0.5f, 0f, 1f);
                break;
            case 4:
                sprite.color = new Color(0f, 0.2f, 1f, 1f);
                break;
            case 5:
                sprite.color = new Color(0.9622642f, 0.5745565f, 0f, 1f);
                break;
            case 6:
                sprite.color = new Color(0.5510858f, 0.9056604f, 0.8913373f, 1f);
                break;
        }
        //Debug.Log("STRING: \n\n\n" + sins[randomNumber]);
        diceText = sins[randomNumber];
        //Debug.Log("SIN:" + getDiceText());
        //Debug.Log("\n\n\n" + sins[randomNumber]);
        //diceText = "\n\n\n" + sins[randomNumber];
        //Debug.Log("SIN:" + diceText);
        //text.text = diceText;
        setDiceText("\n\n\n" + diceText);

    }
    private string getDiceText()
    {
        return diceText;
    }
    private void setDiceText(string t)
    {
        text.text = t;
    }



}
