using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Configs
{
    [CreateAssetMenu(fileName = nameof(LevelsConfig),menuName = "Configs/" + nameof(LevelsConfig), order = 0)]
    public class LevelsConfig : ScriptableObject
    {
         private LevelConfigInfo[] levelsInfo;

         [Inject]
         public void Setup(LevelConfigInfo[] levelsInfo)
         {
             this.levelsInfo = levelsInfo;
         }
        public IList<LevelConfigInfo> LevelsInfo => levelsInfo;
    }
}