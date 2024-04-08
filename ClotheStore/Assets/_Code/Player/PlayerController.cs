using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;  
    [SerializeField] private FloatEventChannelSO _horizontalInput;
    [SerializeField] private FloatEventChannelSO _verticalInput;
    [SerializeField] private FloatEventChannelSO _speedValue;
    [SerializeField] private BoolEventChannelSO _isChoppingDown;
    private Rigidbody2D _rb;
    private Vector2 movement;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        _horizontalInput.RaiseEvent(movement.x);
        _verticalInput.RaiseEvent(movement.y);
        _speedValue.RaiseEvent(movement.sqrMagnitude);
        
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
        _rb.MovePosition(_rb.position + movement * _speed * Time.fixedDeltaTime);
    }
}
