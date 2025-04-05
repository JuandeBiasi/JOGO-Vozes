using System;
using System.Linq;

namespace Puzzles
{
    using UnityEngine;
    using UnityEngine.Events;

    public class CrystalPuzzleManager : MonoBehaviour
    {
        [SerializeField] private CrystalSlot[] slots;
        [SerializeField] private FigureType[] correctCombination;
        [SerializeField] private UnityEvent onPuzzleSolved;
        [SerializeField] private AudioClip audioSourceSolved;
        [SerializeField] private AudioClip audioSourceChanged;
        
        private bool _puzzleSolved;
        private Debouncer _debouncer;
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            _debouncer = new Debouncer(2);
            foreach (var slot in slots)
            {
                slot.OnFigureChanged.AddListener(OnCrystalChanged);
            }
        }

        private void Update()
        {
            _debouncer.Tick(Time.deltaTime);
        }

        private void OnDisable()
        {
            foreach (var slot in slots)
            {
                slot.OnFigureChanged.RemoveListener(OnCrystalChanged);
            }
        }
        
        private void OnCrystalChanged()
        {
            if (_puzzleSolved) return;
            _audioSource.PlayOneShot(audioSourceChanged);
            _debouncer.Trigger(CheckCombination);
        }

        private void CheckCombination()
        {
            if (_puzzleSolved) return;

            if (slots.Where((t, i) => t.CurrentFigure != correctCombination[i]).Any())
            {
                return;
            }

            _puzzleSolved = true;
            foreach (var crystalSlot in slots)
            {
                crystalSlot.Solve();
            }
            onPuzzleSolved?.Invoke();
            _audioSource.PlayOneShot(audioSourceSolved);
        }
    }

}