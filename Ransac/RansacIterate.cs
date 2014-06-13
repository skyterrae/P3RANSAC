﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

partial class Ransac
{
    //part of the class that takes care of the iterative planefinding part

    private void FindPlane()
    {
        //tries to find the plane 'amountOfIterations'-times, and stores the results in this array:
        results = new int[amountOfIterations];

        //finds the planes
        for (int i = 0; i < results.Length; i++)
        {
            int j = 0;
            int k = 0;
            int minFoundPoints = (amountOfPlanePoints/10)*3;
            while(k<minFoundPoints)
            {
                k = IterateOnce();
                j++;
            }
            results[i] = j;
        }

        //sorts the results and gives the appropriate result back;
        SortResults();

        //return 5th-biggest-value?
       totalResult = results[5];
    }
    private int IterateOnce()
    {
        //maakt een plane uit random punten en geeft terug hoeveel punten er in de box langs de plane liggen

        //vind 3 verschillende random punten die straks een plane vormen
        int a, b, c;
        a = r.Next(amountOfPoints);
        b = r.Next(amountOfPoints);
        c = r.Next(amountOfPoints);
        while (b == a)
            b = r.Next(amountOfPoints);
        while(c==a || a==b)
            c = r.Next(amountOfPoints);

        //kijkt voor alle punten...
        int L = 0;
        for (int i = 0; i < pointList.Length; i++)
        {
            //..of ze dicht genoeg bij de gevormde plane liggen
            float D =Punt.DistanceFromPlane(pointList[a],pointList[b],pointList[c],pointList[i]);
            if(-planeDistance <= D && D <= planeDistance)
                L++;
        }
        //geeft het aantal punten terug dat bij de plane ligt
        return L;
    }
    private void SortResults()
    {
        //sorteert de resultaten op #iterations
        QuickSort(results, 0, results.Length-1);
    }
    private int Partition(int[] Arr, int p, int r)
    {
        //partitioning the array
        int s;
        int i = p - 1;
        for (int j = p; j < r; j++)
        {
            if (Arr[j] > Arr[r])
            {
                i++;
                s = Arr[i];
                Arr[i] = Arr[j];
                Arr[j] = s;
            }
        }
        s = Arr[i + 1];
        Arr[i + 1] = Arr[r];
        Arr[r] = s;

        //returning the pivot
        return i + 1;
    }
    private void QuickSort(int[] Arr, int p, int r)
    {
        //quicksort
        if (p < r)
        {
            int q = Partition(Arr, p, r);
            QuickSort(Arr, p, q - 1);
            QuickSort(Arr, q + 1, r);
        }
    }

    private bool Debug_CorrectSort()
    {
        for (int k = 1; k < results.Length; k++)
        {
            if (results[k] > results[k - 1])
                return false;
        }
        return true;
    }
}