using System.Collections.Generic;
using UnityEngine;

namespace Version2.Shape
{

    public interface IShape
    {
        public List<List<bool>> Image { get; set; }
        public Color Color { get; }
    }

    abstract class Shape : IShape
    {
        protected Shape(List<List<bool>> image, Color color)
        {
            Color = color;
            Image = image;
        }

        public Color Color { get; }
        public List<List<bool>> Image { get; set; }
    }

    class I : Shape
    {
        public I() : base(new List<List<bool>>()
        {
            new List<bool>() {true, true, true, true}
        }, Color.cyan)
        {
        }
    }

    class J : Shape
    {
        public J() : base(new List<List<bool>>
        {
            new List<bool>() {true, false, false},
            new List<bool>() {true, true, true}
        }, Color.blue)
        {
        }

    }

    class L : Shape
    {
        public L() : base(new List<List<bool>>
        {
            new List<bool>() {true, true, true},
            new List<bool>() {true, false, false}
        }, Color.magenta)
        {
        }
    }

    class O : Shape
    {
        public O() : base(new List<List<bool>>
        {
            new List<bool>() {true, true},
            new List<bool>() {true, true}
        }, Color.yellow)
        {
        }
    }

    class S : Shape
    {
        public S() : base(new List<List<bool>>
        {
            new List<bool>() {false, true, true},
            new List<bool>() {true, true, false}
        }, Color.green)
        {
        }
    }

    class T : Shape
    {
        public T() : base(new List<List<bool>>
        {
            new List<bool>() {true, true, true},
            new List<bool>() {false, true, false}
        }, Color.gray)
        {
        }

    }

    class Z : Shape
    {
        public Z() : base(new List<List<bool>>
        {
            new List<bool>() {true, true, false},
            new List<bool>() {false, true, true}
        }, Color.red)
        {
        }
    }
}