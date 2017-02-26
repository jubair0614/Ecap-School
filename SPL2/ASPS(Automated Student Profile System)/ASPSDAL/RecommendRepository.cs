using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPSDAL
{
    public class RecommendRepository
    {
        ASPSEntities db = null;

        public RecommendRepository()
        {
            db = new ASPSEntities();
        }

        public bool AddRecommend(CourseRecommendation courseRecommendation)
        {
            db.CourseRecommendations.Add(courseRecommendation);
            return db.SaveChanges() > 0;
        }

        public bool EditRecommend(CourseRecommendation courseRecommendation)
        {
            db.CourseRecommendations.Attach(courseRecommendation);
            db.Entry(courseRecommendation).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool DeleteRecommend(CourseRecommendation courseRecommendation)
        {
            db.CourseRecommendations.Attach(courseRecommendation);
            db.Entry(courseRecommendation).State = EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        public List<CourseRecommendation> CourseRecommendationsList()
        {
            return db.CourseRecommendations.ToList();
        }

        public CourseRecommendation GetCourseRecommendationById(long id)
        {
            return db.CourseRecommendations.FirstOrDefault(cr => cr.ContentID == id);
        }
    }
}
