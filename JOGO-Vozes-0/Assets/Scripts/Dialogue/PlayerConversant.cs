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

        public IEnumerable<string> GetChoices()
        {
            yield return "i lived here my whole life";
            yield return "i love her";
        }

        public void Next()
        {
           DialogNode[] children = currentDialogue.GetAllChildren(currentNode).ToArray();
            int randomIndex = Random.Range(0, children.Count());
            currentNode =  children[randomIndex];
        }


        public bool HasNext()
        {
            
             return   currentDialogue.GetAllChildren(currentNode).Count() > 0;
            
        }

    }
}