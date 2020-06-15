using System;

namespace ValidationAttributes
{
    class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minvalue;
        private readonly int maxvalue;

        public MyRangeAttribute(int minvalue,int maxvalue)
        {
            this.ValidateRange(minvalue, maxvalue);
            this.minvalue = minvalue;
            this.maxvalue = maxvalue;
        }
        public override bool IsValid(object obj)
        {
            if(obj is Int32)
            {
                int value = (int)obj;
                if(value >= minvalue && value < maxvalue)
                {
                    return true;
                }
                return false;
            }
            else
            {
                throw new ArgumentException("Invalid object Type!");
            }
        }

        private void ValidateRange(int minvalue, int maxvalue)
        {
            if(minvalue > maxvalue)
            {
                throw new ArgumentException("Ivalid Range!");
            }
        }
    }
}
