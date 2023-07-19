using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MobEvent : MonoBehaviour
{
    public MobModel MobModel = new MobModel();
    public int _mobNum;
    public GameObject _mobParent;
    private List<MobController> _mobList = new List<MobController>();
    void Start()
    {
        var factory = new MobFactory(this.MobModel);
        
        for (int i = 0; i < _mobNum; i++)
        {
            _mobList.Add(factory.Create(_mobParent));
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
