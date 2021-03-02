using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities
{
    class ShellCommandExecutor
    {
        #region METHODS
        public bool ExecuteCommandWaitForExpectedResponse(string command, string expectedString = "")
        {
            string output;
            do
            {
                Process process = new Process();
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.FileName = "cmd.exe";
                process.Start();

                //Read the output stream first and then wait
                process.StandardInput.WriteLine(command);
                process.StandardInput.WriteLine("exit");
                output = process.StandardOutput.ReadToEnd();
                if (string.IsNullOrEmpty(expectedString))
                {
                    break;
                }

            }while(!output.Contains(expectedString));
            return output.Contains(expectedString);
        }


        #endregion METHODS
    }
}
