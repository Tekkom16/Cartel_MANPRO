namespace GoogleARCore.Examples.AugmentedImage
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using GoogleARCore;
    using GoogleARCoreInternal;
    using UnityEngine;
    using UnityEngine.UI;


    public class AugmentedImageVisualizer : MonoBehaviour
    {
        public AugmentedImage Image;
        public GameObject FrameLowerLeft;
        public GameObject FrameLowerRight;
        public GameObject FrameUpperLeft;
        public GameObject FrameUpperRight;
        public GameObject Cylinder;

        public Text Console;


        private void Start()
        {
            FrameLowerLeft.SetActive(false);
            FrameLowerRight.SetActive(false);
            FrameUpperLeft.SetActive(false);
            FrameUpperRight.SetActive(false);
            Cylinder.SetActive(false);
            Console = GameObject.Find("TextConsole").GetComponent<Text>();
            if (GameObject.FindGameObjectWithTag("Player")){
                Destroy(GameObject.FindGameObjectWithTag("Player").gameObject);
            }
            this.gameObject.tag = "Player";
        }

        public void Update()
        {
            if (Image == null || Image.TrackingState != TrackingState.Tracking)
            {
                FrameLowerLeft.SetActive(false);
                FrameLowerRight.SetActive(false);
                FrameUpperLeft.SetActive(false);
                FrameUpperRight.SetActive(false);
                Cylinder.SetActive(false);
                return;
            }



            if (Image != null && Console != null)
            {
                if (Image.TrackingState == TrackingState.Tracking)
                {
                    Console.text = "Tracking";
                }
                else if (Image.TrackingState == TrackingState.Paused)
                {
                    Console.text = "Paused";
                }
                else if (Image.TrackingState == TrackingState.Stopped)
                {
                    Console.text = "Stopped";
                }
            }

            float halfWidth = Image.ExtentX / 2;
            float halfHeight = Image.ExtentZ / 2;
            FrameLowerLeft.transform.localPosition = (halfWidth * Vector3.left) + (halfHeight * Vector3.back);
            FrameLowerRight.transform.localPosition = (halfWidth * Vector3.right) + (halfHeight * Vector3.back);
            FrameUpperLeft.transform.localPosition = (halfWidth * Vector3.left) + (halfHeight * Vector3.forward);
            FrameUpperRight.transform.localPosition = (halfWidth * Vector3.right) + (halfHeight * Vector3.forward);

            if (Image.DatabaseIndex == 0)
            {
                FrameLowerLeft.SetActive(true);
                FrameLowerRight.SetActive(true);
                FrameUpperLeft.SetActive(false);
                FrameUpperRight.SetActive(false);
                Cylinder.SetActive(false);
            }
            else if (Image.DatabaseIndex == 1)
            {
                FrameLowerLeft.SetActive(false);
                FrameLowerRight.SetActive(false);
                FrameUpperLeft.SetActive(true);
                FrameUpperRight.SetActive(true);
                Cylinder.SetActive(false);
            }
            else
            {
                FrameLowerLeft.SetActive(false);
                FrameLowerRight.SetActive(false);
                FrameUpperLeft.SetActive(false);
                FrameUpperRight.SetActive(false);
                Cylinder.SetActive(true);
                Cylinder.GetComponent<Canvas>().worldCamera = Camera.main;
            }
        }
    }
}
