using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMob : MonoBehaviour
{
    
    [SerializeField] private List<ModelMob> _listMob;
    
    private ModelMob _character;
    private ViewMob _charterView;

    public ControllerMob(ModelMob modelMob, ViewMob viewMob)
    {
        _character = modelMob;
        _charterView = viewMob;
    }
    public int GetCoins()
    {
        return _character.CurrentCoins;
    }
    
}
