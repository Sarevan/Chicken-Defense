using UnityEngine;
using UnityEngine.Serialization;

namespace Configs
{
   [CreateAssetMenu(fileName = nameof(AllConfigs),menuName = "Configs/" + nameof(AllConfigs), order = 0)]
   public class AllConfigs : ScriptableObject
   {
      [FormerlySerializedAs("levelConfig")]
      [SerializeField] private LevelsConfig levelsConfig;

      public LevelsConfig LevelsConfig => levelsConfig;
   }
}
