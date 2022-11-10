using UnityEngine;
public static class RandomSelection
{ 
    public static bool RandomGenerate(float chanceSuccess)
    { 
        float randomNumber = Random.Range(0.0f, 1.0f);

        if (randomNumber < chanceSuccess)
        {
            return true;
        }
        else return false;   
    }
}
