using System;
using System.Collections.Generic;
using System.Linq;
using AutoBuilder.Items;
using AutoBuilder.Model;
using log4net.Repository.Hierarchy;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace AutoBuilder
{
    public class AutoBuilderWorld : ModWorld
    {
        public override void Initialize()
        {
            Constants.Logger = mod.Logger;
            if (!Constants.GetCatalogEntries().Any())
            {
                Constants.Init();
            }
            base.Initialize();
        }

        public override void Load(TagCompound tag)
        {
            try
            {
                List<Blueprint> blueprints = tag.Get<List<Blueprint>>("CustomBlueprints");
                BlueprintArchive.Instance.LoadCustomBlueprints(blueprints);
            }
            catch (Exception e)
            {
                mod.Logger.Error(e);
            }
        }

        public override TagCompound Save()
        {
            try
            {
                return new TagCompound
                {
                    ["CustomBlueprints"] = BlueprintArchive.Instance.CustomBlueprints
                };
            }
            catch (Exception e)
            {
                mod.Logger.Error(e);
            }

            return new TagCompound()
            {
                ["CustomBlueprints"] = new List<Blueprint>()
            };
        }
    }
}