﻿using Engine;
using Engine.Actions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkHeresyForm
{
    public partial class CharacterCreationForm : Form
    {
        public Player Player { get; set; }


        public CharacterCreationForm(Player player = null)
        {
            InitializeComponent();
            if (player == null)
            {
                Player newPlayer = new Player();
                Player = newPlayer;
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCloseForm2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        //FUNCTIONS FOR THE CLASS
        private void btnGenerateHomeworld_Click(object sender, EventArgs e)
        {
            SelectHomeWorld(this.Player);
            rtbInformation.Text = String.Format("You were born on a {0}.", Player.HomeWorld);
            btnGenerateHomeworld.Hide();
            //create new button and replace the current one.
            CreateFormButton("Generate Statistics", new Point(93, 259), new Size(142, 23), b_AllocateValues, panelInformation);

        }


        //button bindings to be assigned dynamically
        private void b_AllocateValues(object sender, EventArgs e)
        {
            var _player = Player;
            AllocateValues(_player);
            rtbInformation.Text += Environment.NewLine;
            rtbInformation.Text += String.Format("Character Statistics have been generated: WS: {0}, BS: {1}", Player.Ws, Player.Bs);
        }

        void CreateFormButton(string buttonName, Point location, Size size, EventHandler handler, Panel panel = null)
        {
            var btnNameString = String.Format("btn{0}", buttonName);
            Button btn = new Button();
            btn.Text = buttonName;
            btn.Location = location;
            btn.Size = size;
            btn.Name = btnNameString;
            btn.Click += new EventHandler(handler);
            panel.Controls.Add(btn);


        }

        static void SelectHomeWorld(Player player)
        {
            Random rn = new Random();
            var result = Convert.ToInt32(DiceRolls.RollD100(rn));
            if (result >= 1 && result <= 15)
                player.HomeWorld = "Feral World";
            if (result >= 16 && result <= 33)
                player.HomeWorld = "Forge World";
            if (result >= 34 && result <= 44)
                player.HomeWorld = "High Born";
            if (result >= 45 && result <= 69)
                player.HomeWorld = "Hive World";
            if (result >= 70 && result <= 85)
                player.HomeWorld = "Shrine World";
            if (result >= 86 && result <= 100)
                player.HomeWorld = "Void Born";
        }

        static void ResetValues(Player player)
        {
            PropertyInfo[] pi = player.GetType().GetProperties();
            for (int i = 0; i < pi.Length; i++)
            {
                if (pi[i].PropertyType == typeof(int))
                {
                    pi[i].SetValue(player, 0);
                }
                if (pi[i].PropertyType == typeof(string))
                {
                    pi[i].SetValue(player, "");
                }
            }
        }
        static void AllocateValues(Player player)
        {
            Random rn = new Random();
            PropertyInfo[] pi = player.GetType().GetProperties();
            var statValue = 0;
            //TEST
            player.HomeWorld = "Feral World";
            //
            for (int i = 0; i < 12; i++)
            {
                statValue = 0;
                if (pi[i].PropertyType == typeof(int))//checks if the value is an int 
                {
                    statValue = DiceRolls.RollD10(2, rn).Sum();
                    if (player.HomeWorld == "Feral World")
                    {
                        if (pi[i].Name == "Str")
                        {
                            int[] roll = DiceRolls.RollD10(3, rn);
                            statValue = DiceRolls.TakeDice(2, roll, true).Sum();
                        }
                        if (pi[i].Name == "T")
                        {
                            int[] roll = DiceRolls.RollD10(3, rn);
                            statValue = DiceRolls.TakeDice(2, roll, true).Sum();
                        }
                        if (pi[i].Name == "Inte")
                        {
                            int[] roll = DiceRolls.RollD10(3, rn);
                            statValue = DiceRolls.TakeDice(2, roll, false).Sum();
                        }
                    }
                    statValue += 25;
                    if (statValue >= 100)
                    {
                        statValue = 100;
                    }
                    pi[i].SetValue(player, statValue);
                }


            }
        }
    }
}
