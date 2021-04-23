using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pluscourtchemin
{
    abstract public class GenericNode
    {
        protected double GCost;               //coût du chemin du noeud initial jusqu'à ce noeud
        protected double HCost;               //estimation heuristique du coût pour atteindre le noeud final
        protected double totalCost;           //coût total (=G+H)
        protected GenericNode parentNode;     // noeud parent
        protected List<GenericNode> children;  // noeuds enfants

        public GenericNode()
        {
            parentNode = null;
            children = new List<GenericNode>();
        }


        public double GetGCost()
        {
            return GCost;
        }

        public void SetGCost(double g)
        {
            GCost = g;
        }

        public double TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }

        public List<GenericNode> GetChildren()
        {
            return children;
        }

        public GenericNode GetParentNode()
        {
            return parentNode;
        }

        public void SetParentNode(GenericNode g)
        {
            parentNode = g;
            g.children.Add(this);
        }

        /// <summary>
        /// Calcul coût total d'un chemin avec méthode A*
        /// </summary> 
        public void CalculateTotalCost()
        {
            HCost = CalculateHCost();
            totalCost = GCost + HCost;
        }

        /// <summary>
        /// Suppression du noeud parent précédent
        /// </summary>
        public void SuppressParentNodes()
        {
            if (parentNode == null) return;
            parentNode.children.Remove(this);
            parentNode = null;
        }


        /// <summary>
        /// Calcul du coût total d'un chemin avec stratégie humaine
        /// </summary>
        /// <param name="value"></param>
        public void CalculateTotalCostHumanStrategy(int value)
        {
            HCost = CalculateHCostHumanStrategy(value); //heuristique H différente pour stratégie humaine
            totalCost = GCost + HCost;
        }

        public void RecalculateTotalCost()
        {
            totalCost = GCost + HCost;
        }

        // Méthodes abstraites à définir obligatoirement avec override dans une classe fille
        public abstract bool IsEqual(GenericNode N2);
        public abstract double GetArcCost(GenericNode N2);
        public abstract bool IsEndState();
        public abstract List<GenericNode> GetListSucc();
        public abstract List<GenericNode> GetListSuccHumanStrategy(List<int> listRightPlace);
        public abstract double CalculateHCost();
        public abstract double CalculateHCostHumanStrategy(int value);
        public abstract bool IsMiddleState(int value);
    }
}
