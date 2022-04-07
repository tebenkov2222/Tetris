using System.Collections.Generic;
using UnityEngine;

namespace Version1.Core
{
    public class ShapeBase
    {
        public List<List<byte>> Image;
        public Color Color;

        public static ShapeBase T = new ShapeBase()
        {
            Image = new List<List<byte>>()
            {
                new List<byte>() {1, 1, 1},
                new List<byte>() {0, 1, 0}
            },
            Color = Color.red
        };
        public static ShapeBase I = new ShapeBase()
        {
            Image = new List<List<byte>>()
            {
                new List<byte>() {1, 1, 1, 1}
            },
            Color = Color.black
        };
        public static ShapeBase Z = new ShapeBase()
        {
            Image = new List<List<byte>>()
            {
                new List<byte>() {1, 1, 0},
                new List<byte>() {0, 1, 1}
            },
            Color = Color.green
        };
        public static ShapeBase S = new ShapeBase()
        {
            Image = new List<List<byte>>()
            {
                new List<byte>() {0, 1, 1},
                new List<byte>() {1, 1, 0}
            },
            Color = Color.blue
        };
        public static ShapeBase O = new ShapeBase()
        {
            Image = new List<List<byte>>()
            {
                new List<byte>() {1, 1},
                new List<byte>() {1, 1}
            },
            Color = Color.yellow
        };
        public static ShapeBase J = new ShapeBase()
        {
            Image = new List<List<byte>>()
            {
                new List<byte>() {1, 0, 0},
                new List<byte>() {1, 1, 1}
            },
            Color = Color.cyan
        };
        public static ShapeBase L = new ShapeBase()
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

