using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Sprite[] images;
    [SerializeField] private CharacterStats characterStats;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        characterStats.OnHealthChanged += UpdateHealthUI;
    }

    private void UpdateHealthUI(int current, int max)
    {
        Debug.Log($"health current: {current}, max: {max}");

        if (images == null || images.Length < 2)
            return;

        if (current <= 0)
        {
            _image.sprite = images[0];
            return;
        }

        var percent = (float)current / max;
        var segments = images.Length - 1;
        var index = Mathf.Clamp(Mathf.CeilToInt(percent * segments), 1, segments);

        _image.sprite = images[index];
    }
}