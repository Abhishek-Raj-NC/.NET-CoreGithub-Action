using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using System.Reflection.PortableExecutable;
using Device_Migration_Admin_Portal.Models;
using System.Web;
using log4net;
using System;
//using System.DirectoryServices.AccountManagement;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Net;

namespace Device_Migration_Admin_Portal.Controllers
{
    public class AccountController : Controller
    {
        //private static string domain = "";// ConfigurationManager.AppSettings["ADDomain"];
        //// GET: UserLogin

        //private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        ////public static string version = "ACRA " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

        //public ActionResult Index()
        //{
        //    if (TempData["shortMessage"] != null)
        //        ViewBag.Error = TempData["shortMessage"].ToString();

        //    if (Session["Name"] == null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home", new { area = "" });
        //    }
        //}



        //public static string getNearestDC()
        //{

        //    log.Info("Quering nearest DC");
        //    try
        //    {
        //        var dcsInOrder = (from DomainController c in Domain.GetCurrentDomain().DomainControllers
        //                          let responseTime = Pinger(c.Name)
        //                          where responseTime >= 0
        //                          let pdcStatus = c.Roles.Contains(ActiveDirectoryRole.PdcRole)
        //                          orderby pdcStatus, responseTime
        //                          select new { DC = c, ResponseTime = responseTime }
        //               ).ToList();
        //        log.Info("Nearest DC :" + dcsInOrder[0].DC.ToString());
        //        return dcsInOrder[0].DC.ToString();

        //    }
        //    catch (Exception e)
        //    {
        //        log.Info(e.Message);
        //        return ConfigurationManager.AppSettings["ADDomain"];
        //    }

        //}

        //public static int Pinger(string address)
        //{

        //    Ping p = new Ping();
        //    try
        //    {
        //        PingReply reply = p.Send(address, 3000);
        //        if (reply.Status == IPStatus.Success)
        //        {
        //            log.Info("Pinging : " + address + ", reply time : " + (int)reply.RoundtripTime);
        //            return (int)reply.RoundtripTime;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        log.Info(e.Message);
        //        return -1;
        //    }

        //    return -1;
        //}
        //public static string GetIP4Address()
        //{
        //    try
        //    {
        //        string IP4Address = string.Empty;

        //        foreach (IPAddress IPA in Dns.GetHostAddresses(System.Web.HttpContext.Current.Request.UserHostAddress))
        //        {
        //            if (IPA.AddressFamily.ToString() == "InterNetwork")
        //            {
        //                IP4Address = IPA.ToString();
        //                break;
        //            }
        //        }

        //        if (IP4Address != string.Empty)
        //        {
        //            return IP4Address;
        //        }

        //        foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
        //        {
        //            if (IPA.AddressFamily.ToString() == "InterNetwork")
        //            {
        //                IP4Address = IPA.ToString();
        //                break;
        //            }
        //        }

        //        return IP4Address;
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex);
        //        return "";
        //    }
        //}

        //[HttpPost, ValidateInput(false)]
        //public ActionResult Index(UserLogin lg)
        //{
        //    log.Info("[LogIn] ");
        //    Session["isAuthenticated"] = false;
        //    DateTime Startdatetime = DateTime.Now;
        //    try
        //    {
        //        if (Session["Name"] != null)
        //        {
        //            WriteTimeStamp.info(Startdatetime, "LogIn");
        //            return RedirectToAction("Index", "Home", new { area = "" });
        //        }
        //        log.Info("Starting login process");
        //        //List<string> temp = new List<string>();
        //        //temp.AddRange("Domain Users;Administrators;IIS_IUSRS;Schema Admins;Enterprise Admins;Domain Admins;Group Policy Creator Owners;umg.mgt.acraAdmins.gs;umg.mgt.SecurityAdmins.gs;MyGroup;ADSyncOperators;umg.mgt.serversupport.gs;umg.mgt.security.Admins".Split(';'));
        //        //// temp.Add("");
        //        ////  AuthSiteCodes.siteCodes = fetchSiteCodes(temp);
        //        //Session["siteCodes"] = fetchSiteCodes(temp);
        //        //HttpContext.Session["username"] = Convert.ToString(lg.Name);
        //        //string ipaddress1 = GetIP4Address();
        //        //HttpContext.Session["ipaddress"] = ipaddress1;
        //        //Session["ipaddress"] = ipaddress1;
        //        //Session["Name"] = Convert.ToString(lg.Name);
        //        //Session["Password"] = Convert.ToString(lg.Password);
        //        ////Models.UserInfo.userName = Convert.ToString(lg.Name);
        //        ////Models.UserInfo.password = Convert.ToString(lg.Password);
        //        //return RedirectToAction("index", "home");
        //        //ipAddress = GetIP4Address();


