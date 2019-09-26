using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManipulations.Task6
{
    public class UniqueShapeFinder
    {
        public byte[,] FindUniqueShapes(byte[,] arrayOfShapes)
        {
            if (arrayOfShapes is null)
            {
                throw new ArgumentNullException("Inpur array is null.", nameof(arrayOfShapes));
            }

            bool[,] marks = new bool[arrayOfShapes.GetUpperBound(0), arrayOfShapes.GetUpperBound(1)];

            for (int i = 0; i < marks.GetUpperBound(0); i++)
            {
                for (int j = 0; j < marks.GetUpperBound(1); i++)
                {
                    marks[i, j] = false;
                }
            }

            FindInDepth(0);
            void FindInDepth(byte start)
            {

            }
            //byte[,] source = arrayOfShapes;
            //Stack<int> path = new Stack<int>();
            // Dictionary<int, bool> marks = new Dictionary<int, bool>();

            //for (int i = 0; i < arrayOfShapes.GetUpperBound(0); i++)
            //{
            //    for (int j = 0; j < arrayOfShapes.GetUpperBound(1); i++)
            //    {
            //        marks.Add(arrayOfShapes[i, j], false);
            //    }
            //}

            //FindInDepth(0);
            //void FindInDepth(byte start)
            //{

            //   // marks[start] = true;
            //    path.Push(start);

            //    for (int i = 0; i < arrayOfShapes.GetUpperBound(0); i++)
            //    {
            //        for (int j = 0; j < arrayOfShapes.GetUpperBound(1); i++)
            //        {
            //            if (arrayOfShapes[i, j + 1] != 0)
            //            {
            //                if (marks[arrayOfShapes[i, j + 1]] == false)
            //                {
            //                    FindInDepth(arrayOfShapes[i, j + 1]);

            //                }
            //            }
            //        }
            //    }
            //}
            return new byte[0,0];
        }
    }
}
