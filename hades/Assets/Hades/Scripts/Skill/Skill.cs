using System;

namespace Hades
{
    [Serializable]
    public class Skill
    {
        public int Id;
        public ActionType ActionType;
        public SkillEffect SkillEffect;
    }
}