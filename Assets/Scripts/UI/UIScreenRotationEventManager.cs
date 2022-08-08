﻿/*
* Copyright (c) 2021 PlayEveryWare
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayEveryWare.EpicOnlineServices.Samples
{
    /// <summary>
    /// Class <c>UIScreenRotationEventManager</c> provides event callback functionality for screen rotation on mobile devices. 
    /// </summary>
    public class UIScreenRotationEventManager : MonoBehaviour
    {
        private static UIScreenRotationEventManager Instance;

        public static Action<DeviceOrientation> OnScreenRotatated;
        private DeviceOrientation orientation;

        private void Awake()
        {
            Instance = this;
            orientation = Input.deviceOrientation;
        }

        private void Update()
        {
            switch (Input.deviceOrientation)
            {
                case DeviceOrientation.Unknown:     // Ignore
                case DeviceOrientation.FaceUp:      // Ignore
                case DeviceOrientation.FaceDown:    // Ignore
                    break;
                default:
                    if (orientation != Input.deviceOrientation)
                    {
                        orientation = Input.deviceOrientation;
                        OnScreenRotatated?.Invoke(orientation);
                    }
                    break;
            }
        }
    }
}