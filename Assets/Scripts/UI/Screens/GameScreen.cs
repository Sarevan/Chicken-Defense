using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.ScreensGeneration.Screens
{
    public class GameScreen : BaseScreen
    {
        [SerializeField] private GameObject[] tabs;
        
        public void OnTabSwitch(GameObject tab)
        {
            tab.SetActive(true);
            for (int number = 0; number < tabs.Length; number++)
            {
                if (tabs[number] != tab)
                {
                    tabs[number].SetActive(false);
                }
            }
        }
    }
}