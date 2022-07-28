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
    public int points;
    public bool roll;
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
    public Scene(string text, string b1, string b2, string b3, Scene s1, Scene s2, Scene s3, int bg,int points=0, bool rollDice = false)
    {

        dialogue = text;
        button1 = b1;
        button2 = b2;
        button3 = b3;
        scene1 = s1;
        scene2 = s2;
        scene3 = s3;
        img = bg;
        roll = rollDice;
        this.points = points;

    }

}

public class GameController : MonoBehaviour
{
    public Button diceTester;
    Scene currScene;
    public TMP_Text dialogue;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public GameObject bgImage;
    public Sprite[] images;
    public bool roll = false;
    int points = 0;


     
    //Static objects can only be called after they have been created 

    //static Scene scene111 = new Scene("I will take a potato chip ... and EAT IT!!!!!",
    //                     null, null, null,
    //                     null, null, null,
    //                     5);

    //static Scene scene10 = new Scene("There are three things all wise men fear. A storm in the sea, a night with no moon, and the anger of a gentle man",
    //                     null, "DeathNote", null,
    //                     null, scene5, null,
    //                     4);

    //Ending

    static Scene gameover = new Scene("Game Over",
         null, null, null,
        null, null, null,
         0, 0);

    static Scene scene18 = new Scene("You. YOU. YOU DID IT?! YOU ACTUALLY COMPLETED THEM ALL?! I really thought you’d actually fail on that last one! Well as they say, “Believe in the heart of the cards”. Wait, wrong game. What I meant to say is, Congratulations! Lo hicimos, we did it! And now there’s nothing left but to roll out the red carpet. This sin, this sin, or this sin! Choose the sinful life to go back to as it was and you’ll continue to live a wonderful life from there! *Sven’s dots are crossed, Sven walks back ready to receive the next unlucky player* ",
             null, null, null,
            null, null, null,
             3,0, true);
    //Greed

    static Scene scene17 = new Scene("PHEW! Well you gotta outta there pretty quick! Now gimme that! *takes the duffel bag and counts the money*  Looks good, I’ll be confiscating this for...personal reasons :3 Let’s move on shall we?",
                 null, "Next", null,
                null, scene18, null,
                 3, 0, true);







    static Scene greed22 = new Scene("The police don’t suspect a thing,  find the car, and drive away to safety. Congrats on a successful mission!",
     null, "Next", null,
    null, scene17, null,
     3, 1);

    static Scene greed21 = new Scene("The police look at you and think you are a crazy man. Haven’t you ever heard of personal care? It’s important! Anyways you manage to find the car and drive away while attracting attention to yourself. You know that this isn’t pride or envy right?",
     null, "Next", null,
    null, scene17, null,
     3, -1);

    static Scene greed20 = new Scene("The cops rush inside the bank while you make your get away. Smart but don’t you think they might look for you, the witness, again?",
         null, "Next", null,
        null, scene17, null,
         3, -2);



    static Scene greed19 = new Scene("You grab the money and run out of the building. You realize you stole the manager’s car keys and look for a lamborghini. You see a couple of police nearby.",
     "Calmly walk by and act natural ", "Run in the opposite direction", "Tell the cops that there is a bank robbery happening inside",
    greed22, greed21, greed20,
     3);
    //----------

    static Scene greed18 = new Scene("The manager freezes up and points to where the Vault is and you steal as much as you can. Jewelry, gold bars, cash, you name it.",
     null, "Next", null,
    null, greed19, null,
     3,1);

    static Scene greed17 = new Scene("The manager, although surprised, calmly presents the vault as she talks in depth about her family and realizes her life mattered more than her job. You proceed to take all the money, jewels, and Gol bars that you could and run out.",
     null, "Next", null,
    null, greed19, null,
     3, 2);

    static Scene greed16 = new Scene("You keep talking to the manager and realize what a nice person she is. She cares for her family while working hard at her job, you realize that you have family back home. What would your child say to you if they knew what you did? You go home and give up. What part of you must complete 7 missions did you not understand, dumbass? *suddenly you start to not feel so good. Did you hear a snap? *",
         null, "Next", null,
        null, gameover, null,
         3, -100);



    static Scene greed15 = new Scene("You and the manager keep talking and the manager casually mentions that it’s almost time for lunch. You realize that time is running out. ",
     "Pull out your gun on the manager and demand the money", "“I’m here for the money” and proceed to present all the weapons at your disposal", "Keep talking to the manager",
    greed18, greed17, greed16,
     3);




