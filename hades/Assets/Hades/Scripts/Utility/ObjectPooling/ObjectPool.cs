using System;
using UnityEngine;

namespace Hades
{
    [Serializable]
    public class ObjectPool
    {
        public string Name;
        public GameObject Prefab;
        public int Amount;
    }
}
