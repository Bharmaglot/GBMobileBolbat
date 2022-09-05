using UnityEngine;
using Tools;

namespace GBMobile
{
    public class BaseInputView : MonoBehaviour
    {
        private SubscriptionProperty<float> _diff;
        private float _speed;

        public virtual void Init(SubscriptionProperty<float> diff, float speed)
        {
            _diff = diff;
           _speed = speed;
        }

        protected virtual void OnLeftMove(float value)
        {
            _diff.Value = value;
        }

        protected virtual void OnRightMove(float value)
        {
            _diff.Value = value;
        }
    }
}