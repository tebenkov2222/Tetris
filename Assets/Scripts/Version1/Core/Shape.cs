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
        public static Shape Z = new Shape()
        {
            Image = new List<List<byte>>()
            {
                new List<byte>() {1, 1, 0},
                new List<byte>() {0, 1, 1}
            },
            Color = Color.green
        };
        public static Shape S = new Shape()
        {
            Image = new List<List<byte>>()
            {
                new List<byte>() {0, 1, 1},
                new List<byte>() {1, 1, 0}
            },
            Color = Color.blue
        };
        public static Shape O = new Shape()
        {
            Image = new List<List<byte>>()
            {
                new List<byte>() {1, 1},
                new List<byte>() {1, 1}
            },
            Color = Color.yellow
        };
        public static Shape J = new Shape()
        {
            Image = new List<List<byte>>()
            {
                new List<byte>() {1, 0, 0},
                new List<byte>() {1, 1, 1}
            },
            Color = Color.cyan
        };
        public static Shape L = new Shape()
        {
            Image = new List<List<byte>>()
            {
                new List<byte>() {1, 1, 1},
                new List<byte>() {1, 0, 0}
            },
            Color = Color.magenta
        };
    }
}

