using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Dialogue
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue", order = 0)]

    public class Dialogue : ScriptableObject
    {
        [SerializeField]
        List<DialogNode> nodes = new List<DialogNode>();



        Dictionary<string, DialogNode> nodeLookUP = new Dictionary<string, DialogNode>();
#if UNITY_EDITOR      
        private void Awake()
        {
            if (nodes.Count == 0)
            { DialogNode rootNode = new DialogNode();
                rootNode.uniqueID =Guid.NewGuid().ToString();
                nodes.Add(rootNode);
            }
            
            OnValidate();
        }
#endif
        private void OnValidate()
        {
            nodeLookUP.Clear();
            foreach (DialogNode node in GetAllNodes())
            {
                nodeLookUP[node.uniqueID] = node;
                
            }
           
        }
       
        public IEnumerable<DialogNode> GetAllNodes()
        {
            return nodes;
        }

        public DialogNode GetRootNode()
        {
            return nodes[0];
        }


        public IEnumerable<DialogNode> GetAllChildren(DialogNode parentNode)
        {
           
            foreach (string childID in parentNode.children)
            {        
               if (nodeLookUP.ContainsKey(childID))
               {
                 yield return (nodeLookUP[childID]);
               }
            }
           
        }

        public void CreateNode(DialogNode parent)
        {
            throw new NotImplementedException();
        }
    }
}