using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Hades
{
    public class SkillManager : MonoBehaviour
    {
        [SerializeField] private SkillTable skillTable;
        [SerializeField] private CharacterSkill meleeSkill;
        [SerializeField] private CharacterSkill rangeSkill;
        [SerializeField] private CharacterSkill dashSkill;
        [SerializeField] private int maxSkillCount;

        public UnityEvent MaxSkillSelectedEvent;

        private readonly Dictionary<int, Skill> skillDict = new Dictionary<int, Skill>();
        private readonly List<Skill> selectedSkills = new List<Skill>();

        private void Awake()
        {
            ExtractData();
        }

        public void SelectSkill(int id)
        {
            if (!skillDict.ContainsKey(id)) return;

            Debug.Log($"Select skill id: {id}");
            selectedSkills.Add(skillDict[id]);

            if (selectedSkills.Count >= maxSkillCount)
            {
                Debug.Log($"Max skill selected reach [{maxSkillCount}]");
                MaxSkillSelectedEvent?.Invoke();
            }
        }

        public void SetSkill()
        {
            for (int i = 0; i < selectedSkills.Count; i++)
            {
                Skill skill = selectedSkills[i];
                switch (skill.ActionType)
                {
                    case ActionType.None:
                        break;
                    case ActionType.Melee:
                        meleeSkill.SetEffect(skill.SkillEffect);
                        break;
                    case ActionType.Range:
                        rangeSkill.SetEffect(skill.SkillEffect);
                        break;
                    case ActionType.Dash:
                        dashSkill.SetEffect(skill.SkillEffect);
                        break;
                }
            }
        }

        private void ExtractData()
        {
            Skill[] skills = skillTable.Skills;

            for (int i = 0; i < skills.Length; i++)
            {
                Skill skill = skills[i];
                skillDict[skill.Id] = skill;
            }
        }
    }
}
