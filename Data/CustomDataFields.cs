using System;
using System.Collections.Generic;
using System.Text;
using ZoneFiveSoftware.Common.Data.Fitness.CustomData;
using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Visuals;
using System.Diagnostics;

namespace QuadrantAnalysis.Data
{
    class CustomDataFields
    {
        private static ICustomDataFieldDefinition customTrimp;
        private static ICustomDataFieldDefinition customTSS;
        private static ICustomDataFieldDefinition customNP;
        private static ICustomDataFieldDefinition customFTPcycle;
        private static ICustomDataFieldDefinition customFTPrun;
        private static bool warningMsgBadField;

        public enum TLCustomFields
        {
            Trimp, TSS, FTPcycle, FTPrun, NormPwr
        }

        /// <summary>
        /// Get a Training Load related custom parameter
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static ICustomDataFieldDefinition GetCustomProperty(TLCustomFields field)
        {
            // All data types so far are numbers
            ICustomDataFieldDefinition fieldDef = null;
            ICustomDataFieldDataType dataType = CustomDataFieldDefinitions.StandardDataType(CustomDataFieldDefinitions.StandardDataTypes.NumberDataTypeId);
            ICustomDataFieldObjectType objType;
            Guid id;
            string name;

            switch (field)
            {
                case TLCustomFields.Trimp:
                    if (customTrimp != null) return customTrimp;
                    objType = CustomDataFieldDefinitions.StandardObjectType(typeof(IActivity));
                    id = GUIDs.customTrimp;
                    name = "Trimp";
                    fieldDef = GetCustomProperty(dataType, objType, id, name);
                    customTrimp = fieldDef;
                    break;

                case TLCustomFields.TSS:
                    if (customTSS != null) return customTSS;
                    objType = CustomDataFieldDefinitions.StandardObjectType(typeof(IActivity));
                    id = GUIDs.customTSS;
                    name = "TSS";
                    fieldDef = GetCustomProperty(dataType, objType, id, name);
                    customTSS = fieldDef;
                    break;

                case TLCustomFields.NormPwr:
                    if (customNP != null) return customNP;
                    objType = CustomDataFieldDefinitions.StandardObjectType(typeof(IActivity));
                    id = GUIDs.customNP;
                    name = "NormPwr";
                    fieldDef = GetCustomProperty(dataType, objType, id, name);
                    customNP = fieldDef;
                    break;

                case TLCustomFields.FTPcycle:
                    if (customFTPcycle != null) return customFTPcycle;
                    objType = CustomDataFieldDefinitions.StandardObjectType(typeof(IAthleteInfoEntry));
                    id = GUIDs.customFTPcycle;
                    name = "FTPcycle";
                    fieldDef = GetCustomProperty(dataType, objType, id, name);
                    customFTPcycle = fieldDef;
                    break;

                case TLCustomFields.FTPrun:
                    if (customFTPrun != null) return customFTPrun;
                    objType = CustomDataFieldDefinitions.StandardObjectType(typeof(IAthleteInfoEntry));
                    id = GUIDs.customFTPrun;
                    name = "FTPrun";
                    fieldDef = GetCustomProperty(dataType, objType, id, name);
                    customFTPrun = fieldDef;
                    break;
            }

            return fieldDef;
        }

        /// <summary>
        /// Private helper to dig the logbook for a custom parameter
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private static ICustomDataFieldDefinition GetCustomProperty(ICustomDataFieldDataType dataType, ICustomDataFieldObjectType objType, Guid id, string name)
        {
            // Dig all of the existing custom params looking for a match.
            foreach (ICustomDataFieldDefinition customDef in PluginMain.GetLogbook().CustomDataFieldDefinitions)
            {
                if (customDef.Id == id)
                {
                    // Is this really necessary...?
                    if (customDef.DataType != dataType)
                    {
                        // Invalid match found!!! Bad news.
                        // This might occur if a user re-purposes a field.
                        if (!warningMsgBadField)
                        {
                            warningMsgBadField = true;
                            MessageDialog.Show("Invalid " + name + " Custom Field.  Was this field data type modified? (" + customDef.Name + ")", Resources.Strings.Label_QuadrantAnalysis);
                        }

                        return null;
                    }
                    else
                    {
                        // Return custom def
                        return customDef;
                    }
                }
            }

            // No match found, create it
            return PluginMain.GetLogbook().CustomDataFieldDefinitions.Add(id, objType, dataType, name);
        }

    }
}
