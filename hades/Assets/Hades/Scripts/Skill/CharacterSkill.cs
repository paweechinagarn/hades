using UnityEngine;

namespace Hades
{
    public class CharacterSkill : MonoBehaviour
    {
        [SerializeField] private SkillEffect skillEffect;

        public void SetEffect(SkillEffect skillEffect)
        {
            this.skillEffect = skillEffect;
        }

        public void ApplyEffect(GameObject _, Damagable damagable)
        {
            if (skillEffect != null) StartCoroutine(skillEffect.Apply(damagable));
        }
    }
}