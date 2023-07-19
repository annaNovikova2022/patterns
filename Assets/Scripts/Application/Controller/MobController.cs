using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    private MobView _mobView;

    public MobController(MobView mobView)
    {
        _mobView = mobView;
    }
    public int GetCoins()
    {
        return _mobView._currentCoins;
    }

}
