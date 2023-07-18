using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MobEvent : MonoBehaviour
{
    public int _mobNum;
    private List<MobFactory> _mobFactory = new List<MobFactory>();
    void Start()
    {
        for (int i = 0; i < _mobNum; i++)
        {
            _mobFactory.Add(new MobFactory());
            _mobFactory[i].Create();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
