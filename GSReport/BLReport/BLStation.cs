using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAReport;
using ReportModel;

namespace BLReport
{
    public class BLStation
    {
        private DAStation dastation = new DAStation();

        #region Station

        public StationModel GetStation(int id)
        {
            return dastation.GetStation(id);
        }

        public IList<StationModel> GetStations()
        {
            return dastation.GetStations();
        }

        public int AddStation(string stationname)
        {
            return dastation.AddStation(stationname);
        }

        public void DeleteStation(int id)
        {
            dastation.DeleteStation(id);
        }


        public void UpdateStation(int id, string stationname)
        {
            dastation.UpdateStation(id, stationname);
        }

        #endregion

        #region class

        public IList<CollectionClassModel> GetCollectionClasses(int stationid)
        {
            return dastation.GetCollectionClasses(stationid);
        }

        public CollectionClassModel GetCollection(int id)
        {
            return dastation.GetCollectionClass(id);
        }

        public int AddCollectionClass(int stationid, string classname)
        {
            return dastation.AddCollectionClass(stationid, classname);
        }

        public void DeleteClass(int classid)
        {
            dastation.DeleteCollectionClass(classid);
        }

        #endregion
    }
}
