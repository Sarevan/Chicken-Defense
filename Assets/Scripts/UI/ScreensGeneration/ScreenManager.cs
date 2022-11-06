using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.ScreensGeneration
{
    public class ScreenManager : SingletonBehaviour<ScreenManager>
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private BaseScreen[] screens;
        [SerializeField] private BasePopup[] popups;

        private List<BaseScreen> cashesScreens = new List<BaseScreen>();
        private List<BasePopup> cashesPopups = new List<BasePopup>();

        public TScreen ShowScreen<TScreen>() where TScreen : BaseScreen
        {
            foreach (var casheSceen in cashesScreens)
            {
                casheSceen.gameObject.SetActive(false);
            }

            BaseScreen screenFounded = cashesScreens.FirstOrDefault(screen => screen is TScreen);

            if (screenFounded == null)
            {
                var screenPrefab = screens.First(screen => screen is TScreen);
                screenFounded = Instantiate(screenPrefab, canvas.transform);
                cashesScreens.Add(screenFounded);
            }

            return (TScreen) screenFounded;
        }
        
        public TPopup ShowPopup<TPopup>() where TPopup : BasePopup
        {
            foreach (var cashePopup in cashesPopups)
            {
                cashePopup.gameObject.SetActive(false);
            }

            BasePopup screenFounded = cashesPopups.FirstOrDefault(popup => popup is TPopup);

            if (screenFounded == null)
            {
                var popupPrefab = popups.First(screen => screen is TPopup);
                screenFounded = Instantiate(popupPrefab, canvas.transform);
                cashesPopups.Add(screenFounded);
            }

            return (TPopup) screenFounded;
        }
    }
}