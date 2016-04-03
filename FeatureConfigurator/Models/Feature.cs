using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeatureConfigurator.Models
{
    public class Feature
    {
        public bool IsEnabled { get; set; }
        public string Description { get; set; }
        public FeatureAspect Property { get; set; }
    }
}