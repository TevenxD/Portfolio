using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlidePuzzle
{
    class Arrays
    {
        public static int[,] GetArray()
        {
            Random random = new Random();

            switch (random.Next(1, 12))
            {
                case 1:
                    return new int[,]
                    {
                        {1,2,3,14},
                        {5,12,10,7},
                        {13,11,6,8},
                        {4,9,15,16},
                    };
                case 2:
                    return new int[,]
                    {
                        {2,6,3,12},
                        {11,14,9,4},
                        {13,1,5,7},
                        {8,16,10,15},
                    };
                case 3:
                    return new int[,]
                    {
                        {7,6,2,4},
                        {3,9,1,12},
                        {11,14,5,10},
                        {13,16,15,8},
                    };
                case 4:
                    return new int[,]
                    {
                        {2,5,3,4},
                        {1,13,6,15},
                        {10,9,7,8},
                        {11,16,14,12},
                    };
                case 5:
                    return new int[,]
                    {
                        {5,14,15,11},
                        {6,16,12,4},
                        {1,2,8,13},
                        {9,10,3,7},
                    };
                case 6:
                    return new int[,]
                    {
                        {1,15,6,7},
                        {4,16,10,8},
                        {9,2,11,3},
                        {13,5,12,14},
                    };
                case 7:
                    return new int[,]
                    {
                        {1,2,3,4},
                        {5,12,14,6},
                        {13,9,11,8},
                        {10,16,15,7},
                    };
                case 8:
                    return new int[,]
                    {
                        {2,6,7,15},
                        {15,16,8,5},
                        {9,4,1,11},
                        {10,14,13,3},
                    };
                case 9:
                    return new int[,]
                    {
                        {6,5,2,7},
                        {1,3,15,16},
                        {10,8,9,12},
                        {4,11,13,14},
                    };
                case 10:
                    return new int[,]
                    {
                        {15,12,1,3},
                        {8,16,7,10},
                        {14,4,5,6},
                        {9,2,13,11},
                    };
                case 11:
                    return new int[,]
                    {
                        {1,6,15,2},
                        {14,12,13,4},
                        {3,5,10,8},
                        {9,16,7,11},
                    };
                case 12:
                    return new int[,]
                    {
                        {3,15,9,4},
                        {14,6,7,16},
                        {5,8,13,1},
                        {12,10,11,2},
                    };
            }

            return new int[,] { };
        }
    }
}
