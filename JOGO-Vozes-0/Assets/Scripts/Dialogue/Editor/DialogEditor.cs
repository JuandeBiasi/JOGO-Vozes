using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using Codice.Client.Common.GameUI;
using Unity.VisualScripting;

namespace RPG.Dialogue.Editor
{
    
      public class DialogEditor : EditorWindow
      {
        Dialogue selectedDialogue = null;

            [MenuItem("Window/Dialogue Editor")]
           public static void ShowEditorWindow()
           {
                GetWindow(typeof(DialogEditor), false, "Dialog Editor");
           }

             [OnOpenAsset(1)]
           public static bool OnOpenAsset(int instanceID , int line)
           {
              Dialogue dialogue =  EditorUtility.InstanceIDToObject(instanceID) as Dialogue;
            if (dialogue != null)
            {
                ShowEditorWindow();
                return true;
            }
              
                 return false;         
           }
        private void OnEnable()
        {
            Selection.selectionChanged += OnSelectionChanged;
        }

        private void OnSelectionChanged()
        {
            Dialogue newDialogue = Selection.activeObject as Dialogue;
            if (newDialogue != null)
            {
                selectedDialogue = newDialogue;
                Repaint();
            }
        }

        private void OnGUI()
        {
            if (selectedDialogue== null)
            {
             EditorGUILayout.LabelField("HELLO bicth");

            }
            else
            {
                EditorGUILayout.LabelField(selectedDialogue.name);
            }

        }
    }

}