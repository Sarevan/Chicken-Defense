using Configs;
using UnityEngine;
using Zenject;

namespace Core.Zenject.ProjectContext
{
    public class BootstrapInstaller : MonoInstaller // Here official services registration 
    {
        [SerializeField]
        [InjectOptional]
        private LevelsConfig levelsConfig;

        [SerializeField]
        [InjectOptional]
        private LevelConfigInfo[] levelConfigInfo;
        public override void InstallBindings()
        {
            if (levelConfigInfo == null && levelsConfig == null)
            {
                Debug.LogWarning("No config");
                return;
            }
            Container.Bind(levelsConfig.GetType(), typeof(LevelsConfig)).FromInstance(levelsConfig);
            Container.Bind(levelConfigInfo.GetType(), typeof(LevelConfigInfo[])).FromInstance(levelConfigInfo);
        }
    }
}