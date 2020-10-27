namespace MusicBox.Domain.DomainServices.Interfaces
{
    public interface ITrackStatisticsDomainService : IBaseDomainService
    {
        void IncrementCountOfCalls(int trackId);
    }
}