    //-------------

    static Scene greed14 = new Scene("You pull out your gun and shoot at the Manager. The whole building is on alert. This is the wrong sin! Go back and commit the right sin! ",
     null, "Next", null,
    null, gameover, null,
     3,-100);

    static Scene greed13 = new Scene("You’ve always wanted a nice race car like the Lamborghini! The Manager keeps talking to you and you slowly get bored.",
     null, "Next", null,
    null, greed15, null,
     3, 2);

    static Scene greed12 = new Scene("Turns out your credit score sucks, you get kicked out and you fail. Maybe you shouldn’t be using credit cards if your debt is 100,000 from the housing crash of 2008-9.",
         null, "Next", null,
        null, gameover, null,
         3, -2);



    static Scene greed11 = new Scene("While in the manager’s office, it’s just you and the manager. You notice a set of car keys for a lamborghini, a circle on his calendar for something special, and a photo of a family happily living together. Would be a shame if something happened to them. The manager begins to ask you the matter of your business and you",
     "“I’m here to kill you!”", "Steal the keys without the manager looking", "Ask for an investment loan",
    greed14, greed13, greed12,
     3);



    //------------------

    static Scene greed10 = new Scene("You smack the teller and the teller is flabbergasted, security runs over and simply kicks you out, but not without the manager chewing out the teller in the distance. ",
     null, "Next", null,
    null, gameover, null,
     3, -1);

    static Scene greed9 = new Scene("You request their attention, and they don’t respond, you move to another teller instead who turns out to be the manager and fires the first teller on the spot. The manager call you into their office and helps provide great customer service from there",
     null, "Next", null,
    null, greed11, null,
     3, 1);

    static Scene greed8 = new Scene("The teller looks at you funny and then sees a nearby kid with a toy gun. He calls over the manager and whispers to him. You vaguely here the words “funny in the head” and “joker” before the manager turns to you and invites you to his office while smiling.",
         null, "Next", null,
        null, gameover, null,
         3,-1);



    static Scene greed7 = new Scene("As you inch closer to the teller, they don’t seem to be paying any attention to their work, instead they seem busy on a call with their significant other. You reach this teller. Choose your action:",
     "Smack the teller across the head", "Request their attention", "Whisper to the Teller that you have a gun",
    greed10, greed9, greed8,
     3);

    //-----------------

    static Scene greed6 = new Scene("You walk in casually and nobody suspects a thing",
     null, "Next", null,
    null, greed7, null,
     3,1);

    static Scene greed5 = new Scene("You forgot you get nervous and missed all your shots, cops shot you and now you’re about to die. Meanwhile, you hear a faint cry, old room mate and he still doesn't have his half of the rent, even in hell",
     null, "Next", null,
    null, gameover, null,
     3,-1);

    static Scene greed4 = new Scene("They think you’re just a weird mentally ill homeless dude, reverse psychology is weird.",
         null, "Next", null,
        null, greed7, null,
         3,1);


    static Scene greed3 = new Scene("“What will you do first?”",
         "Walk in casually", "Take out your gun and immediately start shooting", "Tell the people on the street that you’re going to rob the bank",
        greed6, greed5, greed4,
         3);

    //----------------

    static Scene greed2 = new Scene("*You’ve been given a gun, three bombs, and a lighter*",
             null, "Next", null,
            null, greed3, null,
             3);

    static Scene greed1 = new Scene("Sven: “Looks like you gotta rob a bank. Don’t you love it when greed supersedes the need to be righteous? Well, it’s quite alright; not to worry! Off you go! Don’t forget, if you get caught your soul gets demolished to a million little pieces in whatever way amuses me the most! By the way, here is a starter kit. Enjoy! ”",
                 null, "Next", null,
                null, greed2, null,
                 3);

    static Scene scene16 = new Scene("AHHHH Greed eh?  Money and Good ol Gold. Who doesn’t want to be rich? I’d buy myself a house if I had just enough... But who’s got time?! Anyway, hop to it and try not to get caught.",
                     null, "Next", null,
                    null, greed1, null,
                     3);

    //Pride
    static Scene scene15 = new Scene("Well that was smashing! Brains, smashed brains. Get it? Sigh fine, humor is wasted on you. But at least you survived with your pride intact.Just uh, don’t get carried away, you’re not a rebel anymore, just another soul ready to get judged on my scale * Pulls out a cute looking scale * Dammit, my daughter switched my scales... no matter, ONWARDS!",
    null, "next", null,
    null, scene16, null,
     3, 0, true);



