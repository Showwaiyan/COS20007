using System.Collections.Generic;

namespace SwinAdventure
{
    public class IndentifiableObject
    {
        // Fields
        private List<string> _identifiers = new List<string>();

        // Constructor
        public IndentifiableObject(string[] idents)
        {
            foreach (string s in idents)
            {
                AddIdentifier(s);
            }
        }

        //Methods
        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }

        public void PrivilegeEscalation(string pin)
        {
            if (pin == "3041")
            {
                _identifiers[0] = "105293041";
            }
        }

        // Propertry
        public string FirstId
        {
            get
            {
                if (_identifiers.Count == 0) return "";
                return _identifiers.First();
            }
        }
    }
}
