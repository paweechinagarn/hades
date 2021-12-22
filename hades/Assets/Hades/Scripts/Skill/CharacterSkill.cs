using UnityEngine;

namespace Hades
{
    public class CharacterSkill : MonoBehaviour
    {
        [SerializeField] private Unit unit;
        [SerializeField] private SkillEffect skillEffect;

        public void SetEffect(SkillEffect skillEffect)
        {
            this.skillEffect = skillEffect;
        }

        public void ApplyEffect(GameObject _, Damagable damagable)
        {
            if (damagable == null || damagable.Unit == unit) return;
            if (skillEffect != null) StartCoroutine(skillEffect.Apply(damagable));
        }
    }
}