    static Scene pride18 = new Scene("You scatter oil around and make your escape. All pursuing police and security personnel fall on their butts and can’t catch up. Nice use of the oil!",
     null, "Next", null,
    null, scene15, null,
     3, 2);

    static Scene pride17 = new Scene("You struggle to find the police frequency. As you are struggling, the police catch up with you. You are arrested. Who told you to use something you have no experience with? Why couldn’t you just run? You had a head start as well? Useless.",
     null, "Next", null,
    null, gameover, null,
     3, -100);

    static Scene pride16 = new Scene("You just start running. Some pedestrians stare but no one says anything because of the confidence you are running with. You get away but someone might have taken a video of you.",
         null, "Next", null,
        null, scene15, null,
         3, -1);


    static Scene pride15 = new Scene("Alright now time to get away! What do you do?",
         "Spill oil behind you and run into an alley", "Use the walkie talkie to try and listen in to police radio ", "Run like the wind",
        pride18, pride17, pride16,
         3);

    //--------------

    static Scene pride14 = new Scene("You manage successfully to blow her brains out. Guess they don’t know about guns in fairy tales. Boring kill but at least you assassinated her.",
     null, "Next", null,
    null, pride15, null,
     3, 1);

    static Scene pride13 = new Scene("You do a 360 turn aim the gun at the Queen without looking through the scope and pull the trigger. Damn that felt good and that bullet goes straight through her heart. She’s not going to be lying to any children ever again. +STYLE POINTSx100!! Ain’t nobody got more swag than you right now!",
     null, "Next", null,
    null, pride15, null,
     3, 2);

    static Scene pride12 = new Scene("Umm you realize you’re pretty far away right? None of your shots hit the Queen. The police and security see the multiple bullets coming out of the clock tower and arrest you. You do have a brain right? Why would you choose to do that of all things?",
         null, "Next", null,
        null, gameover, null,
         3, -100);


    static Scene pride11 = new Scene("The queen has arrived for her speech. The rest of the square has filled up with people here to hear her lie about how we can all be princesses. LIES!!! Anyways, what do you do?",
         "Calmly aim for the queens head while calculating wind and distance", "Go for that sweet 360 no scope headshot", "Just start blasting",
        pride14, pride13, pride12,
         3);



    //----------

    static Scene pride10 = new Scene("You get a nice nap and wake up well rested. And you didn’t get into any trouble. How about that!",
     null, "Next", null,
    null, pride11, null,
     3, 2);

    static Scene pride9 = new Scene("You decide to play some ranked and get tilted from losing so hard. L+Ratio. You’re annoyed. Bad start to the assassination. Plus someone might have heard your screams echoing in the clock tower.",
     null, "Next", null,
    null, pride11, null,
     3, -2);

    static Scene pride8 = new Scene("You’re a little hungry so you go grab some food. You’re in a good mood after eating which means you’re ready for that assassination!",
         null, "Next", null,
        null, pride11, null,
         3, 1);


    static Scene pride7 = new Scene("After setting up camp there is still 6 hours till the Queen’s speech. What do you want to do meanwhile?",
         "Take a nap", "Play some mobile games", "Go grab some food",
        pride10, pride9, pride8,
         3);


    //-----------

    static Scene pride6 = new Scene("You manage to find a sequestered location and set up your sniper rifle. You have direct line of sight of the Queen.",
     null, "Next", null,
    null, pride7, null,
     3, 1);

    static Scene pride5 = new Scene("The hit squad snitch on you and you get arrested. What? Did you actually think someone would do your job for you? Are you crazy?",
     null, "Next", null,
    null, gameover, null,
     3, -100);

    static Scene pride4 = new Scene("People think you are crazy and someone reports to the police but you manage to successfully set up a sniping location in the clock tower.",
         null, "Next", null,
        null, pride7, null,
         3, -2);


    static Scene pride3 = new Scene("“The Queen is visiting your city today! What a coincidence! She will be giving a speech in the city square there luckily happens to be a defunct clock tower in a straight line from the podium. What will you do first?”",
         "Set up camp on top floor of the clock tower at night", "Call for a hit squad to assassinate the Queen in your place.", "Declare your assassination during the day and set up camp in the clock tower.",
        pride6, pride5, pride4,
         3);

