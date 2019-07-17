namespace EdifactParser.Services
{
    public interface IParser
    {
        string[] ParseEdifactString(string input);
    }
}
