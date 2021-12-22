using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Hades
{
    [Serializable]
    public class SelectSkillEvent : UnityEvent<int> { }

    public class SelectSkillUI : MonoBehaviour
    {
        [SerializeField] private Button[] skillButtons;

        public SelectSkillEvent SelectSkillEvent;
        public UnityEvent StartGameEvent;

        public void SelectSkill(int id)
        {
            SelectSkillEvent?.Invoke(id);
        }

        public void DisableAll()
        {
            for (int i = 0; i < skillButtons.Length; i++)
            {
                Button skillButton = skillButtons[i];
                skillButton.interactable = false;
            }
        }

        public void StartGame()
        {
            gameObject.SetActive(false);
            StartGameEvent?.Invoke();
        }
    }
}
