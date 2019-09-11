using IVoice.Models.Components.Common;
using System.Collections.Generic;

namespace IVoice.Models.Components.Tabs
{
    public class CardBodyTabsTableModel
    {
        public List<CardBodyTableModel> _body;
    }

    public class CardBodyTableModel : CardBodyModel
    {
        public List<ColumnModel> _cols;
    }

    public class ColumnModel
    {
        public string _name;
        public string _class;
        public string _scope;
    }
}