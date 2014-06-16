using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

partial class Ransac
{
    bool DoneThreading;

    public void FindPlaneInThread(object StateInfo)
    {
        int index = (int)StateInfo;

        //starting iterating
        int j = 0; //iterationcounter
        int k = 0; //currentFoundPoints

        //moet meer dan 90% van de punten op de echte plane aan de huidige plane kunnen matchen
        int minFoundPoints = (int)((float)amountOfPlanePoints * PlaneSupport);
        while (k < minFoundPoints)
        {
            k = FindPointsForSomePlane();
            j++;
        }

        //saving result
        results[index] = j;

        //als het laatste item geweest is, geef dat door
        if (index == results.Length - 1) 
            DoneThreading = true;
    }

    private void FindThePlane()
    {
        //tries to find the plane 'amountOfIterations'-times, and stores the results in this array:
        results = new int[amountOfIterations];
        DoneThreading = false;

        //start Threads (makes a que that includes all iteration-indexes
        for (int index = 0; index < results.Length; index++)
            ThreadPool.QueueUserWorkItem(new WaitCallback(FindPlaneInThread), index);

        //wait for the que to end
        while (!DoneThreading)
            ;

        //sorts the results and gives the appropriate result back;
        SortResults();

        //return 5th-biggest-value?
        totalResult = results[5];
    }
    private int FindPointsForSomePlane()
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

        //plane gaat door a en heeft normaalvector N = (b-a)X(c-a)
        Punt N = pointList[b].Substract(pointList[a]).Cross(pointList[c].Substract(pointList[a]));

        //kijkt voor alle punten...
        int L = 0;
        
        for (int i = 0; i < pointList.Length; i++)
        {
            //..of ze dicht genoeg bij de gevormde plane liggen
            float D = Punt.DistanceFromPlane(pointList[a], N, pointList[i]);
            if(Math.Abs(D) <= planeDistance)
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
}