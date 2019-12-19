using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

/// <summary>
/// CSV를 받아와서 읽고 애님배열을 반환
/// </summary>
public class Spine_CSVReader : MonoBehaviour
{
    static string SPLIT_LINE = "\n"; // 줄바꿈 패턴의 문자열을 분리 하는데 쓰임
    static string SPLIT_COMMA = ","; // 특정 패턴의 문자열로 분리 하는데 쓰임
    static string SPLIT_UNDERBAR = "_";
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
            var voka = Regex.Split(splitLine[i], SPLIT_COMMA);//라인별로 콤마로 나눈 배열뭉탱이
            splitVoka.Add(voka);
        }
        return splitVoka;//콤마로 나는 배열의 리스트
    }

    /// <summary>
    /// 단어배열을 받아서 스킨 비교하여 애니메이션 배열을 반환(할당)합니다.
    /// </summary>
    public static List<string> SplitAnim(List<string[]> voka, string skin)
    {
        List<string> anim = new List<string>();
        for (int i = 0; i < voka.Count; i++)
        {
            //print("matched with " + voka[i][(int)SpineCategory.Skin] + "?");
            if (skin == voka[i][(int)SpineCategory.Skin])
            {
                //print("matched : " + voka[i][(int)SpineCategory.Skin]);
                for (int j = (int)SpineCategory.Idle; j < voka[i].Length; j++)
                {
                    anim.Add(voka[i][j]);
                }
                return anim;
            }
            /*else
            {
                print("NOTmatched : " + voka[i][(int)SpineCategory.Skin] + ", 내스킨은 " + skin);

            }*/
        }
        return null;
    }
    
    /// <summary>
    /// 단어배열을 받아서 스킨 비교하여 스킨배열을 반환합니다.
    /// </summary>
    public static List<string> SplitSkin(List<string[]> voka, string defaultSkin)
    {
        List<string> skin = new List<string>();
        for (int i = 0; i < voka.Count; i++)
        {
            if(defaultSkin == voka[i][(int)SpineCategory.Skin])
            {
                for (int j = (int)SpineCategory.Skin; j < voka[i].Length; j++)
                {
                    skin.Add(voka[i][j]);
                }
                return skin;
            }
        }
        return null;
    }

    public static string SplitType(string anim)
    {
        string[] splitAnim = Regex.Split(anim, SPLIT_UNDERBAR);
        string splitType = splitAnim[splitAnim.Length - 1];
        return splitType;
    }

    public enum SpineCategory
    {
        Name,
        Skin,
        Idle
    }

    public enum AnimCategory
    {
        idle,
        t1,
        t2,
        t3,
        t4
    }
}
