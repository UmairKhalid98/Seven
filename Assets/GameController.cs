using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Scene
{
    public string dialogue;
    public string button1;
    public string button2;
    public string button3;
    public string button4;
    public Scene scene1;
    public Scene scene2;
    public Scene scene3;
    public Scene scene4;

    public int img;

    /**
     * text : main dialogue on the screen
     * b1 : button 1 text,
     * b2 : button 2 text,
     * b3 : button 3 text,
     * s1 : scene 1 
     * s2 : scene 2 
     * s3 : scene 3 
     * 
     * Each button number takes you to the corresponding scene number
     * **/

    //Should definitely use an array or linkedlist of scenes with an id, will make it very clean. If time permits, I will do that
    public Scene(string text, string b1, string b2, string b3, Scene s1, Scene s2, Scene s3, int bg)
    {

        dialogue = text;
        button1 = b1;
        button2 = b2;
        button3 = b3;
        scene1 = s1;
        scene2 = s2;
        scene3 = s3;
        img = bg;

    }

}

public class GameController : MonoBehaviour
{
    Scene currScene;
    public TMP_Text dialogue;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public GameObject bgImage;
    public Sprite[] images;

    //Static objects can only be called after they have been created 

    static Scene scene5 = new Scene("I will take a potato chip ... and EAT IT!!!!!",
                         null, null, null,
                         null, null, null,
                         4);

    static Scene scene4 = new Scene("There are three things all wise men fear. A storm in the sea, a night with no moon, and the anger of a gentle man",
                         null, "DeathNote", null,
                         null, scene5, null,
                         3);

    static Scene scene3 = new Scene("I have found that it is the small everyday deed of ordinary folks that keep the darkness at bay. Small acts of kindness and love",
                         "Lord of the Rings", "KingKiller Chronicles", "Harry Potter",
                         null, scene4, scene5,
                         2);

    static Scene scene2 = new Scene("One Ring to rule them all, one ring to find them. One ring to bring them all and in the darkness bind them",
                         "Death Note", "The Hobbit", "Kingkiller Chronicles",
                         scene5, scene3, scene4,
                         1);

    static Scene scene1 = new Scene("Mr and Mrs Dursley of number four, privet drive were proud to say, they were completey normal. Thank you very much",
                         "Lord of the Rings", "The Hobbit", null,
                         scene2, scene3, null,
                         0);


    void Start()
    {
        //sets the first scene
        switchScene(scene1);
    }


    void switchScene(Scene newScene)
    {
        Debug.Log("dialogue Text:" + dialogue.text + "newScene dialoge: " + newScene.dialogue);
        dialogue.text = newScene.dialogue;

        //again an array would be a MUCH better option

        //checks if the button has been assigned a value
        button1.gameObject.SetActive(newScene.button1 != null);
        button2.gameObject.SetActive(newScene.button2 != null);
        button3.gameObject.SetActive(newScene.button3 != null);

        //adds the text to the scene
        button1.GetComponentInChildren<TMP_Text>().text = newScene.button1;
        button2.GetComponentInChildren<TMP_Text>().text = newScene.button2;
        button3.GetComponentInChildren<TMP_Text>().text = newScene.button3;

        bgImage.GetComponent<Image>().sprite = images[newScene.img];


        //sets the current scene to the new scene
        currScene = newScene;

    }

    public void onButtonClick1()
    {
        Debug.Log("Button1 Clicked");
        switchScene(currScene.scene1);
    }
    public void onButtonClick2()
    {
        Debug.Log("Button2 Clicked");
        switchScene(currScene.scene2);
    }
    public void onButtonClick3()
    {
        Debug.Log("Button3 Clicked");
        switchScene(currScene.scene3);
    }

}
