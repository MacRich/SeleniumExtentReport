using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RelevantCodes.ExtentReports;
using System.Diagnostics;

namespace TestRegister
{

    public static class BasicReport 
    {


        public static ExtentReports extent;

        public static ExtentTest test;


        public static void StartReport(string testName)
        {
            //To obtain the current solution path/project path
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;

            string actualpath = path.Substring(0, path.LastIndexOf("bin"));

            string projectpath = new Uri(actualpath).LocalPath;


            //Append the html report file to current project path
            string reportpath = projectpath + "Reports\\MyOwnReport_"+testName+".html";

            //Boolean value for replacing existing report
            extent = new ExtentReports(reportpath, true);

            //Add QA system info to html report
            extent.AddSystemInfo("Host Name", "localhost")
                .AddSystemInfo("Environment", "YourQAEnvironment")
                .AddSystemInfo("Username", "RJM");

            //Adding config.xml file

            extent.LoadConfig(projectpath + "extent_config.xml"); //Get the config.xml file from http://extentreports.com

            test = extent.StartTest(testName);


        }


        private static string GetMethodName()
        {

            StackTrace stackTrace = new StackTrace();
            string methodName = stackTrace.GetFrame(2).GetMethod().Name;
            //if (!string.IsNullOrEmpty(methodName))
            //    test= extent.StartTest(methodName);
            return methodName;
        }

        public static void PrintMessageExtension(bool result)
        {

            string methodName = GetMethodName();

            if (result)
            {
                test.Log(LogStatus.Pass, methodName + " - Passed");
            }
            else
            {
                test.Log(LogStatus.Fail, methodName + " - Failed");
            }
        }
        public static void EndReport()
        {
            //End report
            extent.EndTest(test);
            extent.Flush();
            extent.Close();
        }
    }
}
