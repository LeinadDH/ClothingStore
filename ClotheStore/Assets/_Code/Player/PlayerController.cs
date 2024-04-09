using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;  
    [SerializeField] private float _rayLength = 2f;
    [SerializeField] private LayerMask _ignoreLayers;
    [SerializeField] private FloatEventChannelSO _horizontalInput;
    [SerializeField] private FloatEventChannelSO _verticalInput;
    [SerializeField] private FloatEventChannelSO _lastHorizontalInput;
    [SerializeField] private FloatEventChannelSO _lastVerticalInput;
    [SerializeField] private BoolEventChannelSO _isChoppingDown;
    [SerializeField] private BoolValue _canChoppingDown;
    private Rigidbody2D _rb;
    private Vector2 _movement;
    private Vector2 _lookDirection;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _horizontalInput.RaiseEvent(_movement.x);
        _verticalInput.RaiseEvent(_movement.y);
        if (_movement != Vector2.zero)
        {
            _lastHorizontalInput.RaiseEvent(_movement.x);
            _lastVerticalInput.RaiseEvent(_movement.y);
            _lookDirection = _movement.normalized;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootRaycast();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _isChoppingDown.RaiseEvent(false);
        }

        
    }
    
    void FixedUpdate()
    {
        _movement.Set(InputManagger.Movement.x, InputManagger.Movement.y); 
        _rb.velocity = _movement * _speed;
    }

    void ShootRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _lookDirection, _rayLength, ~_ignoreLayers);
        
        if (hit.collider != null)
        {
            switch (hit.collider.tag)
            {
                case "Tree":
                    if (_canChoppingDown.value)
                    {
                        _isChoppingDown.RaiseEvent(true);
                    }
                    break;
                case "Axe":
                    hit.collider.gameObject.SetActive(false);
                    break;
                case "Door":
                    hit.collider.gameObject.GetComponent<Door>().ChangeScene();
                    break;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)_lookDirection * _rayLength);
    }
}