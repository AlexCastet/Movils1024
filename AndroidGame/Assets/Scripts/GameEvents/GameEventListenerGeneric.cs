// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener<T> : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public GameEvent<T> Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent<T> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(T parametre)
    {
        Response.Invoke(parametre);
    }
}





