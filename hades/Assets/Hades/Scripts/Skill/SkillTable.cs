using UnityEngine;

namespace Hades
{
    [CreateAssetMenu(fileName = "SkillTable", menuName = "Hades/Skill/SkillTable")]
    public class SkillTable : ScriptableObject
    {
        public Skill[] Skills;
    }
}