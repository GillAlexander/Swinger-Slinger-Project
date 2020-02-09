using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jonathan
{
    public abstract class ButtonController : MonoBehaviour
    {
        private bool leftMouseButtonHeldDown = false;
        private bool leftMouseButonPressed = false;
        private bool leftMouseButtonReleased = false;
        private bool rightMouseButtonHeldDown = false;
        private bool rightMouseButtonPressed = false;
        private bool rightMouseButtonReleased = false;
        private bool forwardButtonHeldDown = false;
        private bool forwardButtonPressed = false;
        private bool forwardButtonReleased = false;
        private bool leftButtonHeldDown = false;
        private bool leftButtonPressed = false;
        private bool leftButtonReleased = false;
        private bool rightButtonHeldDown = false;
        private bool rightButtonPressed = false;
        private bool rightButtonReleased = false;
        private bool backwardButtonHeldDown = false;
        private bool backwardButtonPressed = false;
        private bool backwardButtonReleased = false;

        public bool LeftMouseButtonHeldDown { get => leftMouseButtonHeldDown; set => leftMouseButtonHeldDown = value; }
        public bool LeftMouseButonPressed { get => leftMouseButonPressed; set => leftMouseButonPressed = value; }
        public bool LeftMouseButtonReleased { get => leftMouseButtonReleased; set => leftMouseButtonReleased = value; }
        public bool RightMouseButtonHeldDown { get => rightMouseButtonHeldDown; set => rightMouseButtonHeldDown = value; }
        public bool RightMouseButtonPressed { get => rightMouseButtonPressed; set => rightMouseButtonPressed = value; }
        public bool RightMouseButtonReleased { get => rightMouseButtonReleased; set => rightMouseButtonReleased = value; }
        public bool ForwardButtonHeldDown { get => forwardButtonHeldDown; set => forwardButtonHeldDown = value; }
        public bool ForwardButtonPressed { get => forwardButtonPressed; set => forwardButtonPressed = value; }
        public bool ForwardButtonReleased { get => forwardButtonReleased; set => forwardButtonReleased = value; }
        public bool LeftButtonHeldDown { get => leftButtonHeldDown; set => leftButtonHeldDown = value; }
        public bool LeftButtonPressed { get => leftButtonPressed; set => leftButtonPressed = value; }
        public bool LeftButtonReleased { get => leftButtonReleased; set => leftButtonReleased = value; }
        public bool RightButtonHeldDown { get => rightButtonHeldDown; set => rightButtonHeldDown = value; }
        public bool RightButtonPressed { get => rightButtonPressed; set => rightButtonPressed = value; }
        public bool RightButtonReleased { get => rightButtonReleased; set => rightButtonReleased = value; }
        public bool BackwardButtonHeldDown{ get => backwardButtonHeldDown; set => backwardButtonHeldDown = value; }
        public bool BackwardButtonPressed{ get => backwardButtonPressed; set => backwardButtonPressed = value; }
        public bool BackwardButtonReleased{ get => backwardButtonReleased; set => backwardButtonReleased = value; }
    }
}