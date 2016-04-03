using System;
using System.Collections.Generic;

namespace FeatureConfigurator.Models
{
    public sealed class FeatureAspect
    {
        private readonly string name;
        private readonly int order;

        // GetValue can use case switch to specify type
        public Object Value { get; set; }
        public Object Remarks { get; set; }

        private static readonly Dictionary<string, FeatureAspect> AspectType = new Dictionary<string, FeatureAspect>();

        public static readonly FeatureAspect Text    = new FeatureAspect(1, "Text");
        public static readonly FeatureAspect Number  = new FeatureAspect(2, "Number");
        public static readonly FeatureAspect Boolean = new FeatureAspect(3, "Boolean");
        public static readonly FeatureAspect Custom  = new FeatureAspect(4, "Custom");        

        public FeatureAspect(int order, string name)
        {
            this.name = name;
            this.order = order;
            AspectType[name] = this;
        }

        public override string ToString()
        {
            return name;
        }

        public static explicit operator FeatureAspect(string str)
        {
            FeatureAspect result;
            if (AspectType.TryGetValue(str, out result))
                return result;
            else
                throw new InvalidCastException();
        }

    }
}