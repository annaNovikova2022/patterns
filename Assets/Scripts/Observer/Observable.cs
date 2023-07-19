using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observable : MonoBehaviour, IObservable
{
    private List<IObserver> _observers;

    public Observable()
    {
        _observers = new List<IObserver>();
    }
    
    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update();
        }
    }

    private void Start()
    {
        var observ = new Observable();
        Observer go = new Observer(observ);
        observ.NotifyObservers();
    }
}
