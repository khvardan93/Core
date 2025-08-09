using System;

namespace Core.Data
{
    [Serializable]
    public class StringDataObject : PrimitiveBaseDataObject<string>
    {
        public override DataType DataType => DataType.String;
        
        protected override bool CheckEquality(string v1, string v2)
        {
            return v1.Equals(v2);
        }
    }
}
