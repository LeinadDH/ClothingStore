using UnityEngine;

public class AnimatorsController : MonoBehaviour
{
    [SerializeField] private FloatEventChannelSO _horizontalInput;
    [SerializeField] private FloatEventChannelSO _verticalInput;
    [SerializeField] private FloatEventChannelSO _speedValue;
    [SerializeField] private BoolEventChannelSO _isChoppingDown;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _horizontalInput.FloatEvent += HandleHorizontalInput;
        _verticalInput.FloatEvent += HandleVerticalInput;
        _speedValue.FloatEvent += HandleSpeedValue;
        _isChoppingDown.BoolEvent += isChoppingDown => _animator.SetBool("IsChoppingDown", isChoppingDown);
    }
    
    private void OnDisable()
    {
        _horizontalInput.FloatEvent -= HandleHorizontalInput;
        _verticalInput.FloatEvent -= HandleVerticalInput;
        _speedValue.FloatEvent -= HandleSpeedValue;
        _isChoppingDown.BoolEvent -= isChoppingDown => _animator.SetBool("IsChoppingDown", isChoppingDown);
    }
    
    void HandleHorizontalInput(float value)
    {
        _animator.SetFloat("Horizontal", value);
    }
    
    void HandleVerticalInput(float value)
    {
        _animator.SetFloat("Vertical", value);
    }
    
    void HandleSpeedValue(float value)
    {
        _animator.SetFloat("Speed", value);
    }
}
