using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ClickDice : MonoBehaviour
{

    private Text text;
    private Image image;
    public int randomNumber;
    Image sprite;
    string[] sins;
    //MAKE SURE TO CHECK THE SIZE OF THE HASH SET AND COMPARE IT WITH THE ARRAY SIZE TO SEE IF YOU HAVE WON
    /*
     * Also we can put a meter
     */
    HashSet<int> sinChecker;

    private string diceText;
    float deltaTime;
    public float countTimer;
    public int randomNumberCount;
    bool startCount;
    bool canRoll;


    private void Start()
    {
        text = GetComponentInChildren<Text>();
        sprite = GetComponent<Image>();
        randomNumber = 0;
        sins = new string[8] { "", "Pride", "Greed", "Wrath", "Envy", "Lust", "Gluttony", "Sloth" };
        sinChecker = new HashSet<int>();
        diceText = null;
        image = GetComponentInChildren<Image>();
        countTimer = 20;
        startCount = false;
        canRoll = false;
        //setDiceText();

        //USED FOR TESTING
        //--------------------
        //red = 1f;
        //green = 1f;
        //blue = 1f;
        //alpha = 1f;
        // --------------------

    }
    private void notCalled()
    {
        Debug.Log("updating..."+ countTimer);
        countTimer += Time.deltaTime;
        if (!canRoll && countTimer > 3)
        {
            Debug.Log("Can roll now, random number back to zero");
            //setRandomNumber(0);
            canRoll = true;
        }
    }
    //not used atm
    public void mouseClicked()
    {
        deltaTime = Time.deltaTime;
        countTimer += deltaTime * 0.1f;

        //USED FOR TESTING
        //---------------------------
        //Color c = new Color(red, green, blue, alpha);
        //sprite.color = c;
        //----------------------------

        /*
         * Mouse click down on the dice's box collider to detect a mouse point. if hits the collider, so something! 
         */
        if (Input.GetMouseButtonUp(0))
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                //make active once scene arrives again
                image.gameObject.SetActive(false);
                startCount = true;
                countTimer = 0;
                canRoll = true;
                //FindObjectOfType<AudioManager>().Play("DiceShuffle");




                //USED FOR TESTING
                //--------------------------
                //foreach (string s in sinChecker)
                //{
                //    Debug.Log("SIN:" + s);
                //}
                //-----------------------------

            }
        }
        //this for the shuffle effect
        //start a count and see how long it takes to reach 5 seconds
        if (startCount && countTimer < 5)
        {

            countTimer += deltaTime * 2; // i multiplied delta time here with 5 to speed things up
            randomNumberCount = Random.Range(1, 7);
            text.text = "\n" + randomNumberCount + "\n\n" + sins[randomNumberCount]; // just some random numbers for that subtle random number shuffle effect

        }
        else

        {

            startCount = false;
        }

        //stop the counting and can roll
        if (startCount == false && canRoll)
        {
            //rollDice(); // look into setDice Text afterwards
            canRoll = false;

        }

    }
    /*
     
    Will program in a number randomizing animation later or never. idk. its backlog. 
     
     */
    public void setDiceText()
    {

        //numbers 1 - > 7 for each sin
        //if (canRoll)
        //{
            randomNumber = Random.Range(1, 8);
        switch (randomNumber)
        {
            case 1:
                sprite.color = new Color(1f, 0.3f, 0.49f, 1f);
                break;
            case 2:
                sprite.color = new Color(1f, 1f, 0f, 1f);
                break;
            case 3:
                sprite.color = new Color(1f, 0f, 0.2f, 1f);
                break;
            case 4:
                sprite.color = new Color(0f, 0.5f, 0f, 1f);
                break;
            case 5:
                sprite.color = new Color(0f, 0.2f, 1f, 1f);
                break;
            case 6:
                sprite.color = new Color(0.9622642f, 0.5745565f, 0f, 1f);
                break;
            case 7:
                sprite.color = new Color(0.5510858f, 0.9056604f, 0.8913373f, 1f);
                break;


        }


        canRoll = false;
        countTimer = 0;

            text.text = "\n" + randomNumber + "\n\n" + sins[randomNumber];
            checkDice(randomNumber);
        //}

        //return randomNumber;



    }
    //called from gamecontroller
    //public void setRandomNumber(int t)
    //{
    //    randomNumber = t;
    //    text.text = "\n" + randomNumber + "\n\n" + sins[randomNumber];
    //}

    private string getDiceText()
    {
        return diceText;
    }
    private void checkDice(int t)
    {

        if (sinChecker.Contains(t))
        {
            Debug.Log("Dice Added");
            setDiceText(); //roll again
        }
        else
        {
            sinChecker.Add(t);
        }

    }




}
