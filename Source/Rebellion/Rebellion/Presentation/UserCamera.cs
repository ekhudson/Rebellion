using System;

using UnityEngine;

namespace Rebellion.Presentation
{
    public class UserCamera : MonoBehaviour
    {
        private Vector3 mStartPos = Vector3.zero;
        private Vector3 mStartRotation = Vector3.zero;
        private Vector3 mEndPos = Vector3.zero;
        private Vector3 mEndRotation = Vector3.zero;

        private Vector3 mPreviousMousePos = Vector3.zero;

        public float PanSpeed = 5f;
        public float PanDistance = 200f;
        public float OrbitSpeed = 0.5f;
        public float OrbitDistance = 1000f;
        public int MinFOV = 15;
        public int MaxFOV = 23;
        public float ZoomSpeed = 1f;
        public bool InvertZoom = true;

        private float mCurrentRelativePosition = 0f;
        private float mCurrentRelativeZoom = 1f;
        private static Camera sCamera = null;
        private Vector3 mStartingPosition = Vector3.zero;
        private Vector3 mCurrentPosition = Vector3.zero;
        private Vector3 mCurrentPositionOffset = Vector3.zero;

        public static Camera CurrentUserCamera
        {
            get
            {
                return sCamera;
            }
        }

        private void Start()
        {
            mCurrentPosition = transform.position;
            mStartPos = transform.position;
            mStartRotation = transform.localRotation.eulerAngles;
            mEndRotation = mStartRotation;
            mEndRotation.y *= -1;
            sCamera = GetComponent<Camera>();
        }

        public void Update()
        {
            mEndPos = mStartPos + (Vector3.right * OrbitDistance);

            if (Input.GetMouseButton(1))
            {
                float deltaX =  mPreviousMousePos.x - Input.mousePosition.x;
                deltaX *= OrbitSpeed;
                deltaX *= Time.deltaTime;

                if (InvertZoom)
                {
                    deltaX *= -1;
                }

                mCurrentRelativePosition = Mathf.Clamp(mCurrentRelativePosition + deltaX, 0f, 1f);
                mCurrentPosition = Vector3.Lerp(mStartPos, mEndPos, mCurrentRelativePosition);
                transform.rotation = Quaternion.Euler(Vector3.Lerp(mStartRotation, mEndRotation, mCurrentRelativePosition));
            }

            if (Input.GetMouseButton(2))
            {
                float panX = mPreviousMousePos.x - Input.mousePosition.x;
                panX *= PanSpeed;
                panX *= Time.deltaTime;

                mCurrentPositionOffset.x = Mathf.Clamp(mCurrentPositionOffset.x + panX, -PanDistance, PanDistance);
            }

            if (Input.mouseScrollDelta != Vector2.zero)
            {
                float zoomDelta = (Input.mouseScrollDelta.y * ZoomSpeed) * Time.deltaTime;
                mCurrentRelativeZoom = Mathf.Clamp(mCurrentRelativeZoom + zoomDelta, 0f, 1f);
                sCamera.fieldOfView = Mathf.Lerp(MinFOV, MaxFOV, mCurrentRelativeZoom);
            }

            transform.position = mCurrentPosition + mCurrentPositionOffset;

            mPreviousMousePos = Input.mousePosition;
        }
    }
}
