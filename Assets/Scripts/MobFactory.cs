using UnityEngine;

namespace DefaultNamespace
{
    public class MobFactory
    {
        private ModelMob _loadMobs;
        private ViewMob _viewMob;
        private ModelMob _initMobs;
        
        public MobFactory(/*ModelMob modelMob*/)
        {
            _loadMobs = Resources.Load<ModelMob>("Mob");
            
        }

        public ControllerMob Create()
        {
            int randPoint = Random.Range(-50, 50);
            int randEnemy = Random.Range(-50, 50);
            Vector3 ransV = new Vector3(randPoint,1 , randEnemy);
            _initMobs = MonoBehaviour.Instantiate(_loadMobs, ransV, Quaternion.identity);
            _viewMob = new ViewMob();
            _viewMob.Mob = _initMobs.gameObject;
            
            var mob = new ControllerMob(_initMobs,_viewMob);
            return mob;
        }
    }
}