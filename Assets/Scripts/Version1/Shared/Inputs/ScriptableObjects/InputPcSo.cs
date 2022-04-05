using UnityEngine;

namespace App.Scripts.Shared.Inputs.ScriptableObjects
{
    [CreateAssetMenu(fileName = "CharacterSetting", menuName = "ScriptableObjects/InputPC", order = 1)]
    public class InputPcSo : ScriptableObject
    {
        public KeyCode UpBtn;
        public KeyCode DownBtn;
        public KeyCode RightBtn;
        public KeyCode LeftBtn;
    }
}
