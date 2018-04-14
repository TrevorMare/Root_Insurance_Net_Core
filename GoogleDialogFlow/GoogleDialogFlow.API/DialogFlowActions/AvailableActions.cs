using GoogleDialogFlow.API.Interfaces;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GoogleDialogFlow.API.DialogFlowActions
{
    public class AvailableActions : IAvailableActions
    {

        #region Properties
        public List<IDialogFlowAction> DialogFlowActions { get; set; } = new List<IDialogFlowAction>();
        #endregion

        #region Methods
        public void LoadAvailableActions()
        {
            var types = this.GetAllTypesOf<IDialogFlowAction>();
            foreach (var tp in types)
            {
                IDialogFlowAction instance = (IDialogFlowAction)Activator.CreateInstance(tp);
                DialogFlowActions.Add(instance);
            }
        }

        private IEnumerable<Type> GetAllTypesOf<T>()
        {
            return Assembly.GetEntryAssembly().GetTypes()
                .Where(t => t.IsClass == true && t.IsAbstract == false && typeof(T).IsAssignableFrom(t))
                .ToList();
        }
        #endregion

    }
}
