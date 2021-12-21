using UnityEngine;

namespace Hades
{
    public class Skill : MonoBehaviour
    {
        [SerializeField] private SkillEffect skillEffect;

        public void SetEffect()
        {

        }

        public void ApplyEffect(GameObject _, Damagable damagable)
        {
            if (skillEffect != null) StartCoroutine(skillEffect.Apply(damagable));
        }
    }
}