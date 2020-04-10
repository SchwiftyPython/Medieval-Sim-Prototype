using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GlobalHelper : MonoBehaviour
{
    public const string DoubleSpace = "\n\n";
    public const string SingleSpace = "\n";

    #region EventNames

    public const string SendMessageToConsoleEventName = "SendMessageToConsole";

    #endregion EventNames

    public static void DestroyAllChildren(GameObject parent)
    {
        for (var i = 0; i < parent.transform.childCount; i++)
        {
            Destroy(parent.transform.GetChild(i).gameObject);
        }
    }

    public static void DestroyAllChildren(RectTransform parent)
    {
        for (var i = 0; i < parent.transform.childCount; i++)
        {
            Destroy(parent.transform.GetChild(i).gameObject);
        }
    }

    public static void DestroyObject(GameObject go)
    {
        Destroy(go);
    }

    public static string Capitalize(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        return char.ToUpper(s[0]) + s.Substring(1);
    }

    public static string CapitalizeAllWords(string s)
    {
        return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
    }

    //<Summary>
    // Returns a random enum value of type T
    //</Summary>
    public static T GetRandomEnumValue<T>()
    {
        var values = Enum.GetValues(typeof(T));

        return (T)values.GetValue(Random.Range(0, values.Length));
    }

    public static Dice GetDiceFromString(string dice)
    {
        var splitDice = dice.Split('d');

        var numDice = int.Parse(splitDice[0]);
        var numSides = int.Parse(splitDice[1]);

        return new Dice(numDice, numSides);
    }
}
