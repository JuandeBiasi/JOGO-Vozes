
using UnityEngine;

public class DialogPuzzle : MonoBehaviour
{
    [SerializeField] private DialogueTrigger dialogueTrigger2;
    [SerializeField] private DialogueTrigger dialogueTrigger3;

    private int _count = 0;
    
    public void RuinedVisited()
    {
        _count++;
        
        if (_count == 2) return;
        
        dialogueTrigger2.gameObject.SetActive(false);
        dialogueTrigger3.gameObject.SetActive(true);
    }
}
