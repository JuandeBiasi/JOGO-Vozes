using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Dialogue 
{ 
[System.Serializable]
public class DialogNode
{
    public string uniqueID;
    public string text;
    public string[] children;
}

}