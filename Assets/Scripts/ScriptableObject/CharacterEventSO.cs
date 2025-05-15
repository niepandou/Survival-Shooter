using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/CharacterEventSO")]
public class CharacterEventSO : ScriptableObject
{
    public UnityAction<Character> onEventRaised;

    public void onRaisedEvent(Character chara)
    {
        onEventRaised.Invoke(chara);
    }
}
