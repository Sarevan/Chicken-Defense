using UnityEngine;
using Zenject;

namespace Configs
{
   [CreateAssetMenu(fileName = nameof(AllConfigs),menuName = "Configs/" + nameof(AllConfigs), order = 0)]
   public class AllConfigs : ScriptableObject
   {
      private LevelsConfig levelsConfig;

      [Inject]
      public void Setup(LevelsConfig levelsConfig)
      {
         this.levelsConfig = levelsConfig;
      }
      public LevelsConfig LevelsConfig => levelsConfig;
   }
}
