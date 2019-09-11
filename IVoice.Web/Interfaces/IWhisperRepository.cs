namespace IVoice.Interfaces
{
    public interface IWhisperRepository : IGenericTableRepository<Database.Whisper, Models.Whisper.WhisperRowModel>
    {
    }
}
