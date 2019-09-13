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
            CONNECTED,
            WAITING,
            REMOVE,
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
    }
}
