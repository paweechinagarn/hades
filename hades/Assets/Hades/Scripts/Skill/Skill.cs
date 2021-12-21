using System.Collections;
using System.Collections.Generic;
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
            StartCoroutine(skillEffect.Apply(damagable));
        }
    }
}