using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using Tools;

namespace GBMobile
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _purchase;

        public void Init(UnityAction startGame, UnityAction onPurchase)
        {
            _startButton?.onClick.AddListener(startGame);
            _purchase?.onClick.AddListener(onPurchase);
        }

        private void OnDestroy()
        {
            _startButton.onClick.RemoveAllListeners();
        }
    }
}
