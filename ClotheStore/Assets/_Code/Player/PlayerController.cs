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
    [SerializeField] private IntValue _trunk;
    [SerializeField] private GameObject _inventory;
    [SerializeField] private GameObject _playerequip;
    private Rigidbody2D _rb;
    private Vector2 _movement;
    private Vector2 _lookDirection;
    private bool _isChopping = false;
    
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _inventory.SetActive(true);
        _playerequip.SetActive(true);
    }

    private void Start()
    {
        _inventory.SetActive(false);
        _playerequip.SetActive(false);
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
            CheckTree();
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isChopping = true;
            ShootRaycast();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            DisableTurckCollect();
        }
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            _inventory.SetActive(true);
            _playerequip.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.Tab))
        {
            _inventory.SetActive(false);
            _playerequip.SetActive(false);
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
                        if (_isChopping) InvokeRepeating("IncrementTrunk", 2f, 2f);
                    }
                    break;
                case "Axe":
                    hit.collider.gameObject.GetComponent<AxeInteraction>().BoughtAxe();
                    hit.collider.gameObject.SetActive(false);
                    break;
                case "Door":
                    hit.collider.gameObject.GetComponent<Door>().ChangeScene();
                    break;
                case "Shop":
                    hit.collider.gameObject.GetComponent<Shop>().Charge();
                    break;
                case "Clothes":
                    hit.collider.gameObject.GetComponent<Shop>().BuyClothes();
                    break;
            }
        }
    }

    void CheckTree()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _lookDirection, _rayLength, ~_ignoreLayers);
        if (hit.collider != null)
        {
            if (!hit.collider.CompareTag("Tree"))
            {
                DisableTurckCollect();
            }
        }
        if(hit.collider == null)
        {
            DisableTurckCollect();
        }
    }

    void DisableTurckCollect()
    {
        _isChoppingDown.RaiseEvent(false);
        _isChopping = false;
        CancelInvoke("IncrementTrunk");
    }
    
    void IncrementTrunk()
    {
        _trunk.value++;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)_lookDirection * _rayLength);
    }
}