    //------------


    static Scene pride2 = new Scene("*You’ve been given a sniper rifle, one can of oil, and a walkie talkie*",
              null, "Next", null,
             null, pride3, null,
              3);



    static Scene pride1 = new Scene("Sven: “Don’t you just hate some people? Like your boss who stole money and framed you for it? Or maybe that two faced person who lives just for clout? Well congrats because this mission is assasination! And your target is the Queen of Fairy Tales! Why? Because someone wanted to be a princess. And when they grew up they realized they could never be a princess. So kill the Queen that lied to them? Here are some tools to help you”",
                 null, "Next", null,
                null, pride2, null,
                 3);

    static Scene scene14 = new Scene("HO HO! Pride, the single most guaranteed way for most men to die a painful and often stupid death. Florida’s got a ton of it, and you have none. But this crime is gonna need you to find some, so good luck! I’ll be watching from the sidelines *eats popcorn*",
                     null, "Next", null,
                    null, pride1, null,
                     3);





    //Gluttony
    static Scene scene13 = new Scene("WAIT WAIT WAIT, DON’T DO THAT....*Player starts vomitting*  right here....Well...I guess your appetite is gonna be nonexistent for the rest of this game. But at least that taste stays fore- * you continue vomiting* you continue that, and I’ll just roll myself instead... ",
    null, "next", null,
    null, scene14, null,
     3, 0, true);

    static Scene gluttony6 = new Scene("You toss the bonesaw. People aren’t focused on you but now you don’t have your needed weapon. Bones are tough you know?",
    null, "Next", null,
    null, gameover, null,
    3, -1);

    static Scene gluttony5 = new Scene("You enter the shop, turns out it’s a deli! Guess your bonesaw came in handy. The manager asks if you’re the new hire and you say yes to blend in. ",
    null, "Next", null,
    null, scene13, null,
    3, 1);

    static Scene gluttony4 = new Scene("You keep walking and gain the attention of the District Attorney and consequently get questioned by the police, you starve to death.",
    null, "Next", null,
    null, gameover, null,
    3, -100);

    static Scene gluttony3 = new Scene("You walk down the street, Everyone gives you weird looks. They seem to be staring at you because of the bonesaw. What do you do?",
     "Toss the bonesaw away", "Enter the closest food shop", "Keep walking with your bonesaw in hand",
    gluttony6, gluttony5, gluttony4,
     3);

    //-------------

    static Scene gluttony2 = new Scene("*You’ve been given a bonesaw*",
         null, "Next", null,
        null, gluttony3, null,
         3);


    static Scene gluttony1 = new Scene("Sven: *stomach gurgles more* Damn, You must be really hungry! Well, good luck satiating it! *bites into a sandwich while looking you in the eyes* The crime you gotta commit this time is cannibalism! Are you excited?!",
                     null, "Next", null,
                    null, gluttony2, null,
                     3);



    static Scene scene12 = new Scene("*STOMACH GURGLES* oh hey, it’s gluttony! Time to eat! I was getting super hungry. What? You think Dice don’t eat ? Amazing, I couldn’t find a dumber player if I wanted to.We eat your soul after you lose at the casino and when your DND gamemaster rolls you a 1 on your game finishing sequence.Your depression feeds me! But in your case...Well good luck finding someone! :D",
                     null, "Next", null,
                    null, gluttony1, null,
                     3);



    //Lust
    static Scene scene11 = new Scene("JESUS, Get a room, you two! *Sven poofs your partner to oblivion* you’ll be able to lust some more after I’m through with you. Now get back up and put your clothes on, nudity isn’t one of the sins here but my eyes don’t need to see THAT *Sven gags a little* ",
    null, "next", null,
    null,scene12, null,
     3, 0, true);

    static Scene scene10 = new Scene("*Sven moans* Aww Yeah! Just like that! Now we’re onto Lust! This one is probably my favorite because watching you humans get worked up over nothing is always funny. If you’d come over to my place, you’d see that it takes communication about boundaries and expectations to make a real relationship, but you peons can’t even do that! Svena always chokes me whenever i don’t do something right. Aren’t we such an understanding couple? Anyway, looks like you might finish this mission the fastest yet, so take your time and don’t get stuck in your head ;)",
                     null, "Next", null,
                    null, scene11, null,
                     3);


