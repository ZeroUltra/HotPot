using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    private float appetite = 1.0f;
    public int combo = 0;
    public int id;// Œª÷√–≈œ¢ 0-◊Û…œ 1-”“…œ 2-◊Ûœ¬ 3-”“œ¬
    public Characters type;
    public int repletion = 0;
    public List<int> prefer;
    public List<int> dislike;
    //public Arm arm;
    public int score = 0;
    public int robTimes = 0;
    public int attackTime = 0;
    private List<int> actRecord;
    private int lastFood = -1;
    int[] foodSatie;

    public PlayerInfo(int _id, Characters characters)
    {
        id = _id;
        type = characters;
        prefer = new List<int>();
        actRecord = new List<int>();
        dislike = new List<int>();
        for (int i = 0; i < 4; i++) actRecord.Add(0);
<<<<<<< HEAD
        setPrefers(characters);
=======
        setPrefers(type);

        //foodSatie = new int[20];
        foodSatie = new int[14] { 5,3,1,2,5,5,4,2,3,3,2,1,4,2 };

    }

    public void beVomitted()
    {
        combo = 0;
        appetite = 1.0f;

>>>>>>> a510c19978ad213e2135ad8fbead4e8239973dd3
    }

    public void vomit(int delta)
    {
        repletion -= delta;
    }


    public void attackCount(int opponent)
    {
        actRecord[opponent]++;
    }
    public List<string> getPreferLists()
    {
        List<string> res = new List<string>();
        for (int i = 0; i < prefer.Count; i++)
        {
            res.Add(getFoodNameById(prefer[i]));
        }
        return res;
    }
    private string getFoodNameById(int id)
    {
        if (id == FoodType.beaf) return "∑ ≈£";
        else if (id == FoodType.beafball) return "≈£»‚ÕË";
        else if (id == FoodType.egg) return "º¶µ∞";
        else if (id == FoodType.eggDumpling) return "µ∞Ω»";
        else if (id == FoodType.lotus) return "≈∫∆¨";
        else if (id == FoodType.luncheonMeat) return "ŒÁ≤Õ»‚";
        else if (id == FoodType.mushroom) return "œ„πΩ";
        else if (id == FoodType.pakchoi) return "«‡≤À";
        else if (id == FoodType.ricecake) return "ƒÍ∏‚";
        else if (id == FoodType.sausage) return "ø™ª®œ„≥¶";
        else if (id == FoodType.shrimp) return "œ∫";
        else if (id == FoodType.tofu) return "∂≥∂π∏Ø";
        else return "?";
    }

    public int updateInfo(int foodtype_)//∑µªÿº”ºıµƒ ˝÷µ
    {
        int delta = 0;
        if (lastFood == -1)
        {
            delta = foodSatie[foodtype_] + (int)(getPrefer(foodtype_));
            repletion += delta;
            lastFood = foodtype_;
            combo++;
            
        }
        else if(foodtype_==lastFood)
        {
            float buff = 1.0f;
            combo++;
            if (combo > 3)
            {
                buff += 0.5f * (combo - 3);
            }
            delta = (int)(buff * (foodSatie[foodtype_] + (int)(getPrefer(foodtype_))));
            repletion += delta;
            lastFood = foodtype_;
        }
        else
        {
            combo = 1;
            delta = foodSatie[foodtype_] + (int)(getPrefer(foodtype_));
            repletion += delta;
            lastFood = foodtype_;
        }

        return delta;
    }

    public int getCombo()
    {
        return combo;
    }

    public int getRepletion()
    {
        return repletion;
    }

    public int getGreatestOpponent()
    {
        int res = 0;
        for (int i = 0; i < 4; i++)
            if (actRecord[i] > actRecord[res]) res = i;
        return res;
    }

    public float getPrefer(int food)
    {
        if (prefer.Exists((int s) => s == food ? true : false))
        {
            return 1.0f;
        }
        else if (dislike.Exists((int s) => s == food ? true : false))
        {
            return -1.0f;
        }
        return 0.0f;
    }
    public void setPrefers(Characters type)
    {
        switch (type)
        {
            case Characters.Grandpa:
                prefer.Add(FoodType.tofu);
                prefer.Add(FoodType.egg);

                dislike.Add(FoodType.beafball);
                dislike.Add(FoodType.intestine);
                dislike.Add(FoodType.sausage);
                dislike.Add(FoodType.lotus);
                break;
             case Characters.Grandma:
                prefer.Add(FoodType.shrimp);
                prefer.Add(FoodType.luncheonMeat);

                dislike.Add(FoodType.ricecake);
                dislike.Add(FoodType.tofu);
                dislike.Add(FoodType.eggDumpling);
                dislike.Add(FoodType.lotus);


                break;
            case Characters.Father:
                prefer.Add(FoodType.mushroom);
                prefer.Add(FoodType.intestine);

                dislike.Add(FoodType.shrimp);
                dislike.Add(FoodType.beaf);
                dislike.Add(FoodType.luncheonMeat);
                dislike.Add(FoodType.eggDumpling);
                break;
            case Characters.Mother:
                prefer.Add(FoodType.luncheonMeat);
                prefer.Add(FoodType.egg);

                dislike.Add(FoodType.eggDumpling);
                dislike.Add(FoodType.ricecake);
                dislike.Add(FoodType.mushroom);
                dislike.Add(FoodType.intestine);
                break;
            case Characters.Brother:
                prefer.Add(FoodType.luncheonMeat);
                prefer.Add(FoodType.lotus);

                dislike.Add(FoodType.tofu);
                dislike.Add(FoodType.beafball);
                dislike.Add(FoodType.egg);
                dislike.Add(FoodType.sausage);
                break;
            case Characters.Sister:
                prefer.Add(FoodType.tofu);
                prefer.Add(FoodType.lotus);

                dislike.Add(FoodType.beaf);
                dislike.Add(FoodType.shrimp);
                dislike.Add(FoodType.intestine);
                dislike.Add(FoodType.sausage);
                break;
        }
    }
}

public class FoodType
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

    public static int getAFood()
    {
        int res = Random.Range(0, 14);
        return res;
    }
}

public enum Characters
{
    Grandpa=0,
    Grandma = 1,
    Father = 2,
    Mother = 3,
    Brother = 4,
    Sister = 5
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
