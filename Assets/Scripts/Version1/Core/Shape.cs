using System.Collections.Generic;
using UnityEngine;

namespace Version1
{
    public class Shape
    {
        public List<List<byte>> Image;
        public Color Color;

        public static Shape T = new Shape()
        {
            Image = new List<List<byte>>()
            {
                new List<byte>() {1, 1, 1},
                new List<byte>() {0, 1, 0}
            },
            Color = Color.red
        };
        public static Shape I = new Shape()
        {
            Image = new List<List<byte>>()
            {
                new List<byte>() {1, 1, 1, 1}
            },
            Color = Color.black
        };
    }
}