    //Envy
    static Scene scene9 = new Scene("HMMMMM, that’s all you got? Well how did it feel to get all those things? Feeling happy now? Or do you feel absolutely unfulfilled because the one thing you were searching for in life was not what someone else had but what you already had? SIKE, everyone knows the grass is greener on the other side! Speaking of other sides, what’s next?",
     null, "next", null,
    null, scene10, null,
     3, 0, true);


    static Scene envy18 = new Scene("You put the armor inside of a trash bin and start walking out. No one stops you probably because you’re dressed like you are the garbage man. Probably smell like garbage too. Ever heard of deodorant? Anyways, you manage to leave the mall and successfully steal the armor. Congrats! No one cares. Literally only you.",
    null, "Next", null,
    null, scene9, null,
    3, 2);

    static Scene envy17 = new Scene("It’s just a live viewing session at the mall. Whatever that means. But you’re acting like you bought it which isn’t possible. Your confidence actually sways the crowd and they let you through. Your supreme confidence lets you get out of the mall but you have a crowd of people and cameras that remember who you are.",
    null, "Next", null,
    null, scene9, null,
    3, -5);

    static Scene envy16 = new Scene("Yes, because clearly this works. No. No, it doesn't. Congrats by the way! For your arrest and failure to complete this mission. Let me give you a close up and interactive introduction to my giant industrial meat slicer. I’m sure you will love it!",
    null, "Next", null,
    null, gameover, null,
    3, -100);

    static Scene envy15 = new Scene("Inside the room you see a big shiny black and silver armor. As you get closer you can see that the armor is made up of numerous black and silver scales. You are entranced by it. You just touch it gently as if the condition will be ruined. Luckily no one else is in the room. What do you do?",
     "Shove the armor into a trash bin and cart it out like you are janitorial services", "Put it back in its original packaging and act like you bought it", "Wear it and walk out of the mall",
    envy18, envy17, envy16,
     3);

    //-------

    static Scene envy14 = new Scene("You walk towards the room like you are an ordinary person interested in the exhibit. Lucky for you, no one else seems to be interested. You calmly walk into the room without having alerted anyone.",
    null, "Next", null,
    null, envy15, null,
    3, 2);

    static Scene envy13 = new Scene("People see you acting weird and just assume that you are a special person. They don’t pay any more attention towards you but you have left an impression. You enter the room without anyone stopping you.",
    null, "Next", null,
    null, envy15, null,
    3, -1);

    static Scene envy12 = new Scene("Seriously, you are a skinny individual who is clearly not security holding a gun. Do you think that people are really going to fall for it? Because they are not. They all run down as they want to get away from you. You manage to get into the room",
    null, "Next", null,
    null, envy15, null,
    3,-2);

    static Scene envy11 = new Scene("You look around and see some escalators and elevators. You remember that it’s on the 5th floor so you grab an elevator all the way up. Now that you are on the 5th floor you see a door in the distance that has a sign that says “Don’t Miss the new Armor!” What do you do?",
     "Walk into the room like a normal person", "Start sneaking into the room like you are a spy", "Take out your pistol and act like you’re security",
    envy14, envy13, envy12,
     3);



    //--------

    static Scene envy10 = new Scene("You walk into the mall like a normal shopper. No one suspects a thing. It’s your lucky day. The metal detector seems broken. Looks like it was scraped by something.",
    null, "Next", null,
    null, envy11, null,
    3, 1);

    static Scene envy9 = new Scene("You ask the staff about the dragon scale armor. The staff talks about how cool it is and points to the picture on the flier. You ask if the staff has seen it in person. The staff seems hurt and just walks away. You have no new information and just walk into the mall.",
    null, "Next", null,
    null, envy11, null,
    3);

    static Scene envy8 = new Scene("What’s actually wrong with you? This mission is to steal a priceless suit of armor! Its not about murdering people. Do you need some help? Or do you need a brain? Because it looks like you’re missing one. ",
    null, "Next", null,
    null, gameover, null,
    3,-100);

    static Scene envy7 = new Scene("Having decided that it’s probably best to go check it out, you head to the mall. After getting there you see a big poster that says Dragon scale armor! Live viewing at the 5th floor! Do not Miss! You also see some staff handing out flyers for the event. You grab one and it says the same stuff as on the giant poster. What do you do?",
     "Confidently walk into the mall", "Go and talk to the staff handing out flyers", "Shoot the staff",
    envy10, envy9, envy8,
     3);

    //--------

