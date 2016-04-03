using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using FeatureConfigurator.Models;

namespace FeatureConfigurator.Controllers
{
    public class FeaturesController : ApiController
    {
        private Feature[] defaultFeatures = new Feature[]
        {
            new Feature {IsEnabled = false, Description = "Organization Name", Property = FeatureAspect.Text},
            new Feature
            {
                IsEnabled = true,
                Description = "Time Format",
                Property = new FeatureAspect(3, "Boolean")
                {
                    Remarks = "Use 24 hours time format",
                    Value = true
                }

            },
            new Feature {IsEnabled = true, Description = "Concurrent sessions", Property = FeatureAspect.Number}
        };

        


        public IEnumerable<Feature> GetAllFeatures()
        {
            defaultFeatures[0].Property.Value = "Remware";
            defaultFeatures[2].Property.Value = 6;
            return defaultFeatures;
        }

        public IHttpActionResult GetFeature(string desc)
        {
            var feature = defaultFeatures.FirstOrDefault((p) => p.Description == desc);
            if (feature == null)
            {
                return NotFound();
            }
            return Ok(feature);
        }

    }
}
