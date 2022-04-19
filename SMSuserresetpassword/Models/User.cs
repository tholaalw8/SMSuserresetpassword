using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace SMSuserresetpassword.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public  async Task getAduser() {

            const string fileName = "C:\\Users\\public\\data.txt";
            
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            var start = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                Arguments = "get-aduser -filter * -property SamAccountName,Displayname,Officephone,mobilephone,office,distinguishedname,mail,lastlogondate,logonworkstations, lastlogontimestamp | where-object {$_.SamAccountName -eq 'js3015'} | select-object SamaccountName,Displayname,office, distinguishedname,mobilephone,officephone, mail  | convertto-json | out-file C:\\users\\public\\data.txt ",
                CreateNoWindow = true
            };

            using var process = Process.Start(start);
            using var reader = process.StandardOutput;

            process.EnableRaisingEvents = true;
           
           /* var test = await reader.ReadToEndAsync();

            foreach (String tx in test) {
                test = test + "" + t;
            }


            await File.WriteAllLinesAsync(fileName,test);*/
            await process.WaitForExitAsync();
        }
    

    }
}
