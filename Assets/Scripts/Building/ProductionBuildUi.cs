using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Building
{
    public class ProductionBuildUi : MonoBehaviour
    {
        [SerializeField] private Image counterImage;
        [SerializeField] private Image spriteItem;
        [SerializeField] private TextMeshProUGUI countItemText;
        [SerializeField] private TextMeshProUGUI nameItemText;

        private float stepToFill = -1f;

        public void Initialize(int timeToGeneration, Sprite sprite, string nameItem)
        {
            spriteItem.sprite = sprite;
            stepToFill = 1f / timeToGeneration;
            nameItemText.text = nameItem;
            FillImage(0);
            FillCount(0);
        }

        public void Refresh(float fill, float itemCount)
        {
            if (counterImage.fillAmount > 1)
            {
                counterImage.fillAmount = 0;
            }
            FillImage(fill);
            FillCount(itemCount);
        }

        private void FillImage(float fill)
        {
            counterImage.fillAmount = fill * stepToFill;
        }
        private void FillCount(float count)
        {
            countItemText.text = $"{count}";
        }
    }
}