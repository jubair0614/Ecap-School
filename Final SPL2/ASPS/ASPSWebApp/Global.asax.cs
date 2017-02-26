using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using ASPSDataModel;

namespace ASPSWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {

            StudentRepository studentRepository = new StudentRepository();
            FacultyRepository facultyRepository = new FacultyRepository();
            AdminRepository systemAdminRepository = new AdminRepository();

            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        //let us take out the username now                
                        string email = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                        String userRole = "";
                       
                        Student student = studentRepository.FindStudent(email);
                        if (student != null)
                        {
                            userRole = "Student";
                        }

                        Faculty faculty = facultyRepository.FindFaculty(email);
                        if (faculty != null)
                        {
                            userRole = "Faculty";
                        }

                        SystemAdministrator systemAdministrator = systemAdminRepository.FindSystemAdmin(email);
                        if (systemAdministrator != null)
                        {
                            userRole = "SystemAdministrator";
                        }

                        //let us extract the roles from our own custom cookie


                        //Let us set the Pricipal with our user specific details
                        System.Web.HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(
                          new System.Security.Principal.GenericIdentity(email, "Forms"), new String[] { userRole});
                    }
                    catch (Exception)
                    {
                        //somehting went wrong
                    }
                }
            }
        }
    }
}

