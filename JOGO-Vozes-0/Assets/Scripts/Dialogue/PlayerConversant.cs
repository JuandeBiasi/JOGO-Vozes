using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace RPG.Dialogue
{
    public class PlayerConversant : MonoBehaviour
    {
        [SerializeField] string playerName;
        
         Dialogue currentDialogue;
        DialogNode currentNode = null;
        DialogueActivator currentConversant = null;
        bool isChoosing = false;

        public event Action onConversationUpdated;
       
      
        public void StartDialogue(DialogueActivator newConversant ,Dialogue newDialogue)
        {
            currentConversant = newConversant;
            currentDialogue = newDialogue;
            currentNode = currentDialogue.GetRootNode();
            
            onConversationUpdated?.Invoke();
        }
        public void Quit()
        {
            currentDialogue = null;
            currentNode = null;
            isChoosing=false;
            onConversationUpdated();
            currentConversant =null;
        }
        public bool IsActive()
        {
            return currentDialogue != null;
        }
        public bool IsChoosing()
        {
            return isChoosing;
        }

        public string GetText()
        {
            if (currentNode == null)
            {
                return "";
            }


           return currentNode.GetText();

        }

        public IEnumerable<DialogNode> GetChoices()
        {
            return currentDialogue.GetPlayerChildren(currentNode);
        }
        public void SelecteChoices(DialogNode chosenNode)
        {
            currentNode = chosenNode;
            isChoosing = false;
            Next();
        }
        public void Next()
        {
           int numPlayerResponses = currentDialogue.GetPlayerChildren(currentNode).Count();
            if (numPlayerResponses > 0)
            {
                isChoosing = true;
                onConversationUpdated();
                return;
            }


           DialogNode[] children = currentDialogue.GetAIChildren(currentNode).ToArray();
            int randomIndex = UnityEngine.Random.Range(0, children.Count());
            currentNode =  children[randomIndex];
            onConversationUpdated();
        }


        public bool HasNext()
        {
            
             return   currentDialogue.GetAllChildren(currentNode).Count() > 0;
            
        }

        public string GetCurrentConversantName()
        {
            if (isChoosing)
            {
                return playerName;
            }
            else
            {
                return currentConversant.GetName();
            }
        }
    }
}