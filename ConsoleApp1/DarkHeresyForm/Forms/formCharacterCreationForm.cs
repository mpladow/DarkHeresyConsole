using Engine;
using Engine.Actions;
using Engine.Characters.CharacterCreation;
using Engine.Characters.HomeWorlds;
using Engine.Skills;
using Engine.Statistics;
using Engine.Utilities;
using Engine.Utilities.Constants;
using Engine.World_Objects;
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
using static Engine.Character_base;
using static Engine.Statistics.CharacterStat;

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
            else
            {
                Player = player;
                UpdateDisplay(panelPlayerStats, Player);

            }
            cboHomeWorld.DataSource = World.HomeWorlds;
            cboHomeWorld.DisplayMember = "Name";
            cboBackground.DataSource = World.Backgrounds;
            cboBackground.DisplayMember = "Name";
            cboWeapons.DataSource = Player.Weapons.Count > 0? Player.Weapons:null;
            cboWeapons.DisplayMember = "Name";
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

        private void btnSelectHomeworld_Click_1(object sender, EventArgs e)
        {
            Player.AllocateValues();
            Player.SetPlayerMainStatOntoSkill();
            Player.UpdateHomeWorldCharacteristicBonuses();

            int[] startingMovementSkillsIds = { 1, 2 };
            Player.SetPlayerStartingSkillsLevel(startingMovementSkillsIds);
            rtbInformation.Text += Environment.NewLine;
            rtbInformation.Text += String.Format("Character Statistics have been generated.");
            UpdateDisplay(panelPlayerStats, Player);
            if (cboHomeWorld.Enabled)
            {
                cboHomeWorld.Enabled = false;
                btnSelectHomeworld.Text = "Selected";
            }
            else
            {
                cboHomeWorld.Enabled = true;
                btnSelectHomeworld.Text = "Select HomeWorld";
            };
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
            var children = panel.Controls.OfType<TextBox>();

            foreach (var textbox in children)
            {
                textbox.ForeColor = Color.Black;
                foreach (var stat in player.Stats)
                {

                    if (textbox.Name.Contains(stat.Name))
                    {
                        textbox.Text = stat.Value.ToString();
                    }
                    foreach (var posStat in player.HomeWorld.StatsAffectedPositive)
                    {
                        if (textbox.Name.Contains(posStat))
                        {
                            textbox.ForeColor = Color.DarkSeaGreen;
                        }
                    }
                    foreach (var negStat in player.HomeWorld.StatsAffectedNegative)
                    {
                        if (textbox.Name.Contains(negStat))
                        {
                            textbox.ForeColor = Color.DarkRed;
                        }
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
            if (Player != null)
            {
                var selection = cboHomeWorld.SelectedItem;
                Player.HomeWorld = (HomeWorld)selection;
                rtbInformation.Text = Player.HomeWorld.Description;
            }
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
            rtbInformation.Text += String.Format("You attempt to use acrobatics. You are {0} so you require a roll below {1}...", World.GetSkillLevelsById(1).Description, 20);//need to get the aptitude level, and need to get the modified value required
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSaveCharacter_Click(object sender, EventArgs e)
        {
            SaveLoad.Save(Player);
            Close();
        }

        private void tbCharacterName_TextChanged(object sender, EventArgs e)
        {
            Player.Name = tbCharacterName.Text;
        }

        private void btnSelectBackground_Click(object sender, EventArgs e)
        {
            var selected = cboBackground.Enabled;

            if (selected)
            {
                foreach (var weapon in Player.Background.StartingEquipment)
                {
                    weapon.EquipWeapon(Player);
                }
            }
            else
            {
                foreach (var weapon in Player.Background.StartingEquipment)
                {
                    weapon.UnequipWeapon(Player);
                }
            }

            if (selected)
            {
                cboBackground.Enabled = false;
                btnSelectBackground.Text = "Selected";
            }
            else
            {
                cboBackground.Enabled = true;
                btnSelectBackground.Text = "Select Background";

            };
            UpdateSkillsDisplay(panelSkills, Player);

        }

        private void cboBackground_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Player != null)
            {
                var selection = cboBackground.SelectedItem;
                Player.Background = (Background)selection;
                rtbBackgroundText.Text = Player.Background.Description;
                rtbBackgroundText.Text += Environment.NewLine;
                foreach (var item in Player.Background.StartingEquipment)
                {
                    rtbBackgroundText.Text += item.Name;
                    rtbBackgroundText.Text += Environment.NewLine;
                }
            }
        }

        private void cboWeapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Player != null)
            {
                var selection = (Weapon_base)cboWeapons.SelectedItem;
                rtbEquipment.Text += Player.Weapons.FirstOrDefault(x => x == selection).Description;
            }
        }
    }
}