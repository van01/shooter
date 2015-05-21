using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BigNumber{
    public decimal num;
	public int suffixIdx;

	public string[] suffix = { "", "K", "M", "B", "T", "aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh", "ii", "jj", "kk", "ll", "mm", "nn", "oo", "pp", "qq", "rr", "ss", "tt", "uu", "vv", "ww", "xx", "yy", "zz" };

    public void MakeSuffix()
    {
        // 1000 보다 크면 단위를 올린다.
        while (true)
        {
            if (num >= 1000.0m)
            {
                num /= 1000.0m;
                suffixIdx++;
            }
            else
            {
                break;
            }
        }

        // 1보다 작다면 단위를 줄인다.
        while (true)
        {
            // 더 이상 줄일 수 없다면 포기
            if (suffixIdx <= 0) break;

            if(num < 1.0m)
            {
                num *= 1000.0m;
                suffixIdx--;
            }
            else
            {
                break;
            }
        }
    }

    public BigNumber()
    {
        num = 0;
        suffixIdx = 0;
    }

    public BigNumber(BigNumber v)
    {
        num = v.num;
        suffixIdx = v.suffixIdx;
    }
    
    public BigNumber(int v)
    {
        num = (decimal)v;
        suffixIdx = 0;

        MakeSuffix();
    }

    public BigNumber(decimal v)
    {
        num = v;
        suffixIdx = 0;

        MakeSuffix();
    }

    public BigNumber(double v)
    {
        num = (decimal)v;
        suffixIdx = 0;

        MakeSuffix();
    }

    public BigNumber(float v)
    {
        num = (decimal)v;
        suffixIdx = 0;

        MakeSuffix();
    }
    
    public BigNumber(string v)
    {
        suffixIdx = 0;
        switch(v[v.Length - 1]) 
        {
            case 'K': suffixIdx = 1; break;
            case 'M': suffixIdx = 2; break;
            case 'B': suffixIdx = 3; break;
            case 'T': suffixIdx = 4; break;
            case 'a': suffixIdx = 5; break;
            case 'b': suffixIdx = 6; break;
            case 'c': suffixIdx = 7; break;
            case 'd': suffixIdx = 8; break;
            case 'e': suffixIdx = 9; break;
            case 'f': suffixIdx = 10; break;
            case 'g': suffixIdx = 11; break;
            case 'h': suffixIdx = 12; break;
            case 'i': suffixIdx = 13; break;
            case 'j': suffixIdx = 14; break;
            case 'k': suffixIdx = 15; break;
            case 'l': suffixIdx = 16; break;
            case 'm': suffixIdx = 17; break;
            case 'n': suffixIdx = 18; break;
            case 'o': suffixIdx = 19; break;
            case 'p': suffixIdx = 20; break;
            case 'q': suffixIdx = 21; break;
            case 'r': suffixIdx = 22; break;
            case 's': suffixIdx = 23; break;
            case 't': suffixIdx = 24; break;
            case 'u': suffixIdx = 25; break;
            case 'v': suffixIdx = 26; break;
            case 'w': suffixIdx = 27; break;
            case 'x': suffixIdx = 28; break;
            case 'y': suffixIdx = 29; break;
            case 'z': suffixIdx = 30; break;
        }

        if (suffixIdx > 0)
        {
            if (suffixIdx >= 5)
                v = v.Remove(v.Length - 2, 2);
            else
                v = v.Remove(v.Length - 1, 1);
        }

        num = Convert.ToDecimal(v);
    }

    static public implicit operator BigNumber(int v)
    {
        return new BigNumber(v);
    }

    static public implicit operator BigNumber(decimal v)
    {
        return new BigNumber(v);
    }

    static public implicit operator BigNumber(double v)
    {
        return new BigNumber(v);
    }

    static public implicit operator BigNumber(float v)
    {
        return new BigNumber(v);
    }
        
    static public explicit operator decimal(BigNumber v)
    {
        if(v.suffixIdx>0)
        {
            int i;
            for (i = 0; i < v.suffixIdx;i++)
            {
                v.num *= 1000.0m;                     
            }
        }

        return v.num;        
    }

    static public explicit operator float(BigNumber v)
    {
        if (v.suffixIdx > 0)
        {
            int i;
            for (i = 0; i < v.suffixIdx; i++)
            {
                v.num *= 1000.0m;
            }
        }

        return (float)v.num;
    }

    
    static public BigNumber operator + (BigNumber a, BigNumber b)
    {
        // 7단계 이상 작다면 사실 21자리 이상 차이므로 무시한다.
        if (a.suffixIdx > b.suffixIdx + 7)
            return new BigNumber(a);

        // 7단계 이상 큰수라면 그것을 택한다!
        if (a.suffixIdx + 7 < b.suffixIdx)
            return new BigNumber(b);

        int i;

        // 아니라면 계산 후 더한다.
        BigNumber r = new BigNumber();
        r.suffixIdx = a.suffixIdx;
        decimal real_a = a.num, real_b = b.num;        
        if(a.suffixIdx>b.suffixIdx)
        {
            int diff = a.suffixIdx - b.suffixIdx;            
            for (i = 0; i < diff; i++)
                real_a *= 1000.0m;
            
            r.suffixIdx = b.suffixIdx;    // 작은쪽 단위를 지정한다.
        }
        else if(a.suffixIdx<b.suffixIdx)
        {
            int diff = b.suffixIdx - a.suffixIdx;
            for (i = 0; i < diff; i++)
                real_b *= 1000.0m;

            r.suffixIdx = a.suffixIdx;
        }

        r.num = real_a + real_b;
        r.MakeSuffix();

        return r;
    }

    static public BigNumber operator -(BigNumber a, BigNumber b)
    {
        // 7단계 이상 작다면 사실 21자리 이상 차이므로 무시한다.
        if (a.suffixIdx > b.suffixIdx + 7)
            return new BigNumber(a);

        // 7단계 이상 큰수라면 그것을 택한다!
        if (a.suffixIdx + 7 < b.suffixIdx)
            return new BigNumber(b);

        int i;

        // 아니라면 계산 후 더한다.
        BigNumber r = new BigNumber();
        r.suffixIdx = a.suffixIdx;
        decimal real_a = a.num, real_b = b.num;
        if (a.suffixIdx > b.suffixIdx)
        {
            int diff = a.suffixIdx - b.suffixIdx;
            for (i = 0; i < diff; i++)
                real_a *= 1000.0m;

            r.suffixIdx = b.suffixIdx;    // 작은쪽 단위를 지정한다.
        }
        else if (a.suffixIdx < b.suffixIdx)
        {
            int diff = b.suffixIdx - a.suffixIdx;
            for (i = 0; i < diff; i++)
                real_b *= 1000.0m;

            r.suffixIdx = a.suffixIdx;
        }

        r.num = real_a - real_b;
        r.MakeSuffix();

        return r;
    }

    static public BigNumber operator *(BigNumber a, decimal b)
    {
        // 아니라면 계산 후 더한다.
        BigNumber r = new BigNumber();
        r.suffixIdx = a.suffixIdx;

        r.num = a.num * b;
        r.MakeSuffix();

        return r;
    }

    static public BigNumber operator /(BigNumber a, BigNumber b)
    {
        // 아니라면 계산 후 더한다.
        BigNumber r = new BigNumber();
        r.suffixIdx = a.suffixIdx - b.suffixIdx;

        int diff, i;

        // 마이너스로 가면.. 소스점이 되므로.. 
        decimal real_b = b.num;        
        if(r.suffixIdx < 0)
        {
            diff = -r.suffixIdx;
           
            for (i = 0; i < diff; i++)
                real_b *= 1000.0m;

            r.suffixIdx = 0;
        }

        decimal real_a = a.num;
        if(r.suffixIdx > 0)
        {
            diff = r.suffixIdx;
            for (i = 0; i < diff; i++)
                real_a *= 1000.0m;
        }

        r.suffixIdx = 0;

        r.num = real_a / real_b;
        r.MakeSuffix();

        return r;
    }

    static public bool operator ==(BigNumber a, BigNumber b)
    {
        if (a.num == b.num && a.suffixIdx == b.suffixIdx) return true;
        else return false;
    }

    static public bool operator !=(BigNumber a, BigNumber b)
    {
        return !(a==b);
    }

    static public bool operator <(BigNumber a, BigNumber b)
    {
        // 자리수가 차이나면 값을 비교할 필요도 없다!
        if (a.suffixIdx < b.suffixIdx)
            return true;

        if (a.suffixIdx > b.suffixIdx)
            return false;

        // 같으면 값 비교ㅕ
        return (a.num < b.num);
    }

    static public bool operator >(BigNumber a, BigNumber b)
    {
        return !(a < b);
    }

    static public bool operator <=(BigNumber a, BigNumber b)
    {
        return (a < b || a == b);
    }

    static public bool operator >=(BigNumber a, BigNumber b)
    {
        return (a > b || a == b);
    }


    string GetSuffixText()
    {
        if (suffixIdx == 0) 
            return string.Empty;

        return suffix[suffixIdx - 1];
    }

    public string ToStringForSave()
    {
        return num.ToString() + GetSuffixText();
    }

    public string ToString()
    {
        if (suffixIdx == 0)
        {
            return num.ToString("N0");
        }
        else
        {
            return num.ToString("N2") + GetSuffixText();
        }
    }

    
}
