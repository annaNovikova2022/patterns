using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobView : MonoBehaviour
{
    private GameObject _mob;
    public int _currentCoins; 

    public GameObject Mob
    {
        get => _mob;
        set { _mob = value; }
    }
    
    
}
