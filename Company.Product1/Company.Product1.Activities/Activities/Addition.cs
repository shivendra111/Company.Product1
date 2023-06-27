using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using Company.Product1.Activities.Properties;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;

namespace Company.Product1.Activities
{
    [LocalizedDisplayName(nameof(Resources.Addition_DisplayName))]
    [LocalizedDescription(nameof(Resources.Addition_Description))]
    public class Addition : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.Addition_FirstNumber_DisplayName))]
        [LocalizedDescription(nameof(Resources.Addition_FirstNumber_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<int> FirstNumber { get; set; }

        [LocalizedDisplayName(nameof(Resources.Addition_SecondNumber_DisplayName))]
        [LocalizedDescription(nameof(Resources.Addition_SecondNumber_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<int> SecondNumber { get; set; }

        [LocalizedDisplayName(nameof(Resources.Addition_Sum_DisplayName))]
        [LocalizedDescription(nameof(Resources.Addition_Sum_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<int> Sum { get; set; }

        #endregion


        #region Constructors

        public Addition()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (FirstNumber == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(FirstNumber)));
            if (SecondNumber == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(SecondNumber)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            var firstNumber = FirstNumber.Get(context);
            var secondNumber = SecondNumber.Get(context);

            var sum = firstNumber + secondNumber;

            // Outputs
            return (ctx) => {
                Sum.Set(ctx, sum);
            };
        }

        #endregion
    }
}

