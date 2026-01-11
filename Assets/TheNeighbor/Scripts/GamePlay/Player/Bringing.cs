using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using Trellcko.Gameplay.QuestLogic;
using UnityEngine;

namespace Trellcko.Gameplay.Player
{
    public partial class Bringing : MonoBehaviour
    {
        [SerializeField] private List<ItemToBring> _itemsToBring;
        [SerializeField] private GameObject _go;

        [SerializeField] private Material _bringingMaterial;

        [SerializeField] private QuestItem _testItem;

        [Button]
        private void Test()
        {
            SetItem(_testItem);
        }
        
        public void SetItem(QuestItem questItem)
        {
            if (questItem == QuestItem.None)
            {
                _go.gameObject.SetActive(false);
            }
            else
            {
                _go.gameObject.SetActive(true);
                ItemToBring itemToBring = _itemsToBring.First(x => x.Item == questItem);
                Texture bringingMaterialMainTexture = itemToBring.Sprite;
                _go.transform.localScale = new Vector3(bringingMaterialMainTexture.width/100f, bringingMaterialMainTexture.height/100f, 1);
                _bringingMaterial.mainTexture = bringingMaterialMainTexture;
                _go.transform.localPosition = itemToBring.Offset;

            }
        }
    }
}