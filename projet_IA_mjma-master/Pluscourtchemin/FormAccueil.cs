using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pluscourtchemin
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Choix d'un Taquin 3*3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_33_Click(object sender, EventArgs e)
        {
            Taquin_3x3 f = new Taquin_3x3(); 
            this.Hide(); //cache le formAccueil quand on décide d'aller dans le form 3*3
            f.Show(); //affiche le form du Taquin 3*3
        }

        /// <summary>
        /// Choix d'un Taquin 5*5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_55_Click(object sender, EventArgs e)
        {
            Taquin_5x5 f = new Taquin_5x5();
            this.Hide(); //cache le formAccueil quand on décide d'aller dans le form 3*3
            f.Show(); //affiche le form du Taquin 3*3
        }

    }
}
