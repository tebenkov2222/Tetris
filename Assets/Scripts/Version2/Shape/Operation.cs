using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Version2.Shape
{

    public class Operation
    {
        public IShape RandomShape()
        {
            var value = Random.Range(1, 8);
            Debug.Log($"Shape inst {value}");
            return value switch
            {
                1 => RandomRotation(new I()),
                2 => RandomRotation(new J()),
                3 => RandomRotation(new L()),
                4 => RandomRotation(new O()),
                5 => RandomRotation(new S()),
                6 => RandomRotation(new T()),
                7 => RandomRotation(new Z()),
                _ => new I()
            };
        }

        private IShape RandomRotation(IShape shape)
        {
            var i = Random.Range(0, 4);
            while (i-- > 0)
                Rotation(shape);
            return shape;
        }

        public void Rotation(IShape shape)
        {
            var result = new List<List<bool>>();
            for (var j = shape.Image[0].Count - 1; j > -1; j--)
                result.Add(shape.Image.Select(t => t[j]).ToList());

            shape.Image = result;
        }
    }
}