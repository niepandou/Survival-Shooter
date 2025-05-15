using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/TransEventSO")]
public class TransEventSO : ScriptableObject
{
    public UnityAction<Vector3,float> onEventRaised;

    public void OnRaisedEvent(Vector3 position,float damage)
    {
        onEventRaised.Invoke(position,damage);
    }
}
