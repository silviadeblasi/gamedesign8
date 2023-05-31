using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Signal : ScriptableObject 
{
    public List<SignalListener> listeners = new List<SignalListener>();

    public void Raise() // Questa funzione legge la lista dei listeners e li chiama
    {
        for(int i = listeners.Count -1; i >= 0; i--) 
        {
            listeners[i].OnSignalRaised();
        }
    }

    public void RegisterListener(SignalListener listener) // Questa funzione aggiunge il listener alla lista di listeners
    {
        listeners.Add(listener);
    }

    public void DeRegisterListener(SignalListener listener) // Questa funzione rimuove il listener dalla lista di listeners
    {
        listeners.Remove(listener);
    }
}