    static Scene envy6 = new Scene("You put on the sunglasses. You check yourself out in the mirror. You look stylish AF. Time to rob in STYLE!",
    null, "Next", null,
    null, envy7, null,
    3, 2);

    static Scene envy5 = new Scene("You put a piece of tape on yourself. And now it’s stuck to you forever. You try to pull it off but it seems to have fused to your skin. Why would you do this? Now you have a bright silver patch on your arm. Just great.",
    null, "Next", null,
    null, envy7, null,
    3, -1);

    static Scene envy4 = new Scene("You ask someone about the armor but they have no idea. They seem to have heard of it for the first time as well. Now both of you are interested but know nothing about it. Great.",
    null, "Next", null,
    null, envy7, null,
    3);

    static Scene envy3 = new Scene("“Today is your lucky day. The FML Institute is showing off the dragon scale armor at the local shopping mall for some reason. Seriously there’s no reason to do it. But they are, so now’s your chance. What will you do first?”",
     "Wear the sunglasses", "Put some tape on yourself", "Ask someone about the dragon scale armor",
    envy6, envy5, envy4,
     3);

    //-----------
    static Scene envy2 = new Scene("*You’ve been given a pistol, a pair of sunglasses, and a roll of indestructible tape*",
             null, "Next", null,
            null, envy3, null,
             3);

    static Scene envy1 = new Scene("Sven: “Isn’t there that one thing that you’ve always wanted? Like that car, jewelry, or video game in that store that you’ve always wanted but can’t afford. That one thing that’s just beckoning to you. Well now’s your chance. The Full Meta Life Institute of FML institute is revealing their unique, only one in existence, dragon scale armor. I don’t know how they made it, but they’ve studied video games and somehow managed to make an actual dragon scale armor. And don’t you want it? Only you can own it. Why do they get to have it? So your next crime is to steal it. Here are some tools to help you.”",
                 null, "Next", null,
                null, envy2, null,
                 3);


    static Scene scene8 = new Scene("OMG, don’t you ever get Green with envy looking at someone have what you always wanted? I know I don’t! You expected me to desire things? I’m a die! What the hell else could i ever want besides my lovely Svena? Oh I’m coming my darling, but you need to commit that crime so hurry on and get envious! Hehe!",
                     null, "Next", null,
                    null, envy1, null,
                     3);

    //Sloth




    static Scene scene7 = new Scene("Yup. Did a good job. Next... *you can hear faint snoring*",
         null, "next", null,
        null, scene8, null,
         3, 0, true);

    //---------

    static Scene sloth9 = new Scene("You somehow manage to sneak out with the sloth, no one being the wiser about the missing sloth, nor the trail of sloth droppings that somehow led to you. ",
    null, "Next", null,
    null, scene7, null,
    3);

    static Scene sloth8 = new Scene("At the sloth enclosure, you notice someone didn’t take care in closing the door to the sloths. You enter. You find a sloth. I’m lazy, so here’s your next options.",
     "Take the sloth", "Take the sloth", "Take the sloth",
    sloth9, sloth9, sloth9,
     3);


    //---------

    static Scene sloth7 = new Scene("You see some tracks, and you begin to follow them. Turns out it was sloth poop and it led you 2 meters away to the sloth enclosure.",
    null, "Next", null,
    null, sloth8, null,
    3, 1);

    static Scene sloth6 = new Scene("You arrive at the sloth enclosure",
    null, "Next", null,
    null, sloth8, null,
    3, 1);

    static Scene sloth5 = new Scene("You relieved yourself and notice that a sloth is also relieving itself close by. Before you can do anything, a lion trudges a long and bites the sloth to its death while glaring back at you as if you were a pathetic hyena. Mission fail.",
    null, "Next", null,
    null, gameover, null,
    3, -100);

    static Scene sloth4 = new Scene("You arrive at the City Zoo. At the zoo you notice a few things. The security guards are at the entrance but seemingly nonchalant if people walk by without tickets. All the animals seem to be eating all the low-hanging fruit growing in their enclosures. Staff members seem to walking about very slowly as they tend each animal as if time has slowed down. But your timer continues to tick. What will you do?",
    "Observe some more", "Find the Sloth enclosure", "Go to the bathroom",
    sloth7, sloth6, sloth5,
    3);

    static Scene sloth3 = new Scene("What will you do first?",
     "You arrive at the Zoo", "You arrive at the Zoo", "You arrive at the Zoo",
    sloth4, sloth4, sloth4,
     3);


