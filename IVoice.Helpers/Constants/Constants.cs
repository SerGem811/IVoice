namespace IVoice.Helpers
{
    public static class Constants
    {
        public enum Visibility
        {
            PRIVATE,
            PUBLIC
        }

        public enum VoicerConnectionType
        {
            BLOCKED,
            GOTBLOCKED,
            CONNECTED,
            WAITING,
            REMOVED,
            REQUESTED
        }

        public enum SearchFormType
        {
            VOICER,
            SPREAD,
            IPSAVE,
            PUBLIC_MAGAZINE,
            IPCREATE,
            ADCENTRE
        }

        public enum ActivityType
        {
            ACTIVITY,
            UPDATES
        }

        public enum ActivityOperationType
        {
            SPREAD,
            VIEW,
            EP,
            COMMENT,
            REMOVE_SURF,
            ADD_SURF
        }

        public enum UserType
        {
            PROFILE,
            PROJECT
        }

        public static int EVENT_ID = 4;
        public static int URBANDICTIONARY_ID = 8;
        public static int WAVE_ID = 11;
        public static int JOURNAL_ID = 12;
        public static int NOTEBOOK_ID = 13;
    }
}
