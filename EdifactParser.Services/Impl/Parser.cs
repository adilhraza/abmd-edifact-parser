
using System.Linq;

namespace EdifactParser.Services.Impl
{
    public class Parser : IParser
    {
        public string[] ParseEdifactString(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;
            
            // declare array to store 2nd and 3rd elements of LOC segment
            string[] ResultElements;

            // split the input string and get only LOC segments
            var LocSegments = input.Split('\'').Where(x => x.StartsWith("LOC")).ToArray();

            // initialize result array, size x 2 because we need 2 (2nd and 3rd) elements from LOC segment
            ResultElements = new string[LocSegments.Count() * 2];

            int i = 0; // counter

            for (var j = 0; j < LocSegments.Length; j++)
            {
                var Elements = LocSegments[j].Split('+');

                ResultElements[i] = Elements[1]; i++;
                ResultElements[i] = Elements[2]; i++;
            }

            return ResultElements;
        }
    }
}
