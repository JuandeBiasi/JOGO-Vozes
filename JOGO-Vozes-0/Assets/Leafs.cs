using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine.Events;

public class LeafFallTrigger : MonoBehaviour
{
    [SerializeField] private float fallDuration = 2f;
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private float fallDistance = 3f;
    [SerializeField] private Ease fallEase = Ease.OutQuad;
    [SerializeField] private UnityEvent onFall;

    private readonly List<Transform> _leaves = new();
    private bool _hasTriggered = false;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        foreach (Transform child in transform)
        {
            if (child.GetComponent<SpriteRenderer>() != null)
                _leaves.Add(child);
        }
    }

    private void Update()
    {
        if (_hasTriggered) return;
        if (!Input.GetMouseButtonDown(0)) return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var hit = Physics2D.OverlapPoint(mousePos);

        if (hit == null || hit.transform != transform) return;
        _hasTriggered = true;
        _audioSource.Play();
        foreach (var leaf in _leaves.Where(leaf => leaf != null))
        {
            TriggerLeafFall(leaf);
        }
    }

    private void TriggerLeafFall(Transform leaf)
    {
        var sr = leaf.GetComponent<SpriteRenderer>();
        if (sr == null) return;

        var startPos = leaf.position;
        var targetY = startPos.y - fallDistance;
        var randomXOffset = Random.Range(-1f, 1f);

        leaf.DOMove(new Vector2(startPos.x + randomXOffset, targetY), fallDuration)
            .SetEase(fallEase);
        sr.DOFade(0, fadeDuration).SetDelay(fallDuration - fadeDuration);

        Destroy(leaf.gameObject, fallDuration + 0.2f);
        onFall?.Invoke();
    }
}