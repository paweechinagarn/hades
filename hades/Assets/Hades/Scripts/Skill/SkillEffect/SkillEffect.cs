using System.Collections;
using UnityEngine;

namespace Hades
{
    public abstract class SkillEffect : ScriptableObject
    {
        public abstract IEnumerator Apply(Damagable damagable);
    }
}
