namespace Logbook.Server.Infrastructure.Configuration
{
    public interface IAzureConfig
    {
        string EmailQueueName { get; }
        string SummonerUpdateQueueName { get; }
        string AnalyzeSummonerMatchHistoryQueueName { get; }
        string AzureStorageConnectionString { get; }
        string ApplicationInsightsKey { get; }
        string MatchContainerName { get; set; }
    }
}