    //---------

    static Scene sloth2 = new Scene("*You’ve been given...nothing*",
                     null, "Next", null,
                    null, sloth3, null,
                     3);

    static Scene sloth1 = new Scene("Sven: zzzzz...hUH OH whA? Oh yeah...Sloth, so uh... Just get a sloth, yeah...good luck",
                     null, "Next", null,
                    null, sloth2, null,
                     3);


    static Scene scene6 = new Scene("YAAAAAAAAAAAAAAAAWWWWNNNNN, just uh...get in there or something. *you pass Sven and try to start the mission*",
                     null, "Next", null,
                    null, sloth1, null,
                     3);

    //Wrath

    

    

    static Scene scene5 = new Scene("OH MY! DON’T STEP ON THE CARPET *lays down some newspaper* Jeez you’re absolutely covered in blood! The stains are pretty tough if you don’t get 'em out quick. How do I get them out? Excuse you! You don’t ask a lady that question! Then again, I’m just a seven sided die. NEXT!",
             null, "next", null,
            null, scene6 , null,
             3, 0, true);


    static Scene wrath15 = new Scene("The jogger is about to pick up a rock leaving himself wide-open. You go in for the kill and he drops a knife from his hand. Turns out he was going to kill you all because you happened to be walking too slow for the jogger’s preference. You notice a few more bones along this river bank. They’re human bones buried in a hurried manner and exposed from recent rainfall. Some people just need to take a chill pill, don’t you agree?",
         null, "Next", null,
        null, scene5, null,
         3);


    //-----------


    static Scene wrath14 = new Scene("You kill him and he lets out a blood-curdling scream. Suddenly you hear even more rustling in the bushes followed by a phone call. Turns out a frisky couple were attempting salacious actions but stopped right when they saw you take out your knife. The police are going to come after you now. Now you know how it feels to take the SAT.",
     null, "Next", null,
    null, gameover, null,
     3, -100);

    static Scene wrath13 = new Scene("You decide not to kill him. He takes his leave, and now you’re alone in this park, by yourself. As you walk away and reach the end of the park. You feel a sharp pain in your back. It turns out that the jogger was planning on stabbing you for a sick sense of perversion! You die.",
     null, "Next", null,
    null, gameover, null,
     3, -100);

    static Scene wrath12 = new Scene("You both walk towards the river. You double-check the area and the coast is clear.",
         null, "Next", null,
        null, wrath15, null,
         3, 2);


    static Scene wrath11 = new Scene("You begin to inch closer to the playground. You hear some rustling in the bushes. You remember your knife is in your back pocket. The jogger still doesn’t notice your killing presence. Will you go for the kill?",
         "Kill him", "Don’t kill him", "Throw away the trash",
        wrath14, wrath13, wrath12,
         3);



    //-------------

    static Scene wrath10 = new Scene("You continue to follow him and he begins to take a break by the empty playground You look around and there’s no one around.",
     null, "Next", null,
    null, wrath11, null,
     3, 1);

    static Scene wrath9 = new Scene("You start having a conversation with the jogger, you learn that he’s a decent person! He likes video games and has an amazing personality! He sits by the empty playground ahead of you.",
     null, "Next", null,
    null, wrath11, null,
     3, -1);

    static Scene wrath8 = new Scene("You throw away the trash but you lose sight of him. After enough searching, you find him by the empty playground.",
         null, "Next", null,
        null, wrath11, null,
         3, 1);


    static Scene wrath7 = new Scene("You start following the jogging man. He’s talking very loudly into his airpods and can’t seem to notice his surroundings. You see something flashy drop. It’s a protein bar wrapper. Couldn’t this guy have properly thrown away his trash? ",
         "Continue to follow him", "Strike up a conversation", "Throw away the trash",
        wrath10, wrath9, wrath8,
         3);


    //--------

    static Scene wrath6 = new Scene("You go to the park, It’s somewhat empty and deserted on a Sunday night. Out of the corner of your eyes, you see a man jogging.",
     null, "Next", null,
    null, wrath7, null,
     3, 1);

    static Scene wrath5 = new Scene("Maybe you should wait instead of jumping into the job. You were on a busy street and the police are only seconds away from shooting you, idiot. Think about that when you’re dead.",
     null, "Next", null,
    null, gameover, null,
     3, -100);

