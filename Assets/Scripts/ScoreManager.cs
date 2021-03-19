using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{

    static int score;

   public static void setScore(int sc)
   {
        score = sc;
   }

    public static int getScore()
    {
        return score;
    }
}
