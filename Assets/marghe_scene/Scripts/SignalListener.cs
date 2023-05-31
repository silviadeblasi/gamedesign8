using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{
    public Signal signal;
    public UnityEvent signalEvent;

    public void OnSignalRaised() 
    {
        signalEvent.Invoke();
    }

    private void OnEnable() // Questa funzione aggiunge il listener alla lista di listeners
    {
        signal.RegisterListener(this);
    }

    private void OnDisable() // Questa funzione rimuove il listener dalla lista di listeners
    {
        signal.DeRegisterListener(this);
    }
}
