using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.GameUI.Shop
{
    public class ShopItem : MonoBehaviour
    {
        [field: SerializeField] public RectTransform RectTransform { get; private set; }
        [field: SerializeField] public string NameItem{ get; private set; }
        public int ItemIndex { get; private set; }
        private Vector2 _targetPosition;
        private float _targetScale;

        public void SetNewIndex(int index, Vector2 position, bool isCentral)
        {
            ItemIndex = index;
            _targetPosition = position;
            _targetScale = isCentral ? 1.3f : 1f;
            ApplyAnimations();
        }

        private void ApplyAnimations()
        {
            RectTransform.DOAnchorPos(_targetPosition, 1f)
                .OnComplete(() => { RectTransform.DOScale(_targetScale, 1f); }).SetEase(Ease.OutQuad);
        }
    }
}