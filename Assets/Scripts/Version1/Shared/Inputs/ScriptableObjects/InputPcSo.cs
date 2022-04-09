using UnityEngine;

namespace Version1.Shared.Inputs.ScriptableObjects
{
    [CreateAssetMenu(fileName = "CharacterSetting", menuName = "ScriptableObjects/InputPC", order = 1)]
    public class InputPcSo : ScriptableObject
    {
        public KeyCode UpBtn = KeyCode.W;
        public KeyCode DownBtn = KeyCode.S;
        public KeyCode RightBtn = KeyCode.D;
        public KeyCode LeftBtn = KeyCode.A;
        public KeyCode SpaceBtn = KeyCode.Space;
    }
}
