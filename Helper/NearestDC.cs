using log4net;
using System.Net.NetworkInformation;
using System.Reflection;
using System;
using Device_Migration_Admin_Portal.Controllers;
namespace Device_Migration_Admin_Portal.Helper
{
    public class NearestDC
    {

    //    private static string domain = string.Empty;
    //    private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    //    public string fetchNearestDC()
    //    {
    //        try
    //        {
    //            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(@"~\Data\NearestDC.txt")))
    //            {
    //                string[] DC = System.IO.File.ReadAllLines(HttpContext.Current.Server.MapPath(@"~\Data\NearestDC.txt"));

    //                try
    //                {
    //                    if (Pinger(DC[0].Trim()) != -1)
    //                    {
    //                        Models.DC.nearestDC = DC[0].Trim();
    //                        domain = Models.DC.nearestDC;

    //                    }
    //                    else if (Pinger(DC[1].Trim()) != -1)
    //                    {
    //                        Models.DC.nearestDC = DC[1].Trim();
    //                        domain = Models.DC.nearestDC;

    //                    }
    //                    else
    //                    {
    //                        Models.DC.nearestDC = AccountController.getNearestDC();
    //                        domain = Models.DC.nearestDC;
    //                    }

    //                }
    //                catch (Exception w)
    //                {
    //                    log.Error(w.Message);
    //                    Models.DC.nearestDC = AccountController.getNearestDC();
    //                    domain = Models.DC.nearestDC;
    //                }


    //            }
    //            else
    //            {
    //                log.Info("File not found for Nearest DC");
    //                Models.DC.nearestDC = AccountController.getNearestDC();
    //                domain = Models.DC.nearestDC;
    //            }
    //            return domain;
    //        }
    //        catch (Exception ex)
    //        {
    //            log.Error(ex);
    //            return null;
    //        }
    //    }


    //    private static int Pinger(string address)
    //    {

    //        Ping p = new Ping();
    //        try
    //        {
    //            PingReply reply = p.Send(address, 3000);
    //            if (reply.Status == IPStatus.Success)
    //            {
    //                log.Info("Pinging : " + address + ", reply time : " + (int)reply.RoundtripTime);
    //                return (int)reply.RoundtripTime;
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            log.Info(e.Message);
    //            return -1;
    //        }

    //        return -1;
    //    }
    }
}
