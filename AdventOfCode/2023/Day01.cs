using AdventOfCodeSupport;

namespace AdventOfCode._2023;

public class Day01 : AdventBase
{
    private const int FirstNum = '0';
    private const int LastNum = '9';

    protected override object InternalPart1()
    {
        var answer = this.Input.Lines
            .Select(l => l.Where(c => c >= FirstNum && c <= LastNum).ToList())
            .Select(nums => int.Parse($"{nums[0]}{nums[^1]}"))
            .Sum();

        return answer;
    }

    protected override object InternalPart2()
    {
        var answer = this.Input.Lines
            .Select(line =>
                {
                    int firstNum = GetFirstNum(line);
                    int lastNum = GetLastNum(string.Create(line.Length, line, (chars, state) =>
                    {
                        state.AsSpan().CopyTo(chars);
                        chars.Reverse();
                    }));
                    
                    return int.Parse($"{firstNum}{lastNum}");
                }
            )
            .Sum();

        return answer;
    }

    private int GetFirstNum(ReadOnlySpan<char> input)
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

    private int GetLastNum(ReadOnlySpan<char> input)
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