using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace WeUiSharp.Localization
{
    public class TranslationSource : INotifyPropertyChanged
    {
        public static TranslationSource Instance { get; } = new TranslationSource();

        private readonly Dictionary<string, ResourceManager> resourceManagerDictionary = new Dictionary<string, ResourceManager>()
        {
            // 默认添加的 ResourceManager
            {"WeUiSharp.Properties.Strings", Properties.Strings.ResourceManager}
        };

        public List<ResourceManager> ResourceManagerList { get; set; } = new List<ResourceManager>()
        {
            // 默认添加的 ResourceManager
            Properties.Strings.ResourceManager
        };
        public string this[string key]
        {
            get
            {
                Tuple<string, string> tuple = SplitName(key);
                string translation = null;
                if (resourceManagerDictionary.ContainsKey(tuple.Item1))
                    translation = resourceManagerDictionary[tuple.Item1].GetString(tuple.Item2, Thread.CurrentThread.CurrentUICulture);
                return translation ?? key;
            }
        }

        private string language = Thread.CurrentThread.CurrentUICulture.Name;
        public string Language
        {
            get { return language; }
            set
            {
                if (language != null)
                {
                    language = value;

                    var cultureInfo = new CultureInfo(value);
                    Thread.CurrentThread.CurrentUICulture = cultureInfo;
                    Thread.CurrentThread.CurrentCulture = cultureInfo;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
                }
            }
        }

        // WPF bindings register PropertyChanged event if the object supports it and update themselves when it is raised
        public event PropertyChangedEventHandler PropertyChanged;

        public void AddResourceManager(ResourceManager resourceManager)
        {
            if (!resourceManagerDictionary.ContainsKey(resourceManager.BaseName))
            {
                resourceManagerDictionary.Add(resourceManager.BaseName, resourceManager);
                ResourceManagerList.Add(resourceManager);
            }
        }

        public static Tuple<string, string> SplitName(string local)
        {
            int idx = local.ToString().LastIndexOf(".");
            var tuple = new Tuple<string, string>(local.Substring(0, idx), local.Substring(idx + 1));
            return tuple;
        }
    }

}
