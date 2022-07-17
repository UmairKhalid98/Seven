using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ClickDice : MonoBehaviour
{

    private Text text;
    private Image image;
    int randomNumber;
    SpriteRenderer sprite;
    string[] sins;
    //MAKE SURE TO CHECK THE SIZE OF THE HASH SET AND COMPARE IT WITH THE ARRAY SIZE TO SEE IF YOU HAVE WON
    /*
     * Also we can put a meter
     */
    HashSet<string> sinChecker;
    private string diceText;
    float deltaTime;
    float countTimer;
    int randomNumberCount;
    bool startCount;
    private void Start()
    {
        text = GetComponentInChildren<Text>();
        sprite = GetComponent<SpriteRenderer>();
        randomNumber = 0;
        sins = new string[7] { "Pride", "Greed", "Wrath", "Envy", "Lust", "Gluttony", "Sloth" };
        sinChecker = new HashSet<string>();
        diceText = null;
        image = GetComponentInChildren<Image>();
        countTimer = 0;
        randomNumberCount = 1;
        startCount = false;
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
        deltaTime = Time.deltaTime;
        countTimer += deltaTime * 0.1f;
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
                //make active once scene arrives again
                image.gameObject.SetActive(false);
                startCount = true;
                countTimer = 0;
                //rollDice();
                rollDice();
                if (sinChecker.Add(getDiceText()))
                {

                    //FADE OUT THE DICE BUTTON AND FADE IN THE TEXT ADVENTURE


                    //this.gameObject.SetActive(false);
                }
                else
                {

                    //keep rolling because of sins already being finished



                    rollDice();
                }


                //USED FOR TESTING
                //--------------------------
                //foreach (string s in sinChecker)
                //{
                //    Debug.Log("SIN:" + s);
                //}
                //-----------------------------

            }
        }


    }
    /*
     
    Will program in a number randomizing animation later or never. idk. its backlog. 
     
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



        diceText = sins[randomNumber];
        setDiceText("\n" + randomNumber + "\n\n\n" + diceText);






    }
    private string getDiceText()
    {
        return diceText;
    }
    private void setDiceText(string t)
    {
        if (!sinChecker.Add(t))
        {
            //fade out already stored sins
            text.color = new Color(0.1960f, 0.1960f, 0.1960f, 0.25f);
            text.text = t;
        }
        else
        {
            //maintain regular alpha channel and color of dice information
            text.color = new Color(0.1960f, 0.1960f, 0.1960f, 1f);
            text.text = t;
        }

    }


    /*
     
     Number Generation Animation
     
     */


}
