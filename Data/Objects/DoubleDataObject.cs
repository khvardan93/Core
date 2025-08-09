using System;

namespace Core.Data
{
    [Serializable]
    public class DoubleDataObject : PrimitiveBaseDataObject<double>
    {
        public override DataType DataType => DataType.Double;
        
        protected override bool CheckEquality(double v1, double v2)
        {
            return v1.Equals(v2);
        }
    }
}
