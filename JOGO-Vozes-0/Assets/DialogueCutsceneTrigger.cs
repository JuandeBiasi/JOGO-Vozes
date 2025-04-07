using UnityEngine;
using Yarn.Unity;

public class DialogueCutsceneTrigger : MonoBehaviour
{
    [SerializeField] private DialogueRunner dialogueRunner;
    [SerializeField] private string dialogueNode;
    [SerializeField] private Player player;

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
        if (!other.CompareTag("Player")) return;
        
        _spriteRenderer.enabled = true;
        dialogueRunner.onNodeComplete.AddListener(OnNodeFinished);
        dialogueRunner.StartDialogue(dialogueNode);
        _hasTriggered = true;
        player.inputFrozen = true;
    }
    
    private void OnNodeFinished(string nodeName)
    {
        _hasTriggered = false;
        _spriteRenderer.enabled = false;
        player.inputFrozen = false;
        gameObject.SetActive(false);
    }
}
