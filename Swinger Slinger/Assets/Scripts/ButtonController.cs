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

        public bool LeftMouseButtonHeldDown { get => leftMouseButtonHeldDown; set => leftMouseButtonHeldDown = value; }
        public bool LeftMouseButonPressed { get => leftMouseButonPressed; set => leftMouseButonPressed = value; }
        public bool LeftMouseButtonReleased { get => leftMouseButtonReleased; set => leftMouseButtonReleased = value; }
        public bool RightMouseButtonHeldDown { get => rightMouseButtonHeldDown; set => rightMouseButtonHeldDown = value; }
        public bool RightMouseButtonPressed { get => rightMouseButtonPressed; set => rightMouseButtonPressed = value; }
        public bool RightMouseButtonReleased { get => rightMouseButtonReleased; set => rightMouseButtonReleased = value; }

        protected void RegisterInput() {}
    }
}