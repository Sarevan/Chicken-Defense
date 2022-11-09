using Gameplay.Tower;
using UI.Bars;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ScreensGeneration.Screens
{
    public class GameScreen : BaseScreen
    {
        [SerializeField] private GameObject[] tabs;
        [SerializeField] private HealthBar healthBar;
        private TowerHealth towerHealth;

        public void Setup(TowerHealth towerHealth)
        {
            this.towerHealth = towerHealth;

            towerHealth.MaxHealthBarChanged += ChangedMaxHealthBar;
            towerHealth.CurrentHealthBarChanged += ChangedCurrentHealthBar;
        }

        private void OnDisable()
        {
            if (towerHealth != null)
            {
                towerHealth.MaxHealthBarChanged -= ChangedMaxHealthBar;
                towerHealth.CurrentHealthBarChanged -= ChangedCurrentHealthBar;
            }
        }

        private void ChangedMaxHealthBar()
        {
            healthBar.SetMaxHealth(towerHealth.Max);
        }

        private void ChangedCurrentHealthBar()
        {
            healthBar.SetHealth(towerHealth.Current);
        }

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