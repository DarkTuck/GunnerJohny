using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "EnemyDificultyValuses", menuName = "Enemy/EnemyDificultyValuses")]
public class EnemyDificultyValuses : EnemyInt
{
    public int[]healthArray,damageArray;
    public float[] rangeArray, cooldownArray, targetDistanceArray, speedArray;
    public int currentDificulty;

    public void ChangeDificultyValues(int dificulty)
    {
        health=healthArray[dificulty];
        damage=damageArray[dificulty];
        range=rangeArray[dificulty];
        cooldown=cooldownArray[dificulty];
        targetDistance=targetDistanceArray[dificulty];
        speed=speedArray[dificulty];
    }
}
