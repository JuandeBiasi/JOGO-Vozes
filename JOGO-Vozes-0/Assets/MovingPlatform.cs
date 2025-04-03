using UnityEngine;
using UnityEngine.Serialization;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 2f;
    [SerializeField] private bool pingPong = true;
    [SerializeField] private Sprite disabledSprite;
    [SerializeField] private Sprite enabledSprite;
    [SerializeField] private SpriteRenderer enableSpriteRenderer;
    [SerializeField] private bool isMoving;

    private Vector3 _pointA;
    private Vector3 _currentTargetPosition;
    private void Start()
    {
        if (pointB == null)
        {
            Debug.LogError("MovingPlatform: Point B must be assigned.");
            enabled = false;
            return;
        }

        _pointA = transform.position;
        _currentTargetPosition = pointB.position;
        isMoving = false;
        enableSpriteRenderer.sprite = isMoving ? enabledSprite : disabledSprite;
    }

    private void Update()
    {
        if (isMoving)
        {
            MovePlatform();
        }
    }

    private void MovePlatform()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTargetPosition, speed * Time.deltaTime);

        if (!(Vector3.Distance(transform.position, _currentTargetPosition) <= 0.01f)) return;
        
        if (pingPong)
        {
            _currentTargetPosition = IsApproximately(_currentTargetPosition, _pointA)
                ? pointB.position
                : _pointA;
        }
        else
        {
            TeleportToStart();
        }
    }

    private void TeleportToStart()
    {
        transform.position = _pointA;
        _currentTargetPosition = pointB.position;
    }

    private static bool IsApproximately(Vector3 a, Vector3 b)
    {
        return Vector3.Distance(a, b) <= 0.01f;
    }

    public void StartMovement()
    {
        isMoving = true;
        enableSpriteRenderer.sprite = enabledSprite;
    }

    public void StopMovement()
    {
        isMoving = false;
        enableSpriteRenderer.sprite = disabledSprite;
    }

    private void OnDrawGizmosSelected()
    {
        if (pointB == null) return;
        
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, pointB.position);
    }
}