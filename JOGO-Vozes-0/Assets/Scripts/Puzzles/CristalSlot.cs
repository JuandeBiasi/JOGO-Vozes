using UnityEngine.Serialization;
using UnityEngine.U2D.IK;

namespace Puzzles
{
    using UnityEngine;
    using UnityEngine.Events;
    
    public enum FigureType
    {
        Red, Green, Blue, Yellow
    }

    [RequireComponent(typeof(SpriteRenderer), typeof(CircleCollider2D))]
    public class CrystalSlot : MonoBehaviour
    {
        [SerializeField] private FigureType[] figureCycle;
        [SerializeField] private int currentIndex;
        [SerializeField] private Sprite[] figureSprites;
        [SerializeField] private Sprite[] figureSpritesSolved;

        private SpriteRenderer _spriteRenderer;

        public UnityEvent OnFigureChanged;

        public FigureType CurrentFigure => figureCycle[currentIndex];
        private bool _isPuzzleSolved;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            UpdateFigure();
        }

        public void CycleFigure()
        {
            if (_isPuzzleSolved) return;
            
            currentIndex = (currentIndex + 1) % figureCycle.Length;
            UpdateFigure();
            OnFigureChanged?.Invoke();
        }

        public void Solve()
        {
            _isPuzzleSolved = true;
            if (figureSprites != null && figureSpritesSolved.Length > currentIndex)
                _spriteRenderer.sprite = figureSpritesSolved[currentIndex];
        }

        private void UpdateFigure()
        {
            if (figureSprites != null && figureSprites.Length > currentIndex)
                _spriteRenderer.sprite = figureSprites[currentIndex];
        }
        
        private void OnMouseDown()
        {
            CycleFigure();
        }
    }

}