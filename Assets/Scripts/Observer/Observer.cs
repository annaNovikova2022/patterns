using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour, IObserver
{
    private IObservable _observable;

    public Observer(IObservable observable)
    {
        _observable = observable;
        _observable.AddObserver(this);
    }
    public void Update()
    {
        Debug.Log("Connect observer ");
    }
}
