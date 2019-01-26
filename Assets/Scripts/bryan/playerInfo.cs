using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    public int appetite = 1;
    public int id;// Œª÷√–≈œ¢ 0-◊Û…œ 1-”“…œ 2-◊Ûœ¬ 3-”“œ¬
    public int type;
    public int repletion = 0;
    public List<int> prefer;
    public List<int> dislike;
    //public Arm arm;
    public int score = 0;
    public int robTimes = 0;
    public int attackTime = 0;
    private List<int> actRecord;

    // Start is called before the first frame update
    public PlayerInfo(int _id, int _type)
    {
        id = _id;
        type = _type;
        prefer = new List<int>();
        actRecord = new List<int>();
        dislike = new List<int>();
        for (int i = 0; i < 4; i++) actRecord.Add(0);
        setPrefers(type);
    }

    public void attackCount(int opponent)
    {
        actRecord[opponent]++;
    }
    public List<string> getPreferLists()
    {
        List<string> res = new List<string>();
        for(int i = 0; i < prefer.Count; i++)
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

    public int getGreatestOpponent()
    {
        int res = 0;
        for (int i = 0; i < 4; i++)
            if (actRecord[i] > actRecord[res]) res = i;
        return res;
    }

    public float getPrefer(int food)
    {
        if(prefer.Exists((int s) => s == food ? true : false))
        {
            return 2.0f;
        }
        else if (dislike.Exists((int s) => s == food ? true : false))
        {
            return -1.0f;
        }
        return 0.0f;
    }
    public void setPrefers(int no)
    {
        switch (no)
        {
            case 0://grandpa
                prefer.Add(FoodType.tofu);
                prefer.Add(FoodType.egg);

                dislike.Add(FoodType.beafball);
                dislike.Add(FoodType.intestine);
                dislike.Add(FoodType.sausage);
                dislike.Add(FoodType.lotus);
                break;
            case 1://grandma
                prefer.Add(FoodType.shrimp);
                prefer.Add(FoodType.luncheonMeat);

                dislike.Add(FoodType.ricecake);
                dislike.Add(FoodType.tofu);
                dislike.Add(FoodType.eggDumpling);
                dislike.Add(FoodType.lotus);


                break;
            case 2://pa
                prefer.Add(FoodType.mushroom);
                prefer.Add(FoodType.intestine);

                dislike.Add(FoodType.shrimp);
                dislike.Add(FoodType.beaf);
                dislike.Add(FoodType.luncheonMeat);
                dislike.Add(FoodType.eggDumpling);
                break;
            case 3://ma
                prefer.Add(FoodType.luncheonMeat);
                prefer.Add(FoodType.egg);

                dislike.Add(FoodType.eggDumpling);
                dislike.Add(FoodType.ricecake);
                dislike.Add(FoodType.mushroom);
                dislike.Add(FoodType.intestine);
                break;
            case 4://bro
                prefer.Add(FoodType.luncheonMeat);
                prefer.Add(FoodType.lotus);

                dislike.Add(FoodType.tofu);
                dislike.Add(FoodType.beafball);
                dislike.Add(FoodType.egg);
                dislike.Add(FoodType.sausage);
                break;
            case 5://sis
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
