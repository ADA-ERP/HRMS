
using Ardalis.GuardClauses;
using Shared.Abstractions.Types;

namespace Core.Domains
{
    public class KeyValue:BaseEntity
    {
        

        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public KeyValue()
        {

        }
        public KeyValue(string key, string value, string description)
        {
            Key = Guard.Against.NullOrEmpty(key);
            Value = Guard.Against.NullOrEmpty(value);
            Description = description;
        }
        public void  UpdateKeyValue(string key, string value, string description)
        {
            Key = Guard.Against.NullOrEmpty(key);
            Value = Guard.Against.NullOrEmpty(value);
            Description = description;
        }
    }
}
