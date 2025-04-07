using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using Yarn.Unity;

public class DialogueCutsceneTrigger : MonoBehaviour
{
    [SerializeField] private DialogueRunner dialogueRunner;
    [SerializeField] private string dialogueNode;
    [SerializeField] private Player player;
    [FormerlySerializedAs("_tilemap")] [SerializeField] private Tilemap tilemap;
    [SerializeField] private Cinemachine.CinemachineVirtualCamera virtualCamera;
    [FormerlySerializedAs("targetTransform")] [SerializeField] private Enemy_Skeleton enemySkeleton;

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
        virtualCamera.Follow = gameObject.transform;
    }
    
    private void OnNodeFinished(string nodeName)
    {
        if  (nodeName != dialogueNode) return;
        
        _hasTriggered = false;
        _spriteRenderer.enabled = false;
        player.inputFrozen = false;
        gameObject.SetActive(false);
        tilemap.gameObject.SetActive(true);
        virtualCamera.Follow = player.transform;
    }

    public void BossDead()
    {
        tilemap.gameObject.SetActive(false);
    }
}
