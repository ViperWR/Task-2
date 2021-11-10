using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GADE_POE_task_1
{
    public partial class Form1 : Form
    {
        map map11 = new map(); 
        int directions = 0;
        int directions_A = 0;
        int enemy = 0;

        List<String> goblins_List = new List<string>();
        List<String> mage_List = new List<string>();

        int c = 0;

        public Form1()
        {
            InitializeComponent();

            map11.map_Height = 20;
            map11.map_Width = 20;
            map11.enemies_Arr = new int[5];
            map11.map_Arr = new string[map11.map_Width, map11.map_Height];

            map11.Create();              //creating the map

            map11.UpdateVision();           

            map11.Create_Objects();           //creating border and enemies

            hero_Stats();
            goblin_Stats();              //methods for creating the characters stats
            mage_Stats();

            MapLabel.Text = ""; //Create Map
            for (int i = 0; i < map11.map_Width; i++)
            {
                for (int n = 0; n < map11.map_Height; n++)
                {
                    MapLabel.Text = MapLabel.Text + map11.map_Arr[i, n];
                }
                MapLabel.Text = MapLabel.Text + "\n";
            }

            update_P_Stats();
        }      
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void update_Map()          //updates the map and new positions
        {
            MapLabel.Text = "";
            for (int i = 0; i < map11.map_Width; i++)
            {
                for (int n = 0; n < map11.map_Height; n++)
                {
                    MapLabel.Text = MapLabel.Text + map11.map_Arr[i, n];
                }
                MapLabel.Text = MapLabel.Text + "\n";
            }
        }
        public void update_P_Stats()            //updates player ui stats
        {
            richTextBox_Player_Stats.Text = "Player Stats:" + "\n HP: " + map11.hero_HP + "/" + map11.hero_Max_HP + "               Gold : " + map11.gold + "\n Damage: 2" + "\n [" + map11.hero_Coords_X + "," + map11.hero_Coords_Y + "]";
        }
        private void moveHero()              //moves hero
        {
            check_Lost();
            switch (directions)
            {
                case 1:                //left
                    if (map11.hero_Coords_Y > 0)
                    {
                        move_Enemies();
                        if (map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y - 1] == " ")
                        {
                            map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y] = " ";
                            map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y - 1] = "H";
                            map11.hero_Coords_Y -= 1;
                        }
                        else if (map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y - 1] == "C")
                        {
                            map11.gold += 1;
                            richTextBox_Item_Pickup.Text = "1 Gold coin added" + '\n' + "======================" + "\n" + richTextBox_Item_Pickup.Text;
                            map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y] = " ";
                            map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y - 1] = "H";
                            map11.hero_Coords_Y -= 1;
                        }
                    }

                    directions = 0;                //gets set to 0 so the player stops moving
                    return;
                case 2:                //right
                    if (map11.hero_Coords_Y < map11.map_Height - 1)
                    {
                        move_Enemies();
                        if (map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y + 1] == " ")
                        {
                            map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y] = " ";
                            map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y + 1] = "H";
                            map11.hero_Coords_Y += 1;
                        }
                        else if (map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y + 1] == "C")
                        {
                            map11.gold += 1;
                            richTextBox_Item_Pickup.Text = "1 Gold coin added" + '\n' + "======================" + "\n" + richTextBox_Item_Pickup.Text;
                            map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y] = " ";
                            map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y + 1] = "H";
                            map11.hero_Coords_Y += 1;
                        }
                    }
                    directions = 0;
                    return;
                case 3:                //up
                    if (map11.hero_Coords_X > 0)
                    {
                        move_Enemies();
                        if (map11.map_Arr[map11.hero_Coords_X - 1, map11.hero_Coords_Y] == " ")
                        {
                            map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y] = " ";
                            map11.map_Arr[map11.hero_Coords_X - 1, map11.hero_Coords_Y] = "H";
                            map11.hero_Coords_X -= 1;
                        }
                        else if (map11.map_Arr[map11.hero_Coords_X - 1, map11.hero_Coords_Y] == "C")
                        {
                            map11.gold += 1;
                            richTextBox_Item_Pickup.Text = "1 Gold coin added" + '\n' + "======================" + "\n" + richTextBox_Item_Pickup.Text;
                            map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y] = " ";
                            map11.map_Arr[map11.hero_Coords_X - 1, map11.hero_Coords_Y] = "H";
                            map11.hero_Coords_X -= 1;
                        }
                    }
                    directions = 0;
                    return;
                case 4:                //down
                    if (map11.hero_Coords_X < map11.map_Width - 1)
                    {
                        move_Enemies();
                        if (map11.map_Arr[map11.hero_Coords_X + 1, map11.hero_Coords_Y] == " ")
                        {
                            map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y] = " ";
                            map11.map_Arr[map11.hero_Coords_X + 1, map11.hero_Coords_Y] = "H";
                            map11.hero_Coords_X += 1;
                        }
                        else if (map11.map_Arr[map11.hero_Coords_X + 1, map11.hero_Coords_Y] == "C")
                        {
                            map11.gold += 1;
                            richTextBox_Item_Pickup.Text = "1 Gold coin added" + '\n' + "======================" + "\n" + richTextBox_Item_Pickup.Text;
                            map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y] = " ";
                            map11.map_Arr[map11.hero_Coords_X + 1, map11.hero_Coords_Y] = "H";
                            map11.hero_Coords_X += 1;
                        }
                    }
                    directions = 0;                //gets set to 0 so the player stops moving
                    return;
            }
        }
        private void move_Enemies()        //moves enemies when hero moves
        {
            Random ran_D = new Random();                  //randomizes the direction of the enemy
            int direction_G;

            for (int i = 0; i < map11.map_Width; i++)
            {
                for (int n = 0; n < map11.map_Height; n++)
                {
                    direction_G = ran_D.Next(0, 5);                   

                    if (map11.map_Arr[i, n] == "G")
                    {
                        if (direction_G == 1)                  //up
                        {
                            if (map11.map_Arr[i - 1, n] == " ")
                            {
                                map11.map_Arr[i - 1, n] = "G";
                                map11.map_Arr[i, n] = " ";

                                for (int b = 0; b < 5; b++)
                                {
                                    if (map11.enemies_Coords_X[b] == i & map11.enemies_Coords_Y[b] == n)
                                    {
                                        map11.enemies_Coords_X[b] -= 1;
                                        //goblins_List[b] = Convert.ToString(map11.enemies_Coords_X[b] + "," + map11.enemies_Coords_Y[b]);
                                    }
                                }
                            }
                        }
                        if (direction_G == 2)                  // down
                        {
                            if (map11.map_Arr[i + 1, n] == " ")
                            {
                                map11.map_Arr[i + 1, n] = "G";
                                map11.map_Arr[i, n] = " ";

                                for (int b = 0; b < 5; b++)
                                {
                                    if (map11.enemies_Coords_X[b] == i & map11.enemies_Coords_Y[b] == n)
                                    {
                                        map11.enemies_Coords_X[b] += 1;
                                    }
                                }
                            }
                        }
                        if (direction_G == 3)                    //left
                        {
                            if (map11.map_Arr[i, n - 1] == " ")
                            {
                                map11.map_Arr[i, n - 1] = "G";
                                map11.map_Arr[i, n] = " ";

                                for (int b = 0; b < 5; b++)
                                {
                                    if (map11.enemies_Coords_X[b] == i & map11.enemies_Coords_Y[b] == n)
                                    {
                                        map11.enemies_Coords_Y[b] -= 1;
                                    }
                                }
                            }
                        }
                        if (direction_G == 4)                    //right
                        {
                            if (map11.map_Arr[i, n + 1] == " ")
                            {
                                map11.map_Arr[i, n + 1] = "G";
                                map11.map_Arr[i, n] = " ";

                                for (int b = 0; b < 5; b++)
                                {
                                    if (map11.enemies_Coords_X[b] == i & map11.enemies_Coords_Y[b] == n)
                                    {
                                        map11.enemies_Coords_Y[b] += 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void friendly_Attack()                //mages attack allies in range
        {
            for (int i = 0; i < map11.map_Width; i++)
            {
                for (int n = 0; n < map11.map_Height; n++)
                {
                    if (map11.map_Arr[i, n] == "G")
                    {
                        if (map11.map_Arr[i - 1, n] == "M" || map11.map_Arr[i + 1, n] == "M" || //up / down
                            map11.map_Arr[i, n - 1] == "M" || map11.map_Arr[i, n + 1] == "M" || //left / right
                            map11.map_Arr[i - 1, n - 1] == "M" || map11.map_Arr[i - 1, n + 1] == "M" || //top_left / top_right
                            map11.map_Arr[i + 1, n + 1] == "M" || map11.map_Arr[i + 1, n - 1] == "M")   //bottom_left / bottom_right
                        {
                            for (int b = 0; b < 5; b++)
                            {
                                string temp_GH = i + "," + n;
                                if (map11.enemies_Coords_X[b] == i & map11.enemies_Coords_Y[b] == n)
                                {
                                    if (map11.g_Health[b] > 0)
                                    {
                                        map11.g_Health[b] -= 5;
                                        attack_richTextBox.Text = ("Goblin got Hit for 5 " + '\n' + "Goblin HP: " + map11.g_Health[b] + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                                    }
                                    if (map11.g_Health[b] <= 0)
                                    {
                                        map11.map_Arr[i, n] = " ";
                                        attack_richTextBox.Text = ("Goblin Killed" + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                                        update_Map();
                                    }
                                }
                            }                           
                        }
                    }
                }
            }
        }
        private void my_Goblin_List()               //creating seperate goblins
        {
            goblins_List.Clear();
            for (int i = 0; i < map11.map_Width; i++)
            {
                for (int n = 0; n < map11.map_Height; n++)
                {
                    if (map11.map_Arr[i, n] == "G")
                    {
                        goblins_List.Add(Convert.ToString(i + "," + n));
                    }
                }
            }          
        }
        private void my_Mage_List()               // creating seperate mages
        {
            for (int i = 0; i < map11.map_Width; i++)
            {
                for (int n = 0; n < map11.map_Height; n++)
                {
                    if (map11.map_Arr[i, n] == "M")
                    {
                        mage_List.Add(Convert.ToString(i + "," + n));
                    }
                }
            }
        }
        private void selected_Enemy()                     //checks wich individual enemy is getting attacked
        {
            my_Goblin_List();
            my_Mage_List();
            string temp_G = Convert.ToString(map11.hero_Coords_X + "," + map11.hero_Coords_Y);
            string temp_M = Convert.ToString(map11.hero_Coords_X + "," + map11.hero_Coords_Y);

            if (map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y] == "G")
            {
                if (map11.enemies_Coords_X[0] == map11.hero_Coords_X & map11.enemies_Coords_Y[0] == map11.hero_Coords_Y)
                {
                    enemy = 1;
                }
                if (map11.enemies_Coords_X[1] == map11.hero_Coords_X & map11.enemies_Coords_Y[1] == map11.hero_Coords_Y)
                {
                    enemy = 2;
                }
                if (map11.enemies_Coords_X[2] == map11.hero_Coords_X & map11.enemies_Coords_Y[2] == map11.hero_Coords_Y)
                {
                    enemy = 3;
                }
                if (map11.enemies_Coords_X[3] == map11.hero_Coords_X & map11.enemies_Coords_Y[3] == map11.hero_Coords_Y)
                {
                    enemy = 4;
                }
                if (map11.enemies_Coords_X[4] == map11.hero_Coords_X & map11.enemies_Coords_Y[4] == map11.hero_Coords_Y)
                {
                    enemy = 5;
                }
            }


            if (mage_List[0] == temp_M)
            {
                enemy = 1;
            }
            if (mage_List[1] == temp_M)
            {
                enemy = 2;
            }
            if (mage_List[2] == temp_M)
            {
                enemy = 3;
            }
            if (mage_List[3] == temp_M)
            {
                enemy = 4;
            }
            if (mage_List[4] == temp_M)
            {
                enemy = 5;
            }
        }
        private void attack_Enemy()               //method attacks the enemy selected in Select_Enemy() and lets the corrisponding enemy hp go down in the g_Health array
        {          
            if (select_enemy.SelectedIndex == 0)       //up
            {
                map11.hero_Coords_X -= 1;
                selected_Enemy();
                map11.hero_Coords_X += 1;
                if (map11.map_Arr[map11.hero_Coords_X - 1, map11.hero_Coords_Y] == "G")
                {                
                    if (map11.g_Health[enemy - 1] > 0)
                    {
                        map11.g_Health[enemy - 1] -= map11.hero_DMG;
                        attack_richTextBox.Text = ("Goblin got Hit for 2 " + '\n' + "Goblin HP: " + map11.g_Health[enemy - 1] + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                    if (map11.g_Health[enemy - 1] <= 0)
                    {
                        map11.map_Arr[map11.hero_Coords_X - 1, map11.hero_Coords_Y] = " ";
                        attack_richTextBox.Text = ("Goblin Killed" + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                }
                if (map11.map_Arr[map11.hero_Coords_X - 1, map11.hero_Coords_Y] == "M")
                {
                    if (map11.m_Health[enemy - 1] > 0)
                    {
                        map11.m_Health[enemy - 1] -= map11.hero_DMG;
                        attack_richTextBox.Text = ("Mage got Hit for 2 " + '\n' + "Mage HP: " + map11.m_Health[enemy - 1] + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                    if (map11.m_Health[enemy - 1] <= 0)
                    {
                        map11.map_Arr[map11.hero_Coords_X - 1, map11.hero_Coords_Y] = " ";
                        attack_richTextBox.Text = ("Mage Killed" + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                }
            }
            if (select_enemy.SelectedIndex == 1)      //down
            {
                map11.hero_Coords_X += 1;
                selected_Enemy();
                map11.hero_Coords_X -= 1;
                c = map11.g_Position[map11.hero_Coords_X + 1, map11.hero_Coords_Y];
                if (map11.map_Arr[map11.hero_Coords_X + 1, map11.hero_Coords_Y] == "G")
                {
                    if (map11.g_Health[enemy - 1] > 0)
                    {
                        map11.g_Health[enemy - 1] -= map11.hero_DMG;
                        attack_richTextBox.Text = ("Goblin got Hit for 2 " + '\n' + "Goblin HP: " + map11.g_Health[enemy - 1] + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                    if (map11.g_Health[enemy - 1] <= 0)
                    {
                        map11.map_Arr[map11.hero_Coords_X + 1, map11.hero_Coords_Y] = " ";
                        attack_richTextBox.Text = ("Goblin Killed" + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                }
                if (map11.map_Arr[map11.hero_Coords_X + 1, map11.hero_Coords_Y] == "M")
                {
                    if (map11.m_Health[enemy - 1] > 0)
                    {
                        map11.m_Health[enemy - 1] -= map11.hero_DMG;
                        attack_richTextBox.Text = ("Mage got Hit for 2 " + '\n' + "Mage HP: " + map11.m_Health[enemy - 1] + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                    if (map11.m_Health[enemy - 1] <= 0)
                    {
                        map11.map_Arr[map11.hero_Coords_X + 1, map11.hero_Coords_Y] = " ";
                        attack_richTextBox.Text = ("Mage Killed" + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                }
            }
            if (select_enemy.SelectedIndex == 2)      //right
            {
                map11.hero_Coords_Y += 1;
                selected_Enemy();
                map11.hero_Coords_Y -= 1;
                c = map11.g_Position[map11.hero_Coords_X, map11.hero_Coords_Y + 1];
                if (map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y + 1] == "G")
                {
                    if (map11.g_Health[enemy - 1] > 0)
                    {
                        map11.g_Health[enemy - 1] -= map11.hero_DMG;
                        attack_richTextBox.Text = ("Goblin got Hit for 2 " + '\n' + "Goblin HP: " + map11.g_Health[enemy - 1] + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                    if (map11.g_Health[enemy - 1] <= 0)
                    {
                        map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y + 1] = " ";
                        attack_richTextBox.Text = ("Goblin Killed" + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                }
                if (map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y + 1] == "M")
                {
                    if (map11.m_Health[enemy - 1] > 0)
                    {
                        map11.m_Health[enemy - 1] -= map11.hero_DMG;
                        attack_richTextBox.Text = ("Mage got Hit for 2 " + '\n' + "Mage HP: " + map11.m_Health[enemy - 1] + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                    if (map11.m_Health[enemy - 1] <= 0)
                    {
                        map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y + 1] = " ";
                        attack_richTextBox.Text = ("Mage Killed" + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                }
            }
            if (select_enemy.SelectedIndex == 3)       //left
            {
                map11.hero_Coords_Y -= 1;
                selected_Enemy();
                map11.hero_Coords_Y += 1;
                c = map11.g_Position[map11.hero_Coords_X, map11.hero_Coords_Y - 1];
                if (map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y - 1] == "G")
                {
                    if (map11.g_Health[enemy - 1] > 0)
                    {
                        map11.g_Health[enemy - 1] -= map11.hero_DMG;
                        attack_richTextBox.Text = ("Goblin got Hit for 2 " + '\n' + "Goblin HP: " + map11.g_Health[enemy - 1] + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                    if (map11.g_Health[enemy - 1] <= 0)
                    {
                        map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y - 1] = " ";
                        attack_richTextBox.Text = ("Goblin Killed" + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                }
                if (map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y - 1] == "M")
                {
                    if (map11.m_Health[enemy - 1] > 0)
                    {
                        map11.m_Health[enemy - 1] -= map11.hero_DMG;
                        attack_richTextBox.Text = ("Mage got Hit for 2 " + '\n' + "Mage HP: " + map11.m_Health[enemy - 1] + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                    if (map11.m_Health[enemy - 1] <= 0)
                    {
                        map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y - 1] = " ";
                        attack_richTextBox.Text = ("Mage Killed" + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                }
            }
            update_Map();
        }
        private void hero_Stats()
        {
            
        }
        private void goblin_Stats()         // setting goblin stats
        {
            for (int i = 0; i < map11.map_Width; i++)
            {
                for (int n = 0; n < map11.map_Height; n++)
                {
                    if (map11.map_Arr[i, n] == "G")
                    {
                        map11.g_Position[c, 0] = i;
                        map11.g_Position[c, 1] = n;
                        map11.g_Health[c] = 10;

                        c += 1;
                    }
                }
                MapLabel.Text = MapLabel.Text + "\n";
            }
            c = 0;
        }
        private void mage_Stats()         // setting mage stats
        {
            for (int i = 0; i < map11.map_Width; i++)
            {
                for (int n = 0; n < map11.map_Height; n++)
                {
                    if (map11.map_Arr[i, n] == "G")
                    {
                        map11.m_Position[c, 0] = i;
                        map11.m_Position[c, 1] = n;
                        map11.m_Health[c] = 5;

                        c += 1;
                    }
                }
                MapLabel.Text = MapLabel.Text + "\n";
            }
            c = 0;
        }
        private void check_Range()                     //checks if the hero is in range of enemies
        {
            if (map11.map_Arr[map11.hero_Coords_X - 1, map11.hero_Coords_Y] != " " & map11.map_Arr[map11.hero_Coords_X - 1, map11.hero_Coords_Y] != "X")        //up
            {
                directions_A = 1;
            }
            if (map11.map_Arr[map11.hero_Coords_X + 1, map11.hero_Coords_Y] != " " & map11.map_Arr[map11.hero_Coords_X + 1, map11.hero_Coords_Y] != "X")        //down
            {
                directions_A = 2;
            }
            if (map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y - 1] != " " & map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y - 1] != "X")        //left
            {
                directions_A = 3;
            }
            if (map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y + 1] != " " & map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y + 1] != "X")        //right
            {
                directions_A = 4;
            }

            if (map11.map_Arr[map11.hero_Coords_X - 1, map11.hero_Coords_Y - 1] != " " & map11.map_Arr[map11.hero_Coords_X - 1, map11.hero_Coords_Y - 1] != "X")        //top left
            {
                directions_A = 5;
            }
            if (map11.map_Arr[map11.hero_Coords_X - 1, map11.hero_Coords_Y + 1] != " " & map11.map_Arr[map11.hero_Coords_X - 1, map11.hero_Coords_Y + 1] != "X")        //top right
            {
                directions_A = 6;
            }
            if (map11.map_Arr[map11.hero_Coords_X + 1, map11.hero_Coords_Y - 1] != " " & map11.map_Arr[map11.hero_Coords_X + 1, map11.hero_Coords_Y - 1] != "X")        //bottom left
            {
                directions_A = 7;
            }
            if (map11.map_Arr[map11.hero_Coords_X + 1, map11.hero_Coords_Y + 1] != " " & map11.map_Arr[map11.hero_Coords_X + 1, map11.hero_Coords_Y + 1] != "X")        //bottom right
            {
                directions_A = 8;
            }


            switch (directions_A)                          //allows the enemy in range of the player to attack that player
            {
                case 1:                //up

                    if (map11.map_Arr[map11.hero_Coords_X - 1, map11.hero_Coords_Y] == "G")
                    {
                        map11.hero_HP -= map11.g_Damage;
                        attack_richTextBox.Text = ("Goblin Hit for 1 " + '\n' + "Hero HP: " + map11.hero_HP + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                    if (map11.map_Arr[map11.hero_Coords_X - 1, map11.hero_Coords_Y] == "M")
                    {
                        map11.hero_HP -= map11.mage_DMG;
                        attack_richTextBox.Text = ("Mage Hit for 5 " + '\n' + "Hero HP: " + map11.hero_HP + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                    return;
                case 2:               //down
                    if (map11.map_Arr[map11.hero_Coords_X + 1, map11.hero_Coords_Y] == "G")
                    {
                        map11.hero_HP -= map11.g_Damage;
                        attack_richTextBox.Text = ("Goblin Hit for 1 " + '\n' + "Hero HP: " + map11.hero_HP + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                    if (map11.map_Arr[map11.hero_Coords_X + 1, map11.hero_Coords_Y] == "M")
                    {
                        map11.hero_HP -= map11.mage_DMG;
                        attack_richTextBox.Text = ("Mage Hit for 5 " + '\n' + "Hero HP: " + map11.hero_HP + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                    return;
                case 3:               //left
                    if (map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y - 1] == "G")
                    {
                        map11.hero_HP -= map11.g_Damage;
                        attack_richTextBox.Text = ("Goblin Hit for 1 " + '\n' + "Hero HP: " + map11.hero_HP + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                    if (map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y - 1] == "M")
                    {
                        map11.hero_HP -= map11.mage_DMG;
                        attack_richTextBox.Text = ("Mage Hit for 5 " + '\n' + "Hero HP: " + map11.hero_HP + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                    return;
                case 4:               //right
                    if (map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y + 1] == "G")
                    {
                        map11.hero_HP -= map11.g_Damage;
                        attack_richTextBox.Text = ("Goblin Hit for 1 " + '\n' + "Hero HP: " + map11.hero_HP + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                    if (map11.map_Arr[map11.hero_Coords_X, map11.hero_Coords_Y + 1] == "M")
                    {
                        map11.hero_HP -= map11.mage_DMG;
                        attack_richTextBox.Text = ("Mage Hit for 5 " + '\n' + "Hero HP: " + map11.hero_HP + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                    return;
                case 5:               //top left
                    if (map11.map_Arr[map11.hero_Coords_X - 1, map11.hero_Coords_Y - 1] == "M")
                    {
                        map11.hero_HP -= map11.mage_DMG;
                        attack_richTextBox.Text = ("Mage Hit for 5 " + '\n' + "Hero HP: " + map11.hero_HP + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                    return;
                case 6:               //top right
                    if (map11.map_Arr[map11.hero_Coords_X - 1, map11.hero_Coords_Y + 1] == "M")
                    {
                        map11.hero_HP -= map11.mage_DMG;
                        attack_richTextBox.Text = ("Mage Hit for 5 " + '\n' + "Hero HP: " + map11.hero_HP + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                    return;
                case 7:               //bottom left
                    if (map11.map_Arr[map11.hero_Coords_X + 1, map11.hero_Coords_Y - 1] == "M")
                    {
                        map11.hero_HP -= map11.mage_DMG;
                        attack_richTextBox.Text = ("Mage Hit for 5 " + '\n' + "Hero HP: " + map11.hero_HP + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                    return;
                case 8:               //bottom right
                    if (map11.map_Arr[map11.hero_Coords_X + 1, map11.hero_Coords_Y + 1] == "M")
                    {
                        map11.hero_HP -= map11.mage_DMG;
                        attack_richTextBox.Text = ("Mage Hit for 5 " + '\n' + "Hero HP: " + map11.hero_HP + '\n' + "======================" + '\n' + attack_richTextBox.Text);
                    }
                    return;
            }
        }
        private void gold_Value()      //Task 2 Question 2.2
        {
            Random ran_G = new Random();
            int gold_Value = ran_G.Next(1, 6);
            map11.gold = gold_Value;
        }
        private void MapLabel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            update_Map();
            update_P_Stats();
        }
        private void buttonUP1_Click(object sender, EventArgs e)
        {
            directions = 3;
            moveHero();
            check_Range();
            update_P_Stats();
            friendly_Attack();
            update_Map();
        }
        private void buttonLEFT1_Click(object sender, EventArgs e)
        {
            directions = 1;
            moveHero();
            check_Range();
            update_P_Stats();
            friendly_Attack();
            update_Map();
        }
        private void buttonDown1_Click(object sender, EventArgs e)
        {
            directions = 4;
            moveHero();
            check_Range();
            update_P_Stats();
            friendly_Attack();
            update_Map();
        }
        private void buttonRIGHT1_Click(object sender, EventArgs e)
        {
            directions = 2;
            moveHero();
            check_Range();
            update_P_Stats();
            friendly_Attack();
            update_Map();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void richTextBox_Player_Stats_TextChanged(object sender, EventArgs e)
        {

        }
        private void button_Attack_Click(object sender, EventArgs e)
        {
            attack_Enemy();
            check_Win();
            check_Range();
            update_P_Stats();
        }
        private void select_enemy_SelectedIndexChanged(object sender, EventArgs e)
        {
           //my_Goblin_List();
        }
        public void check_Win()                 //checks if any enemies on the map remain if not player wins
        {
            for (int i = 0; i < map11.map_Width; i++)
            {
                for (int n = 0; n < map11.map_Height; n++)
                {
                    if (map11.map_Arr[i, n] == "G" || map11.map_Arr[i, n] == "M")
                    {
                        goto mojo;
                    }
                }
            }
            MessageBox.Show("congratulations" + '\n' + "You won");
            this.Close();
            mojo:
            return;
        }
        public void check_Lost()
        {
            if (map11.hero_HP <= 0)
            {
                this.Close();
                MessageBox.Show("You have lost");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            map11.Save();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {

            map11.Load();

            update_Map();
            update_P_Stats();
        }
    }
    //Question 2.1
    public abstract class Tile
    {
        protected int X;
        protected int Y;
   
        enum TileType
        {
            Hero,
            Enemy,
            Gold,
            Weapon,
        }

        public Tile()
        {
            
        }
        public Tile(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    abstract class Obstacle : Tile
    {
        
    }
    abstract class EmptyTile
    {

    }
    //Question 2.2 
    abstract class Character : Tile
    {
        
        protected int MapBorder;

        protected int[] Vision = new int[4];

        public enum Movement
        {
            No_movement,
            Up,
            Down,
            Left,
            Right,
        }

        //Question 2.3
        public Character()
        {

        }
        public Character(int x, int y, char border)
        {
            X = x;
            Y = y;
            MapBorder = border;
        }
        public virtual void Attack(Character target)
        {

        }
        public void IsDead()
        {

        }
        public virtual void CheckRange(Character target)
        {
            DistanceTo();
        }
        private void DistanceTo()
        {

        }
        public void Move(Movement move)
        {

        }
        public abstract Movement ReturnMove(Movement move = 0);

        public abstract override string ToString();
    }
    //Question 2.4
    abstract class Enemy : Character
    {
        public Random rndObject = new Random();

        public Enemy()
        {

        }
        public Enemy(int x, int y, int enemy_Damage, int enemy_Starting_HP, char symbol)
        {

        }
        public override string ToString()
        {
            return ("Goblin at " + X + Y + 10);
        }
        //Question 2.5
        public abstract class Goblin : Enemy
        {
            protected int goblin_HP = 10;
            protected int goblin_Damage = 1;
            public Goblin()
            {

            }
            public Goblin(int x, int y)
            {
                
            }
            public static void ReturnMove()
            {
                Random rnd = new Random();
                int direction = rnd.Next(0, 3);
            }
        }
        public abstract class Mage : Enemy
        {
            protected int mage_HP = 5;
            protected int mage_Damage = 5;

            public static void ReturnMove()
            {
                
            }
        }
    }
    abstract class Hero : Character
    {
        protected int HP = 100;
        protected int Max_HP = 100;
        protected int Damage = 2;
        protected int Hero_Damage = 2;
        public Hero()
        {

        }
        public Hero(int x, int y, int hp)
        {
            X = x;
            Y = y;
            HP = hp;
            Max_HP = hp;
        }
        public void ReturnMove()
        {

        }
        public override string ToString()
        {
            return ("Player Stats:" + "\n HP: " + HP + "\n Damage: 2" + "\n [" + X + "," + Y + "]");
        }
    }
    //question 3.1
    public class map
    {
        public string[,] map_Arr;

        public object Hero_Symbol;
        public int hero_Coords_X;                                      //
        public int hero_Coords_Y;                                    //

        public int prev_hero_Coords_X;                             
        public int prev_hero_Coords_Y;                        

        public int[] enemies_Arr;
        public int[] enemies_Coords_X = new int[5];                  //
        public int[] enemies_Coords_Y = new int[5];                   //

        public int map_Width = 20;
        public int map_Height = 20;

        public int[] map_Items = new int[5];

        public int[,] g_Position = new int[20, 20];
        public int[] g_Health = new int[5];                            //
        public int g_Damage = 1;

        public int[,] m_Position = new int[20, 20];
        public int[] m_Health = new int[5];                          //
        public int mage_DMG = 5;

        public int gold;
        public int[] gold_X = new int[5];
        public int[] gold_Y = new int[5];

        public int hero_HP = 100, hero_Max_HP = 100, hero_DMG = 2;

        ArrayList list_Goblins = new ArrayList();
        ArrayList list_Mages = new ArrayList();
        ArrayList list_Gold = new ArrayList();

        //Question 3.2

        public map()
        {

        }
        public map(int min_Width, int max_Width, int min_Height, int max_Height , int enemies, int gold)
        {
            Random ran = new Random();

            map_Width = ran.Next(min_Width, max_Width);
            map_Height = ran.Next(min_Height, max_Height);

            map_Arr = new string[map_Width, map_Height];

            enemies_Arr = new int[enemies];

            map_Items = new int[gold];

            Create();

            UpdateVision();

            Create_Objects();
        }
        public void Create() //creates Map Border
        {
            for (int i = 0; i < map_Width; i++)
            {
                for (int n = 0; n < map_Height; n++)
                {
                    map_Arr[i, n] = " ";
                }
            }
            for (int i = 0; i < map_Width; i++)
            {
                map_Arr[i, 0] = "X";
                map_Arr[i, map_Height - 1] = "X";
            }
            for (int i = 0; i < map_Height; i++)
            {
                map_Arr[0, i] = "X";
                map_Arr[map_Width - 1, i] = "X";
            }
        }

        public void UpdateVision()
        {
            
        }
        public void Create_Objects() //spawns and creates the enemies and items
        {
            bool done_2 = false;

            for (int i = 0; i < enemies_Arr.Length; i++)
            {
                int x, y;

                Random ran = new Random();
                x = ran.Next(1, map_Width - 1);
                y = ran.Next(1, map_Height - 1);

                while (map_Arr[x, y] != " ")
                {
                    x = ran.Next(1, map_Width - 1);
                    y = ran.Next(1, map_Height - 1);
                }

                if (map_Arr[x, y] == " ")
                {
                    map_Arr[x, y] = "G";
                    enemies_Coords_X[i] = x;
                    enemies_Coords_Y[i] = y;
                    list_Goblins.Add(Convert.ToString(x + "," + y));
                }
            }

            for (int i = 0; i < enemies_Arr.Length; i++)
            {
                int x, y;

                Random ran = new Random();
                x = ran.Next(1, map_Width - 1);
                y = ran.Next(1, map_Height - 1);

                while (map_Arr[x, y] != " ")
                {
                    x = ran.Next(1, map_Width - 1);
                    y = ran.Next(1, map_Height - 1);
                }

                if (map_Arr[x, y] == " ")
                {
                    map_Arr[x, y] = "M";
                    list_Mages.Add(Convert.ToString(x + "," + y));
                }
            }

            Random ran_Gold = new Random();
            int gold_Ammount = ran_Gold.Next(1, 6);

            for (int i = 0; i < gold_Ammount; i++)
            {
                int x, y;

                Random ran = new Random();
                x = ran.Next(1, map_Width - 1);
                y = ran.Next(1, map_Height - 1);

                while (map_Arr[x, y] != " ")
                {
                    x = ran.Next(1, map_Width - 1);
                    y = ran.Next(1, map_Height - 1);
                }

                if (map_Arr[x, y] == " ")
                {
                    map_Arr[x, y] = "C";
                    list_Gold.Add(Convert.ToString(x + "," + y));
                    gold_X[i] = x;
                    gold_Y[i] = y;
                }
            }

            while (done_2 == false)
            {
                int x, y;

                Random ran = new Random();
                x = ran.Next(1, map_Width - 1);
                y = ran.Next(1, map_Height - 1);

                while (map_Arr[x, y] != " ")
                {
                    x = ran.Next(1, map_Width - 1);
                    y = ran.Next(1, map_Height - 1);
                }
                if (map_Arr[x, y] == " ")
                {
                    map_Arr[x, y] = "H";
                    hero_Coords_X = x;
                    hero_Coords_Y = y;

                    done_2 = true;
                }
            }
        }
        //question 4
        //saving the variables to a text file
        public void Save()
        {
            TextWriter tw = new StreamWriter("SavedGame.txt");

            // write lines of text to the file
            tw.WriteLine(hero_Coords_X);
            tw.WriteLine(hero_Coords_Y);
            tw.WriteLine(hero_HP);

            for (int i = 0; i < map_Width; i++)
            {
                for (int n = 0; n < map_Height; n++)
                {
                    tw.WriteLine(map_Arr[i, n]);
                }
            }

            for (int d = 0; d < 5; d++)
            {
                tw.WriteLine(g_Health[d]);
            }
            for (int d = 0; d < 5; d++)
            {
                tw.WriteLine(enemies_Coords_X[d]);
            }
            for (int d = 0; d < 5; d++)
            {
                tw.WriteLine(enemies_Coords_Y[d]);
            }

            for (int d = 0; d < 5; d++)
            {
                tw.WriteLine(m_Health[d]);
            }

            // close the stream     
            tw.Close();
        }
        //reading the saved game bvariables from the text file
        public void Load()
        {
            TextReader tr = new StreamReader("SavedGame.txt");

            // read lines of text
            string x_Hero = tr.ReadLine();
            string y_Hero = tr.ReadLine();
            string hp_Hero = tr.ReadLine();

            string the_Map;

            string g_E_HP, enemy_X, enemy_Y;

            string m_E_HP;


            for (int i = 0; i < map_Width; i++)
            {
                for (int n = 0; n < map_Height; n++)
                {
                    the_Map = tr.ReadLine();
                    map_Arr[i, n] = the_Map;
                }
            }

            for (int d = 0; d < 5; d++)
            {
                g_E_HP = tr.ReadLine();
                g_Health[d] = Convert.ToInt32(g_E_HP);
                //MessageBox.Show(g_Health[d]);
            }
            for (int d = 0; d < 5; d++)
            {
                enemy_X = tr.ReadLine();
                enemies_Coords_X[d] = Convert.ToInt32(enemy_X);
            }
            for (int d = 0; d < 5; d++)
            {
                enemy_Y = tr.ReadLine();
                enemies_Coords_Y[d] = Convert.ToInt32(enemy_Y);
            }

            for (int d = 0; d < 5; d++)
            {
                m_E_HP = tr.ReadLine();
                m_Health[d] = Convert.ToInt32(m_E_HP);
            }

            //Convert the strings to int
            hero_Coords_X = Convert.ToInt32(x_Hero);
            hero_Coords_Y = Convert.ToInt32(y_Hero);
            hero_HP = Convert.ToInt32(hp_Hero);

            // close the stream
            tr.Close();
        }
    }
    public class GameEngine
    {
        map map11 = new map();
        Form1 form1 = new Form1();
        public bool goRight, goLeft, goUp, goDown;

        public GameEngine()
        {
            
        }
    }
    public class Item
    {

    }
    public class Gold : Item
    {
        int p_Gold;
    }
}