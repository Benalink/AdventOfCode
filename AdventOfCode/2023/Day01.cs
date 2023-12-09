using AdventOfCodeSupport;

namespace AdventOfCode._2023;

public class Day01 : AdventBase
{
    private const int FirstNum = '0';
    private const int LastNum = '9';

    protected override object InternalPart1()
    {
        var answer = this.Input.Lines
            .Select(line =>
                {
                    int firstNum = GetPart1FirstNum(line);
                    int lastNum = GetPart1FirstNum(ReverseString(line));
                    
                    return int.Parse($"{firstNum}{lastNum}");
                }
            )
            .Sum();

        return answer;
    }
    
    protected override object InternalPart2()
    {
        var answer = this.Input.Lines
            .Select(line =>
                {
                    int firstNum = GetPart2FirstNum(line);
                    int lastNum = GetPart2LastNum(ReverseString(line));
                    
                    return int.Parse($"{firstNum}{lastNum}");
                }
            )
            .Sum();

        return answer;
    }

    private static string ReverseString(string input)
    {
        return string.Create(input.Length, input, (chars, state) =>
        {
            state.AsSpan().CopyTo(chars);
            chars.Reverse();
        });
    }

    private int GetPart1FirstNum(ReadOnlySpan<char> input)
    {
        for (int index = 0; index < input.Length; index++)
        {
            char c = input[index];
            if (c >= FirstNum && c <= LastNum)
            {
                return int.Parse(c.ToString());
            }
        }
        
        throw new InvalidDataException("Could not find number in line");
    }

    private int GetPart2FirstNum(ReadOnlySpan<char> input)
    {
        for (int index = 0; index < input.Length; index++)
        {
            char c = input[index];
            if (c >= FirstNum && c <= LastNum)
            {
                return int.Parse(c.ToString());
            }

            ReadOnlySpan<char> processed = input[..(index + 1)];
            
            int haveAnswer = processed switch
            {
                [.., 'o', 'n', 'e'] => 1,
                [.., 't', 'w', 'o'] => 2,
                [.., 't', 'h', 'r', 'e', 'e'] => 3,
                [.., 'f', 'o', 'u', 'r'] => 4,
                [.., 'f', 'i', 'v', 'e'] => 5,
                [.., 's', 'i', 'x'] => 6,
                [.., 's', 'e', 'v', 'e', 'n'] => 7,
                [.., 'e', 'i', 'g', 'h', 't'] => 8,
                [.., 'n', 'i', 'n', 'e'] => 9,
                _ => -1,
            };


            if (haveAnswer != -1)
            {
                return haveAnswer;
            }
        }

        throw new InvalidDataException("Could not find number in line");
    }

    private int GetPart2LastNum(ReadOnlySpan<char> input)
    {
        for (int index = 0; index < input.Length; index++)
        {
            char c = input[index];
            if (c >= FirstNum && c <= LastNum)
            {
                return int.Parse(c.ToString());
            }

            ReadOnlySpan<char> processed = input[..(index + 1)];
            int haveAnswer = processed switch
            {
                [.., 'e', 'n', 'o'] => 1,
                [.., 'o', 'w', 't'] => 2,
                [.., 'e', 'e', 'r', 'h', 't'] => 3,
                [.., 'r', 'u', 'o', 'f'] => 4,
                [.., 'e', 'v', 'i', 'f'] => 5,
                [.., 'x', 'i', 's'] => 6,
                [.., 'n', 'e', 'v', 'e', 's'] => 7,
                [.., 't', 'h', 'g', 'i', 'e'] => 8,
                [.., 'e', 'n', 'i', 'n'] => 9,
                _ => -1,
            };


            if (haveAnswer != -1)
            {
                return haveAnswer;
            }
        }

        throw new InvalidDataException("Could not find number in line");
    }
}