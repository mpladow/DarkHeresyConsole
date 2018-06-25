﻿using Engine;
using Engine.Actions;
using Engine.Characters.HomeWorlds;
using Engine.Statistics;
using Engine.Utilities;
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
using static Engine.Characters.HomeWorlds.HomeWorlds;
using static Engine.Human_Base;
using static Engine.Statistics.CharacterStat;

namespace DarkHeresyForm
{
    public partial class CharacterCreationForm : Form
    {
        public Player Player { get; set; }
        private List<HomeWorlds> HomeWorlds { get; set; }

        

        public CharacterCreationForm(Player player = null)
        {
            InitializeComponent();
            if (player == null)
            {
                Player newPlayer = new Player();
                Player = newPlayer;
            }
            HomeWorlds = ListGenerator.GenerateHomeWorldList();
            cboHomeWorld.DataSource = HomeWorlds;
            cboHomeWorld.DisplayMember = "Name";
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
            AllocateValues(Player);
            SelectHomeWorld(this.Player);
            rtbInformation.Text += String.Format("{0}. {1}", Player.HomeWorld.Name, Player.HomeWorld.Description);
            rtbInformation.Text += Environment.NewLine;
            rtbInformation.Text += "Strengths include:";
            rtbInformation.Text += Environment.NewLine;
            foreach (var item in Player.HomeWorld.StatsAffectedPositive)
            {
                rtbInformation.Text += item;
                rtbInformation.Text += Environment.NewLine;
            }
            rtbInformation.Text += "Weaknesses include:";
            rtbInformation.Text += Environment.NewLine;
            foreach (var item in Player.HomeWorld.StatsAffectedNegative)
            {
                rtbInformation.Text += item;
                rtbInformation.Text += Environment.NewLine;
            }

            
            AllocateValues(Player);
            rtbInformation.Text += Environment.NewLine;
            rtbInformation.Text += String.Format("Character Statistics have been generated.");
            UpdateDisplay(panelPlayerStats, Player);

            btnGenerateHomeworld.Hide();
            //create new button and replace the current one.
            //CreateFormButton("GenerateStatistics", new Point(93, 259), new Size(142, 23), b_AllocateValues, panelInformation);

        }


        //button bindings to be assigned dynamically
        private void b_AllocateValues(object sender, EventArgs e)
        {
            var _player = Player;
            AllocateValues(_player);
            rtbInformation.Text += Environment.NewLine;
            rtbInformation.Text += String.Format("Character Statistics have been generated: WS: {0}, BS: {1}", Player.Ws.Value, Player.Bs.Value);
            UpdateDisplay(panelPlayerStats, Player);

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
        //this will update the display on the page and fill in the details generated
        void UpdateDisplay(Panel panel, Player player)
        {

            var playerProperties = player.GetType().GetProperties().Where(x => x.PropertyType == typeof(CharacterStat)).ToList();//finds the properties of the player
            var children = panel.Controls.OfType<TextBox>();//
            var enumPropertyNames = EnumUtility.GetValues<StatName>();
            foreach (Control control in children)
            {
                //if this text box contains the appropriate statistic, then update the text
                foreach (var stat in enumPropertyNames)
                {
                    if (control.Name.Contains(stat.ToString()))
                    {
                        var pi = playerProperties.Where(x => x.Name == stat.ToString()).FirstOrDefault();
                        var prop = (CharacterStat)pi.GetValue(player);//gets the property from the player object
                        control.Text = prop.Value.ToString();//sets this value to the control text
                    }
                }
                foreach (var strength in player.HomeWorld.StatsAffectedPositive)
                {
                    if (control.Name.Contains(strength))
                    {
                        control.ForeColor = Color.DarkSeaGreen;
                    }
                }
                foreach (var weakness in player.HomeWorld.StatsAffectedNegative)
                {
                    if (control.Name.Contains(weakness))
                    {
                        control.ForeColor = Color.DarkRed;
                    }
                }
            }
        }



        static void SelectHomeWorld(Player player)
        {
            List<Engine.Characters.HomeWorlds.HomeWorlds> list = ListGenerator.GenerateHomeWorldList();

            Random rn = new Random();
            var result = Convert.ToInt32(DiceRolls.RollD100(rn));
            if (result >= 1 && result <= 15)

                player.HomeWorld = list.Where(x => x.Name == enumHomeWorlds.FeralWorld.ToString()).FirstOrDefault();
            if (result >= 16 && result <= 33)
                player.HomeWorld = list.Where(x => x.Name == enumHomeWorlds.ForgeWorld.ToString()).FirstOrDefault();
            if (result >= 34 && result <= 44)
                player.HomeWorld = list.Where(x => x.Name == enumHomeWorlds.HighBorn.ToString()).FirstOrDefault();
            if (result >= 45 && result <= 69)
                player.HomeWorld = list.Where(x => x.Name == enumHomeWorlds.HiveWorld.ToString()).FirstOrDefault();
            if (result >= 70 && result <= 85)
                player.HomeWorld = list.Where(x => x.Name == enumHomeWorlds.ShrineWorld.ToString()).FirstOrDefault();
            if (result >= 86 && result <= 100)
                player.HomeWorld = list.Where(x => x.Name == enumHomeWorlds.VoidBorn.ToString()).FirstOrDefault();
        }

        //static void ResetValues(Player player)
        //{
        //    PropertyInfo[] pi = player.GetType().GetProperties();
        //    for (int i = 0; i < pi.Length; i++)
        //    {
        //        if (pi[i].PropertyType == typeof(int))
        //        {
        //            pi[i].SetValue(player, 0);
        //        }
        //        if (pi[i].PropertyType == typeof(string))
        //        {
        //            pi[i].SetValue(player, "");
        //        }
        //    }
        //}
        static void AllocateValues(Player player)
        {
            Random rn = new Random();
            var enumPropertyNames = EnumUtility.GetValues<StatName>();//creates a list of characteristic enums
            var playerProperties = player.GetType().GetProperties().Where(x => x.PropertyType == typeof(CharacterStat)).ToList(); //uses reflection to get the property types in 
            //casts this object into a list

            foreach (var prop in playerProperties)
            {
                foreach (var name in enumPropertyNames)
                {
                    var statValue = 25;
                    if (name.ToString() == prop.Name)
                    {
                        statValue += DiceRolls.RollD10(2, rn).Sum();
                        if (player.HomeWorld != null)
                        {
                            foreach (var stat in player.HomeWorld.StatsAffectedPositive)
                            {
                                if (stat == prop.Name)
                                {
                                    int[] roll = DiceRolls.RollD10(3, rn);
                                    statValue += DiceRolls.TakeDice(2, roll, true).Sum();
                                };
                            }
                            foreach (var stat in player.HomeWorld.StatsAffectedNegative)
                            {
                                if (stat == prop.Name)
                                {
                                    int[] roll = DiceRolls.RollD10(3, rn);
                                    statValue += DiceRolls.TakeDice(2, roll, false).Sum();
                                }
                            }
                        }
                        CharacterStat _stat = new CharacterStat(name.ToString(), statValue);
                        prop.SetValue(player, _stat);

                    }
                }
            }
        }
        private void cboHomeWorld_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selection = cboHomeWorld.SelectedItem;
            Player.HomeWorld = (HomeWorlds)selection;
            rtbInformation.Text = Player.HomeWorld.Description;
        }

        private void btnSelectHomeWorld_Click(object sender, EventArgs e)
        {

        }
    }
}
