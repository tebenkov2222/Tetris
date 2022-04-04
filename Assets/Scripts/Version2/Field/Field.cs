using System;
using System.Collections.Generic;
using UnityEngine;
using Version2.Shape;
using Version2.Shared;

namespace Version2.Field
{
    public class Position
    {
        public int X;
        public int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public class Beaker
    {
        public event ReturnVoid OnShapeInstantiate;
        public List<List<bool>> Field
        {
            get;
            private set;
        }
        public IShape Shape;
        private Position _pos;

        public Position Pos => _pos;

        public Operation Operation;

        public Beaker()
        {
            Field = new List<List<bool>>();
            Initialization();
            Operation = new Operation();
        }

        private void Initialization()
        {
            for (var i = 0; i < 20; i++)
            {
                Field.Add(new List<bool>());
                for (var j = 0; j < 10; j++)
                    Field[i].Add(false);
            }
        }

        public void Visualisation()
        {
            foreach (var i in Field)
            {
                foreach (var j in i)
                    Console.Write(j ? 1 + " ": 0 + " ");
                Console.WriteLine();
            }
        }

        public void PutShape(int x, int y)
        {
            for (int i = 0, i1 = y; i < Shape.Image.Count; i++,i1++)
            {
                for (int j = 0, j1 = x; j < Shape.Image[i].Count; j++, j1++)
                    Field[i1][j1] = Field[i1][j1] ? Switch(Shape.Image[i][j]) : Shape.Image[i][j];
            }
            _pos = new Position(x, y);
        }
        public void MoveShape(int x, int y)
        {
            PutShape(_pos.X, _pos.Y);
            _pos.X += x;
            _pos.Y += y;
            PutShape(_pos.X, _pos.Y);
        }

        private bool Switch(bool value) => !value;
    
        public void InstShape()
        {
            Shape = Operation.RandomShape();
            PutShape(4,0);
            OnShapeInstantiate?.Invoke();
        }
    
    

        public void Down()
        {
        
        
        
        }
    
    
    }
}