using ModelReplacement;
using UnityEngine;

namespace ModelReplacement
{
    public class MRROBLOXEMPLOYEESUIT : BodyReplacementBase
    {
        protected override GameObject LoadAssetsAndReturnModel()
        {
            string model_name = "RobloxEmployeeSuit";
            return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
        }
    }
}