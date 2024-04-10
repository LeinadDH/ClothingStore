using UnityEngine;

public class AxeAnimator : MonoBehaviour
{
    [SerializeField] private FloatEventChannelSO _lastHorizontalInput;
    [SerializeField] private FloatEventChannelSO _lastVerticalInput;
    [SerializeField] private BoolEventChannelSO _isChoppingDown;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _lastHorizontalInput.FloatEvent += HandleLastHorizontalInput;
        _lastVerticalInput.FloatEvent += HandleLastVerticalInput;
        _isChoppingDown.BoolEvent += HandleIsChoppingDown;
    }
    
    private void OnDisable()
    {
        _lastHorizontalInput.FloatEvent -= HandleLastHorizontalInput;
        _lastVerticalInput.FloatEvent -= HandleLastVerticalInput;
        _isChoppingDown.BoolEvent -= HandleIsChoppingDown;
    }
    
    void HandleLastHorizontalInput(float value)
    {
        _animator.SetFloat("LastHorizontal", value);
    }
    
    void HandleLastVerticalInput(float value)
    {
        _animator.SetFloat("LastVertical", value);
    }
    
    void HandleIsChoppingDown(bool value)
    {
        _animator.SetBool("IsChoppingDown", value);
    }
}
