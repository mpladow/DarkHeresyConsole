using Engine;
using Engine.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkHeresyForm.Forms
{
    public partial class LoadCharacter : Form
    {
        public LoadCharacter()
        {
            InitializeComponent();
            listSavedCharacters.DataSource = SaveLoad.savePlayers;
            
            listSavedCharacters.DisplayMember = "Name";
        }

        private void listSavedCharacters_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player selected = (Player)listSavedCharacters.SelectedItem;
            UpdateDisplay(panelCharacterLoad, selected);
            listSavedCharacters.Refresh();
        }
        void UpdateDisplay(Panel panel, Player player)
        {
            if(player!= null)
            {
                var children = panel.Controls.OfType<TextBox>();

                foreach (var textbox in children)
                {
                    textbox.ForeColor = Color.Black;
                    if (textbox.Name.Contains("Name"))
                        textbox.Text = player.Name;
                    if (textbox.Name.Contains("Wounds"))
                        textbox.Text = player.Wounds.ToString();
                    if (textbox.Name.Contains("Xp"))
                        textbox.Text = player.XP.ToString();
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

        }

        private void btnLoadCharacter_Click(object sender, EventArgs e)
        {
            CharacterCreationForm characterCreationForm = new CharacterCreationForm((Player)listSavedCharacters.SelectedItem);
            characterCreationForm.Show();
            Close();
        }

        private void btnDeleteCharacter_Click(object sender, EventArgs e)
        {
            listSavedCharacters.BeginUpdate();
            Player selectedPlayer = (Player)listSavedCharacters.SelectedItem;
            SaveLoad.Delete(selectedPlayer);
            var c = SaveLoad.savePlayers;
            
            listSavedCharacters.EndUpdate();
            listSavedCharacters.DataSource = null;
            listSavedCharacters.DataSource = SaveLoad.savePlayers;
        }
    }
}
