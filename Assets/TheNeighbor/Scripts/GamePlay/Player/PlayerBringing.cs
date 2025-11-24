using System.Collections.Generic;
using System.Linq;
using Trellcko.Gameplay.QuestLogic;
using UnityEngine;

namespace Trellcko.Gameplay.Player
{
    public partial class PlayerBringing : MonoBehaviour
    {
        [SerializeField] private List<ItemToBring> _itemsToBring;
        [SerializeField] private GameObject _go;

        [SerializeField] private Material _bringingMaterial;

        public void SetItem(QuestItem questItem)
        {
            if (questItem == QuestItem.None)
            {
                _go.gameObject.SetActive(false);
            }
            else
            {
                _go.gameObject.SetActive(true);
                Texture bringingMaterialMainTexture = _itemsToBring.First(x => x.Item == questItem).Sprite;
                _go.transform.localScale = new Vector3(bringingMaterialMainTexture.width/100f, bringingMaterialMainTexture.height/100f, 1);
                _bringingMaterial.mainTexture = bringingMaterialMainTexture;
            }
        }
    }
}