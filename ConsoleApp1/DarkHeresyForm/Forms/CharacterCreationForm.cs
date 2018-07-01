using Engine;
using Engine.Actions;
using Engine.Characters.HomeWorlds;
using Engine.Skills;
using Engine.Statistics;
using Engine.Utilities;
using Engine.Utilities.Constants;
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
using static Engine.Characters.HomeWorlds.HomeWorld;
using static Engine.Human_Base;
using static Engine.Statistics.CharacterStat;

namespace DarkHeresyForm
{
    public partial class CharacterCreationForm : Form
    {
        public Player Player { get; set; }
        private List<HomeWorld> HomeWorlds { get; set; }

        public CharacterCreationForm(Player player = null)
        {
            InitializeComponent();
            if (player == null)
            {
                Player newPlayer = new Player();
                Player = newPlayer;
            }
            HomeWorlds = ReadOnlyLists.PopulateHomeWorlds();
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

            //SelectHomeWorld(this.Player);

            Player.AllocateValues();
            Player.AllocateSkills();
            int[] startingSkillsIds = { 1, 2 };
            Player.AllocateStartingSkills(startingSkillsIds);
            rtbInformation.Text += Environment.NewLine;
            rtbInformation.Text += String.Format("Character Statistics have been generated.");
            UpdateDisplay(panelPlayerStats, Player);
            UpdateSkillsDisplay(panelSkills, Player);

            //btnGenerateHomeworld.Hide();
            //cboHomeWorld.Enabled = false;            //create new button and replace the current one.
            //CreateFormButton("GenerateStatistics", new Point(93, 259), new Size(142, 23), b_AllocateValues, panelInformation);

        }




        //button bindings to be assigned dynamically
        //private void b_AllocateValues(object sender, EventArgs e)
        //{
        //    var _player = Player;
        //    AllocateValues(_player);
        //    rtbInformation.Text += Environment.NewLine;
        //    rtbInformation.Text += String.Format("Character Statistics have been generated: WS: {0}, BS: {1}", Player.Ws.Value, Player.Bs.Value);
        //    UpdateDisplay(panelPlayerStats, Player);

        //}

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
            if(player.Ws != null)
            {
                var playerProperties = player.GetType().GetProperties().Where(x => x.PropertyType == typeof(CharacterStat)).ToList();//finds the properties of the player
                var children = panel.Controls.OfType<TextBox>();//
                var enumPropertyNames = EnumUtility.GetValues<StatName>();
                foreach (Control control in children)
                {
                    control.ForeColor = Color.Black;
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
                    if (control.Name == "tbWounds")
                    {
                        control.Text = player.Wounds.ToString();
                    }
                }
            }
            

        }
        void UpdateSkillsDisplay(Panel panel, Player player)
        {
            var children = panel.Controls.OfType<TextBox>();
            foreach (var control in children)
            {
                foreach (var skill in player.MovementSkills)
                {
                    if (control.Name.Contains(skill.Name) && (control.Name.Contains("Rank")))
                    {
                        control.Text = skill.Rank.ToString();
                    }
                    else if (control.Name.Contains(skill.Name) && (control.Name.Contains("Base")))
                        {
                        control.Text = skill.ModifiedValue.ToString();
                    }
                }
            }
        }
     
        private void cboHomeWorld_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selection = cboHomeWorld.SelectedItem;
            Player.HomeWorld = (HomeWorld)selection;
            rtbInformation.Text = Player.HomeWorld.Description;
        }

        private void btnSelectHomeWorld_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //rtbInformation.Text += String.Format("Result = {0}  Success? = {1}  Degrees of success/failure: {2}", result.Item1, result.Item2, result.Item3);
            rtbInformation.Text += Environment.NewLine;
            //Player.MovementSkills.Add(new SkillsWithRank("Acrobatics", "description", Player.Ag, 1.0));
            var result = Player.ConductMovementCheck("Acrobatics");
            var isSuccess = result.isSuccess ? "SUCCESSFUL" : "unsuccessful";
            var dof = result.isSuccess ? "success" : "failure";
            rtbInformation.Text += String.Format("You attempt to use acrobatics. You are {0} so you require a roll below {1}...", ReadOnlyLists.GetSkillLevelsById(1).Description, 20);//need to get the aptitude level, and need to get the modified value required
            rtbInformation.Text += String.Format("You rolled a {0}, and was {1} to {2} degrees of {3}.", result.StrValue, isSuccess, result.DegreesofSuccess, dof);
            rtbInformation.Text += Environment.NewLine;

        }

        private void CharacterCreationForm_Load(object sender, EventArgs e)
        {

        }


        private void btnCheckAptitudes_Click(object sender, EventArgs e)
        {
           
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}