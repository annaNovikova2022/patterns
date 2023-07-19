using UnityEngine;

namespace DefaultNamespace
{
    public class MobFactory
    {
        private MobModel _mobModel;
        private MobView _mobView;

        public MobFactory(MobModel modelMob)
        {
            _mobModel = modelMob;
            _mobView = Resources.Load<MobView>("Mob");
        }

        public MobController Create(GameObject mobParent)
        {
            int randX = Random.Range(-50, 50);
            int randZ = Random.Range(-50, 50);
            Vector3 randXZ = new Vector3(randX,1 , randZ);
            var mobGameObject = MonoBehaviour.Instantiate(_mobView, randXZ, Quaternion.identity);
            mobGameObject.transform.SetParent(mobParent.transform, false);
            
            _mobView._currentCoins = Random.Range(0, _mobModel._maxCoins);

            var mob = new MobController(_mobView);
            return mob;
        }
    }
}