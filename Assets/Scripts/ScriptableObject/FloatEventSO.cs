using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/FloatEventSO")]
public class FloatEventSO : ScriptableObject
{
    public UnityAction<float> onEventRaised;

    public void onRaisedEvent(float score)
    {
        onEventRaised.Invoke(score);
    }
}
