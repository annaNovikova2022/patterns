using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewMob : MonoBehaviour
{
    private GameObject _mob;
    public Text txtCoins;

    public GameObject Mob
    {
        get
        {
            return _mob;
        }
        set
        {
            _mob = value;
        }
    }

    private void Update()
    {
        
    }
}
