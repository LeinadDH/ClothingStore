using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;  
    [SerializeField] private FloatEventChannelSO _horizontalInput;
    [SerializeField] private FloatEventChannelSO _verticalInput;
    [SerializeField] private BoolEventChannelSO _isChoppingDown;
    private Rigidbody2D _rb;
    private Vector2 _movement;
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _horizontalInput.RaiseEvent(_movement.x);
        _verticalInput.RaiseEvent(_movement.y);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isChoppingDown.RaiseEvent(true);
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
}
