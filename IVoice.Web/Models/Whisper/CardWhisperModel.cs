using IVoice.Models.Components.Tabs;

namespace IVoice.Models.Whisper
{
    public class CardWhisperModel : BaseModel
    {
        public CardHeaderTabsModel _header;
        public CardBodyTabsTableModel _body;
    }
}