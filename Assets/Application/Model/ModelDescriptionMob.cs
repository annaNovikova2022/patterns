using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelDescriptionMob : MonoBehaviour
{
    private int _maxCoins = 100;
    private int _maxHP = 100;

    public int MaxCoins
    {
        get => _maxCoins;
        set {_maxCoins = value;}
    }
    public int MaxHP
    {
        get => _maxHP;
        set {_maxHP = value;}
    }
}
