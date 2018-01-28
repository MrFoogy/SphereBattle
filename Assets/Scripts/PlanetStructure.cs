using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetStructure {

    public static List<List<int>> neighbors = new List<List<int>>
    {
        new List<int> {1, 2, 3, 4, 5},

        new List<int> {0, 2, 5, 11, 6, 15},
        new List<int> {0, 1, 3, 7, 11, 12},       
        new List<int> {0, 2, 4, 8, 12, 13},       
        new List<int> {0, 3, 5, 9, 13, 14},       
        new List<int> {0, 1, 4, 10, 14, 15},       

        new List<int> {1, 11, 15, 16, 25},       
        new List<int> {2, 11, 12, 17, 18},       
        new List<int> {3, 12, 13, 19, 20},       
        new List<int> {4, 13, 14, 21, 22},       
        new List<int> {5, 14, 15, 23, 24},

        new List<int> {1, 2, 6, 7, 16, 17},       
        new List<int> {2, 3, 7, 8, 18, 19},       
        new List<int> {3, 4, 8, 9, 20, 21},       
        new List<int> {4, 5, 9, 10, 22, 23},       
        new List<int> {1, 5, 6, 10, 24, 25},       

        new List<int> {6, 11, 17, 25, 26, 31}, 
        new List<int> {7, 11, 16, 18, 27, 31}, 
        new List<int> {7, 12, 17, 19, 27, 32}, 
        new List<int> {8, 12, 18, 20, 28, 32}, 
        new List<int> {8, 13, 19, 21, 28, 33}, 
        new List<int> {9, 13, 20, 22, 29, 33}, 
        new List<int> {9, 14, 21, 23, 29, 34}, 
        new List<int> {10, 14, 22, 24, 30, 34}, 
        new List<int> {10, 15, 23, 25, 30, 35}, 
        new List<int> {6, 15, 16, 24, 26, 35},

        new List<int> {16, 25, 31, 35, 36}, 
        new List<int> {17, 18, 31, 32, 37}, 
        new List<int> {19, 20, 32, 33, 38}, 
        new List<int> {21, 22, 33, 34, 39}, 
        new List<int> {23, 24, 34, 35, 40}, 

        new List<int> {16, 17, 26, 27, 36, 37}, 
        new List<int> {18, 19, 27, 28, 37, 38}, 
        new List<int> {20, 21, 28, 29, 38, 39}, 
        new List<int> {22, 23, 29, 30, 39, 40}, 
        new List<int> {24, 25, 26, 31, 36, 40}, 
        new List<int> {26, 31, 35, 37, 40, 41}, 
        new List<int> {27, 31, 32, 36, 38, 41}, 
        new List<int> {28, 32, 33, 37, 39, 41}, 
        new List<int> {29, 33, 34, 38, 40, 41}, 
        new List<int> {30, 34, 35, 36, 39, 41}, 

        new List<int> {36, 37, 38, 39, 40}
    };
}
