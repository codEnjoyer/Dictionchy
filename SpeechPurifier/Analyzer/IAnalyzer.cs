namespace SpeechPurifier.Analyzer;

public interface IAnalyzer<out TAnalyzeResult> 
    where TAnalyzeResult: IAnalyzeResult
{
    public TAnalyzeResult Analyze(string content); 
}