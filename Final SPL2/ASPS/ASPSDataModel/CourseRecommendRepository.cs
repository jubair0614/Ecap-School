using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPSDataModel
{
    public class CourseRecommendRepository
    {
        ASPSEntities aspsEntities = null;

        public CourseRecommendRepository()
        {
            aspsEntities = new ASPSEntities();
        }

        public bool AddCourseRecommendation(CourseRecommendation courseRecommendation)
        {
            aspsEntities.CourseRecommendations.Add(courseRecommendation);
            return aspsEntities.SaveChanges() > 0;
        }

        public bool EditCourseRecommendation(CourseRecommendation courseRecommendation)
        {
            aspsEntities.CourseRecommendations.Attach(courseRecommendation);
            aspsEntities.Entry(courseRecommendation).State = EntityState.Modified;
            return aspsEntities.SaveChanges() > 0;
        }


        public bool DeleteCourseRecommendation(CourseRecommendation courseRecommendation)
        {
            aspsEntities.CourseRecommendations.Attach(courseRecommendation);
            aspsEntities.Entry(courseRecommendation).State = EntityState.Deleted;
            return aspsEntities.SaveChanges() > 0;
        }

        public List<CourseRecommendation> CourseRecommendationList()
        {
            return aspsEntities.CourseRecommendations.ToList();
        } 
    }
}
