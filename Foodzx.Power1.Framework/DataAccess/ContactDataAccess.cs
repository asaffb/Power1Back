using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.DataAccess.Base;
using Foodzx.Power1.Framework.DataModel;

namespace Foodzx.Power1.Framework.DataAccess
{
    public class ContactDataAccess : MySqlDataAccessBase<ContactDataModel>
    {
        public ContactDataAccess(MySqlDataAccessConnection connection) : base(connection)
        {

        }

        /*
        public List<QueryResultDataModel> ActivateProgram(SaesCreateProgramSet saesCreateProgramSet)
        {
            List<QueryResultDataModel> result = new List<QueryResultDataModel>();

            Dictionary<string, object> parameterList = new Dictionary<string, object>
            {
                { "SaesProgramId", saesCreateProgramSet.SaesProgramId.ToString() },
                { "BMSSaesProgramId", saesCreateProgramSet.BmsSaesProgramId.ToString() },
                { "Name", saesCreateProgramSet.Name },
                { "OrganizationCode", (int)saesCreateProgramSet.OrganizationType },
                { "GridInstituteId", saesCreateProgramSet.GridInstituteId.ToString() },
                { "MainRegionId", saesCreateProgramSet.MainRegionId.ToString() },
                { "BMSMainRegionId", saesCreateProgramSet.BMSMainRegionId.ToString() },
                { "TeacherPrincipalID", saesCreateProgramSet.TeacherPrincipalID.ToString() },
                { "BMSTeacherId", saesCreateProgramSet.BMSTeacherId.ToString() },
                { "TeacherName", saesCreateProgramSet.TeacherName },
                { "TeacherLanguageCode", saesCreateProgramSet.TeacherLanguageCode },

                { "SaesGroup1Id", saesCreateProgramSet.SaesCreateGroupSetList[0].SaesGroupId.ToString() },
                { "BMSSaesGroup1Id", saesCreateProgramSet.SaesCreateGroupSetList[0].BMSSaesGroupId.ToString() },
                { "Group1Name", saesCreateProgramSet.SaesCreateGroupSetList[0].Name },
                { "Group1Code", saesCreateProgramSet.SaesCreateGroupSetList[0].Code },
                { "Group1RegionId", saesCreateProgramSet.SaesCreateGroupSetList[0].RegionId.ToString() },
                { "Group1BMSRegionId", saesCreateProgramSet.SaesCreateGroupSetList[0].BMSRegionId.ToString() },

                { "SaesGroup2Id", saesCreateProgramSet.SaesCreateGroupSetList[1].SaesGroupId.ToString() },
                { "BMSSaesGroup2Id", saesCreateProgramSet.SaesCreateGroupSetList[1].BMSSaesGroupId.ToString() },
                { "Group2Name", saesCreateProgramSet.SaesCreateGroupSetList[1].Name },
                { "Group2Code", saesCreateProgramSet.SaesCreateGroupSetList[1].Code },
                { "Group2RegionId", saesCreateProgramSet.SaesCreateGroupSetList[1].RegionId.ToString() },
                { "Group2BMSRegionId", saesCreateProgramSet.SaesCreateGroupSetList[1].BMSRegionId.ToString() },

                { "SaesGroup3Id", saesCreateProgramSet.SaesCreateGroupSetList[2].SaesGroupId.ToString() },
                { "BMSSaesGroup3Id", saesCreateProgramSet.SaesCreateGroupSetList[2].BMSSaesGroupId.ToString() },
                { "Group3Name", saesCreateProgramSet.SaesCreateGroupSetList[2].Name },
                { "Group3Code", saesCreateProgramSet.SaesCreateGroupSetList[2].Code },
                { "Group3RegionId", saesCreateProgramSet.SaesCreateGroupSetList[2].RegionId.ToString() },
                { "Group3BMSRegionId", saesCreateProgramSet.SaesCreateGroupSetList[2].BMSRegionId.ToString() },

                { "SaesGroup4Id", saesCreateProgramSet.SaesCreateGroupSetList[3].SaesGroupId.ToString() },
                { "BMSSaesGroup4Id", saesCreateProgramSet.SaesCreateGroupSetList[3].BMSSaesGroupId.ToString() },
                { "Group4Name", saesCreateProgramSet.SaesCreateGroupSetList[3].Name },
                { "Group4Code", saesCreateProgramSet.SaesCreateGroupSetList[3].Code },
                { "Group4RegionId", saesCreateProgramSet.SaesCreateGroupSetList[3].RegionId.ToString() },
                { "Group4BMSRegionId", saesCreateProgramSet.SaesCreateGroupSetList[3].BMSRegionId.ToString() },

                // Money
                { "Money", saesCreateProgramSet.Money },
                { "MaxMoney", saesCreateProgramSet.MaxMoney },
                { "MoneyEffect", saesCreateProgramSet.MoneyEffect },

                // Food
                { "Food", saesCreateProgramSet.Food },
                { "MaxFood", saesCreateProgramSet.MaxFood },
                { "FoodEffect", saesCreateProgramSet.FoodEffect },

                // Energy
                { "Energy", saesCreateProgramSet.Energy },
                { "MaxEnergy", saesCreateProgramSet.MaxEnergy },
                { "EnergyEffect", saesCreateProgramSet.EnergyEffect },

                // O2
                { "O2", saesCreateProgramSet.O2 },
                { "MaxO2", saesCreateProgramSet.MaxO2 },
                { "O2Effect", saesCreateProgramSet.O2Effect },

                // CO2
                { "CO2", saesCreateProgramSet.CO2 },
                { "MaxCO2", saesCreateProgramSet.MaxCO2 },
                { "CO2Effect", saesCreateProgramSet.CO2Effect },

                // H2O
                { "H2O", saesCreateProgramSet.H2O },
                { "MaxH2O", saesCreateProgramSet.MaxH2O },
                { "H2OEffect", saesCreateProgramSet.H2OEffect },

                { "SaesProgramWeekId", saesCreateProgramSet.SaesProgramWeekId.ToString() },
                { "BMSSaesProgramWeekId", saesCreateProgramSet.BMSSaesProgramWeekId.ToString() },
                { "GQFormId", saesCreateProgramSet.GQFormId.ToString() },
                { "TaskText", saesCreateProgramSet.TaskText },
                { "TaskTextLanguageCode", saesCreateProgramSet.TaskTextLanguageCode }
            };

            result = this.GetFromQuery(SaesCreateProgramSet.GetCreateProgramQuery(), parameterList);

            return result;
        }
        */

        public override ContactDataModel CreateDataModel()
        {
            return new ContactDataModel();
        }

        public override string GetTableName()
        {
            return "Contacts";
        }
    }
}
