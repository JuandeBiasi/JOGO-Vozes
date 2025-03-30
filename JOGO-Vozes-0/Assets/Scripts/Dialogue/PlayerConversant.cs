using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RPG.Dialogue
{
    public class PlayerConversant : MonoBehaviour
    {

        [SerializeField] Dialogue currentDialogue;
        DialogNode currentNode = null;


        private void Awake()
        {
            currentNode = currentDialogue.GetRootNode();
        }

        public string GetText()
        {
            if (currentNode == null)
            {
                return "";
            }


           return currentNode.GetText();

        }

        public void Next()
        {
           DialogNode[] children = currentDialogue.GetAllChildren(currentNode).ToArray();
            currentNode =  children[0];
        }


        public bool HasNext()
        {
            
             return   currentDialogue.GetAllChildren(currentNode).Count() > 0;
            
        }

    }
}