    static Scene wrath4 = new Scene("Smart play, now you’re ready to stab without getting fingerprints anywhere. You end up walking to the park somehow. It’s somewhat empty and deserted on a Sunday night. Out of the corner of your eyes, you see a man jogging.",
         null, "Next", null,
        null, wrath7, null,
         3, 2);


    static Scene wrath3 = new Scene("What will you do? ",
         "Go and sit at a park", "Stab someone random", "Put on the gloves and walk around",
        wrath6, wrath5, wrath4,
         3);

    //-------

    static Scene wrath2 = new Scene("*You’ve been given a pair of gloves and a knife*",
                 null, "Next", null,
                null, wrath3, null,
                 3);


    static Scene wrath1 = new Scene("Sven:  BURNING WR- oh we’re here! Alright, so your goal is to commit murder! Why? I don’t know, I just deal out your sentence. Just find someone annoying to kill if you really gotta, but be quiet about it.Have fun!",
                 null, "Next", null,
                null, wrath2, null,
                 3);

    static Scene scene4 = new Scene("FIERY BURNING WRATH! Feel the heat of my wrath! Oh oh how about “Face my blazing wrath!” or what about “don’t make me wrathful, you don’t want to see me when I’m wrathing!”...I’ll workshop that, but in the meantime, lose your cool or die trying mwehehehe....",
                     null, "Next", null,
                    null, wrath1, null,
                     3);






    //Intro

    static Scene scene3 = new Scene("Ah right! You gotta complete each crime the right way or else you gotta do it allll over again. So make sure your decision is the right decision! Or I suppose wrong if you’re committing a crime. Now take me in your hands and throw me to find out what sin you commit first!",
                         null, "Next", null,
                        null, scene4, null,
                         3, 0, true);

    static Scene scene2 = new Scene("You will commit 7 crimes, one for each deadly sin that exists in your depressing little world! It’s quite the treat to spy- I mean observe your people. It’s like a variety mix of Chex Mix but with different flavors of sins. Chex Mix slaps! Anyways, what was I saying?",
                         null, "Next", null,
                        null, scene3, null,
                         2);

    static Scene scene1 = new Scene("Sven: Helloooo! Wakey-wakey. Ah you’re awake. You “fell” off a cliff but I think you should be fine. Weren’t you praying for money, fame, and power? Well today’s your lucky day! Kind of.. Maybe.. Probably not. But at least I’ll enjoy this. You were pretty lucky to get chosen for this wonderful mission. I’m Sven, don’t ask about the name, the developers had spell check turned off. Now let’s get started!",
                         null, "Next", null,
                         null, scene2, null,
                         1);

    int randomNumber() {
        return Random.Range(1, 7);
        }
    public void diceRoll()
    {
       //set a timer and change scene after a few seconds the dice has been rolled
        int number =  diceTester.GetComponent<ClickDice>().randomNumber;
        Debug.Log(number + "NUMBER");
        Scene newScene = scene14;
        switch (number) {
            case 1:
                newScene = scene14;
                break;
            case 2:
                newScene = scene16;
                break;
            case 3:
                newScene = scene4;
                break;
            case 4:
                newScene = scene8;
                break;
            case 5:
                newScene = scene10;
                break;
            case 6:
                newScene = scene12;
                break;
            case 7:
                newScene = scene6;
                break;
        }
        switchScene(newScene);
        //diceTester.GetComponent<ClickDice>().setRandomNumber(0);
        
    }

    void Start()
    {
        //sets the first scene
        diceTester.gameObject.SetActive(false);
        
        switchScene(scene1);
    }


    void switchScene(Scene newScene)
    {
        //Debug.Log("curRoll: "+ roll + " newRoll: "+ newScene.roll );
        if (roll)
        {
            diceTester.gameObject.SetActive(true);
            Debug.Log("Dice roll true");
            Scene diceScene = new Scene("Roll a dice",
                          null, null, null,
                          null, null, null,
                          1);
            newScene =diceScene;
        }
        else
        {
            diceTester.gameObject.SetActive(false);
        }



            //Debug.Log("dialogue Text:" + dialogue.text + "newScene dialoge: " + newScene.dialogue);
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

            roll = newScene.roll;

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
        if (currScene.roll) {
            diceTester.gameObject.SetActive(true);
        }
        switchScene(currScene.scene2);
    }
    public void onButtonClick3()
    {
        Debug.Log("Button3 Clicked");
        switchScene(currScene.scene3);
    }

}
