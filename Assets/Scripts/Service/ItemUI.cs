using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Service
{
    public class ItemUI : MonoBehaviour
    {
        [SerializeField] private Image spriteImage;
        [SerializeField] private TextMeshProUGUI textItemAmount;

        public void Initialize(Sprite sprite, float amount)
        {
            spriteImage.sprite = sprite;
            Refresh(amount);
        }
        public void Refresh(float amount)
            => textItemAmount.text = amount.ToString(CultureInfo.InvariantCulture);

    }
}