using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager
{
    public static int life = 0;

    public static void setLife(int lf)
    {
        if (life + lf <= 300)
            life += lf;
        else
            life = 300;
    }

    public static int getLife()
    {
        return life;
    }
}
