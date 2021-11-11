using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Real_Programmer_Gaming
{
    public partial class Form1 : Form
    {
        //there's a lot of random chance in this one lol
        Random randGen = new Random();

        //Page 0 is the title screen
        int page = 0;
        //player hp values
        int hp = 20;
        int hpMax = 20;
        //the items the player starts with
        int bombAmount = 1;
        int potionAmount = 1;
        //the hp of all the enemies
        int enemyHpMax;
        int enemyHp;
        //damage for battles
        int playerDamage;
        int enemyDamage;
        int fireDamage;
        int guardDamage;
        //variable for karma (determining the ending)
        int karma = 0;
        //variable for whether or not the player has seen the tutorial
        int tutorialDone = 0;
        int itemTutorialDone = 0;
        //determine which enemy it is
        int enemy;


        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Title screen to first page
            if (page == 0)
            {
                //progress the page
                page = 1;
                //display text
                label1.Text = "You are an up-and-coming adventurer.";
                label2.Text = "However, you have nothing to do at the moment.";
                label3.Text = "You can think of two options,";
                label4.Text = "you could either investigate the town you're in,";
                label5.Text = "or go explore the nearby forest.";
                button1.Text = "FOREST";
                button2.Text = "TOWN";
                //disable the two buttons that are being unused
                button3.Enabled = false;
                button4.Enabled = false;
            }
            else if (page == 1)
            {
                page = 2;

                label1.Text = "You decide to explore the forest.";
                label2.Text = "There are many rumors about this place.";
                label3.Text = "Some say that there's a magical spirit defending it,";
                label4.Text = "while some believe that's complete hogwash,";
                label5.Text = "rightfully so.";
                button1.Text = "CONTINUE";
                button2.Text = " ";
                button2.Enabled = false;
            }


            else if (page == 2)
            {
                page = 3;

                label1.Text = "Whilst thinking of the possibility of";
                label2.Text = "a forest spirit actually existing,";
                label3.Text = "you hear a rustling from a nearby bush.";
                label4.Text = "Would you like to investigate?";
                label5.Text = " ";
                label6.Text = " ";
                button1.Text = "YES";
                button2.Text = "NO";
                button2.Enabled = true;
            }
            else if (page == 3)
            {
                page = 4;

                label1.Text = "You peek into the bush...";
                label2.Text = "...and a wolf jumps right out at you!";
                label3.Text = "Prepare for battle!";
                label4.Text = " ";
                label5.Text = "(Yes, that's a wolf";
                label6.Text = "using pictures would be too hard.)";
                //display something on the opposite side of the smiley
                enemyLabel.Text = ">";
                //determine that it is indeed a wolf
                enemy = 1;

                button1.Text = "BATTLE!";
                button2.Text = " ";
                button2.Enabled = false;

                //set enemy hp
                enemyHpMax = 10;
                enemyHp = 10;
            }

            else if (page == 4)
            {
                page = 5;
                tutorialDone = 1;
                //tutorial
                label1.Text = "Welcome to battle!";
                label2.Text = "ATTACK attacks the enemy.";
                label3.Text = "ITEM allows you to use potions and bombs.";
                label4.Text = "DEFEND nullifies all damage this turn,";
                label5.Text = "And you can run with FLEE.";
                label6.Text = " ";
                label7.Text = "Now, fight!";

                button1.Text = "ATTACK";
                button2.Text = "ITEM";
                button3.Text = "DEFEND";
                button4.Text = "FLEE";

                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;

                //enemy hp is displayed
                healthLabel2.Text = $"❤ {enemyHp}/{enemyHpMax}";
            }
            else if (page == 5 || page == 16)
            {
                //attacking
                playerDamage = randGen.Next(5, 10);
                enemyHp = enemyHp - playerDamage;
                if (enemy == 1)
                {
                    enemyDamage = randGen.Next(3, 6);
                    hp = hp - enemyDamage;
                }
                else if (enemy == 2)
                {
                    enemyDamage = randGen.Next(6, 9);
                }
                //display

                //hp of both the player and enemy
                healthLabel.Text = $"❤ {hp}/{hpMax}";
                healthLabel2.Text = $"❤ {enemyHp}/{enemyHpMax}";

                
                //actual text
                if (enemy == 1)
                {
                    label1.Text = "You hack at the wolf with your sword!";
                }
                else if (enemy == 2)
                {
                    label1.Text = "You stab at the bear with your blade!";
                }
                label2.Text = " ";
                label3.Text = $"You dealt {playerDamage} to it,";
                label4.Text = $"and it dealt {enemyDamage} to you!";
                label5.Text = " ";
                label6.Text = " ";
                label7.Text = " ";

                //progressing the battle
                if (enemyHp > 0 && hp > 0)
                {
                    if (enemy == 1)
                    {
                        page = 4;
                    }
                    else if (enemy == 2)
                    {
                        page = 15;
                    }
                }
                else if (enemyHp < 0)
                {
                    if (enemy == 1)
                    {
                        page = 9;
                    }
                    else if (enemy == 2)
                    {
                        page = 17;
                    }
                }
                else if (hp < 0)
                {
                    page = 999;
                }

                button1.Text = "CONTINUE";
                button2.Text = " ";
                button3.Text = " ";
                button4.Text = " ";
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
            else if (page == 9)
            {
                //victory text
                label1.Text = "You defeated the wolf!";
                label2.Text = "Your HP has increased by 5,";
                label3.Text = "and it dropped a health potion...";
                label4.Text = "somehow.";
                label5.Text = " ";
                label6.Text = " ";
                label7.Text = " ";
                enemyLabel.Text = " ";
                //victory rewards
                hpMax = 25;
                hp = 25;
                potionAmount = potionAmount + 1;
                page = 10;
                karma = karma - 1;
                healthLabel.Text = $"❤ {hp}/{hpMax}";
            }
            else if (page == 17)
            {
                //victory text
               
                label1.Text = "You defeated the bear!";
                if (karma == -1)
                {
                    label2.Text = "That wasn't so hard!";
                    label3.Text = "Nothing could possibly stop you!";
                }
                else if (karma == 0)
                {
                    label2.Text = "For your first fight, that was";
                    label3.Text = "Pretty tough!";
                }
                else if (karma == 1)
                {
                    label2.Text = "After you defeated the bear...";
                    label3.Text = "the glow of the forest dims.";
                }
                label4.Text = " ";
                label5.Text = "Whatever the case, the bear had...";
                label6.Text = "a bomb. Where did that come from?";
                label7.Text = "And your hp increases by 5.";
                enemyLabel.Text = " ";
                healthLabel2.Text = "❤ ??/??";
                //victory rewards
                hpMax = hpMax + 5;
                hp = hpMax;
                potionAmount = potionAmount + 1;
                page = 18;
                karma = karma - 1;
                healthLabel.Text = $"❤ {hp}/{hpMax}";
            }
            else if (page == 10)
            {
                healthLabel2.Text = "❤ ??/??";
                label1.Text = "After having successfully";
                label2.Text = "defeated the wolf, you continue";
                label3.Text = "to explore.";
                label4.Text = " ";
                label5.Text = " ";
                label6.Text = " ";
                label7.Text = " ";
                page = 12;
            }
            else if (page == 999)
            {
                label1.Text = "You died!";
                label2.Text = "Now, unfortunately, due to the fact";
                label3.Text = "that I am bad at coding";
                label4.Text = "your game will close once you press";
                label5.Text = "continue.";
                label6.Text = " ";
                label7.Text = "I hope you try again!";
                page = 1000;
            }
            else if (page == 1000)
            {
                Close();
            }

            else if (page == 12)
            {
                label1.Text = "Exploring deep into the forest";
                label2.Text = "you find more and more things";
                label3.Text = "that appear to be amiss.";
                label4.Text = "Lights deeper into the forest,";
                label5.Text = "crystals that you've never seen before...";
                label6.Text = " ";
                label7.Text = "It was almost as if the place was magic.";
                page = 13; 
            }
            else if (page == 13)
            {
                label1.Text = "...before you could think any more";
                label2.Text = "about it, you hear something approaching...";
                label3.Text = "the bushes begin to rustle loudly...";
                label4.Text = "getting louder.";
                label5.Text = "You realize if you don't do something now,";
                label6.Text = "you'll surely be caught by what's approaching.";
                label7.Text = "What will you do?";
                button1.Text = "ATTACK";
                button2.Text = "DEFEND";
                button2.Enabled = true;
                page = 14;
            }
            else if (page == 14)
            {
                label1.Text = "You decide to ready for battle...";
                label2.Text = "...";
                label3.Text = "And a bear jumps out at you!!";
                label4.Text = "You were ready for the attack,";
                label5.Text = "dealing 8 damage to the beast!";
                label6.Text = "It staggers backwards, and looks mad...";
                label7.Text = "and you're already ready for battle!";
                enemyLabel.Text = ">º";
                enemyHp = 17;
                enemyHpMax = 25;
                healthLabel2.Text = $"❤ {enemyHp}/{enemyHpMax}";
                button1.Text = "CONTINUE";
                button2.Text = " ";
                button2.Enabled = false;
                page = 15;
                enemy = 2;
            }
            else if (page == 15)
            {
                page = 16;
                if (tutorialDone == 0)
                {
                    //tutorial
                    label1.Text = "Welcome to battle!";
                    label2.Text = "ATTACK attacks the enemy.";
                    label3.Text = "ITEM allows you to use potions and bombs.";
                    label4.Text = "DEFEND nullifies all damage this turn,";
                    label5.Text = "And you can run with FLEE.";
                    label6.Text = " ";
                    label7.Text = "Now, fight!";
                    tutorialDone = 1;
                }
                else if (karma == -1)
                {
                    label1.Text = "The bear stands before you!";
                    label2.Text = " ";
                    label3.Text = "You've already defeated another";
                    label4.Text = "denizen of this place.";
                    label5.Text = "This shouldn't be too different!";
                    label6.Text = " ";
                    label7.Text = " ";
                }
                else if (karma == 1)
                {
                    label1.Text = "The bear stands before you!";
                    label2.Text = " ";
                    label3.Text = "However, it seems like";
                    label4.Text = "it's only trying to defend itself";
                    label5.Text = "Maybe it'd be better to leave it alone.";
                    label6.Text = " ";
                    label7.Text = " ";
                }
                button1.Text = "ATTACK";
                button2.Text = "ITEM";
                button3.Text = "DEFEND";
                button4.Text = "FLEE";
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
            //POTION USE BELOW
            // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // 
            // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // 
            //XANDER DON'T DO ANYTHING DOWN HERE 

            else if (page == 7)
            {
                if (potionAmount > 0 && hp < hpMax)
                {
                    page = 4;

                    //restore hp
                    hp = hp + 20;
                        if (hp > 20)
                    {
                        hp = 20;
                    }
                    potionAmount = potionAmount - 1;
                    //hp of both the player and the wolf
                    healthLabel.Text = $"❤ {hp}/20";
                    healthLabel2.Text = $"❤ {enemyHp}/{enemyHpMax}";

                    label1.Text = "You drank the potion, you feel better already!";
                    label2.Text = "Glory to the magic of pre-modern medicine!";
                    label3.Text = $"Your HP was restored to {hp}.";

                    //hp of both the player and the wolf
                    healthLabel.Text = $"❤ {hp}/20";
                    healthLabel2.Text = $"❤ {enemyHp}/{enemyHpMax}";

                    label4.Text = " ";
                    label5.Text = " ";
                    label6.Text = " ";
                    label7.Text = " ";

                    button1.Text = "CONTINUE";
                    button2.Text = " ";
                    button3.Text = " ";
                    button4.Text = " ";

                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                }

                else if (potionAmount == 0)
                {
                    if (enemy == 1)
                    {
                        page = 4;
                    }
                    else if (enemy == 2)
                    {
                        page = 15;
                    }

                    label1.Text = "You reafch into your pocket for";
                    label2.Text = "a cure for all that ails you...";
                    label3.Text = " ";
                    label4.Text = "But you realize you wasted them already.";
                    label5.Text = "Good going.";
                    label6.Text = " ";
                    label7.Text = " ";

                    button1.Text = "BACK";
                    button2.Text = " ";
                    button3.Text = " ";
                    button4.Text = " ";

                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                }
                else if (hp == hpMax)
                {
                    if (enemy == 1)
                    {
                        page = 4;
                    }
                    else if (enemy == 2)
                    {
                        page = 15;
                    }
                    label1.Text = "You couldn't stomach this potion if you tried.";
                    label2.Text = "Your HP is already full.";
                    label3.Text = " ";
                    label4.Text = " ";
                    label5.Text = " ";
                    label6.Text = " ";
                    label7.Text = " ";

                    button1.Text = "BACK";
                    button2.Text = " ";
                    button3.Text = " ";
                    button4.Text = " ";

                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;

                }
            } 
                

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (page == 3)
            {
                label1.Text = " ";
                label2.Text = " ";
                label3.Text = " ";
                label4.Text = " ";
                label5.Text = " ";
                label6.Text = " ";
                label7.Text = " ";
            }
            else if (page == 5 || page == 16)
            {

                    page = 7;
                    //item tutorial
                    label1.Text = $"You have {potionAmount} potions.";
                    label2.Text = $"You have {bombAmount} bombs.";
                    label3.Text = " ";
                    label4.Text = "Using a potion will heal you for 15 HP,";
                    label5.Text = "while using a bomb will hurt the";
                    label6.Text = "enemy for 15 hp.";
                    label7.Text = "Use them wisely!";

                    button1.Text = "POTION";
                    button2.Text = "BOMB";
                    button3.Text = "BACK";
                    button4.Text = " ";
                    button4.Enabled = false;

            }

                //BOMB STUFF DOWN HERE
                // // // // // // // // // // // // // // // // // 
                // // // // // // // // // // // // // // // // // 
                //XANDER I SAID DON'T EDIT DOWN HERE

                else if (page == 7)
                {
                    //using the bomb
                    if (bombAmount > 0)
                    {
                    if (enemy == 1)
                    {
                        page = 4;
                    }
                    else if (enemy == 2)
                    {
                        page = 15;
                    }
                        //consume the bomb
                        bombAmount = bombAmount - 1;

                        //do damage with the bomb
                        enemyHp = enemyHp - 15;

                        //somehow the enemy is still standing
                        if (enemy == 1)
                    {
                        enemyDamage = randGen.Next(3, 6);
                    }
                        else if (enemy == 2)
                    {
                        enemyDamage = randGen.Next(6, 9);
                    }
                        hp = hp - enemyDamage;

                        //hp of both the player and the enemy
                        healthLabel.Text = $"❤ {hp}/{hpMax}";
                        healthLabel2.Text = $"❤ {enemyHp}/{enemyHpMax}";

                        //bomb text
                        label1.Text = "The bomb delivers a powerful blow to the enemy!.";
                        label2.Text = "It takes 15 damage!.";
                        label3.Text = $"And you also take {enemyDamage},";
                        label4.Text = "because it somehow attacked you.";
                        label5.Text = " ";
                        label6.Text = " ";
                        label7.Text = " ";

                        button1.Text = "CONTINUE";
                        button2.Text = " ";
                        button3.Text = " ";
                        button4.Text = " ";

                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                    if (enemyHp < 1)
                    {
                        page = 9;
                    }
                    else if (hp < 1)
                    {
                        page = 999;
                    }

                    }
                    else if (bombAmount == 0)
                    {
                        page = 4;
                        label1.Text = "You reach into your pocket for";
                        label2.Text = "one of your trusty explosives...";
                        label3.Text = " ";
                        label4.Text = "But you realize you wasted them already.";
                        label5.Text = "Good going.";
                        label6.Text = " ";
                        label7.Text = " ";

                        button1.Text = "BACK";
                        button2.Text = " ";
                        button3.Text = " ";
                        button4.Text = " ";

                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                    }

                

                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (page == 5 || page == 16)
            {
                label1.Text = "You blocked the enemies attack!";
                label2.Text = " ";
                label3.Text = "Neither of you took any damage.";
                label4.Text = " ";
                label5.Text = " ";
                label6.Text = " ";
                label7.Text = " ";
                if (enemy == 1)
                {
                    page = 4;
                }
                else if (enemy == 2)
                {
                    page = 15;
                }

                button1.Text = "CONTINUE";
                button2.Text = " ";
                button3.Text = " ";
                button4.Text = " ";
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
            //DON'T EDIT DOWN HERE EITHER
            // // // // // // // // // // // // // // // // // // // 
            // // // // // // // // // // // // // // // // // // // 
            //THIS ONES FOR GOING BACK TO YOUR MAIN OPTIONS 

            if (page == 7)
            {
                if (enemy == 1)
                {
                    page = 4;
                }
                else if (enemy == 2)
                {
                    page = 16;
                }
                label1.Text = "You decide not to use an item.";
                label2.Text = " ";
                label3.Text = "Sometimes it's better to save your items.";
                label4.Text = " ";
                label5.Text = " ";
                label6.Text = " ";
                label7.Text = " ";

                button1.Text = "CONTINUE";
                button2.Text = " ";
                button3.Text = " ";
                button4.Text = " ";

                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (page == 5)
            {
                label1.Text = "You decide to book it the hell";
                label2.Text = "outta there!";
                label3.Text = " ";
                label4.Text = "Maybe that was the right choice.";
                label5.Text = "You also found a health potion";
                label6.Text = "while you were running.";
                label7.Text = " ";
                //victory rewards
                potionAmount = potionAmount + 1;
                karma = karma + 1;
                page = 12;
                button1.Text = "CONTINUE";
                button2.Text = " ";
                button3.Text = " ";
                button4.Text = " ";

                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;

            }
            else if (page == 16)
            {
                karma = karma + 1;
                label1.Text = "You decide that you'd better flee!";
                label2.Text = "But, instead of the bear chasing you,";
                label3.Text = "it leaves you be.";
                if (karma == 2)
                {
                    label4.Text = " ";
                    label5.Text = "You turn back around to face it.";
                    label6.Text = "You feel a weird tinge in your body";
                    label7.Text = "as it looks you in the eyes.";
                }
                else
                {
                    label4.Text = " ";
                    label5.Text = "You decide not to think about it";
                    label6.Text = "too hard. After all, animals are";
                    label7.Text = "pretty weird sometimes.";
                }

            }
            
        }
    }
}
