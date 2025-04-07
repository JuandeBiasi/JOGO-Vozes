using UnityEngine;
using Yarn.Unity;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueRunner dialogueRunner;
    [SerializeField] private string dialogueNode = "PudgyCat";

    private SpriteRenderer _spriteRenderer;
    private bool _hasTriggered;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;
        _hasTriggered = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_hasTriggered) return;
        
        _spriteRenderer.enabled = true;
        dialogueRunner.StartDialogue(dialogueNode);
        _hasTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _hasTriggered = false;
        _spriteRenderer.enabled = false;
        dialogueRunner.Stop();
    }
}