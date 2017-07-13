using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBLL
{
    public class Counter
    {
        public Counter()
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            _dbConnection = new DBConnection(connectionString);
        }

        private DBConnection _dbConnection;
        public int CurrentCounter
        {
            get;
            set;
        }

        public bool AddCounter()
        {
            if (ValidateCounter())
            {
                CurrentCounter++;
                UpdateCurrentCounter(CurrentCounter);
                return true;
            }
            else
            { return false; }

        }

        private bool ValidateCounter()
        {
            if (CurrentCounter < 10)
                return true;
            else
                return false;
        }

        public void GetCurrentCounter()
        {
            CurrentCounter = _dbConnection.GetCounter();
        }

        private void UpdateCurrentCounter(int ctr)
        {
            _dbConnection.UpdateCurrentCounter(ctr);
        }
    }
}
