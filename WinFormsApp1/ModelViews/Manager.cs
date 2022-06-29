using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.ModelViews
{
    public class Manager
    {
        #region Fields

        #endregion Fields

        #region Properties

        List<Models.Human> peoples = new List<Models.Human>();

        public List<Models.Human> Peoples
        {
            get { return  peoples; }
            set { peoples = value; }
        }
        #endregion Properties

        #region Events
        public event Action HumansListChanged;
        #endregion Events

        #region Constructors

        #endregion Constructors

        #region Methods

        #region Privates

        #endregion Privates	

        #region Public
        public void AddHuman(string name, string secondName, int year)
        {
            var human = new Models.Human { Name = name, SecondName = secondName, Year = year };
            Peoples.Add(human);
            HumansListChanged?.Invoke();
        }
        
        public List<string> GetHumansNames()
        {
            var result = new List<string>();
            foreach (var human in Peoples)
            {
                result.Add(human.Name);
            }
            return result;
        }
        #endregion Public

        #endregion Methods
    }
}
