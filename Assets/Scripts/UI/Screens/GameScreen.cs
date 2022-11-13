using Gameplay.Tower_base_;
using UI.Bars;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ScreensGeneration.Screens
{
    public class GameScreen : BaseScreen
    {
        [SerializeField] private GameObject attackTab;
        [SerializeField] private GameObject protectedTab;
        [SerializeField] private GameObject experienceTab;
        [SerializeField] private Button attackTabButton;
        [SerializeField] private Button protectedTabButton;
        [SerializeField] private Button experienceTabButton;

        [SerializeField] private HealthBar healthBar;

        private TowerHealth towerHealth;
        private GameObject[] tabs;

        public void Setup(TowerHealth towerHealth)
        {
            this.towerHealth = towerHealth;

            towerHealth.MaxHealthBarChanged += ChangedMaxHealthBar;
            towerHealth.CurrentHealthBarChanged += ChangedCurrentHealthBar;
        }

        public void UpdatedHealthValue()
        {
            healthBar.TextHealthValue.SetText($"{towerHealth.Max}/{towerHealth.Current}");
        }

        private void Awake()
        {
            tabs = new GameObject[]
            {
                attackTab,
                protectedTab,
                experienceTab,
            };
        }

        private void OnEnable()
        {
            attackTabButton.onClick.AddListener(AttackTabButtonOnClick);
            protectedTabButton.onClick.AddListener(ProtectedTabButtonOnClick);
            experienceTabButton.onClick.AddListener(ExperienceTabButtonOnClick);
        }

        private void OnDisable()
        {
            if (towerHealth != null)
            {
                towerHealth.MaxHealthBarChanged -= ChangedMaxHealthBar;
                towerHealth.CurrentHealthBarChanged -= ChangedCurrentHealthBar;
            }
        }

        private void AttackTabButtonOnClick()
        {
            HideAllTabs();
            attackTab.SetActive(true);
        }

        private void ProtectedTabButtonOnClick()
        {
            HideAllTabs();
            protectedTab.SetActive(true);
        }

        private void ExperienceTabButtonOnClick()
        {
            HideAllTabs();
            experienceTab.SetActive(true);
        }

        private void ChangedMaxHealthBar()
        {
            healthBar.SetMaxHealth(towerHealth.Max);
        }

        private void ChangedCurrentHealthBar()
        {
            UpdatedHealthValue();
            healthBar.SetHealth(towerHealth.Current);
        }

        private void HideAllTabs()
        {
            foreach (var tab in tabs)
            {
                tab.SetActive(false);
            }
        }
    }
}