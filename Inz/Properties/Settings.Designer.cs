﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inz.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf" +
            ";Integrated Security=True")]
        public string Database1ConnectionString {
            get {
                return ((string)(this["Database1ConnectionString"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("20")]
        public double bladkierunkucc {
            get {
                return ((double)(this["bladkierunkucc"]));
            }
            set {
                this["bladkierunkucc"] = value;
            }
        }
        
        /// <summary>
        /// Ścieżka do pliku z modelem geoidy w formacie B L ksi
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Ścieżka do pliku z modelem geoidy w formacie B L ksi")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Users\\Piotrek\\Desktop\\gugik-geoid2011.txt")]
        public string sciezkageoidy {
            get {
                return ((string)(this["sciezkageoidy"]));
            }
            set {
                this["sciezkageoidy"] = value;
            }
        }
        
        /// <summary>
        /// Półoś równikowa a
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Półoś równikowa a")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("6378137")]
        public double elipsoida_a {
            get {
                return ((double)(this["elipsoida_a"]));
            }
            set {
                this["elipsoida_a"] = value;
            }
        }
        
        /// <summary>
        /// Półoś biegunowa b
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Półoś biegunowa b")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("6356752.3142452")]
        public double elipsoida_b {
            get {
                return ((double)(this["elipsoida_b"]));
            }
            set {
                this["elipsoida_b"] = value;
            }
        }
        
        /// <summary>
        /// Spłaszczenie elipsoidy 1/f
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Spłaszczenie elipsoidy 1/f")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("298.257223563")]
        public double elipsoida_f {
            get {
                return ((double)(this["elipsoida_f"]));
            }
            set {
                this["elipsoida_f"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\rtklib\\rtklib_2.4.2\\bin\\rnx2rtkp.exe")]
        public string rtklibPath {
            get {
                return ((string)(this["rtklibPath"]));
            }
            set {
                this["rtklibPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\wyniki z rtkliba")]
        public string wynikirtklib {
            get {
                return ((string)(this["wynikirtklib"]));
            }
            set {
                this["wynikirtklib"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Projekty C\\dane\\konfig.conf")]
        public string config {
            get {
                return ((string)(this["config"]));
            }
            set {
                this["config"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Praca_Inz\\rtklib Wyniki")]
        public string outputPath {
            get {
                return ((string)(this["outputPath"]));
            }
            set {
                this["outputPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public int bladcentrowaniam {
            get {
                return ((int)(this["bladcentrowaniam"]));
            }
            set {
                this["bladcentrowaniam"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5")]
        public int bladwysantm {
            get {
                return ((int)(this["bladwysantm"]));
            }
            set {
                this["bladwysantm"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5")]
        public int bladdlugosci1 {
            get {
                return ((int)(this["bladdlugosci1"]));
            }
            set {
                this["bladdlugosci1"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5")]
        public int bladdlugosci2 {
            get {
                return ((int)(this["bladdlugosci2"]));
            }
            set {
                this["bladdlugosci2"] = value;
            }
        }
    }
}