        //        if (System.IO.File.Exists(Server.MapPath(@"~\Data\NearestDC.txt")))
        //        {
        //            string[] DC = System.IO.File.ReadAllLines(Server.MapPath(@"~\Data\NearestDC.txt"));

        //            try
        //            {
        //                if (Pinger(DC[0].Trim()) != -1)
        //                {
        //                    Models.DC.nearestDC = DC[0].Trim();
        //                    domain = Models.DC.nearestDC;

        //                }
        //                else if (Pinger(DC[1].Trim()) != -1)
        //                {
        //                    Models.DC.nearestDC = DC[1].Trim();
        //                    domain = Models.DC.nearestDC;

        //                }
        //                else
        //                {
        //                    Models.DC.nearestDC = getNearestDC();
        //                    domain = Models.DC.nearestDC;
        //                }

        //            }
        //            catch (Exception w)
        //            {
        //                log.Error(w.Message);
        //                Models.DC.nearestDC = getNearestDC();
        //                domain = Models.DC.nearestDC;
        //            }


        //        }
        //        else
        //        {
        //            log.Info("File not found for Nearest DC");
        //            Models.DC.nearestDC = getNearestDC();
        //            domain = Models.DC.nearestDC;
        //        }

        //        log.Info(" Models.DC.nearestDC : " + Models.DC.nearestDC);
        //        log.Info("Getting IP of machine");
        //        // ipAddress = GetIP4Address();

        //        string ipaddress = GetIP4Address();
        //        HttpContext.Session["ipaddress"] = ipaddress;
        //        Session["ipaddress"] = ipaddress;
        //        log.Info("IP : " + ipaddress);

        //        if (lg.Name != null && lg.Password != null)
        //        {

        //            //  valid = context.ValidateCredentials(lg.Name, lg.Password, ContextOptions.Negotiate);
        //            if (AuthenticateUser(domain, lg.Name, lg.Password))
        //            {
        //                Session["isAuthenticated"] = true;
        //                Session["Duouser"] = lg.Name;
        //                Session["Duopassword"] = lg.Password;
        //                return RedirectToAction("DUO2FA");
        //            }
        //            else
        //            {
        //                ViewBag.Error = "Incorrect Username or Password";
        //            }

        //        }

        //        else
        //        {
        //            ViewBag.Error = "Username or Password can't be blank";
        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        log.Info("In Catch");
        //        log.Info(ex);
        //        ViewBag.Error = "Incorrect UserName or Password";

        //    }
        //    WriteTimeStamp.info(Startdatetime, "LogIn");
        //    return View();
        //}

        //public static bool AuthenticateUser(string domainName, string userName, string password)
        //{
        //    bool ret = false;
        //    log.Info("Authenticating user : " + userName);
        //    try
        //    {
        //        DirectoryEntry ldapsAuth =
        //             new DirectoryEntry("LDAP://" + domainName + ":636",
        //                                userName, password);
        //        ldapsAuth.AuthenticationType = AuthenticationTypes.SecureSocketsLayer;
        //        DirectorySearcher dsearch = new DirectorySearcher(ldapsAuth);
        //        SearchResult results = null;

        //        results = dsearch.FindOne();
        //        log.Info("User authenticated successfully : " + userName);
        //        ret = true;
        //    }
        //    catch (Exception e)

        //    {
        //        log.Info("AuthenticateUser :" + e);
        //        ret = false;
        //    }
        //    return ret;
        //}

        //public object GetSession()
        //{
        //    return Session["Name"];
        //}

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/" }, OpenIdConnectDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            return SignOut(new AuthenticationProperties { RedirectUri = "/" }, OpenIdConnectDefaults.AuthenticationScheme, "Cookies");
        }
    }

}