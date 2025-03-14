using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Dialogue
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue", order = 0)]

    public class Dialogue : ScriptableObject
    {
        [SerializeField]
       List <DialogNode> nodes = new List<DialogNode>();
        private void Awake()
        {
            if (nodes.Count == 0)
            {
                nodes.Add(new DialogNode());
            }
            
        }
    }
}


