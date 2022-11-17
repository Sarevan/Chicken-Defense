using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Configs
{
    [CreateAssetMenu(fileName = nameof(LevelsConfig), menuName = "Configs/" + nameof(LevelsConfig), order = 0)]
    public class LevelsConfig : ScriptableObject
    {
       [SerializeField] private LevelConfigInfo[] levelsInfo;
       

        public IList<LevelConfigInfo> LevelsInfo => levelsInfo;
    }
}