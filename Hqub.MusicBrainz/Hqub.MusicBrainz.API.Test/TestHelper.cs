﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hqub.MusicBrainz.API.Test
{
    static class TestHelper
    {
        private const string prefix = "Hqub.MusicBrainz.API.Test.Data.";

        public static T Get<T>(string resource, bool withoutMetadata = true) where T : Entities.Entity
        {
            try
            {
                return WebRequestHelper.DeserializeStream<T>(LoadResource(resource), withoutMetadata);
            }
            catch (Exception e)
            {
                if (Configuration.GenerateCommunicationThrow)
                {
                    throw e;
                }
            }

            return default(T);
        }

        private static Stream LoadResource(string name)
        {
            if (!name.StartsWith(prefix))
            {
                name = prefix + name;
            }

            return Assembly.GetExecutingAssembly().GetManifestResourceStream(name);
        }
    }
}
