﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace BeLazy
{
    internal class UplinkManager
    {
        private Link link;

        public UplinkManager(Link link)
        {
            this.link = link;
        }

        internal async Task<bool> GenerateUplinkProjectAsync(AbstractProject[] abstractProjects)
        {
            bool result = false;
            switch (link.UplinkBTMSSystemName)
            {
                case "XTRF":
                    XTRFUploadInterface tdi = new XTRFUploadInterface(link, abstractProjects);
                    result = await tdi.UploadProjects();
                    break;
                default:
                    break;
            }

            Log.AddLog("Uploaded projects to Uplink server");
            return result;
        }
    }
}