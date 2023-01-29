using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventDetails_SO", menuName = "SO/EventDetails")]
public class EventDetails_SO : ScriptableObject
{
    public List<GameEventDetails> gameEventDetails;
}

