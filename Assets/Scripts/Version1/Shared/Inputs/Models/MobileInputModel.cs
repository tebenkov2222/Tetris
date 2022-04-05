using UnityEngine;

namespace App.Scripts.Shared.Inputs.Models
{
    public class MobileInputModel
    {
        public Vector2 InputJoystick;
        public Vector2 CameraMove;
        public bool Run;
        public bool Jump;

        public bool SwitchWeapon
        {
            get
            {
                bool val = _switchWeapon;
                _switchWeapon = false;
                return val;
            }
            set
            {
                _switchWeapon = value;
            }
        }
        public bool Attack;
        private bool _equip;
        private bool _switchWeapon;
        public bool Equip
        {
            get
            {
                bool val = _equip;
                _equip = false;
                return val;
            }
            set
            {
                _equip = value;
            }
        }
    }

    public class trigger
    {
        private bool _value;
        public bool Value
        {
            get
            {
                Debug.Log($"Get {_value} " );
                var val = _value;
                _value = false;
                return val;
            }
            set
            {
                Debug.Log("SET");
                _value = value;
            }
        }
        public static implicit operator trigger(bool value)
        {
            return new trigger { Value = value };
        }
        public static explicit operator bool(trigger trigger)
        {
            return trigger.Value;
        }
        public static bool operator ==(trigger val, trigger val2)
        {
            return val.Value == val2.Value;
        }
        public static bool operator ==(trigger val, bool val2)
        {
            return val.Value == val2;
        }
        

        public static bool operator !=(trigger val, trigger val2)
        {
            return !(val == val2);
        }
        public static bool operator !=(trigger val, bool val2)
        {
            return !(val == val2);
        }

        public static bool operator >(trigger val, trigger val2)

        {
            return val == true && val2 == false;
        }

        public static bool operator <(trigger val, trigger val2)
        {
            return val == false && val2 == true;
        }
    }
}
