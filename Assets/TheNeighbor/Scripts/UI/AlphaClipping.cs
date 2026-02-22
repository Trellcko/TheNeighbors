using UnityEngine;
using UnityEngine.UI;

namespace Trellcko.UI
{
    public class AlphaClwipping : MonoBehaviour
    {
        private void Start()
        {
            Material material = GetComponent<Image>().material;
            material.SetFloat("_AlphaClip", 1);
            material.SetFloat("_Cutoff", 0.5f);
            material.EnableKeyword("_ALPHATEST_ON");
        }
    }
}