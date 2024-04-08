using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObject/Events/Bool Event Channel")]
public class BoolEventChannelSO : ScriptableObject
{
    public UnityAction<bool> BoolEvent;

    public void RaiseEvent(bool value)
    {
        BoolEvent?.Invoke(value);
    }
}