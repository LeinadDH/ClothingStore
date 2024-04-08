using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObject/Events/Float Event Channel")]
public class FloatEventChannelSO : ScriptableObject
{
    public UnityAction<float> FloatEvent;

    public void RaiseEvent(float value)
    {
        FloatEvent?.Invoke(value);
    }
}
