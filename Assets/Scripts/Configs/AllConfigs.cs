using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = nameof(AllConfigs), menuName = "Configs/" + nameof(AllConfigs), order = 0)]
    public class AllConfigs : ScriptableObject
    {
        [SerializeField] private LevelsConfig levelsConfig;

        public LevelsConfig LevelsConfig => levelsConfig;
    }
}