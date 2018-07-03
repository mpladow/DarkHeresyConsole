using DarkHeresyForm.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkHeresyForm
{
    public partial class splashscreen : Form
    {
        public splashscreen()
        {
            InitializeComponent();
        }

        private void btnCreateCharacter_Click(object sender, EventArgs e)
        {
            CharacterCreationForm characterCreationForm = new CharacterCreationForm();
            characterCreationForm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLoadCharacter_Click(object sender, EventArgs e)
        {
            LoadCharacter loadCharacter = new LoadCharacter();
            loadCharacter.Show();
        }
    }
}
