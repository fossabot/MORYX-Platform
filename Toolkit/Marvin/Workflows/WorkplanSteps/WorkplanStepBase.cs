﻿using System.Runtime.Serialization;
using Marvin.Workflows.Transitions;

namespace Marvin.Workflows.WorkplanSteps
{
    /// <summary>
    /// Base class for all workplanstep
    /// </summary>
    [DataContract(IsReference = true)]
    public abstract class WorkplanStepBase : IWorkplanStep
    {
        /// <summary>
        /// Create step and set id
        /// </summary>
        protected WorkplanStepBase()
        {
            Inputs = new IConnector[1];
            Outputs = new IConnector[1];
            OutputDescriptions = new[] { new OutputDescription { Name = "Complete", Success = true } };
        }

        ///
        [DataMember]
        public long Id { get; set; }

        /// 
        public abstract string Name { get; }

        /// 
        [DataMember]
        public IConnector[] Inputs { get; set; }

        /// 
        [DataMember]
        public IConnector[] Outputs { get; set; }

        /// 
        [DataMember]
        public OutputDescription[] OutputDescriptions { get; set; }

        /// 
        public ITransition CreateInstance(IWorkplanContext context)
        {
            var transition = Instantiate(context);
            transition.Id = Id;
            transition.Inputs = new IPlace[Inputs.Length];
            transition.Outputs = new IPlace[Outputs.Length];
            return transition;
        }

        ///
        protected abstract TransitionBase Instantiate(IWorkplanContext context);
    }
}