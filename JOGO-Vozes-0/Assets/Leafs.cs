    /*using UnityEngine;
    using System.Collections.Generic;
    using DG.Tweening;

    public class Leafs : MonoBehaviour
    {
        [SerializeField] float fallDuration = 2f;
        [SerializeField] float fadeDuration = 1f;
        [SerializeField] float fallDistance = 3f;
        [SerializeField] Ease fallEase = Ease.OutQuad;

        List<Transform> leaves = new();

        void Start()
        {
            foreach (Transform child in transform)
            {
                if (child.GetComponent<SpriteRenderer>() != null)
                    leaves.Add(child);
            }
        }

        void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            foreach (var leaf in leaves.ToArray())
            {
                if (leaf == null) continue;

                var collider = leaf.GetComponent<Collider2D>();
                if (collider != null && collider.OverlapPoint(mousePos))
                {
                    TriggerLeafFall(leaf);
                    leaves.Remove(leaf);
                }
            }
        }

        void TriggerLeafFall(Transform leaf)
        {
            var sr = leaf.GetComponent<SpriteRenderer>();
            var startPos = leaf.position;
            var targetY = startPos.y - fallDistance;
            var randomXOffset = Random.Range(-1f, 1f);

            // Move and fade
            leaf.DOMove(new Vector2(startPos.x + randomXOffset, targetY), fallDuration)
                .SetEase(fallEase);
            sr.DOFade(0, fadeDuration).SetDelay(fallDuration - fadeDuration);

            // Destroy after
            Destroy(leaf.gameObject, fallDuration + 0.2f);
        }
    }*/