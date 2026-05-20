using UnityEngine;

namespace HYG.Manager.Base
{
    public interface IMasterManager
    {
        Behaviour GetBehaviour();
        GameObject GetObject();
    }

    public abstract class MasterManager : MonoBehaviour, IMasterManager
    {
        public Behaviour GetBehaviour() { return this; }

        public GameObject GetObject() { return gameObject; }
    }
}
