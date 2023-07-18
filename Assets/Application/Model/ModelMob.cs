using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ModelMob : MonoBehaviour
{
    private ModelDescriptionMob _charact;
    [SerializeField] private int _currentCoins; 
    private int _currentHP;
    
    public ModelDescriptionMob Charact => _charact;
    public int CurrentCoins => _currentCoins;
    public int CurrentHP => _currentHP;

    public ModelMob(ModelDescriptionMob charact)
    {
        _charact = charact;
        _currentHP = _charact.MaxHP;
        _currentCoins = Random.Range(0, 100);
    }

    
}
