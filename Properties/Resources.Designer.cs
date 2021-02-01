﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoBuilder.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AutoBuilder.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [
        ///	{
        ///		&quot;Name&quot; :  &quot;Block&quot;,
        ///		&quot;Suffix&quot; :  &quot;Block&quot;,
        ///		&quot;Height&quot; : 1,
        ///		&quot;Width&quot; : 1,
        ///		&quot;StylesAvailable&quot; :  true,
        ///		&quot;PlacementType&quot; :  &quot;Block&quot;,
        ///		&quot;PreferredPosition&quot; :  0,
        ///		&quot;Satisfies&quot; :  [&quot;Block&quot;],
        ///		&quot;Tags&quot; :  []
        ///	},
        ///	{
        ///		&quot;Name&quot; :  &quot;Wall&quot;,
        ///		&quot;Suffix&quot; :  &quot;Wall&quot;,
        ///		&quot;Height&quot; : 1,
        ///		&quot;Width&quot; : 1,
        ///		&quot;StylesAvailable&quot; :  true,
        ///		&quot;PlacementType&quot; :  &quot;Wall&quot;,
        ///		&quot;PreferredPosition&quot; :  0,
        ///		&quot;Satisfies&quot; :  [&quot;Wall&quot;],
        ///		&quot;Tags&quot; :  []
        ///	},
        ///	{
        ///		&quot;Name&quot; :  &quot;Torch&quot;,
        ///		&quot;Suffix&quot; :  &quot;Torch&quot;,
        ///		&quot;Height&quot; : 2,
        /// [rest of string was truncated]&quot;;.
        /// </summary>
        public static string PlaceableCatalog {
            get {
                return ResourceManager.GetString("PlaceableCatalog", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [
        ///	{
        ///		&quot;Name&quot; :  &quot;Random&quot;,
        ///		&quot;RequiredItems&quot; :  [],
        ///		&quot;AllowedTags&quot; :  []
        ///	},
        ///	{
        ///		&quot;Name&quot; :  &quot;Bathroom&quot;,
        ///		&quot;RequiredTags&quot; :  [&quot;Bathroom&quot;],
        ///		&quot;RequiredItemsCount&quot; :  3,
        ///		&quot;AllowedTags&quot; :  [&quot;Bathroom&quot;, &quot;Pretty&quot;]
        ///	},
        ///	{
        ///		&quot;Name&quot; :  &quot;Bedroom&quot;,
        ///		&quot;RequiredTags&quot; :  [&quot;Bed&quot;,&quot;Dresser&quot;],
        ///		&quot;RequiredItemsCount&quot; :  2,
        ///		&quot;AllowedTags&quot; :  [&quot;Bedroom&quot;, &quot;Container&quot;, &quot;Art&quot;, &quot;Seat&quot;],
        ///		&quot;DisallowedTags&quot; :  [&quot;Bathroom&quot;]
        ///	},
        ///	{
        ///		&quot;Name&quot; :  &quot;Library&quot;,
        ///		&quot;RequiredTags&quot; :  [&quot;Bookcase&quot;],
        ///		&quot;RequiredItemsCount&quot;  [rest of string was truncated]&quot;;.
        /// </summary>
        public static string RoomDefinitions {
            get {
                return ResourceManager.GetString("RoomDefinitions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [
        ///	{
        ///		&quot;WallName&quot; :  &quot;Ice Wall&quot;,
        ///		&quot;BlockName&quot; :  &quot;Ice Block&quot;,
        ///		&quot;FurniturePrefix&quot; :  &quot;Frozen&quot;
        ///	},
        ///	{
        ///		&quot;WallName&quot; :  &quot;Disc Wall&quot;,
        ///		&quot;BlockName&quot; :  &quot;Sunplate Block&quot;,
        ///		&quot;FurniturePrefix&quot; :  &quot;Skyware&quot;
        ///	},
        ///	{
        ///		&quot;WallName&quot; :  &quot;Wood Wall&quot;,
        ///		&quot;BlockName&quot; :  &quot;Wood&quot;,
        ///		&quot;FurniturePrefix&quot; : &quot;&quot;
        ///	},
        ///	{
        ///		&quot;WallName&quot; :  &quot;Smooth Marble Wall&quot;,
        ///		&quot;BlockName&quot; :  &quot;Smooth Marble Block&quot;,
        ///		&quot;FurniturePrefix&quot; : &quot;Marble&quot;
        ///	},
        ///	{
        ///		&quot;WallName&quot; :  &quot;Smooth Granite Wall&quot;,
        ///		&quot;BlockName&quot; :  &quot;Smooth Granite Block&quot;,
        /// [rest of string was truncated]&quot;;.
        /// </summary>
        public static string SpeciallyNamedSets {
            get {
                return ResourceManager.GetString("SpeciallyNamedSets", resourceCulture);
            }
        }
    }
}
