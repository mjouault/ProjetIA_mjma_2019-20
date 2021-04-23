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
    public partial class FormTaquin : Form
    {
        public static int tailleTaquin;
        public FormTaquin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SearchTree g = new SearchTree();

            /*  int case1 = int.Parse(tb_case1.Text);
              int case2 = int.Parse(tb_case2.Text);
              int case3 = int.Parse(tb_case3.Text);
              int case4 = int.Parse(tb_case4.Text);
              int case5 = int.Parse(tb_case5.Text);
              int case6 = int.Parse(tb_case6.Text);
              int case7 = int.Parse(tb_case7.Text);
              int case8 = int.Parse(tb_case8.Text);
              int case9 = int.Parse(tb_case9.Text);*/

            //   int[,] initState = { { case1, case2, case3 }, { case4, case5, case6 }, { case7, case8, case9 } };

            //création d'un taquin aléatoire
            /*  Random R = new Random();
              List<int> taquinAlea = new List<int>();
              for (int i = 0; i < 2; i++)
              {
                  taquinAlea.Add(0);
              }
              for (int i = 1; i <= tailleTaquin * tailleTaquin - 2; i++)
              {
                  taquinAlea.Add(i);
              }
              taquinAlea.OrderBy(x => R.Next()).ToList();*/


            int[,] initState = { { 1, 2, 3,4,5},
                                 { 0, 6, 7,8,9},
                                 { 11, 12, 13,10,0},
                                 { 16, 17, 18,14,15},
                                 { 21, 22, 23,20,19} };


            NodeTaquin N0 = new NodeTaquin(initState); 
            List<GenericNode> Lres = g.SearchAStarSolution(N0);

            if (Lres.Count == 0)
            {
                labelsolution.Text = "Pas de solution";
            }
            else
            {
                labelsolution.Text = "Une solution a été trouvée";
                foreach (GenericNode N in Lres)
                {
                    listBox1.Items.Add(N);
                }
                labelcountopen.Text = "Nb noeuds des ouverts : " + g.CountInOpenList().ToString();
                labelcountclosed.Text = "Nb noeuds des fermés : " + g.CountInClosedList().ToString();
               // g.GetSearchTree(treeView1);
            }

        }
        
    }
}
