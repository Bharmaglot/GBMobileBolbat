using JoostenProductions;
using Tools;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


namespace GBMobile
{
    public class InputJoystickView : BaseInputView
    {
        public override void Init(SubscriptionProperty<float> diff, float speed)
        {
            base.Init(diff, speed);
            UpdateManager.SubscribeToUpdate(Move);
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
        }

        private void Move()
        {
            float moveStep = 10 * Time.deltaTime * CrossPlatformInputManager.GetAxis("Horizontal");
            if (moveStep > 0)
                OnRightMove(moveStep);
            else if (moveStep < 0)
                OnLeftMove(moveStep);
        }
    }
}