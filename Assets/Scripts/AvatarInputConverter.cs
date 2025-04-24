using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

namespace VertextFormCore
{
    public class AvatarInputConverter : MonoBehaviour
    {
        //Avatar Transforms
        public Transform MainAvatarTransform;
        public Transform AvatarHead;
        public Transform AvatarBody;

        public Transform AvatarHand_Left;
        public Transform AvatarHand_Right;

        //XRRig Transforms
        public Transform XRHead;

        public Transform XRHandController_Left;
        public Transform XRHandController_Right;
        public Vector3 headPositionOffset;
        public Vector3 rightHandRotationOffset;
        public Vector3 leftHandRotationOffset;
        public List<GameObject> handControllerModels;
        public List<GameObject> hand;
        public XRInputModalityManager XRIMM;
        void Start()
        {
            HandAndControllerSync();
        }
        private void HandAndControllerSync()
        {
            XRIMM.trackedHandModeStarted.AddListener(OnTrackedHandModeStarted);
            XRIMM.trackedHandModeEnded.AddListener(OnTrackedHandModeEnded);
            XRIMM.motionControllerModeStarted.AddListener(OnMotionControllerModeStarted);
            XRIMM.motionControllerModeEnded.AddListener(OnMotionControllerModeEnded);
        }


        private void OnMotionControllerModeStarted()
        {
            Debug.Log("Hand Controller Modfe Started");
            foreach (GameObject handController in handControllerModels)
            {
                handController.SetActive(true);
            }
            foreach (GameObject hand in hand)
            {
                hand.SetActive(false);
            }
        }
        private void OnMotionControllerModeEnded()
        {

        }

        private void OnTrackedHandModeEnded()
        {

        }

        private void OnTrackedHandModeStarted()
        {
            Debug.Log("Hand Modfe Started");
            foreach (GameObject handController in handControllerModels)
            {
                handController.SetActive(false);
            }
            foreach (GameObject hand in hand)
            {
                hand.SetActive(true);
            }
        }

        // Update is called once per frame
        void Update()
        {
            //Head and Body synch
            //MainAvatarTransform.position = Vector3.Lerp(MainAvatarTransform.position, XRHead.position + headPositionOffset, 0.5f);
            //AvatarHead.rotation = Quaternion.Lerp(AvatarHead.rotation, XRHead.rotation, 0.5f);
            //AvatarBody.rotation = Quaternion.Lerp(AvatarBody.rotation, Quaternion.Euler(new Vector3(0, AvatarHead.rotation.eulerAngles.y, 0)), 0.05f);

            //Hands synch
            if (XRHandController_Right != null)
            {
                AvatarHand_Right.position = Vector3.Lerp(AvatarHand_Right.position, XRHandController_Right.position, 0.5f);
                AvatarHand_Right.rotation = Quaternion.Lerp(AvatarHand_Right.rotation, XRHandController_Right.rotation, 0.5f) * Quaternion.Euler(rightHandRotationOffset);
            }

            if (XRHandController_Left != null)
            {
                AvatarHand_Left.position = Vector3.Lerp(AvatarHand_Left.position, XRHandController_Left.position, 0.5f);
                AvatarHand_Left.rotation = Quaternion.Lerp(AvatarHand_Left.rotation, XRHandController_Left.rotation, 0.5f) * Quaternion.Euler(leftHandRotationOffset);
            }
        }

        public void EnableControllerHands()
        {
            if (XRHandController_Right != null)
            {
                XRHandController_Right.gameObject.SetActive(true);
            }
            if (XRHandController_Left != null)
            {
                XRHandController_Left.gameObject.SetActive(true);
            }
        }

        public void DisableControllerHands()
        {
            if (XRHandController_Right != null)
            {
                XRHandController_Right.gameObject.SetActive(false);
            }
            if (XRHandController_Left != null)
            {
                XRHandController_Left.gameObject.SetActive(false);
            }
        }
    }
}