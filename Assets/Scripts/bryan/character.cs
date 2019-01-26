using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class character : MonoBehaviour
{
    public int appetite = 1;
    public int Satiety = 0;
    public List<int> prefer;
    public List<int> dislike;
    //public Arm arm;
    public int score = 0;
    public int jhtimes = 0;
    public int attackTime = 0;
    public List<int> actRecord;

    // Start is called before the first frame update
    void Start()
    {
        prefer = new List<int>();
        actRecord

    }

    // Update is called once per frame
    void Update()
    {

    }
    public float getPrefer(int food)
    {
        if(prefer.Exists((int s) => s == food ? true : false))
        {
            return 2.0f;
        }
        else if (dislike.Exists((int s) => s == food ? true : false))
        {
            return 0.5f;
        }
        return 1.0f;
    }
    public void setPrefers(int no)
    {
        switch (no)
        {
            case 0://grandpa
                prefer.Add(Foods.tofu);
                prefer.Add(Foods.egg);

                dislike.Add(Foods.beafball);
                dislike.Add(Foods.intestine);
                dislike.Add(Foods.sausage);
                dislike.Add(Foods.lotus);
                break;
            case 1://grandma
                prefer.Add(Foods.shrimp);
                prefer.Add(Foods.luncheonMeat);

                dislike.Add(Foods.ricecake);
                dislike.Add(Foods.tofu);
                dislike.Add(Foods.eggDumpling);
                dislike.Add(Foods.lotus);


                break;
            case 2://pa
                prefer.Add(Foods.mushroom);
                prefer.Add(Foods.intestine);

                dislike.Add(Foods.shrimp);
                dislike.Add(Foods.beaf);
                dislike.Add(Foods.luncheonMeat);
                dislike.Add(Foods.eggDumpling);
                break;
            case 3://ma
                prefer.Add(Foods.luncheonMeat);
                prefer.Add(Foods.egg);

                dislike.Add(Foods.eggDumpling);
                dislike.Add(Foods.ricecake);
                dislike.Add(Foods.mushroom);
                dislike.Add(Foods.intestine);
                break;
            case 4://bro
                prefer.Add(Foods.luncheonMeat);
                prefer.Add(Foods.lotus);

                dislike.Add(Foods.tofu);
                dislike.Add(Foods.beafball);
                dislike.Add(Foods.egg);
                dislike.Add(Foods.sausage);
                break;
            case 5://sis
                prefer.Add(Foods.tofu);
                prefer.Add(Foods.lotus);

                dislike.Add(Foods.beaf);
                dislike.Add(Foods.shrimp);
                dislike.Add(Foods.intestine);
                dislike.Add(Foods.sausage);
                break;
        }
    }
}

public class Foods
{
    public static int ricecake = 0;
    public static int tofu = 1;
    public static int pakchoi = 2;
    public static int shrimp = 3;
    public static int beaf = 4;
    public static int beafball = 5;
    public static int eggDumpling = 6;
    public static int mushroom = 7;
    public static int luncheonMeat = 8;
    public static int intestine = 9;
    public static int egg = 10;
    public static int fishPlate = 11;
    public static int sausage = 12;
    public static int lotus = 13;

}

public class Characters
{
    public static int grandpa = 0;
    public static int grandma = 1;
    public static int father = 2;
    public static int mother = 3;
    public static int brother = 4;
    public static int sister = 5;
}

public class FoodSatie
{
    public static int ricecake = 5;
    public static int tofu = 3;
    public static int pakchoi = 1;
    public static int shrimp = 2;
    public static int beaf = 5;
    public static int beafball = 5;
    public static int eggDumpling = 4;
    public static int mushroom = 2;
    public static int luncheonMeat = 3;
    public static int intestine = 3;
    public static int egg = 2;
    public static int fishPlate = 1;
    public static int sausage = 4;
    public static int lotus = 2;

}
