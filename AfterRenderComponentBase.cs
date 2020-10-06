using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BlazorMasonry
{
    public class AfterRenderComponentBase : ComponentBase
    {
        // store all the actions you want to run **once** after rendering
        private List<Action> actionsToRunAfterRender = new List<Action>();
        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            // run all the actions (.NET code) **once** after rendering
            foreach (var actionToRun in actionsToRunAfterRender)
            {
                actionToRun();
            }
            // clear the actions to make sure the actions only run **once**
            actionsToRunAfterRender.Clear();
            return base.OnAfterRenderAsync(firstRender);
        }

        /// <summary>
        /// Run an action once after the component is rendered
        /// </summary>
        /// <param name="action">Action to invoke after render</param>
        protected void RunAfterRender(Action action) => actionsToRunAfterRender.Add(action);
    }
}