using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluscourtchemin
{
    public class NodeTaquin : GenericNode
    {
        public int[,] state;

        /// <summary>
        /// NodeTaquin : état de jeu
        /// </summary>
        /// <param name="newname"></param>
        public NodeTaquin(int[,]newstate ) : base() 
        {
            state = newstate;
        }
        
        /// <summary>
        /// Permet de comparer les contenus de 2 tableaux (type GenericNode). Si une valeur différente, retourne faux
        /// </summary>
        /// <param name="N2"></param>
        /// <returns></returns>
        public override bool IsEqual (GenericNode N2)
        {
            NodeTaquin NT = (NodeTaquin)(N2);
            for (int j = 0; j < state.GetLength(1); j++)
            {
                for (int i = 0; i < state.GetLength(0); i++)
                {
                    if (state[i, j] != NT.state[i, j])
                        return false;
                }
            }
            return true;
        }

        public override double GetArcCost(GenericNode N2)
        {
            return (1);
        }

        /// <summary>
        /// Permet de vérifier quand un état intermédiaire ets atteint pour la stratégie humaine
        /// True si correspond à l'état intermédiaire, false sinon
        /// Etat intermédiaire : "1" bien placé, puis "2" bien placé etc
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsMiddleState( int value) // value = chiffre à bien placer (entre 1 et dimension du Taquin)
        {
            int[] FinalePlace = ReturnFinaleCoordinates(value); //Position attendue de la case considérée
            int[] CurrentPlace = ReturnCurrentCoordinates(value); //Position actuelle de la case considérée
            
            return (CurrentPlace[0] == FinalePlace[0] && CurrentPlace[1] ==FinalePlace[1]) ? true : false;
        }

        /// <summary>
        /// True si correspond à l'état final, false sinon
        /// </summary>
        /// <returns></returns>
        public override bool IsEndState()
        {
            NodeTaquin endState;
            // Si Taquin 3*3
            if (state.GetLength(0) == 3)
            {
                int[,] gridEndState = new int[,]{ { 1, 2, 3 },
                                                  { 4, 5, 6},
                                                  { 7, 0, 0} };
                endState = new NodeTaquin(gridEndState);
            }
            else //si Taquin 5*5
            {
                int[,] gridEndState = new int[,]{ { 1, 2, 3, 4, 5 },
                                            { 6, 7, 8, 9, 10 },
                                            { 11, 12, 13, 14, 15},
                                            {16, 17, 18, 19, 20 },
                                            {21, 22, 23, 0, 0 } };

                endState = new NodeTaquin(gridEndState);
            }
           
            return (IsEqual(endState)); 
        }

        /// <summary>
        /// Copie du tableau de l'état de jeu courant
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private int[,] CopyState(int[,] state)
        {
            int[,] tab2 = new int[state.GetLength(0), state.GetLength(1)];
            for (int j = 0; j < state.GetLength(1); j++)
                for (int i = 0; i < state.GetLength(0); i++)
                {
                    tab2[i, j] = state[i, j];
                }

            return tab2;
        }

        /// <summary>
        /// Simule le déplacement d'un zéro pour trouver les états possibles à partir de l'état de jeu actuel 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="pos1"></param>
        /// <returns></returns>
        private List<GenericNode> SimulateMove(int[,] state, int[] pos1)
        {
            List<GenericNode> lsucc = new List<GenericNode>();

            // Successeur en HAUT
            if (pos1[0] > 0)
            {
                // recopie du tableau
                int[,] tab2 = this.CopyState(state);
                // MAJ de la position du 0
                tab2[pos1[0], pos1[1]] = tab2[pos1[0] - 1, pos1[1]];
                tab2[pos1[0] - 1, pos1[1]] = 0;
                // Ajout à listsucc
                lsucc.Add(new NodeTaquin(tab2));
            }

            // Successeur en BAS
            if (pos1[0] < state.GetLength(1) - 1)
            {
                // recopie du tableau
                int[,] tab2 = this.CopyState(state);
                // MAJ de la position du 0
                tab2[pos1[0], pos1[1]] = tab2[pos1[0] + 1, pos1[1]];
                tab2[pos1[0] + 1, pos1[1]] = 0;
                // Ajout à listsucc
                lsucc.Add(new NodeTaquin(tab2));
            }
     
            // Successeur à GAUCHE
            if (pos1[1] > 0)
            {
                // recopie du tableau
                int[,] tab2 = this.CopyState(state);
                // MAJ de la position du 0
                tab2[pos1[0], pos1[1]] = tab2[pos1[0], pos1[1] - 1];
                tab2[pos1[0], pos1[1] - 1] = 0;
                // Ajout à listsucc
                lsucc.Add(new NodeTaquin(tab2));
            }

            // Successeur à DROITE
            if (pos1[1] < state.GetLength(1) - 1)
            {
                // recopie du tableau
                int[,] tab2 = this.CopyState(state);
                // MAJ de la position du ?
                tab2[pos1[0], pos1[1]] = tab2[pos1[0], pos1[1] + 1];
                tab2[pos1[0], pos1[1] + 1] = 0;
                // Ajout à listsucc
                lsucc.Add(new NodeTaquin(tab2));
            }

            return lsucc;
        }

        /// <summary>
        /// SimulateMove adaptée à la stratégie humaine 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="pos1"></param>
        /// <param name="listRightPlace"></param>
        /// <returns></returns>
        private List<GenericNode> SimulateMoveHumanStrategy(int[,] state, int[] pos1, List<int> listRightPlace)
        {
            List<GenericNode> lsucc = new List<GenericNode>();

            // Successeur en haut
            if (pos1[0] > 0)
            {
                //Vérifie si le successeur trouvé est déjà bien placé ou non. Si oui, il ne doit pas être déplacé
                if (!listRightPlace.Contains(state[pos1[0] - 1, pos1[1]]))
                {  
                    int[,] tab2 = this.CopyState(state);
                    tab2[pos1[0], pos1[1]] = tab2[pos1[0] - 1, pos1[1]];
                    tab2[pos1[0] - 1, pos1[1]] = 0; 
                    lsucc.Add(new NodeTaquin(tab2));
                }
            }
            // Successeur en bas
            if (pos1[0] < state.GetLength(1) - 1)
            {
                if ( !listRightPlace.Contains(state[pos1[0] + 1, pos1[1]]))
                {
                    int[,] tab2 = this.CopyState(state);
                    tab2[pos1[0], pos1[1]] = tab2[pos1[0] + 1, pos1[1]];
                    tab2[pos1[0] + 1, pos1[1]] = 0;
                    lsucc.Add(new NodeTaquin(tab2));
                }
            }
            // Successeur à gauche
            if (pos1[1] > 0)
            {
                if (!listRightPlace.Contains(state[pos1[0], pos1[1] - 1]))
                {
                    int[,] tab2 = this.CopyState(state);
                    tab2[pos1[0], pos1[1]] = tab2[pos1[0], pos1[1] - 1];
                    tab2[pos1[0], pos1[1] - 1] = 0;
                    lsucc.Add(new NodeTaquin(tab2));
                }
            }
            // Successeur à droite
            if (pos1[1] < state.GetLength(1) - 1)
            {
                if (!listRightPlace.Contains(state[pos1[0], pos1[1] + 1]))
                {
                    int[,] tab2 = this.CopyState(state);
                    tab2[pos1[0], pos1[1]] = tab2[pos1[0], pos1[1] + 1];
                    tab2[pos1[0], pos1[1] + 1] = 0;

                    lsucc.Add(new NodeTaquin(tab2));
                }
            }
            return lsucc;
        }

        /// <summary>
        /// Appelle SimulateMove et renvoie la liste des successeurs trouvés pour les deux trous
        /// </summary>
        /// <param name="pos1"></param>
        /// <param name="pos2"></param>
        /// <returns></returns>
        private List<GenericNode> FindSucc(int [] pos1, int [] pos2)
        {
            List<GenericNode> lsucc = new List<GenericNode>();
            IEnumerable<GenericNode> lsucc1 = this.SimulateMove(this.state, pos1);
            IEnumerable<GenericNode> lsucc2 = this.SimulateMove(this.state, pos2);   
            lsucc = lsucc1.Concat(lsucc2).ToList();//concaténation des deux listes de successeurs
            return lsucc;
        }

        /// <summary>
        /// FindSucc adaptée à stratégie humaine (appel à SimulateMoveHumanStrategy() )
        /// </summary>
        /// <param name="pos1"></param>
        /// <param name="pos2"></param>
        /// <param name="listRightPlace"></param>
        /// <returns></returns>
        private List<GenericNode> FindSuccHumanStrategy(int[] pos1, int[] pos2,List<int> listRightPlace)
        {
            List<GenericNode> lsucc = new List<GenericNode>();
            IEnumerable<GenericNode> lsucc1 = SimulateMoveHumanStrategy(state, pos1, listRightPlace);
            IEnumerable<GenericNode> lsucc2 = SimulateMoveHumanStrategy(state, pos2,listRightPlace);
            lsucc = lsucc1.Concat(lsucc2).ToList();
            return lsucc;
        }

        /// <summary>
        /// Renvoie les coordonnées des deux zéros sous forme de liste de tableau [2]
        /// </summary>
        /// <returns></returns>
        public List<int[]> FindZeroPositions()
        {
            List<int[]> zeroPositions = new List<int[]>();
            for (int j = 0; j < state.GetLength(1); j++)
                for (int i = 0; i < state.GetLength(0); i++)
                {
                    if (state[i, j] == 0)
                    {
                        zeroPositions.Add(new int[] { i, j });
                    }
                }
            return zeroPositions;
        }

        /// <summary>
        /// Retourne la liste des successeurs pour les deux trous identifiés (FindSucc private)
        /// </summary>
        /// <returns></returns>
        public override List<GenericNode> GetListSucc()
        {
           List <int []> zeroPositions = FindZeroPositions();
            return FindSucc(zeroPositions[0], zeroPositions[1]);
        }

        /// <summary>
        /// GetListSucc adaptée à stratégie humaine
        /// ListRightPlace = liste des cases déjà bien placées et à ne pas bouger
        /// </summary>
        /// <param name="listRightPlace"></param>
        /// <returns></returns>
        public override List<GenericNode> GetListSuccHumanStrategy(List<int> listRightPlace)
        {
            List<int[]> zeroPositions = FindZeroPositions();
            return FindSuccHumanStrategy(zeroPositions[0], zeroPositions[1], listRightPlace); //il faut retourner une liste de tableaux
        }

        /// <summary>
        /// Pr une case donnée(value), retourne les coordonnées  qu'elle devrait avoir à l'état final
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int[] ReturnFinaleCoordinates(int value)
        {
            int[] coordinates = new int [2];
            int position = value - 1;
            coordinates[0] = position / state.GetLength(0);
            coordinates[1]= position % state.GetLength(1);
            return (coordinates);
        }

        /// <summary>
        /// retourne les coordonnées d'une valeur (entre 1 et dimTaquin*dimTaquin) dans l'état actuel)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int[] ReturnCurrentCoordinates(int value)
        {
            int i = 0; int j = 0;
            while (i < this.state.GetLength(0) && i < this.state.GetLength(1) && this.state[i, j] != value)
            {
                while (j < state.GetLength(1) && state[i, j] != value)
                {
                    j++;
                }
                if (j == state.GetLength(1)) { i++; j = 0; }
            }
            int[] coordinates = new int[] { i, j };
            return (coordinates);
        }

        /// <summary>
        /// Calcule l'heuristique pour A* : distance de Manhattan pondérée
        /// </summary>
        /// <returns></returns>
        public override double CalculateHCost()
        {
            double manhattan = 0;
            //Calcul de l'heuristique
            for (int j = 0; j < state.GetLength(1); j++)
            {
                for (int i = 0; i < state.GetLength(0); i++)
                {
                    //calcul de la distance de Manhattan entre état actuel et état final
                    if ( state[i,j]!=0)
                    {
                        int [] coordinatesEndState =ReturnFinaleCoordinates(state[i,j]);
                        //1.2 = coeff optimal pr minimiser nb de noeuds ouverts
                        manhattan += 1.2*(Math.Abs (coordinatesEndState[1]-j)+Math.Abs(coordinatesEndState[0]-i));
                    }
                }
            }
            return (manhattan);
        }

        /// <summary>
        /// Calcule l'heuristique pr la stratégie humaine
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override double CalculateHCostHumanStrategy(int value)
        {
            double manhattan = 0;

            int[] coordinatesEndState = ReturnFinaleCoordinates(value);
            int[] currentCoordinates = ReturnCurrentCoordinates(value);

            //Position de la case mal placée considérée (value) par rapport à sa place finale
            manhattan += 7*(Math.Abs(coordinatesEndState[1] - currentCoordinates[1]) + Math.Abs(coordinatesEndState[0] - currentCoordinates[0]));

            List <int[]> zeroCurrentCoordinates = FindZeroPositions();//recherche place des zéros dans l'état actuel

            //-----------    POSITION DES ZEROS PAR RAPPORT AU MAL PLACÉ -----------------
            //recherche du trou le plus proche de la case que l'on veut bien placer
            //a) Manhattan entre 1er zéro et case mal placée
            double zero1FromCurrentPlace = Math.Abs(currentCoordinates[1] - zeroCurrentCoordinates[0][1]) + Math.Abs(currentCoordinates[0] - zeroCurrentCoordinates[0][0]);
            //b) Manhattan entre 2eme zéro et case mal placée
            double zero2FromCurrentPlace = Math.Abs(currentCoordinates[1] - zeroCurrentCoordinates[1][1]) + Math.Abs(currentCoordinates[0] - zeroCurrentCoordinates[1][0]);

            double minFromCurrentPlace = Math.Min(zero1FromCurrentPlace, zero2FromCurrentPlace);
            //Poids + fort pour position du zéro le + proche de la case mal placée considérée
            manhattan += 5*minFromCurrentPlace;

            //-----------    POSITION DES ZEROS PAR RAPPORT A POSITION FINALE DU MAL PLACÉ -----------------
            //recherche du trou le plus proche  de  la case dans son état final 
            double zero1FromFinalePlace = Math.Abs(coordinatesEndState[1] - zeroCurrentCoordinates[0][1]) + Math.Abs(coordinatesEndState[0] - zeroCurrentCoordinates[0][0]);
            double zero2FromFinalePlace = Math.Abs(coordinatesEndState[1] - zeroCurrentCoordinates[1][1]) + Math.Abs(coordinatesEndState[0] - zeroCurrentCoordinates[1][0]);
            manhattan += 4*(zero1FromFinalePlace + zero2FromFinalePlace);
            return (manhattan);
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < state.GetLength(0); i++)
                for (int j = 0; j < state.GetLength(1); j++)
                {
                    result += state[i, j];
                }

            return result;
        }
    }
}
