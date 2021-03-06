using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefixSums
{
  class Program
  {
    static void Main(string[] args)
    {
      bool isIt = IsPalindrome("honda");
      isIt = IsPalindrome("civic");

      //int[] A = new int[] { 0, 1, 0, 1, 1 };
      //int answer = PassingCars(A);

      //int answer = CountDiv(11, 14, 2);

      int[] P = new int[] { 2, 5, 0 };
      int[] Q = new int[] { 4, 5, 6 };
      string S = "CAGCCTA";

      //int[] P = new int[] { 0, 0, 1 };
      //int[] Q = new int[] { 0, 1, 1 };
      //string S = "CC";

      //int[] P = new int[] { 0, 0, 1 };
      //int[] Q = new int[] { 0, 1, 1 };
      //string S = "AC";

      var answer = GenomicRangeQuery(S, P, Q);
    }

    public static int[] GenomicRangeQuery(string S, int[] P, int[] Q)
    {
      Dictionary<char, int> map = new Dictionary<char, int>
      {
        { 'A', 1 },
        { 'C', 2 },
        { 'G', 3 },
        { 'T', 4 }
      };

      char[] minimals = new char[P.Length];
      int[] intMinimals = new int[P.Length];
      int n = S.Length;
      string[] arrayS = new string[n + 1];
      arrayS[0] = string.Empty;
      char track = S[0];
      bool isRepeated = true;
      for (int i = 1; i < n + 1; i++)
      {
        if (isRepeated && track != S[i - 1])
        {
          isRepeated = false;
        }

        arrayS[i] = arrayS[i - 1] + S[i - 1];
      }

      if (isRepeated)
      {
        intMinimals = Enumerable.Repeat(map[S[0]], P.Length).ToArray();
      }
      else
      {
        for (int i = 0; i < P.Length; i++)
        {
          int pElm = P[i];
          int qElm = Q[i];
          string strP = arrayS[pElm];
          string strQ = arrayS[qElm + 1];
          string result = pElm != 0 ? strQ.Substring(strP.Length) : strQ;
          char minimal = result.Distinct().Min();
          minimals[i] = minimal;
        }
        intMinimals = minimals.Select(m => map[m]).ToArray<int>();

      }
      return intMinimals;
    }

    public static bool IsPalindrome(string word)
    {
      char[] wordArray = word.ToCharArray().Reverse().ToArray();
      string reversed = string.Join("", wordArray);
      return reversed.Equals(word);
    }


    //public static int CountDiv(int A, int B, int K)
    //{
    //  int answer = 0;

    //  if (A == B && A % K == 0)
    //    return 1;

    //  if (A == B && A % K != 0)
    //    return 0;

    //  //answer += (((B - A) - ((B - A) % K)) / K);
    //  answer += ((B - (B % K)) - (A - (A % K))) / K;

    //  if (A % K == 0)
    //  {
    //    answer++;
    //  }

    //  return answer;
    //}

    //public static int PassingCars(int[] A)
    //{
    //  int answer = 0;
    //  int increment = 0;

    //  for (int i = 0; i < A.Length; i++)
    //  {
    //    if (A[i] == 0)
    //    {
    //      increment++;
    //    }
    //    else if (A[i] == 1)
    //    {
    //      answer += increment;
    //      if (answer > 1000000000)
    //        return -1;
    //    }
    //  }
    //  return answer;
    //}
  }
}
