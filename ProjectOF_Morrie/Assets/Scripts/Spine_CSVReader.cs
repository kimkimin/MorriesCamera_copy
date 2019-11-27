using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Spine_CSVReader : MonoBehaviour
{
    static string SPLIT_LINE = "\n"; // 줄바꿈 패턴의 문자열을 분리 하는데 쓰임
    static string SPLIT_COMMA = ","; // 특정 패턴의 문자열로 분리 하는데 쓰임
    static char[] TRIM_CHAR = { }; // 단어의 양끝에 공백또는 지정 문자를 제거하는데 쓰임


    /// <summary>
    /// CSV를 받아서 라인별로 나눈 단어 배열을 반환합니다.
    /// </summary>
    public static List<string[]> SplitVoka(string rawCSV)
    {
        string[] splitLine = Regex.Split(rawCSV, SPLIT_LINE); //줄별구분
        List<string[]> splitVoka = new List<string[]>();
        for (int i = 1; i < splitLine.Length; i++)
        {
            var voka = Regex.Split(splitLine[i], SPLIT_COMMA);
            splitVoka.Add(voka);
        }
        return splitVoka;
    }

    /// <summary>
    /// 단어배열을 받아서 스킨 비교하여 애니메이션 배열을 반환(할당)합니다.
    /// </summary>
    public static List<string> SplitSkin(List<string[]> voka, string skin)
    {
        List<string> anim = new List<string>();
        for (int i = 0; i < voka.Count; i++)
        {
            //print("matched with " + voka[i][(int)SpineCategory.Skin] + "?");
            if (skin == voka[i][(int)SpineCategory.Skin])
            {
                //print("matched");
                for (int j = (int)SpineCategory.Idle; j < voka[i].Length; j++)
                {
                    anim.Add(voka[i][j]);
                }
                return anim;
            }
        }
        //print("Return null");
        return null;
    }

    public enum SpineCategory
    {
        Name,
        Skin,
        Idle,
        Touch1,
        Touch2,
        Touch3
    }
}
